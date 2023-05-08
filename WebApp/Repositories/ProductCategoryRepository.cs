using WebApp.Models.Contexts;
using WebApp.Models.Entities;

namespace WebApp.Repositories;

public class ProductCategoryRepository : DataRepository<ProductCategoryEntity>
{
    public ProductCategoryRepository(DataContext context) : base(context)
    {
    }
}
