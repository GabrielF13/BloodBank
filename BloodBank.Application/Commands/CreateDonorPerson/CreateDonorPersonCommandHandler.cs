using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.CreateDonorPerson
{
    public class CreateDonorPersonCommandHandler : IRequestHandler<CreateDonorPersonCommand, int>
    {
        private readonly IDonorPersonRepository _repository;

        public CreateDonorPersonCommandHandler(IDonorPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateDonorPersonCommand request, CancellationToken cancellationToken)
        {
            var donorPerson = new DonorPerson(request.FullName, request.Email, request.BirthDate, request.Gender, request.Weight, request.BloodType, request.RhFactor);

            var emailExists = await _repository.GetByEmailAsync(donorPerson.Email);

            if (emailExists.Id > 0)
                return 0;

            await _repository.AddAsync(donorPerson);

            return donorPerson.Id;
        }
    }
}