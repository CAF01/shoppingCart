namespace ShoppingCart.Entitys.DTOs.Articles
{
    public class CreateArticleDTO
    {
        public string Code { get; set; } = default!;
        public string Description { get; set; } = default!;
        public decimal Price { get; set; } = default!;
        public string Image { get; set; } = default!;
        public int Stock { get; set; } = default!;
        public int IdStore { get; set; }
    }
}
