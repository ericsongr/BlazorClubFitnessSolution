using ClubFitnessDomain;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using ClubFitnessInfrastructure.Interfaces;

namespace ClubFitnessInfrastructure
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ClubFitnessDbContext _context;

        protected Repository(ClubFitnessDbContext context)
        {
            _context = context;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        // New Include method
        public virtual async Task<IEnumerable<T>> GetWithIncludesAsync(
            Expression<Func<T, bool>> filter,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _context.Set<T>();

            // Apply includes
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            // Apply filter
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }
    }
}
