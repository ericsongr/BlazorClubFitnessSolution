using ClubFitnessDomain;

namespace ClubFitnessServices.Interfaces
{
    public interface IDiscountCouponService
    {
        Task<IEnumerable<DiscountCoupon>> GetAllAsync();
        Task<DiscountCoupon> GetByIdAsync(int id);
        Task AddAsync(DiscountCoupon discountCoupon);
        Task UpdateAsync(DiscountCoupon discountCoupon);
        Task DeleteAsync(int id);
    }
}