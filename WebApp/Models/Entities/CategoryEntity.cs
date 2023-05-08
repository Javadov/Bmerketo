using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Entities
{
    public class CategoryEntity
    {
        [Key]
        public int Id { get; set; }
        public string Category { get; set; } = null!;
        public ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();
    }
}
