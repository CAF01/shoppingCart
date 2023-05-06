using ShoppingCart.Entitys.DTOs.Articles;

namespace ShoppingCart.Bussiness.Interfaces.Articles
{
    public interface IArticleListInputPort
        : IPort<int, IEnumerable<ArticleDTO>>
    {
    }
}
