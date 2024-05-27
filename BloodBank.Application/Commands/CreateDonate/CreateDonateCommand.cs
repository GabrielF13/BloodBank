using MediatR;

namespace BloodBank.Application.Commands.CreateDonate
{
    public class CreateDonateCommand : IRequest<int>
    {
        public DateTime DateDonation { get; private set; }
        public int QuantityMl { get; private set; }
        public int DonorPersonId { get; private set; }
    }
}