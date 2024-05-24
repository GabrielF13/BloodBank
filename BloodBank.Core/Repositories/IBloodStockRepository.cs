using BloodBank.Core.Entities;
using BloodBank.Core.Enums;

namespace BloodBank.Core.Repositories
{
    public interface IBloodStockRepository
    {
        Task<List<BloodStock>> GetAllAsync();

        Task<BloodStock> GetByIdAsync(int id);

        Task<List<BloodStock>> GetByBloodTypeAsync(BloodType bloodType);

        Task AddAsync(BloodStock bloodStock);

        Task SaveChangesAsync();
    }
}