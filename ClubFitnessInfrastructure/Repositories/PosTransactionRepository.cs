using ClubFitnessDomain;
using ClubFitnessInfrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubFitnessInfrastructure.Repositories
{
    public class PosTransactionRepository : Repository<PosTransaction>, IPosTransactionRepository
    {
        private readonly ClubFitnessDbContext _context;

        public PosTransactionRepository(ClubFitnessDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PosTransaction>> GetAllAsync(DateTime startDate, DateTime endDate)
        {
            return await Task.Run(() =>
                 _context.PosTransaction
                     .Include(o => o.CreatedByStaff)
                     .Where(o => o.PosTransactionUtcDateTime >= startDate && o.PosTransactionUtcDateTime <= endDate));
        }
    }
}