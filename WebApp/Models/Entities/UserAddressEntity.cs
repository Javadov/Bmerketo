using Microsoft.EntityFrameworkCore;
using WebApp.Models.Identity;

namespace WebApp.Models.Entities;

[PrimaryKey(nameof(UserId), nameof(AddressId))]
public class UserAddressEntity
{
    public string UserId { get; set; } = null!;
    public AppUser User { get; set; } = null!;

    public string AddressId { get; set; } = null!;
    public AddressEntity Address { get; set; } = null!;
}
