﻿using BloodBank.Core.Entities;
using BloodBank.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infrastructure.Persistence.Repositories
{
    public class DonorPersonRepository : IDonorPersonRepository
    {
        private readonly BloodBankDbContext _context;

        public DonorPersonRepository(BloodBankDbContext context)
        {
            _context = context;
        }

        public async Task<List<DonorPerson>> GetAllAsync()
        {
            return await _context.DonorPerson.ToListAsync();
        }

        public async Task<DonorPerson> GetByIdAsync(int id)
        {
            return await _context.DonorPerson.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<DonorPerson> GetByEmailAsync(string email)
        {
            return await _context.DonorPerson.FirstAsync(x => x.Email == email);
        }

        public async Task AddAsync(DonorPerson donorPerson)
        {
            await _context.DonorPerson.AddAsync(donorPerson);
            await _context.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}