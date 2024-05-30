using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;
using BloodBank.Infrastructure.Persistence;
using MediatR;

namespace BloodBank.Application.Commands.CreateDonorPerson
{
    public class CreateDonorPersonCommandHandler : IRequestHandler<CreateDonorPersonCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDonorPersonCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }0

        public async Task<int> Handle(CreateDonorPersonCommand request, CancellationToken cancellationToken)
        {
            var donorPerson = new DonorPerson(request.FullName, request.Email, request.BirthDate, request.Gender, request.Weight, request.BloodType, request.RhFactor);

            var emailExists = await _unitOfWork.DonorPersons.GetByEmailAsync(donorPerson.Email);

            if (emailExists != null)
                return 0;

            await _unitOfWork.DonorPersons.AddAsync(donorPerson);

            await _unitOfWork.CompleteAsync();

            return donorPerson.Id;
        }
    }
}