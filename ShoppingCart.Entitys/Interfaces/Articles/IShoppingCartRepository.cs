using ShoppingCart.Entitys.DTOs.Articles;

namespace ShoppingCart.Entitys.Interfaces.Articles
{
    public interface IShoppingCartRepository
    {
        void ShoppingCart(List<ShoppingCartDTO> data);
    }
}
