using BloodBank.Core.Entities;

namespace BloodBank.Core.Repositories
{
    public interface IBloodStockRepository
    {
        Task<List<BloodStock>> GetAllAsync();

        Task<BloodStock> GetByIdAsync(int id);

        Task AddAsync(BloodStock bloodStock);

        Task SaveChangesAsync();
    }
}