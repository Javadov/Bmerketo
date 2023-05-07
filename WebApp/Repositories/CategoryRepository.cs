using WebApp.Models.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Repositories;

public class CategoryRepository : DataRepository<CategoryEntity>
{
    public CategoryRepository(DataContext context) : base(context)
    {
    }
}
