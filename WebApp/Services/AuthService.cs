using Amazon.CloudSearch.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Net.WebSockets;
using WebApp.Models.Contexts;
using WebApp.Models.Identity;
using WebApp.ViewModels;

namespace WebApp.Services;

public class AuthService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly AddressService _addressService;

    public AuthService(UserManager<AppUser> userManager, AddressService addressService, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _addressService = addressService;
        _signInManager = signInManager;
    }

    public async Task<bool> ExistUserAsync(Expression<Func<AppUser, bool>> expression)
    {
        return await _userManager.Users.AnyAsync(expression);
    }

    public async Task<bool> RegisterAsync(UserRegisterViewModel model)
    {
        try
        {
            AppUser appUser = model;

            var result = await _userManager.CreateAsync(appUser, model.Password);
            if (result.Succeeded) 
            {
                var address = await _addressService.GetorCreateAsync(model);
                if (address != null)
                {
                    await _addressService.AddAddressAsync(appUser, address);
                    return true;
                }
            }

            return false;
        }
        catch { return false; }
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
}
