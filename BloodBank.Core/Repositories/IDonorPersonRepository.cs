using BloodBank.Core.Entities;

namespace BloodBank.Core.Repositories
{
    public interface IDonorPersonRepository
    {
        Task<List<DonorPerson>> GetAllAsync();

        Task<DonorPerson> GetByIdAsync(int id);

        Task<int> AddAsync(DonorPerson donorPerson);

        Task SaveChangesAsync();
    }
}