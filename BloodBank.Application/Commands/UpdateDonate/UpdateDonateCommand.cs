using MediatR;

namespace BloodBank.Application.Commands.UpdateDonate
{
    public class UpdateDonateCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int QuantityMl { get; set; }
    }
}