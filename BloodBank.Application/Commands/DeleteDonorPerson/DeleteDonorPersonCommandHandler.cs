using BloodBank.Core.Repositories;
using MediatR;

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

            donorPerson.Delete(false);

            await _repository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}