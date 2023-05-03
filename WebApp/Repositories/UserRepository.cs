using WebApp.Models.Contexts;
using WebApp.Models.Identity;

namespace WebApp.Repositories
{
    public class UserRepository : IdRepository<AppUser>
    {
        public UserRepository(IdentityContext context) : base(context)
        {
        }
    }
}
