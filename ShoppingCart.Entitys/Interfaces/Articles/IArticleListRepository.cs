using ShoppingCart.Entitys.DTOs.Articles;

namespace ShoppingCart.Entitys.Interfaces.Articles
{
    public interface IArticleListRepository
    {
        public Task<IEnumerable<ArticleDTO>> GetArticlesAsync(int storeId);
    }
}
