using ClubFitnessDomain;
using System.Threading.Tasks;

namespace ClubFitnessInfrastructure.Interfaces
{
    public interface IAccountSupplierRepository : IRepository<AccountSupplier>
    {
        Task<AccountSupplier> GetWithAccountByIdAsync(int id);
    }
}