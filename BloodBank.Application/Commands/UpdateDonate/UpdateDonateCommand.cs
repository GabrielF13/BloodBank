using BloodBank.Application.Abstractions;
using MediatR;

namespace BloodBank.Application.Commands.UpdateDonate
{
    public class UpdateDonateCommand : IRequest<Result<Unit>>
    {
        public int Id { get; set; }
        public int QuantityMl { get; set; }
    }
}