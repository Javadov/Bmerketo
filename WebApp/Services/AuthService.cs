using Microsoft.AspNetCore.Identity;
using WebApp.Models.Contexts;
using WebApp.Models.Identity;
using WebApp.ViewModels;

namespace WebApp.Services;

public class AuthService
{
    private readonly UserManager<IdentityUser> _userManager;

    public AuthService(UserManager<IdentityUser> userManager, IdentityContext identityContext)
    {
        _userManager = userManager;
       // _identityContext = IdentityContext;
    }

    public async Task<bool> RegisterAsync(UserRegisterViewModel model)
    {
        try
        {
            IdentityUser identityUser = model;
            await _userManager.CreateAsync(identityUser, model.Password);

            AppUser appUser = model;

//            _identityContext.

            return true;
        }
        catch { return false; }
    }
}
