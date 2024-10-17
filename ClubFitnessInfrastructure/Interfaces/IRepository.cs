using System.Linq.Expressions;

namespace ClubFitnessInfrastructure.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(object id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(object id, int deletedBy);
        Task<IEnumerable<T>> GetWithIncludesAsync(
            Expression<Func<T, bool>> filter,
            params Expression<Func<T, object>>[] includes);
    }
}