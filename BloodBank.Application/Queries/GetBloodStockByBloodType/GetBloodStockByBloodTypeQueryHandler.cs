using BloodBank.Application.Abstractions;
using BloodBank.Application.ViewModels;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.GetBloodStockByBloodType
{
    public class GetBloodStockByBloodTypeQueryHandler : IRequestHandler<GetBloodStockByBloodTypeQuery, Result<BloodStockViewModel>>
    {
        private readonly IBloodStockRepository _repository;

        public GetBloodStockByBloodTypeQueryHandler(IBloodStockRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<BloodStockViewModel>> Handle(GetBloodStockByBloodTypeQuery request, CancellationToken cancellationToken)
        {
            var bloodStock = await _repository.GetByBloodTypeAsync(request.BloodType, request.RHFactor);

            var bloodStockViewModel = new BloodStockViewModel(
                bloodStock.BloodType, bloodStock.RhFactor, bloodStock.QuantityMl, bloodStock.Id
                );

            return Result<BloodStockViewModel>.Success(bloodStockViewModel);
        }
    }
}