using ClubFitnessDomain;
using ClubFitnessInfrastructure.Interfaces;
using ClubFitnessServices.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubFitnessServices
{
    public class LookupTypesService : ILookupTypesService
    {
        private readonly ILookupTypesRepository _repository;

        public LookupTypesService(ILookupTypesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<LookupType>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<LookupType> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(LookupType lookupType)
        {
            await _repository.AddAsync(lookupType);
        }

        public async Task UpdateAsync(LookupType lookupType)
        {
            await _repository.UpdateAsync(lookupType);
        }

        public async Task DeleteAsync(int id, int deletedBy)
        {
            await _repository.DeleteAsync(id, deletedBy);
        }
    }
}