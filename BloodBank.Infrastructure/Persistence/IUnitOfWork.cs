using BloodBank.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
