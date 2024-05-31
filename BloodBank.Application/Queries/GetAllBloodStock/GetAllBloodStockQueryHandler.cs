using BloodBank.Application.Abstractions;
using BloodBank.Application.ViewModels;
using BloodBank.Infrastructure.Persistence;
using MediatR;

namespace BloodBank.Application.Queries.GetAllBloodStock
{
    public class GetAllBloodStockQueryHandler : IRequestHandler<GetAllBloodStockQuery, Result<List<BloodStockViewModel>>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllBloodStockQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Result<List<BloodStockViewModel>>> Handle(GetAllBloodStockQuery request, CancellationToken cancellationToken)
        {
            var bloodStocks = await unitOfWork.BloodStocks.GetAllAsync();

            var bloodStockViewModel = bloodStocks.Select(
                p => new BloodStockViewModel(p.BloodType, p.RhFactor, p.QuantityMl, p.Id)).ToList();

            return Result<List<BloodStockViewModel>>.Success(bloodStockViewModel);
        }
    }
}