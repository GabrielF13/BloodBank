using BloodBank.Application.ViewModels;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.GetBloodStockByBloodType
{
    public class GetBloodStockByBloodTypeQueryHandler : IRequestHandler<GetBloodStockByBloodTypeQuery, List<BloodStockViewModel>>
    {
        private readonly IBloodStockRepository _repository;

        public GetBloodStockByBloodTypeQueryHandler(IBloodStockRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BloodStockViewModel>> Handle(GetBloodStockByBloodTypeQuery request, CancellationToken cancellationToken)
        {
            var bloodStock = await _repository.GetByBloodTypeAsync(request.BloodType);

            var bloodStockViewModel = bloodStock.Select(
                p => new BloodStockViewModel(p.BloodType, p.RhFactor, p.QuantityMl, p.Id)).ToList();

            return bloodStockViewModel;
        }
    }
}