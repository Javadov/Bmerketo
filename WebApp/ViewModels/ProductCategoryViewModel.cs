using WebApp.Models.Entities;

namespace WebApp.ViewModels;

public class ProductCategoryViewModel
{
    public int Id { get; set; }
    public string Category { get; set; } = null!;
}
