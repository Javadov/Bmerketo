using Amazon.EC2.Model;
using Amazon.IdentityManagement.Model;
using Microsoft.EntityFrameworkCore;
using WebApp.Models.Identity;

namespace WebApp.Models.Entities;

[PrimaryKey(nameof(ProductId), nameof(CategoryId))]
public class ProductCategoryEntity
{
    public string ProductId { get; set; } = null!;
    public ProductEntity Products { get; set; } = null!;

    public int CategoryId { get; set; }
    public CategoryEntity Categories { get; set; } = null!;
}
