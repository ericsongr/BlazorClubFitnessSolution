using ClubFitnessDomain;
using ClubFitnessInfrastructure.Interfaces;

namespace ClubFitnessInfrastructure.Repositories
{
    public class AccountProductCategoryRepository : Repository<AccountProductCategory>, IAccountProductCategoryRepository
    {
        public AccountProductCategoryRepository(ClubFitnessDbContext context) : base(context)
        {
        }
    }
}