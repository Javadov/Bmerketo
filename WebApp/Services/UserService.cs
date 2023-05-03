using Amazon.EC2.Model;
using Amazon.IdentityManagement.Model;
//using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApp.Models.Contexts;
using WebApp.Models.Identity;
using WebApp.Repositories;
using WebApp.ViewModels;

namespace WebApp.Services;

public class UserService
{
    private readonly UserRepository _userRepo;
    private readonly UserAddressRepository _userAddressRepo;
    private readonly AddressRepository _addressRepo;
    private readonly IdentityContext _identityContext;
    private readonly UserManager<AppUser> _userManager;
    //private readonly RoleManager<IdentityRole> _roleManager;

    public UserService(UserRepository userRepo, UserAddressRepository userAddressRepo, IdentityContext identityContext, /*RoleManager<IdentityRole> roleManager,*/ AddressRepository addressRepo, UserManager<AppUser> userManager)
    {
        _userRepo = userRepo;
        _userAddressRepo = userAddressRepo;
        _addressRepo = addressRepo;
        _identityContext = identityContext;
        //_roleManager = roleManager;
        _userManager = userManager;
    }

    public async Task<AppUser> AddUserAsync(AppUser user)
    {
        return await _userRepo.AddAsync(user);
    }

    public async Task<IEnumerable<UserViewModel>> GetAllUsersAsync()
    {
        var profiles = new List<UserViewModel>();

        var users = await _userRepo.GetAllAsync();

        foreach (var user in users)
        {
            var addresses = await _identityContext.AspNetUsersAddresses.Where(x => x.UserId == user.Id).Select(x => x.Address).ToListAsync();
            var role = await _userManager.GetRolesAsync(user);

            var userViewModel = new UserViewModel
            {
                UserId = user.Id,
                UserName = user.UserName!,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber,
                Company = user.CompanyName,
                Role = string.Join(",", role),
                Addresses = addresses.Select(a => new AddressViewModel
                {
                    StreetName = a.StreetName,
                    PostalCode = a.PostalCode,
                    City = a.City
                })
            };

            profiles.Add(userViewModel);

        }

        return profiles;
    }


    //public async Task<List<AppUser>> GetAllUsersAsync()
    //{
    //    return (List<AppUser>)await _userRepo.GetAllAsync();
    //}

    public async Task<AppUser> GetUserAsync(string userId)
    {
        return await _userRepo.GetAsync(u => u.Id == userId);
    }

    public async Task<bool> DeleteUserAsync(AppUser user)
    {
        return await _userRepo.DeleteAsync(user);
    }
}