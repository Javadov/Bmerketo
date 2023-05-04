using Amazon.IdentityManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models.Entities;

public class ProductImagesEntity
{
    public int Id { get; set; }
    public string? ImageUrl { get; set; }
    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;
}
