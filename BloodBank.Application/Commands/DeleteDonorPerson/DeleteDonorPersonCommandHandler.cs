using BloodBank.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.Commands.DeleteDonorPerson
{
    public class DeleteDonorPersonCommandHandler : IRequestHandler<DeleteDonorPersonCommand, Unit>
    {
        private readonly IDonorPersonRepository _repository;

        public DeleteDonorPersonCommandHandler(IDonorPersonRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteDonorPersonCommand request, CancellationToken cancellationToken)
        {
            var donorPerson = _repository.GetByIdAsync(request.Id).Result;

            await _repository.DeleteAsync(donorPerson);

            return Unit.Value;
        }
    }
}
