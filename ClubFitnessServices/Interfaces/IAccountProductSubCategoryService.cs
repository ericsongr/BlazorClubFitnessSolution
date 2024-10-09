using ClubFitnessDomain.Dtos;

namespace ClubFitnessServices.Interfaces
{
    public interface IAccountProductSubCategoryService
    {
        Task<IEnumerable<AccountProductSubCategoryDto>> GetAllAsync();
        Task<AccountProductSubCategoryDto> GetByIdAsync(int id);
        Task AddAsync(AccountProductSubCategoryDto dto);
        Task UpdateAsync(AccountProductSubCategoryDto dto);
        Task DeleteAsync(int id);
    }
}