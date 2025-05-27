using Microsoft.AspNetCore.Authentication;
using Music_App.Models;
using Microsoft.AspNetCore.Identity;

namespace Music_App.Services.Interfaces
{
    public interface IAuthService
    {
        //Task<List<AuthenticationScheme>> GetExternalLoginsAsync();
        //Task SignOutExternalAsync();
        //Task<SignInResult> SignInUserAsync(string email, string password, bool rememberMe);
        //Task<(IdentityResult Result, User User)> RegisterUserAsync(string email, string password);
        //Task SignInAfterRegisterAsync(User user);
        //Task<(bool Success, bool RequiresTwoFactor, bool IsLockedOut)> LoginAsync(string email, string password, bool rememberMe);
        //Task<(bool Success, IEnumerable<IdentityError> Errors)> RegisterAsync(string email, string password);
        //Task SignOutExternalAsync();
        //Task SignInAsync(User user, bool isPersistent);
        //Task<IList<AuthenticationScheme>> GetExternalLoginSchemesAsync();

        //Task<IdentityResult> RegisterAsync(string email, string password);
        //Task<SignInResult> LoginAsync(string email, string password, bool rememberMe);
        //Task SignOutAsync();
        //Task<List<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync();
        //bool requireConfirmation();
        //bool supportsUserEmail();
        //IUserStore<IdentityUser> GetUserEmailStore();

        Task<SignInResult> LoginAsync(string email, string password, bool rememberMe);
        Task<(IdentityResult Result, User User)> RegisterAsync(string email, string password);
       
    }
}
