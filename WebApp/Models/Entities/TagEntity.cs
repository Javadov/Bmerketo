namespace WebApp.Models.Entities;

public class TagEntity
{
    public int Id { get; set; }
    public string Tag { get; set; } = null!;
    public ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();
}
