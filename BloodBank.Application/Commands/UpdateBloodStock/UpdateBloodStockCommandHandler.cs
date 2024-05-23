using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.UpdateBloodStock
{
    public class UpdateBloodStockCommandHandler : IRequestHandler<UpdateBloodStockCommand, Unit>
    {
        private readonly IBloodStockRepository _repository;

        public UpdateBloodStockCommandHandler(IBloodStockRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateBloodStockCommand request, CancellationToken cancellationToken)
        {
            var bloodStock = await _repository.GetByIdAsync(request.Id);

            bloodStock.Donate(request.QuantityMl);

            return Unit.Value;
        }
    }
}