using ClubFitnessDomain;
using ClubFitnessInfrastructure.Interfaces;
using ClubFitnessServices.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubFitnessServices
{
    public class AccountSupplierService : IAccountSupplierService
    {
        private readonly IAccountSupplierRepository _accountSupplierRepository;

        public AccountSupplierService(IAccountSupplierRepository accountSupplierRepository)
        {
            _accountSupplierRepository = accountSupplierRepository;
        }

        public async Task<IEnumerable<AccountSupplier>> GetAllAsync()
        {
            return await _accountSupplierRepository.GetAllAsync();
        }

        public async Task<AccountSupplier> GetByIdAsync(int id)
        {
            return await _accountSupplierRepository.GetByIdAsync(id);
        }

        public async Task<AccountSupplier> GetWithAccountByIdAsync(int id)
        {
            return await _accountSupplierRepository.GetWithAccountByIdAsync(id);
        }

        public async Task AddAsync(AccountSupplier accountSupplier)
        {
            await _accountSupplierRepository.AddAsync(accountSupplier);
        }

        public async Task UpdateAsync(AccountSupplier accountSupplier)
        {
            await _accountSupplierRepository.UpdateAsync(accountSupplier);
        }

        public async Task DeleteAsync(int accountSupplierId)
        {
            await _accountSupplierRepository.DeleteAsync(accountSupplierId);
        }
    }
}