using AutoMapper;
using ClubFitnessInfrastructure.Interfaces;
using ClubFitnessDomain;
using ClubFitnessDomain.Dtos;
using ClubFitnessServices.Interfaces;
using AccountProductSubCategory = ClubFitnessDomain.AccountProductSubCategory;

namespace ClubFitnessServices
{
    public class AccountProductSubCategoryService : IAccountProductSubCategoryService
    {
        private readonly IAccountProductSubCategoryRepository _repository;
        private readonly IMapper _mapper;

        public AccountProductSubCategoryService(
            IAccountProductSubCategoryRepository repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AccountProductSubCategoryDto>> GetAllAsync()
        {
            var subCategories = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<AccountProductSubCategoryDto>>(subCategories);
        }

        public async Task<AccountProductSubCategoryDto> GetByIdAsync(int id)
        {
            var subCategory = await _repository.GetByIdAsync(id);
            return _mapper.Map<AccountProductSubCategoryDto>(subCategory);
        }

        public async Task AddAsync(AccountProductSubCategoryDto dto)
        {
            var subCategory = _mapper.Map<AccountProductSubCategory>(dto);
            await _repository.AddAsync(subCategory);
        }

        public async Task UpdateAsync(AccountProductSubCategoryDto dto)
        {
            var subCategoryBefore = await _repository.GetByIdAsync(dto.AccountProductSubCategoryId);

            var subCategory = _mapper.Map(dto, subCategoryBefore);
            await _repository.UpdateAsync(subCategory);
        }

        public async Task DeleteAsync(int id, int deletedBy)
        {
            await _repository.DeleteAsync(id, deletedBy);
        }
    }
}