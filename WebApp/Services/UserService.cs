using Amazon.EC2.Model;
using Amazon.IdentityManagement.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApp.Models.Contexts;
using WebApp.Models.Identity;
using WebApp.Repositories;

namespace WebApp.Services;

public class UserService
{
    private readonly UserRepository _userRepo;
    private readonly UserManager<AppUser> _userManager;

    public UserService(UserRepository userRepo, UserManager<AppUser> userManager)
    {
        _userRepo = userRepo;
        _userManager = userManager;
    }

    //public async Task<AppUser> GetUserAsync(AppUser user)
    //{
    //    var entity = await _userRepo.GetAsync(x =>
    //            x.Id == user.Id &&
    //            x.FirstName == user.FirstName &&
    //            x.LastName == user.LastName &&
    //            x.Email == user.Email &&
    //            x.PhoneNumber == user.PhoneNumber
    //        );

    //    return entity!;
    //}

    //public async Task<AppUser> GetUserAsync(ClaimsPrincipal claimsPrincipal)
    //{
    //    var entity = await _userManager.GetUserAsync(claimsPrincipal);
    //    return entity!;
    //}

    public async Task<AppUser> GetUserAsync(string userId)
    {
        return await _userRepo.GetAsync(u => u.Id == userId);
    }

    public async Task<List<AppUser>> GetAllUsersAsync()
    {
        return (List<AppUser>)await _userRepo.GetAllAsync();
    }

    public async Task<bool> DeleteUserAsync(AppUser user)
    {
        return await _userRepo.DeleteAsync(user);
    }

    //public async Task<IEnumerable<UserCardViewModel>> GetAllUserProfileAsync()
    //{
    //    var profiles = new List<UserCardViewModel>();
    //    var users = await _identityContext.UserProfiles
    //    .Include(× => x.User)
    //    ToListAsyncO) ;
    //    //var roles = await _identityContext. Roles. ToListAsync.);
    //    foreach (var user in users)
    //    {
    //        UserCardViewModel userCardViewModel = user;
    //        userCardViewModel.Roles = await _userManager.GetRolesAsync(user.User);
    //        profiles.Add(userCardViewModel);
    //        return profiles;
    //    }
    //}
}