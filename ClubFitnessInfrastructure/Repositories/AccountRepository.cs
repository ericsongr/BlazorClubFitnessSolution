using ClubFitnessDomain;
using ClubFitnessInfrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubFitnessInfrastructure.Repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(ClubFitnessDbContext context) : base(context)
        {
        }

        // Example of an additional method specific to Account
        public async Task<Account?> GetAccountByNameAsync(string accountName)
        {
            return await _context.Accounts
                .FirstOrDefaultAsync(a => a.AccountName == accountName);
        }
    }
}