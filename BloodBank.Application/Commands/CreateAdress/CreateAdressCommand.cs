using BloodBank.Application.Abstractions;
using MediatR;

namespace BloodBank.Application.Commands.CreateAdress
{
    public class CreateAdressCommand : IRequest<Result<int>>
    {
        public int DonorId { get; set; }
        public string PublicPlace { get;  set; }
        public string City { get;  set; }
        public string State { get;  set; }
        public string ZipCode { get;  set; }
    }
}