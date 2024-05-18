using BloodBank.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Application.ViewModels
{
    public class DonorPersonViewModel
    {
        public DonorPersonViewModel(int id, string fullName, string email, DateTime birthDate, string gender, double weight, BloodType bloodType, RHFactor rhFactor)
        {
            Id = id;
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Gender = gender;
            Weight = weight;
            BloodType = bloodType;
            RhFactor = rhFactor;
        }

        public int Id { get;  set; }
        public string FullName { get;  set; }
        public string Email { get;  set; }
        public DateTime BirthDate { get;  set; }
        public string Gender { get;  set; }
        public double Weight { get;  set; }
        public BloodType BloodType { get;  set; }
        public RHFactor RhFactor { get;  set; }
    }
}
