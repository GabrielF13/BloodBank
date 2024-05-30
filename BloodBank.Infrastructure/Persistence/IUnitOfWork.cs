using BloodBank.Core.Repositories;

namespace BloodBank.Infrastructure.Persistence
{
    public interface IUnitOfWork
    {
        IBloodStockRepository BloodStocks { get; }
        IDonorPersonRepository DonorPersons { get; }
        IDonateRepository Donates { get; }

        Task<int> CompleteAsync();
    }
}