using ClubFitnessDomain;
using ClubFitnessInfrastructure.Interfaces;

namespace ClubFitnessInfrastructure.Repositories
{
    public class PosTransactionRepository : Repository<PosTransaction>, IPosTransactionRepository
    {
        public PosTransactionRepository(ClubFitnessDbContext context) : base(context)
        {
        }
    }
}