using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels;

public class SubscribeViewModel
{
    public Guid Id { get; set; }

    [Display(Name = "E-mail Address")]
    [Required(ErrorMessage = "You must enter an e-mail address.")]
    [RegularExpression(@"^[a-zA-Z0-9._+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Your must enter a valid e-mail address.")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;
}
