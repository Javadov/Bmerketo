using WebApp.Models.Identity;

namespace WebApp.Models.Entities;

public class AddressEntity
{
    public int Id { get; set; }
    public string StreetName { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
    public ICollection<AppUser> Users { get; set; } = new HashSet<AppUser>();
}
