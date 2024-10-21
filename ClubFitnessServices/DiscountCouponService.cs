using ClubFitnessDomain;
using ClubFitnessServices.Interfaces;
using ClubFitnessInfrastructure.Interfaces;

namespace ClubFitnessServices
{
    public class DiscountCouponService : IDiscountCouponService
    {
        private readonly IDiscountCouponRepository _repository;

        public DiscountCouponService(IDiscountCouponRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DiscountCoupon>> GetAllAsync()
        {
            return await _repository.GetWithIncludesAsync(p => p.IsActive && p.ExpiryDate.HasValue && 
                                                               p.ExpiryDate.Value.Date >= DateTime.Now.Date, 
                                                        p => p.LookupTypeItem);
        }
        

        public async Task<DiscountCoupon> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddAsync(DiscountCoupon discountCoupon)
        {
            await _repository.AddAsync(discountCoupon);
        }

        public async Task UpdateAsync(DiscountCoupon discountCoupon)
        {
            await _repository.UpdateAsync(discountCoupon);
        }

        public async Task DeleteAsync(int id, int deletedBy)
        {
            await _repository.DeleteAsync(id, deletedBy);
        }
    }
}