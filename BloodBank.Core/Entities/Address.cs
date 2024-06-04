namespace BloodBank.Core.Entities
{
    public class Address : BaseEntity
    {
        public Address(int donorId, string publicPlace, string city, string state, string zipCode)
        {
            DonorId = donorId;
            PublicPlace = publicPlace;
            City = city;
            State = state;
            ZipCode = zipCode;
        }

        public int DonorId { get; private set; }
        public string PublicPlace { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string ZipCode { get; private set; }
        public DonorPerson DonorPerson { get; private set; }

        public void SetAdress(string zipCode, string publicPlace, string state, string city)
        {
            ZipCode = zipCode;
            PublicPlace = publicPlace;
            State = state;
            City = city;
        }
    }
}