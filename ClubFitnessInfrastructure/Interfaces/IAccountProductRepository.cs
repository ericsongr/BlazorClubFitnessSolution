using System.Collections.Generic;
using System.Threading.Tasks;
using ClubFitnessDomain;

namespace ClubFitnessInfrastructure.Interfaces
{
    public interface IAccountProductRepository
    {
        Task<IEnumerable<AccountProduct>> GetAllAsync();
        Task<AccountProduct> GetByIdAsync(int id);
        Task AddAsync(AccountProduct accountProduct);
        Task UpdateAsync(AccountProduct accountProduct);
        Task DeleteAsync(int id);
    }
}