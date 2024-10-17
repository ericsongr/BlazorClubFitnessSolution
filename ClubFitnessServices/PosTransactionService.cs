using ClubFitnessDomain;
using ClubFitnessInfrastructure.Interfaces;
using ClubFitnessServices.Interfaces;

namespace ClubFitnessServices
{
    public class PosTransactionService : IPosTransactionService
    {
        private readonly IPosTransactionRepository _repository;

        public PosTransactionService(IPosTransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PosTransaction>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<PosTransaction> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(PosTransaction posTransaction)
        {
            await _repository.AddAsync(posTransaction);
        }

        public async Task UpdateAsync(PosTransaction posTransaction)
        {
            await _repository.UpdateAsync(posTransaction);
        }

        public async Task DeleteAsync(long id, int deletedBy)
        {
            await _repository.DeleteAsync(id, deletedBy);
        }
    }
}