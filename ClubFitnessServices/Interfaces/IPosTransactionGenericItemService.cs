using ClubFitnessDomain;

namespace ClubFitnessServices.Interfaces
{
    public interface IPosTransactionGenericItemService
    {
        Task<IEnumerable<PosTransactionGenericItem>> GetAllAsync();
        Task<PosTransactionGenericItem> GetByIdAsync(long id);
        Task AddAsync(PosTransactionGenericItem posTransactionGenericItem);
        Task UpdateAsync(PosTransactionGenericItem posTransactionGenericItem);
        Task DeleteAsync(long id, int deletedBy);
    }
}