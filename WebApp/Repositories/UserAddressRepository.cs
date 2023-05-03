using WebApp.Models.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Repositories;

public class UserAddressRepository : IdRepository<UserAddressEntity>
{
    public UserAddressRepository(IdentityContext context) : base(context)
    {
    }
}
