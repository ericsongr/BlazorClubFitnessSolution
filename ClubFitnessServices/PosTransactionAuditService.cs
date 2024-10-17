using ClubFitnessDomain;
using ClubFitnessInfrastructure.Interfaces;
using ClubFitnessServices.Interfaces;

namespace ClubFitnessServices
{
    public class PosTransactionAuditService : IPosTransactionAuditService
    {
        private readonly IPosTransactionAuditRepository _repository;

        public PosTransactionAuditService(IPosTransactionAuditRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PosTransactionAudit>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<PosTransactionAudit> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(PosTransactionAudit posTransactionAudit)
        {
            await _repository.AddAsync(posTransactionAudit);
        }

        public async Task UpdateAsync(PosTransactionAudit posTransactionAudit)
        {
            await _repository.UpdateAsync(posTransactionAudit);
        }

        public async Task DeleteAsync(long id, int deletedBy)
        {
            await _repository.DeleteAsync(id, deletedBy);
        }
    }
}