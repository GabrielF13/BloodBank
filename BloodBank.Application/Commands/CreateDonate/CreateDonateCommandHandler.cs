using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            if (person == null)
                return 0;

            var donate = new Donation(person.Id, request.QuantityMl);

            return donate.Id;
        }
    }
}
