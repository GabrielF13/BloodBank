using BloodBank.Core.Repositories;
using BloodBank.Core.Services;

namespace BloodBank.Infrastructure.Persistence
{
    public interface IUnitOfWork
    {
        IBloodStockRepository BloodStocks { get; }
        IDonorPersonRepository DonorPersons { get; }
        IDonateRepository Donates { get; }
        IAdressRepository Adresses { get; }

        Task<int> CompleteAsync();
    }
}