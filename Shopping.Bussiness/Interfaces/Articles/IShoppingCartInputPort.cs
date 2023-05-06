using ShoppingCart.Entitys.DTOs.Articles;

namespace ShoppingCart.Bussiness.Interfaces.Articles
{
    public interface IShoppingCartInputPort
        : IPort<List<ShoppingCartDTO>, int>
    {
    }
}
