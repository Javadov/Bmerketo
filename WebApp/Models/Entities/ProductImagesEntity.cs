using Amazon.IdentityManagement.Model;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Models.Entities;

public class ProductImagesEntity
{
    internal readonly int ContentLength;

    public int Id { get; set; }
    public byte[] ImageData { get; set; } = null!;
    public string ImageMimeType { get; set; } = null!;
    public Guid ProductId { get; set; }
    public ProductEntity Product { get; set; } = null!;
}
