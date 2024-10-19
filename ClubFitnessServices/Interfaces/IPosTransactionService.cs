using ClubFitnessDomain;

namespace ClubFitnessServices.Interfaces
{
    public interface IPosTransactionService
    {
        Task<IEnumerable<PosTransaction>> GetAllAsync();
        Task<IEnumerable<PosTransaction>> GetAllWithStaffAsync();
        Task<IEnumerable<PosTransaction>> GetAllAsync(DateTime startDate, DateTime endDate);
        Task<PosTransaction> GetByIdAsync(long id);
        Task AddAsync(PosTransaction posTransaction);
        Task UpdateAsync(PosTransaction posTransaction);
        Task DeleteAsync(long id, int deletedBy);
    }
}