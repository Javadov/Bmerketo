using WebApp.Models.Identity;

namespace WebApp.ViewModels;

public class UsersViewModel
{
    public List<AppUser> Users { get; set; } = null!;
    public UserRegisterViewModel RegisterModel { get; set; } = null!;
}

