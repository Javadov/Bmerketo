using Microsoft.EntityFrameworkCore;
using WebApp.Models.Entities;

namespace WebApp.Models.Contexts;

public class DataContext : DbContext
{
    #region constructors
    public DataContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProductEntity>(entity =>
        {
            entity.Property(e => e.Price).HasColumnType("decimal(18,2)");
        });
    }
    #endregion

    #region entities
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<ProductImagesEntity> ProductImages { get; set; }
    public DbSet<CategoryEntity> Categories { get; set; }
    public DbSet<ProductCategoryEntity> ProductCategories { get; set; }
    public DbSet<TagEntity> Tags { get; set; }
    public DbSet<ProductTagEntity> ProductTags{ get; set; }
    public DbSet<ProductReviewsEntity> ProductReviews { get; set; }
    #endregion
}
