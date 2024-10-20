using ClubFitnessDomain;
using ClubFitnessInfrastructure.Interfaces;

namespace ClubFitnessInfrastructure.Repositories
{
    public class LookupTypesRepository : Repository<LookupType>, ILookupTypesRepository
    {
        public LookupTypesRepository(ClubFitnessDbContext context) : base(context)
        {
        }
    }
}