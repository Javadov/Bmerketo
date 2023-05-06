using Amazon.CloudSearch.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Net.WebSockets;
using System.Security.Claims;
using WebApp.Models.Contexts;
using WebApp.Models.Dtos;
using WebApp.Models.Identity;
using WebApp.ViewModels;

namespace WebApp.Services;

public class AuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly AddressService _addressService;
    private readonly SeedService _seedService;

    public AuthService(UserManager<AppUser> userManager, AddressService addressService, SignInManager<AppUser> signInManager, SeedService seedService)
    {
        _userManager = userManager;
        _addressService = addressService;
        _signInManager = signInManager;
        _seedService = seedService;
    }

    public async Task<bool> ExistUserAsync(Expression<Func<AppUser, bool>> expression)
    {
        return await _userManager.Users.AnyAsync(expression);
    }

    public async Task<AppUser> RegisterAsync(UserRegisterViewModel model)
    {
        try
        {
            await _seedService.SeedRoles();
            var roleName = "user";

            if (!await _userManager.Users.AnyAsync())
                roleName = "admin";

            AppUser appUser = model;

            //if (model.ProfilePicture != null)
            //    appUser.ImageUrl = $"{appUser.Id}_{Path.GetFileName(model.ProfilePicture.FileName).Replace(" ", "_")}";

            var result = await _userManager.CreateAsync(appUser, model.Password);

            await _userManager.AddToRoleAsync(appUser, roleName);

            if (result.Succeeded) 
            {
                var address = await _addressService.GetorCreateAsync(model);
                if (address != null)
                {
                    await _addressService.AddAddressAsync(appUser, address);
                    return appUser;
                }
            }           

            return null!;
        }
        catch { return null!; }
    }

    public async Task<bool> LoginAsync(UserLoginViewModel model)
    { 
        var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == model.Email);
        if (user != null) 
        {
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
            return result.Succeeded;
        }

        return false;
    }

    public async Task<bool> LogoutAsync(ClaimsPrincipal user)
    {
        await _signInManager.SignOutAsync();
        return _signInManager.IsSignedIn(user);
    }
}
