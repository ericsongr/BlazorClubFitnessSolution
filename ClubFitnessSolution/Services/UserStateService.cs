using System.Net.Mime;
using ClubFitnessDomain;

namespace ClubFitnessSolution.Services
{
    public class UserStateService
    {
        public ApplicationUser? CurrentUser { get; set; }

        public void SetUser(ApplicationUser user)
        {
            CurrentUser = user;
        }

        public ApplicationUser? GetUser()
        {
            return CurrentUser;
        }

        public int GetStaffId()
        {
            return CurrentUser?.StaffId ?? 0;
        }

        public void ClearUser()
        {
            CurrentUser = null;
        }
    }
}
