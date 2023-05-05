namespace WebApp.Models.Entities
{
    public class CategoryEntity
    {
        public int Id { get; set; }
        public string Category { get; set; } = null!;
        public ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();
    }
}
