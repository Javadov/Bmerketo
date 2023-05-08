using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Entities;

public class TagEntity
{
    [Key]
    public int Id { get; set; }
    public string Tag { get; set; } = null!;
    public ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();
}
