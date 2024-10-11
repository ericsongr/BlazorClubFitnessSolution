using AutoMapper;
using ClubFitnessInfrastructure.Interfaces;
using ClubFitnessDomain;
using ClubFitnessServices.Interfaces;

namespace ClubFitnessServices
{
    public class AccountProductService : IAccountProductService
    {
        private readonly IAccountProductRepository _repository;
        private readonly IMapper _mapper;

        public AccountProductService(IAccountProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AccountProduct>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<AccountProduct> GetByIdAsync(int id)
        {
            var accountProduct = await _repository.GetByIdAsync(id);
            return _mapper.Map<AccountProduct>(accountProduct);
        }

        public async Task AddAsync(AccountProduct dto)
        {
            var accountProduct = _mapper.Map<ClubFitnessDomain.AccountProduct>(dto);
            await _repository.AddAsync(accountProduct);
        }

        public async Task UpdateAsync(AccountProduct dto)
        {
            var accountProductBefore = await _repository.GetByIdAsync(dto.AccountProductId);
            var accountProduct = _mapper.Map(dto, accountProductBefore);
            await _repository.UpdateAsync(accountProduct);
        }

        public async Task DeleteAsync(int id, int deletedBy)
        {
            await _repository.DeleteAsync(id, deletedBy);
        }
    }
}