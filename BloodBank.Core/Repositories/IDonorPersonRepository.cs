using BloodBank.Core.Entities;

namespace BloodBank.Core.Repositories
{
    public interface IDonorPersonRepository
    {
        Task<List<DonorPerson>> GetAllAsync();

        Task<DonorPerson> GetByIdAsync(int id);

        Task<DonorPerson> GetByEmailAsync(string email);
        Task<DonorPerson> GetByEmailAndPasswordAsync(string email, string password);

        Task AddAsync(DonorPerson donorPerson);

        Task SaveChangesAsync();
    }
}