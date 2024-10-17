using ClubFitnessDomain;
using ClubFitnessInfrastructure.Interfaces;

namespace ClubFitnessInfrastructure.Repositories
{
    public class PosTransactionAuditRepository : Repository<PosTransactionAudit>, IPosTransactionAuditRepository
    {
        public PosTransactionAuditRepository(ClubFitnessDbContext dbContext) : base(dbContext)
        {
        }
    }
}