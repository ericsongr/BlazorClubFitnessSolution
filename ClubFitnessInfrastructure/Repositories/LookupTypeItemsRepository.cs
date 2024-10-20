using ClubFitnessDomain;
using ClubFitnessInfrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubFitnessInfrastructure.Repositories
{
    public class LookupTypeItemsRepository : Repository<LookupTypeItem>, ILookupTypeItemsRepository
    {
        private readonly ClubFitnessDbContext _context;

        public LookupTypeItemsRepository(ClubFitnessDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LookupTypeItem>> GetLookupItems(int id)
        {
            return await _context.LookupTypeItems.Where(o => o.TypeId == id).ToListAsync();
        }
    }
}