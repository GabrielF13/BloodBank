using BloodBank.Infrastructure.Persistence;
using MediatR;

namespace BloodBank.Application.Commands.DeleteDonorPerson
{
    public class DeleteDonorPersonCommandHandler : IRequestHandler<DeleteDonorPersonCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDonorPersonCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteDonorPersonCommand request, CancellationToken cancellationToken)
        {
            var donorPerson = _unitOfWork.DonorPersons.GetByIdAsync(request.Id).Result;

            donorPerson.Delete(false);

            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}