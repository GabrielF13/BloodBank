using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;
using MediatR;

namespace BloodBank.Application.Commands.CreateBloodStock
{
    public class CreateBloodStockCommandHandler : IRequestHandler<CreateBloodStockCommand, int>
    {
        private readonly IBloodStockRepository _repository;

        public CreateBloodStockCommandHandler(IBloodStockRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Handle(CreateBloodStockCommand request, CancellationToken cancellationToken)
        {
            var bloodStock = new BloodStock(request.BloodType, request.RhFactor, request.QuantityMl);

            await _repository.AddAsync(bloodStock);

            return bloodStock.Id;
        }
    }
}