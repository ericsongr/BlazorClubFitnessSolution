using ClubFitnessDomain;
using ClubFitnessInfrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubFitnessInfrastructure.Repositories
{
    public class DiscountCouponRepository : Repository<DiscountCoupon>, IDiscountCouponRepository
    {
        public DiscountCouponRepository(ClubFitnessDbContext dbContext) : base(dbContext)
        {
        }

        // Additional methods specific to DiscountCoupon if needed
    }
}