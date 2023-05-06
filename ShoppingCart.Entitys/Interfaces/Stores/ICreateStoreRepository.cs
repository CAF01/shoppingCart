using ShoppingCart.Entitys.DTOs.Stores;
using ShoppingCart.Entitys.POCOs;

namespace ShoppingCart.Entitys.Interfaces.Stores
{
    public interface ICreateStoreRepository
    {
        public Store CreateStore(CreateStoreDTO store);
    }
}
