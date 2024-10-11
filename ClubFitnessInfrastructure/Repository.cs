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

        public virtual async Task DeleteAsync(int id, int deletedBy)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                // Check if the entity has an IsDeleted property
                var isDeletedProperty = typeof(T).GetProperty("IsDeleted");
                var deletedDateTimeProperty = typeof(T).GetProperty("DeletedDateTimeUtc");
                var deletedByProperty = typeof(T).GetProperty("DeletedBy");

                if (isDeletedProperty != null && isDeletedProperty.PropertyType == typeof(bool))
                {
                    // Set IsDeleted to true
                    isDeletedProperty.SetValue(entity, true);

                    // Check if the entity has a DeletedDateTimeUtc property and set it to the current UTC date
                    if (deletedDateTimeProperty != null && deletedDateTimeProperty.PropertyType == typeof(DateTime?))
                    {
                        deletedDateTimeProperty.SetValue(entity, DateTime.UtcNow);
                    }

                    // Check if the entity has a DeletedBy property and set its value
                    if (deletedByProperty != null && deletedByProperty.PropertyType == typeof(int?))
                    {
                        deletedByProperty.SetValue(entity, deletedBy);
                    }

                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new InvalidOperationException("The entity does not have an 'IsDeleted' property.");
                }
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
