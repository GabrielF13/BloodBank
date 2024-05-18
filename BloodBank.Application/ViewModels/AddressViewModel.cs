namespace BloodBank.Application.ViewModels
{
    public class AddressViewModel
    {
        public AddressViewModel(int id, int donorId, string publicPlace, string city, string state, string zipCode)
        {
            Id = id;
            DonorId = donorId;
            PublicPlace = publicPlace;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public int Id { get; set; }
        public int DonorId { get; set; }
        public string PublicPlace { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}