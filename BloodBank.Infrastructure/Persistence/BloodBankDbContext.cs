using BloodBank.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BloodBank.Infrastructure.Persistence
{
    public class BloodBankDbContext : DbContext
    {
        public BloodBankDbContext(DbContextOptions<BloodBankDbContext> options) : base(options)
        {
        }

        public DbSet<DonorPerson> DonorPerson { get; set; }
        public DbSet<BloodStock> BloodStock { get; set; }
        public DbSet<Donation> Donatiton { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}