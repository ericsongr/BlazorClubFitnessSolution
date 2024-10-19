using ClubFitnessDomain;

namespace ClubFitnessServices.Interfaces
{
    public interface IPosTransactionItemService
    {
        Task<IEnumerable<PosTransactionItem>> GetAllAsync();
        Task<PosTransactionItem> GetByIdAsync(long id);
        Task<IEnumerable<PosTransactionItem>> GetByTransactionIdAsync(long id);
        Task AddAsync(PosTransactionItem posTransactionItem);
        Task UpdateAsync(PosTransactionItem posTransactionItem);
        Task DeleteAsync(long id, int deletedBy);
    }
}