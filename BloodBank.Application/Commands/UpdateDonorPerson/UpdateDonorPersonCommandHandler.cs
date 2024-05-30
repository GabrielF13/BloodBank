using BloodBank.Infrastructure.Persistence;
using MediatR;

namespace BloodBank.Application.Commands.UpdateDonorPerson
{
    public class UpdateDonorPersonCommandHandler : IRequestHandler<UpdateDonorPersonCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDonorPersonCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateDonorPersonCommand request, CancellationToken cancellationToken)
        {
            var donorPerson = await _unitOfWork.DonorPersons.GetByIdAsync(request.Id);

            donorPerson.Update(request.FullName, request.Email, request.BirthDate, request.Gender, request.Weight, request.BloodType, request.RhFactor);

            await _unitOfWork.DonorPersons.SaveChangesAsync();

            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}