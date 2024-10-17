using ClubFitnessDomain;
using ClubFitnessInfrastructure.Interfaces;

namespace ClubFitnessInfrastructure.Repositories
{
    public class PosTransactionItemRepository : Repository<PosTransactionItem>, IPosTransactionItemRepository
    {
        public PosTransactionItemRepository(ClubFitnessDbContext context) : base(context)
        {
        }
    }
}