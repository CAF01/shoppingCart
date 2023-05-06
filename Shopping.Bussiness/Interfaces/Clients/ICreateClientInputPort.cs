using ShoppingCart.Entitys.DTOs.Users;

namespace ShoppingCart.Bussiness.Interfaces.Clients
{
    public interface ICreateClientInputPort
        : IPort<CreateClientDTO, int>
    {
    }
}
