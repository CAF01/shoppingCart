using ShoppingCart.Entitys.DTOs.Articles;

namespace ShoppingCart.Bussiness.Interfaces.Articles
{
    public interface ICreateArticleInputPort
        : IPort<CreateArticleDTO, int>
    {
    }
}
