using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;
using WebApp.Models.Identity;

namespace WebApp.Models.Contexts;

public class IdentityContext : IdentityDbContext<AppUser>
{
    public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
    {
    }

    public DbSet<AddressEntity> AspNetAddresses { get; set; }
    public DbSet<UserAddressEntity> AspNetUsersAddresses { get; set; }

}
