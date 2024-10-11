using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClubFitnessDomain;
using ClubFitnessInfrastructure.Interfaces;

namespace ClubFitnessInfrastructure.Repositories
{
    public class AccountProductRepository : Repository<AccountProduct>, IAccountProductRepository
    {
        public AccountProductRepository(ClubFitnessDbContext context) : base(context)
        {
        }

        //public async Task<IEnumerable<AccountProduct>> GetAllAsync()
        //{
        //    return await _context.AccountProduct
        //        .Include(ap => ap.Account)
        //        .Include(ap => ap.AccountSupplier)
        //        .Include(ap => ap.AccountProductCategory)
        //        .Include(ap => ap.AccountProductSubCategory)
        //        .ToListAsync();
        //}

        //public async Task<AccountProduct> GetByIdAsync(int id)
        //{
        //    return await _context.AccountProduct
        //        .Include(ap => ap.Account)
        //        .Include(ap => ap.AccountSupplier)
        //        .Include(ap => ap.AccountProductCategory)
        //        .Include(ap => ap.AccountProductSubCategory)
        //        .FirstOrDefaultAsync(ap => ap.AccountProductId == id);
        //}

        //public async Task AddAsync(AccountProduct accountProduct)
        //{
        //    await _context.AccountProduct.AddAsync(accountProduct);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task UpdateAsync(AccountProduct accountProduct)
        //{
        //    _context.AccountProduct.Update(accountProduct);
        //    await _context.SaveChangesAsync();
        //}

    }
}
