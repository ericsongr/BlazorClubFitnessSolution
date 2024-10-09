using ClubFitnessDomain;
using ClubFitnessInfrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubFitnessInfrastructure.Repositories
{
    public class AccountProductSubCategoryRepository : Repository<AccountProductSubCategory>, IAccountProductSubCategoryRepository
    {
        private readonly ClubFitnessDbContext _context;

        public AccountProductSubCategoryRepository(ClubFitnessDbContext context) : base(context)
        {
            _context = context;
        }

        // Override any specific methods or add custom queries if necessary
    }
}