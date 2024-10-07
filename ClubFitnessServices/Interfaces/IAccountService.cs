using ClubFitnessDomain;

namespace ClubFitnessServices.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAllAsync();
        Task<Account?> GetByIdAsync(int id);
        Task AddAsync(Account account);
        Task UpdateAsync(Account account);
        Task DeleteAsync(int id);
    }
}