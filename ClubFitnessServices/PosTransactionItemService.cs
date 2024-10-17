using ClubFitnessDomain;
using ClubFitnessInfrastructure.Interfaces;
using ClubFitnessServices.Interfaces;

namespace ClubFitnessServices
{
    public class PosTransactionItemService : IPosTransactionItemService
    {
        private readonly IPosTransactionItemRepository _repository;

        public PosTransactionItemService(IPosTransactionItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PosTransactionItem>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<PosTransactionItem> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(PosTransactionItem posTransactionItem)
        {
            await _repository.AddAsync(posTransactionItem);
        }

        public async Task UpdateAsync(PosTransactionItem posTransactionItem)
        {
            await _repository.UpdateAsync(posTransactionItem);
        }

        public async Task DeleteAsync(long id, int deletedBy)
        {
            await _repository.DeleteAsync(id, deletedBy);
        }
    }
}