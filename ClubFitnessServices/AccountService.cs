using ClubFitnessDomain;
using ClubFitnessInfrastructure.Interfaces;
using ClubFitnessServices.Interfaces;

namespace ClubFitnessServices
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _accountRepository.GetAllAsync();
        }

        public async Task<Account?> GetByIdAsync(int id)
        {
            return await _accountRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Account account)
        {
            await _accountRepository.AddAsync(account);
        }

        public async Task UpdateAsync(Account account)
        {
            await _accountRepository.UpdateAsync(account);
        }

        public async Task DeleteAsync(int id)
        {
            await _accountRepository.DeleteAsync(id);
        }
        
    }
}