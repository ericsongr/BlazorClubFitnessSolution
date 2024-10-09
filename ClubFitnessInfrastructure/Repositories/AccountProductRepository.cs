using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClubFitnessDomain;
using ClubFitnessInfrastructure.Interfaces;

namespace ClubFitnessInfrastructure.Repositories
{
    public class AccountProductRepository : IAccountProductRepository
    {
        private readonly ClubFitnessDbContext _context;

        public AccountProductRepository(ClubFitnessDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AccountProduct>> GetAllAsync()
        {
            return await _context.AccountProduct
                .Include(ap => ap.Account)
                .Include(ap => ap.AccountSupplier)
                .Include(ap => ap.AccountProductCategory)
                .Include(ap => ap.AccountProductSubCategory)
                .ToListAsync();
        }

        public async Task<AccountProduct> GetByIdAsync(int id)
        {
            return await _context.AccountProduct
                .Include(ap => ap.Account)
                .Include(ap => ap.AccountSupplier)
                .Include(ap => ap.AccountProductCategory)
                .Include(ap => ap.AccountProductSubCategory)
                .FirstOrDefaultAsync(ap => ap.AccountProductId == id);
        }

        public async Task AddAsync(AccountProduct accountProduct)
        {
            await _context.AccountProduct.AddAsync(accountProduct);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AccountProduct accountProduct)
        {
            _context.AccountProduct.Update(accountProduct);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var accountProduct = await GetByIdAsync(id);
            if (accountProduct != null)
            {
                _context.AccountProduct.Remove(accountProduct);
                await _context.SaveChangesAsync();
            }
        }
    }
}
