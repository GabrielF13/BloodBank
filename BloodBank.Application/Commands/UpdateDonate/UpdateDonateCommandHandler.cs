using BloodBank.Application.Abstractions;
using BloodBank.Infrastructure.Persistence;
using MediatR;

namespace BloodBank.Application.Commands.UpdateDonate
{
    public class UpdateDonateCommandHandler : IRequestHandler<UpdateDonateCommand, Result<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateDonateCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Unit>> Handle(UpdateDonateCommand request, CancellationToken cancellationToken)
        {
            var donate = await _unitOfWork.Donates.GetById(request.Id);

            return Result<Unit>.Success(Unit.Value);
        }
    }
}