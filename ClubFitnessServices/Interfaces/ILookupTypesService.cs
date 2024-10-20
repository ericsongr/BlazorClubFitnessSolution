using ClubFitnessDomain;

namespace ClubFitnessServices.Interfaces
{
    public interface ILookupTypesService
    {
        Task<IEnumerable<LookupType>> GetAllAsync();
        Task<LookupType> GetByIdAsync(int id);
        Task AddAsync(LookupType lookupType);
        Task UpdateAsync(LookupType lookupType);
        Task DeleteAsync(int id, int deletedBy);
    }
}