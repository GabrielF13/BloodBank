using BloodBank.Core.Enums;
using MediatR;

namespace BloodBank.Application.Commands.CreateDonorPerson
{
    public class CreateDonorPersonCommand : IRequest<int>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public double Weight { get; set; }
        public BloodType BloodType { get; set; }
        public RHFactor RhFactor { get; set; }
    }
}