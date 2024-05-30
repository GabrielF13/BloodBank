using BloodBank.Application.Abstractions;
using BloodBank.Infrastructure.Persistence;
using MediatR;

namespace BloodBank.Application.Commands.DeleteDonorPerson
{
    public class DeleteDonorPersonCommandHandler : IRequestHandler<DeleteDonorPersonCommand, Result<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDonorPersonCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Unit>> Handle(DeleteDonorPersonCommand request, CancellationToken cancellationToken)
        {
            var donorPerson = _unitOfWork.DonorPersons.GetByIdAsync(request.Id).Result;

            donorPerson.Delete(false);

            await _unitOfWork.CompleteAsync();

            return Result<Unit>.Success(Unit.Value);
        }
    }
}