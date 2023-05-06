using ShoppingCart.Entitys.DTOs.Stores;

namespace ShoppingCart.Bussiness.Interfaces.Stores
{
    public interface ICreateStoreInputPort
        : IPort<CreateStoreDTO, int>
    {
    }
}
