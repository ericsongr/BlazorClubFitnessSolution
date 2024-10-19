using ClubFitnessDomain;

namespace ClubFitnessInfrastructure.Interfaces
{
    public interface IPosTransactionRepository : IRepository<PosTransaction>
    {
        Task<IEnumerable<PosTransaction>> GetAllAsync(DateTime startDate, DateTime endDate);
    }
}