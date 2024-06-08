using BloodBank.Core.Entities;

namespace BloodBank.UnitTests.Core.Entities
{
    public class DonationTests
    {
        [Fact]
        public void TestIfDonationWorks()
        {
            var donate = new Donation(5, 450);

            Assert.NotNull(donate);

            donate.Update(10);

            Assert.Equal(460, donate.QuantityMl);
        }
    }
}