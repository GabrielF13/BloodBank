using BloodBank.Core.Enums;

namespace BloodBank.Core.Entities
{
    public class DonorPerson : BaseEntity
    {
        public DonorPerson(string fullName, string email, DateTime birthDate, string gender, double weight, BloodType bloodType, RHFactor rhFactor)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
            Active = true;
            //Donations = new List<Donation>();
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Gender { get; private set; }
        public double Weight { get; private set; }
        public BloodType BloodType { get; private set; }
        public RHFactor RhFactor { get; private set; }
        public bool Active { get; private set; }

        //public List<Donation> Donations { get; set; }
        public Address Address { get; private set; }

        public void Update(string fullName, string email, DateTime birthDate, string gender, double weight, BloodType bloodType, RHFactor rhFactor)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
        }

        public void Delete(bool active)
        {
            Active = active;
        }
    }
}