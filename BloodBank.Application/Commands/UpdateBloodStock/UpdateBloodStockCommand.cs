using BloodBank.Application.Abstractions;
using MediatR;

namespace BloodBank.Application.Commands.UpdateBloodStock
{
    public class UpdateBloodStockCommand : IRequest<Result<Unit>>
    {
        public int Id { get; set; }
        public int QuantityMl { get; set; }
    }
}