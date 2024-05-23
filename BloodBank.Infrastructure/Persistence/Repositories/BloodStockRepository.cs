using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Persistence.Repositories
{
    public class BloodStockRepository : IBloodStockRepository
    {
        private readonly BloodBankDbContext _context;
        public BloodStockRepository(BloodBankDbContext context)
        {
            _context = context;
        }

        public async Task<List<BloodStock>> GetAllAsync()
        {
            return await _context.BloodStock.ToListAsync();

        }

        public async Task<BloodStock> GetByIdAsync(int id)
        {
            return await _context.BloodStock.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(BloodStock bloodStock)
        {
            await _context.BloodStock.AddAsync(bloodStock);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}