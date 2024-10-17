using ClubFitnessDomain;
using ClubFitnessInfrastructure.Interfaces;
using ClubFitnessServices.Interfaces;

namespace ClubFitnessServices
{
    public class PosTransactionPaymentService : IPosTransactionPaymentService
    {
        private readonly IPosTransactionPaymentRepository _repository;

        public PosTransactionPaymentService(IPosTransactionPaymentRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PosTransactionPayment>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<PosTransactionPayment> GetByIdAsync(long id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(PosTransactionPayment posTransactionPayment)
        {
            await _repository.AddAsync(posTransactionPayment);
        }

        public async Task UpdateAsync(PosTransactionPayment posTransactionPayment)
        {
            await _repository.UpdateAsync(posTransactionPayment);
        }

        public async Task DeleteAsync(long id, int deletedBy)
        {
            await _repository.DeleteAsync(id, deletedBy);
        }
    }
}