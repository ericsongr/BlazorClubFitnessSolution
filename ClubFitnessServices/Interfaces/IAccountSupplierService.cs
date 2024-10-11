using ClubFitnessDomain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubFitnessServices.Interfaces
{
    public interface IAccountSupplierService
    {
        Task<IEnumerable<AccountSupplier>> GetAllAsync();
        Task<AccountSupplier> GetByIdAsync(int id);
        Task<AccountSupplier> GetWithAccountByIdAsync(int id);
        Task AddAsync(AccountSupplier accountSupplier);
        Task UpdateAsync(AccountSupplier accountSupplier);
        Task DeleteAsync(int accountSupplierId, int deletedBy);
    }
}