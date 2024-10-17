using ClubFitnessDomain;
using ClubFitnessInfrastructure.Interfaces;

namespace ClubFitnessInfrastructure.Repositories
{
    public class PosTransactionPaymentRepository : Repository<PosTransactionPayment>, IPosTransactionPaymentRepository
    {
        public PosTransactionPaymentRepository(ClubFitnessDbContext dbContext) : base(dbContext)
        {
        }
    }
}