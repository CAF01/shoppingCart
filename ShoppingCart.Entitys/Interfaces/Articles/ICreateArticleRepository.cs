
using ShoppingCart.Entitys.DTOs.Articles;
using ShoppingCart.Entitys.POCOs;

namespace ShoppingCart.Entitys.Interfaces.Articles
{
    public interface ICreateArticleRepository
    {
        public Article Create(CreateArticleDTO article);
    }
}
