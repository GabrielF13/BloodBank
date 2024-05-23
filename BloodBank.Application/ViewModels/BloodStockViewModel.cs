using BloodBank.Core.Enums;

namespace BloodBank.Application.ViewModels
{
    public class BloodStockViewModel
    {
        public BloodStockViewModel(BloodType bloodType, RHFactor rhFactor, int quantityMl, int id)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            QuantityMl = quantityMl;
            Id = id;
        }

        public int Id { get; set; }
        public BloodType BloodType { get; set; }
        public RHFactor RhFactor { get; set; }
        public int QuantityMl { get; set; }
    }
}