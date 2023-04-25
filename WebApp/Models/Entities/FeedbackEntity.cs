using Microsoft.EntityFrameworkCore;
using WebApp.Models.Identity;

namespace WebApp.Models.Entities;

[PrimaryKey(nameof(UserId))]
public class FeedbackEntity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string? PhoneNumber { get; set; }
    public string? CompanyName { get; set; }
    public string Comment { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public AppUser User { get; set; } = null!;
}
