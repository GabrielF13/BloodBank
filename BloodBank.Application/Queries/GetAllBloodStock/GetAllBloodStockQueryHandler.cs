using BloodBank.Application.ViewModels;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.GetAllBloodStock
{
    public class GetAllBloodStockQueryHandler : IRequestHandler<GetAllBloodStockQuery, List<BloodStockViewModel>>
    {
        private readonly IBloodStockRepository _repository;

        public GetAllBloodStockQueryHandler(IBloodStockRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BloodStockViewModel>> Handle(GetAllBloodStockQuery request, CancellationToken cancellationToken)
        {
            var bloodStocks = await _repository.GetAllAsync();  

            var bloodStockViewModel = bloodStocks.Select(
                p => new BloodStockViewModel(p.BloodType, p.RhFactor, p.QuantityMl, p.Id)).ToList();

            return bloodStockViewModel;
        }
    }
}