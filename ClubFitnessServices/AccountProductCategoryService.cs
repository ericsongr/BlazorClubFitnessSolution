using AutoMapper;
using ClubFitnessInfrastructure.Interfaces;
using ClubFitnessDomain;
using ClubFitnessDomain.Dtos;
using ClubFitnessServices.Interfaces;

namespace ClubFitnessServices
{
    public class AccountProductCategoryService : IAccountProductCategoryService
    {
        private readonly IAccountProductCategoryRepository _repository;
        private readonly IMapper _mapper;

        public AccountProductCategoryService(
            IAccountProductCategoryRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AccountProductCategory>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<AccountProductCategoryDto> GetByIdAsync(int id)
        {
            var accountProductCategory = await _repository.GetByIdAsync(id);
            return _mapper.Map<AccountProductCategoryDto>(accountProductCategory);
        }

        public async Task AddAsync(AccountProductCategoryDto dto)
        {
            var accountProductCategory = _mapper.Map<AccountProductCategory>(dto);
            await _repository.AddAsync(accountProductCategory);
        }

        public async Task UpdateAsync(AccountProductCategoryDto dto)
        {
            var accountProductCategoryBefore = await _repository.GetByIdAsync(dto.AccountProductCategoryId);

            var accountProductCategory = _mapper.Map(dto, accountProductCategoryBefore);

            await _repository.UpdateAsync(accountProductCategory);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}