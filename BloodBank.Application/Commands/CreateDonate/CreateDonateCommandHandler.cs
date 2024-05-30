using BloodBank.Application.Abstractions;
using BloodBank.Core.Entities;
using BloodBank.Infrastructure.Persistence;
using MediatR;

namespace BloodBank.Application.Commands.CreateDonate
{
    public class CreateDonateCommandHandler : IRequestHandler<CreateDonateCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDonateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(CreateDonateCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.DonorPersons.GetByIdAsync(request.DonorPersonId);

            if (person == null || person.BirthDate.Year >= DateTime.Now.AddYears(-18).Year || person.Weight < 50)
                return Result<int>.Failure("Para doação deve ter 18 anos ou mais.");

            var lastDonate = await _unitOfWork.Donates.GetById(person.Id);

            if (lastDonate != null &&
                ((person.Gender.Equals("masculino", StringComparison.OrdinalIgnoreCase) && lastDonate.DateDonation >= DateTime.Now.AddDays(-90)) ||
                (person.Gender.Equals("feminino", StringComparison.OrdinalIgnoreCase) && lastDonate.DateDonation >= DateTime.Now.AddDays(-60))))
            {
                return Result<int>.Failure($"Para nova doação voce deve esperar de 60 a 90 dias sua ultima foi no dia {lastDonate.DateDonation}.");
            }

            if (request.QuantityMl < 420 || request.QuantityMl > 470)
            {
                return Result<int>.Failure("A doação tem que conter de 420 a 470ml.");
            }

            var donate = new Donation(person.Id, request.QuantityMl);

            var stock = await _unitOfWork.BloodStocks.GetByBloodTypeAsync(person.BloodType, person.RhFactor);

            stock.Donate(request.QuantityMl);

            await _unitOfWork.Donates.AddAsync(donate);

            await _unitOfWork.CompleteAsync();

            return Result<int>.Success(donate.Id, "Doação realizada com sucesso.");
        }
    }
}