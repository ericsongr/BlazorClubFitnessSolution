using ClubFitnessDomain;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace ClubFitnessSolution
{
    public class UserAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private ApplicationUser _cachedUser;

        public UserAuthenticationStateProvider(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = _signInManager.Context.User;

            if (user.Identity.IsAuthenticated)
            {
                if (_cachedUser == null)
                {
                    _cachedUser = await _userManager.GetUserAsync(user);  // Load ApplicationUser
                }

                var claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity(user.Claims, "customAuth"));
                return new AuthenticationState(claimsPrincipal);
            }

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public async Task<ApplicationUser> GetCurrentUserAsync()
        {
            // Ensure _cachedUser is loaded
            if (_cachedUser == null)
            {
                await GetAuthenticationStateAsync();
            }

            return _cachedUser;
        }

        public async Task<int> GetStaffId()
        {
            // Ensure _cachedUser is loaded and return StaffId
            var currentUser = await GetCurrentUserAsync();
            return currentUser?.StaffId ?? 0; // Return 0 if _cachedUser is null
        }
    }

}
