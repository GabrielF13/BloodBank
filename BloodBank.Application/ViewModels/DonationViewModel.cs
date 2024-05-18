namespace BloodBank.Application.ViewModels
{
    public class DonationViewModel
    {
        public DonationViewModel(int id, int donorId, DateTime dateDonation, int quantityMl)
        {
            Id = id;
            DonorId = donorId;
            DateDonation = dateDonation;
            QuantityMl = quantityMl;
        }

        public int Id { get; set; }
        public int DonorId { get; set; }
        public DateTime DateDonation { get; set; }
        public int QuantityMl { get; set; }
    }
}