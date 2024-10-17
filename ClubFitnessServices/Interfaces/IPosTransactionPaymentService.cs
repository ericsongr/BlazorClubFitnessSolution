using ClubFitnessDomain;

namespace ClubFitnessServices.Interfaces
{
    public interface IPosTransactionPaymentService
    {
        Task<IEnumerable<PosTransactionPayment>> GetAllAsync();
        Task<PosTransactionPayment> GetByIdAsync(long id);
        Task AddAsync(PosTransactionPayment posTransactionPayment);
        Task UpdateAsync(PosTransactionPayment posTransactionPayment);
        Task DeleteAsync(long id, int deletedBy);
    }
}