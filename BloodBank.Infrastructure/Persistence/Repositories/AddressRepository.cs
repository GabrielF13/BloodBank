using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;

namespace BloodBank.Infrastructure.Persistence.Repositories
{
    public class AddressRepository : IAdressRepository
    {
        private readonly BloodBankDbContext _context;

        public AddressRepository(BloodBankDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Address Address)
        {
            await _context.AddAsync(Address);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}