using ClubFitnessDomain;
using ClubFitnessDomain.Dtos;

namespace ClubFitnessServices.Interfaces
{
    public interface IAccountProductSubCategoryService
    {
        Task<IEnumerable<AccountProductSubCategoryDto>> GetAllAsync();
        Task<AccountProductSubCategoryDto> GetByIdAsync(int id);
        Task<IEnumerable<AccountProductSubCategory>> GetSubCategoriesByCategoryId(int categoryId);
        Task AddAsync(AccountProductSubCategoryDto dto);
        Task UpdateAsync(AccountProductSubCategoryDto dto);
        Task DeleteAsync(int id, int deletedBy);
    }
}