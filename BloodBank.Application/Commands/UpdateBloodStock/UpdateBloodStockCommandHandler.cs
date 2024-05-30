using BloodBank.Application.Abstractions;
using BloodBank.Infrastructure.Persistence;
using MediatR;

namespace BloodBank.Application.Commands.UpdateBloodStock
{
    public class UpdateBloodStockCommandHandler : IRequestHandler<UpdateBloodStockCommand, Result<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBloodStockCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<Unit>> Handle(UpdateBloodStockCommand request, CancellationToken cancellationToken)
        {
            var bloodStock = await _unitOfWork.BloodStocks.GetByIdAsync(request.Id);

            bloodStock.Donate(request.QuantityMl);

            await _unitOfWork.CompleteAsync();

            return Result<Unit>.Success(Unit.Value);
        }
    }
}