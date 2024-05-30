using MediatR;

namespace BloodBank.Application.Commands.CreateDonate
{
    public class CreateDonateCommand : IRequest<int>
    {
        public int QuantityMl { get;  set; }
        public int DonorPersonId { get;  set; }
    }
}