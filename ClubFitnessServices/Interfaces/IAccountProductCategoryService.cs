using ClubFitnessDomain;
using ClubFitnessDomain.Dtos;

namespace ClubFitnessServices.Interfaces
{
    public interface IAccountProductCategoryService
    {
        Task<IEnumerable<AccountProductCategory>> GetAllAsync();

        Task<AccountProductCategoryDto> GetByIdAsync(int id);

        Task AddAsync(AccountProductCategoryDto dto);

        Task UpdateAsync(AccountProductCategoryDto dto);

        Task DeleteAsync(int id, int deletedBy);
    }
}