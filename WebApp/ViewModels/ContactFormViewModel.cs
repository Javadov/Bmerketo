using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels;

public class ContactFormViewModel
{
    [Required(ErrorMessage = "You must enter a first name.")]
    [Display(Name = "Name")]
    [DataType(DataType.Text)]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "You must enter an e-mail address.")]
    [RegularExpression(@"^[a-zA-Z0-9._+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Your must enter a valid e-mail address.")]
    [Display(Name = "E-mail Address")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = null!;

    [Display(Name = "Phone Number")]
    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; set; }

    [Display(Name = "Company")]
    [DataType(DataType.Text)]
    public string? Company { get; set; }

    [Required(ErrorMessage = "You must enter a comment")]
    [Display(Name = "Comment")]
    [DataType(DataType.Text)]
    public string Comment { get; set; } = null!;

    [Display(Name = "Save my name, email, and website in this browser for the next time I comment.")]
    public bool RememberMe { get; set; }
}
