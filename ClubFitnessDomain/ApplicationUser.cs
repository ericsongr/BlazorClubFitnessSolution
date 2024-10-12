using Microsoft.AspNetCore.Identity;

namespace ClubFitnessDomain
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public int StaffId { get; set; }

        public virtual Staff Staff { get; set; }
    }

}
