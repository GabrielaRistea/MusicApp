using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Music_App.Models;
using Music_App.Services.Interfaces;

namespace Music_App.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<SignInResult> LoginAsync(string email, string password, bool rememberMe)
        {
            return await _signInManager.PasswordSignInAsync(email, password, rememberMe, lockoutOnFailure: false);
        }

        public async Task<(IdentityResult Result, User User)> RegisterAsync(string email, string password)
        {
            var user = new User { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, password);
            return (result, user);
        }
    }
}
