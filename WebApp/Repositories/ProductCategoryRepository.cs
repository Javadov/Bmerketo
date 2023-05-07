using WebApp.Models.Contexts;

namespace WebApp.Repositories;

public class ProductCategoryRepository : DataRepository<ProductCategoryRepository>
{
    public ProductCategoryRepository(DataContext context) : base(context)
    {
    }
}
