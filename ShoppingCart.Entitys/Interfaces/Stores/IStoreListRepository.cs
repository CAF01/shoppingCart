using ShoppingCart.Entitys.DTOs.Stores;

namespace ShoppingCart.Entitys.Interfaces.Stores
{
    public interface IStoreListRepository
    {
        Task<IEnumerable<StoreListDTO>> GetStoresAsync();
    }
}
