using BloodBank.Core.Repositories;
using BloodBank.Core.Services;

namespace BloodBank.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BloodBankDbContext _context;

        public UnitOfWork(IBloodStockRepository bloodStocks, IDonorPersonRepository donorPersons, IDonateRepository donates, BloodBankDbContext context)
        {
            BloodStocks = bloodStocks;
            DonorPersons = donorPersons;
            Donates = donates;
            _context = context;
        }

        public IBloodStockRepository BloodStocks { get; }

        public IDonorPersonRepository DonorPersons { get; }

        public IDonateRepository Donates { get; }

        public IAdressRepository Adresses { get; }

        public IAuthService AuthService
        { get; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}