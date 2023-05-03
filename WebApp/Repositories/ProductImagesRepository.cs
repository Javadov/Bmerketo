using WebApp.Models.Contexts;

namespace WebApp.Repositories;

public class ProductImagesRepository : DataRepository<ProductImagesRepository>
{
    public ProductImagesRepository(DataContext context) : base(context)
    {
    }
}
