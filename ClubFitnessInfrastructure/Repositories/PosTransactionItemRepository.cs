using ClubFitnessDomain;
using ClubFitnessInfrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubFitnessInfrastructure.Repositories
{
    public class PosTransactionItemRepository : Repository<PosTransactionItem>, IPosTransactionItemRepository
    {
        private readonly ClubFitnessDbContext _context;

        public PosTransactionItemRepository(ClubFitnessDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PosTransactionItem>> GetByTransactionIdAsync(long id)
        {
            return await Task.Run(() => 
                _context.PosTransactionItem.Include(o => o.AccountProduct)
                    .Where(o => o.PosTransactionId == id)) ;
        }
    }
}