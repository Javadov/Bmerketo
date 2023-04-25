using System.ComponentModel.DataAnnotations;
using WebApp.Models.Identity;

namespace WebApp.ViewModels;

public class UserLoginViewModel
{
    [Display(Name = "E-mail Address")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Display(Name = "Password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Display(Name = "Keep me logged in")]
    public bool RememberMe { get; set; }

    public static implicit operator AppUser(UserLoginViewModel model)
    {
        return new AppUser
        {
            UserName = model.Email,
            Email = model.Email
        };
    }
}
