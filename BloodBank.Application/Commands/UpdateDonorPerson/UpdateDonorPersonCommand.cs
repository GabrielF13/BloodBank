using BloodBank.Application.Abstractions;
using BloodBank.Core.Enums;
using MediatR;

namespace BloodBank.Application.Commands.UpdateDonorPerson
{
    public class UpdateDonorPersonCommand : IRequest<Result<Unit>>
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public double Weight { get; set; }
        public BloodType BloodType { get; set; }
        public RHFactor RhFactor { get; set; }
    }
}