using BloodBank.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Core.Repositories
{
    public interface IAdressRepository
    {
        Task AddAsync(Address Address);

        Task SaveChangesAsync();
    }
}
