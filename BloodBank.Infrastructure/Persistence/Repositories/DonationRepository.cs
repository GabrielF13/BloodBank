using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Persistence.Repositories
{
    public class DonationRepository : IDonateRepository
    {
        private readonly BloodBankDbContext _context;

        public DonationRepository(BloodBankDbContext context)
        {
            _context = context;
        }

        public async Task<List<Donation>> GetAll()
        {
            return await _context.Donatiton.ToListAsync();
        }

        public async Task<Donation> GetById(int id)
        {
            return _context.Donatiton.FirstOrDefault(d => d.Id == id);
        }

        public async Task AddAsync(Donation donation)
        {
            await _context.AddAsync(donation);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}