using BloodBank.Application.Abstractions;
using MediatR;

namespace BloodBank.Application.Commands.CreateDonate
{
    public class CreateDonateCommand : IRequest<Result<int>>
    {
        public int QuantityMl { get; set; }
        public int DonorPersonId { get; set; }
    }
}