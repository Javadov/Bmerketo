using WebApp.Models.Contexts;
using WebApp.Models.Identity;

namespace WebApp.Repositories
{
    public class RoleRepository : IdRepository<AppUser>
    {
        public RoleRepository(IdentityContext context) : base(context)
        {
        }
    }
}
