using BloodBank.Application.ViewModels;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Queries.GetBloodStockById
{
    public class GetBloodStockByIdQueryHandler : IRequestHandler<GetBloodStockByIdQuery, BloodStockViewModel>
    {
        private readonly IBloodStockRepository _repository;

        public GetBloodStockByIdQueryHandler(IBloodStockRepository repository)
        {
            _repository = repository;
        }

        public async Task<BloodStockViewModel> Handle(GetBloodStockByIdQuery request, CancellationToken cancellationToken)
        {
            var bloodStock = await _repository.GetByIdAsync(request.Id);

            if (bloodStock == null)
                return null;

            var bloodStockViewModel = new BloodStockViewModel(
                bloodStock.BloodType, bloodStock.RhFactor, bloodStock.QuantityMl, bloodStock.Id
                );

            return bloodStockViewModel;
        }
    }
}