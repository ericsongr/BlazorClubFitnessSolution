using ClubFitnessDomain;
using ClubFitnessInfrastructure.Interfaces;
using ClubFitnessInfrastructure.Repositories;
using ClubFitnessServices.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubFitnessServices
{
    public class LookupTypeItemsService : ILookupTypeItemsService
    {
        private readonly ILookupTypeItemsRepository _repository;

        public LookupTypeItemsService(ILookupTypeItemsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LookupTypeItem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<LookupTypeItem> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<LookupTypeItem>> GetLookupItems(int id)
        {
            return await _repository.GetLookupItems(id);
        }

        public async Task AddAsync(LookupTypeItem lookupTypeItem)
        {
            await _repository.AddAsync(lookupTypeItem);
        }

        public async Task UpdateAsync(LookupTypeItem lookupTypeItem)
        {
            await _repository.UpdateAsync(lookupTypeItem);
        }

        public async Task DeleteAsync(int id, int deletedBy)
        {
            await _repository.DeleteAsync(id, deletedBy);
        }
    }
}