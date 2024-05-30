using BloodBank.Application.Abstractions;
using BloodBank.Infrastructure.Persistence;
using MediatR;

namespace BloodBank.Application.Commands.UpdateDonorPerson
{
    public class UpdateDonorPersonCommandHandler : IRequestHandler<UpdateDonorPersonCommand, Result<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDonorPersonCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Unit>> Handle(UpdateDonorPersonCommand request, CancellationToken cancellationToken)
        {
            var donorPerson = await _unitOfWork.DonorPersons.GetByIdAsync(request.Id);

            donorPerson.Update(request.FullName, request.Email, request.BirthDate, request.Gender, request.Weight, request.BloodType, request.RhFactor);

            await _unitOfWork.DonorPersons.SaveChangesAsync();

            await _unitOfWork.CompleteAsync();

            return Result<Unit>.Success(Unit.Value);
        }
    }
}