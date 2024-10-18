using ClubFitnessDomain;

namespace ClubFitnessInfrastructure.Interfaces
{
    public interface IPosTransactionItemRepository : IRepository<PosTransactionItem>
    {
        Task<IEnumerable<PosTransactionItem>> GetByTransactionIdAsync(long id);
    }
}