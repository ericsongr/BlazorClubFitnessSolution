using ClubFitnessDomain;
using ClubFitnessInfrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ClubFitnessInfrastructure.Repositories
{
    public class AccountSupplierRepository : Repository<AccountSupplier>, IAccountSupplierRepository
    {
        private readonly ClubFitnessDbContext _dbContext;

        public AccountSupplierRepository(ClubFitnessDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AccountSupplier> GetWithAccountByIdAsync(int id)
        {
            return await _dbContext.AccountSupplier
                .Include(s => s.Account)
                .FirstOrDefaultAsync(s => s.AccountSupplierId == id);
        }
    }
}