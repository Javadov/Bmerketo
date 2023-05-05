using Microsoft.EntityFrameworkCore;

namespace WebApp.Models.Entities;

[PrimaryKey(nameof(ProductId), nameof(TagId))]
public class ProductTagEntity
{
    public string ProductId { get; set; } = null!;
    public ProductEntity Products { get; set; } = null!;

    public int TagId { get; set; }
    public TagEntity Tags { get; set; } = null!;
}
