using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;
using BloodBank.Infrastructure.Persistence;
using MediatR;

namespace BloodBank.Application.Commands.CreateDonate
{
    public class CreateDonateCommandHandler : IRequestHandler<CreateDonateCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDonateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateDonateCommand request, CancellationToken cancellationToken)
        {
            var person = await _unitOfWork.DonorPersons.GetByIdAsync(request.DonorPersonId);

            if (person == null || person.BirthDate.Year >= DateTime.Now.AddYears(-18).Year || person.Weight < 50)
                return 0;

            var lastDonate = await _unitOfWork.Donates.GetById(person.Id);

            if (lastDonate != null &&
                ((person.Gender.Equals("masculino", StringComparison.OrdinalIgnoreCase) && lastDonate.DateDonation >= DateTime.Now.AddDays(-90)) ||
                (person.Gender.Equals("feminino", StringComparison.OrdinalIgnoreCase) && lastDonate.DateDonation >= DateTime.Now.AddDays(-60))))
            {
                return 0;
            }

            if (request.QuantityMl < 420 || request.QuantityMl > 470)
            {
                return 0;
            }

            var donate = new Donation(person.Id, request.QuantityMl);

            var stock = await _unitOfWork.BloodStocks.GetByBloodTypeAsync(person.BloodType, person.RhFactor);

            stock.Donate(request.QuantityMl);

            await _unitOfWork.Donates.AddAsync(donate);

            await _unitOfWork.CompleteAsync();

            return donate.Id;
        }
    }
}