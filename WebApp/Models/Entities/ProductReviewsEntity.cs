namespace WebApp.Models.Entities
{
    public class ProductReviewsEntity
    {
        public int Id { get; set; }
        public float Rating { get; set; }
        public string? Review { get; set; }
        public Guid ProductId { get; set; }
        public ProductEntity Product { get; set; } = null!;
    }
}
