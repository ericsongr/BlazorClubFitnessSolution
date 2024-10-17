using ClubFitnessDomain;
using ClubFitnessInfrastructure.Interfaces;

namespace ClubFitnessInfrastructure.Repositories
{
    public class PosTransactionGenericItemRepository : Repository<PosTransactionGenericItem>, IPosTransactionGenericItemRepository
    {
        public PosTransactionGenericItemRepository(ClubFitnessDbContext dbContext) : base(dbContext)
        {
        }
    }
}