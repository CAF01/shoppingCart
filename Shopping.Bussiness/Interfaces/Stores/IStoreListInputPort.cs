using ShoppingCart.Entitys.DTOs.Stores;

namespace ShoppingCart.Bussiness.Interfaces.Stores
{
    public interface IStoreListInputPort
        : ISingleIport<IEnumerable<StoreListDTO>>
    {
    }
}
