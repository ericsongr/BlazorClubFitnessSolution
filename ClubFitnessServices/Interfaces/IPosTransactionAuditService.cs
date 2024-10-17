using ClubFitnessDomain;

namespace ClubFitnessServices.Interfaces
{
    public interface IPosTransactionAuditService
    {
        Task<IEnumerable<PosTransactionAudit>> GetAllAsync();
        Task<PosTransactionAudit> GetByIdAsync(long id);
        Task AddAsync(PosTransactionAudit posTransactionAudit);
        Task UpdateAsync(PosTransactionAudit posTransactionAudit);
        Task DeleteAsync(long id, int deletedBy);
    }
}