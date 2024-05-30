using BloodBank.Application.Abstractions;
using BloodBank.Core.Entities;
using BloodBank.Infrastructure.Persistence;
using MediatR;

namespace BloodBank.Application.Commands.CreateDonorPerson
{
    public class CreateDonorPersonCommandHandler : IRequestHandler<CreateDonorPersonCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDonorPersonCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(CreateDonorPersonCommand request, CancellationToken cancellationToken)
        {
            var donorPerson = new DonorPerson(request.FullName, request.Email, request.BirthDate, request.Gender, request.Weight, request.BloodType, request.RhFactor);

            var emailExists = await _unitOfWork.DonorPersons.GetByEmailAsync(donorPerson.Email);

            if (emailExists != null)
                return Result<int>.Failure("Email já cadastrado em outra conta");

            await _unitOfWork.DonorPersons.AddAsync(donorPerson);

            await _unitOfWork.CompleteAsync();

            return Result<int>.Success(donorPerson.Id, "Usuario criado com sucesso.");
        }
    }
}