using BloodBank.Core.Entities;

namespace BloodBank.Core.Repositories
{
    public interface IDonateRepository
    {
        Task<List<Donation>> GetAll();

        Task<Donation> GetById(int id);

        Task<Donation> GetByDonorId(int donorId);

        Task AddAsync(Donation donation);

        Task SaveChangesAsync();
    }
}