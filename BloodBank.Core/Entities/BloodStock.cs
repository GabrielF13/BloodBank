using BloodBank.Core.Enums;

namespace BloodBank.Core.Entities
{
    public class BloodStock : BaseEntity
    {
        public BloodStock(BloodType bloodType, RHFactor rhFactor, int quantityMl)
        {
            BloodType = bloodType;
            RhFactor = rhFactor;
            QuantityMl = quantityMl;
        }

        public BloodType BloodType { get; private set; }
        public RHFactor RhFactor { get; private set; }
        public int QuantityMl { get; private set; }

        public void Update(BloodType bloodType, RHFactor rHFactor, int quantityMl)
        {
            BloodType = bloodType;
            RhFactor = rHFactor;
            QuantityMl = quantityMl;
        }

        public void Donate(int quantityMl)
        {
            QuantityMl += quantityMl;
        }
    }
}