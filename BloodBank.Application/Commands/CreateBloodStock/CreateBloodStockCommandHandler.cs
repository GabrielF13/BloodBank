using BloodBank.Application.Abstractions;
using BloodBank.Core.Entities;
using BloodBank.Infrastructure.Persistence;
using MediatR;

namespace BloodBank.Application.Commands.CreateBloodStock
{
    public class CreateBloodStockCommandHandler : IRequestHandler<CreateBloodStockCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBloodStockCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<int>> Handle(CreateBloodStockCommand request, CancellationToken cancellationToken)
        {
            var bloodStock = new BloodStock(request.BloodType, request.RhFactor, request.QuantityMl);

            await _unitOfWork.BloodStocks.AddAsync(bloodStock);

            await _unitOfWork.CompleteAsync();

            return Result<int>.Success(bloodStock.Id);
        }
    }
}