using ClubFitnessDomain;
using ClubFitnessInfrastructure.Interfaces;
using ClubFitnessServices.Interfaces;

namespace ClubFitnessServices
{
    public class PosTransactionGenericItemService : IPosTransactionGenericItemService
    {
        private readonly IPosTransactionGenericItemRepository _repository;

        public PosTransactionGenericItemService(IPosTransactionGenericItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PosTransactionGenericItem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<PosTransactionGenericItem> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(PosTransactionGenericItem posTransactionGenericItem)
        {
            await _repository.AddAsync(posTransactionGenericItem);
        }

        public async Task UpdateAsync(PosTransactionGenericItem posTransactionGenericItem)
        {
            await _repository.UpdateAsync(posTransactionGenericItem);
        }

        public async Task DeleteAsync(long id, int deletedBy)
        {
            await _repository.DeleteAsync(id, deletedBy);
        }
    }
}