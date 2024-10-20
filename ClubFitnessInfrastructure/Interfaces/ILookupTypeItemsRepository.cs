using ClubFitnessDomain;

namespace ClubFitnessInfrastructure.Interfaces
{
    public interface ILookupTypeItemsRepository : IRepository<LookupTypeItem>
    {
        Task<IEnumerable<LookupTypeItem>> GetLookupItems(int id);
    }
}