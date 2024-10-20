using ClubFitnessDomain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubFitnessServices.Interfaces
{
    public interface ILookupTypeItemsService
    {
        Task<IEnumerable<LookupTypeItem>> GetAllAsync();
        Task<LookupTypeItem> GetByIdAsync(int id);
        Task<IEnumerable<LookupTypeItem>> GetLookupItems(int typeId);
        Task AddAsync(LookupTypeItem lookupTypeItem);
        Task UpdateAsync(LookupTypeItem lookupTypeItem);
        Task DeleteAsync(int id, int deletedBy);
    }
}