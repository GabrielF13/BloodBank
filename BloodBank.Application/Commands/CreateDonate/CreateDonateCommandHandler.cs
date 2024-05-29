using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.CreateDonate
{
    public class CreateDonateCommandHandler : IRequestHandler<CreateDonateCommand, int>
    {
        private readonly IDonateRepository _donateRepository;
        private readonly IDonorPersonRepository _personRepository;

        public CreateDonateCommandHandler(IDonateRepository donateRepository, IDonorPersonRepository personRepository)
        {
            _donateRepository = donateRepository;
            _personRepository = personRepository;
        }

        public async Task<int> Handle(CreateDonateCommand request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetByIdAsync(request.DonorPersonId);

            if (person == null || person.BirthDate.Year >= DateTime.Now.AddYears(-18).Year || person.Weight < 50)
                return 0;

            var lastDonate = await _donateRepository.GetById(person.Id);

            if (lastDonate != null &&
                ((person.Gender.Equals("masculino", StringComparison.OrdinalIgnoreCase) && lastDonate.DateDonation >= DateTime.Now.AddDays(-90)) ||
                (person.Gender.Equals("feminino", StringComparison.OrdinalIgnoreCase) && lastDonate.DateDonation >= DateTime.Now.AddDays(-60))))
            {
                return 0;
            }

            if (request.QuantityMl > 420 || request.QuantityMl < 470)
            {
                return 0;
            }

            var donate = new Donation(person.Id, request.QuantityMl);

            return donate.Id;
        }
    }
}