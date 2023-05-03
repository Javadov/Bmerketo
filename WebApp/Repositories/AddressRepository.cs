using WebApp.Models.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Repositories;

public class AddressRepository : IdRepository<AddressEntity>
{
    public AddressRepository(IdentityContext context) : base(context)
    {
    }
}
