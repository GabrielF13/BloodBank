using BloodBank.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Commands.UpdateDonorPerson
{
    public class UpdateDonorPersonCommandHandler : IRequestHandler<UpdateDonorPersonCommand, Unit>
    {
        private readonly IDonorPersonRepository _repository;

        public UpdateDonorPersonCommandHandler(IDonorPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateDonorPersonCommand request, CancellationToken cancellationToken)
        {
            var donorPerson = await _repository.GetByIdAsync(request.Id);

            donorPerson.Update(request.FullName, request.Email, request.BirthDate, request.Gender, request.Weight, request.BloodType, request.RhFactor);

            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}