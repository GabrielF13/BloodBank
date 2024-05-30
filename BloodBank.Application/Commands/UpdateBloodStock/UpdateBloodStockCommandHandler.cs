using BloodBank.Core.Repositories;
using BloodBank.Infrastructure.Persistence;
using MediatR;
using System.Runtime.CompilerServices;

namespace BloodBank.Application.Commands.UpdateBloodStock
{
    public class UpdateBloodStockCommandHandler : IRequestHandler<UpdateBloodStockCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBloodStockCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(UpdateBloodStockCommand request, CancellationToken cancellationToken)
        {
            var bloodStock = await _unitOfWork.BloodStocks.GetByIdAsync(request.Id);

            bloodStock.Donate(request.QuantityMl);

            await _unitOfWork.CompleteAsync();

            return Unit.Value;
        }
    }
}