using ClubFitnessDomain;

namespace ClubFitnessServices.Interfaces
{
    public interface IAccountProductService
    {
        Task<IEnumerable<AccountProduct>> GetAllAsync();
        Task<AccountProduct> GetByIdAsync(int id);
        Task<IEnumerable<AccountProduct>> GetProductsBySubCategoryId(int subCategoryId);
        Task AddAsync(AccountProduct dto);
        Task UpdateAsync(AccountProduct dto);
        Task DeleteAsync(int id, int deletedBy);
    }
}