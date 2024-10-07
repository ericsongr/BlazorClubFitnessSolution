using ClubFitnessDomain;

namespace ClubFitnessInfrastructure.Interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        // Add any additional methods specific to Account here, if needed
        Task<Account?> GetAccountByNameAsync(string accountName);
    }
}