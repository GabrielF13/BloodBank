using BloodBank.Application.Abstractions;
using BloodBank.Application.ViewModels;
using BloodBank.Infrastructure.Persistence;
using MediatR;

namespace BloodBank.Application.Queries.GetBloodStockById
{
    public class GetBloodStockByIdQueryHandler : IRequestHandler<GetBloodStockByIdQuery, Result<BloodStockViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBloodStockByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<BloodStockViewModel>> Handle(GetBloodStockByIdQuery request, CancellationToken cancellationToken)
        {
            var bloodStock = await _unitOfWork.BloodStocks.GetByIdAsync(request.Id);

            if (bloodStock == null)
                return Result<BloodStockViewModel>.NotFound("Estoque de sangue não encontrado");

            var bloodStockViewModel = new BloodStockViewModel(
                bloodStock.BloodType, bloodStock.RhFactor, bloodStock.QuantityMl, bloodStock.Id
                );

            return Result<BloodStockViewModel>.Success(bloodStockViewModel);
        }
    }
}