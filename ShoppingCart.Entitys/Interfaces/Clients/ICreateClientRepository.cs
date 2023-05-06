using ShoppingCart.Entitys.DTOs.Users;
using ShoppingCart.Entitys.POCOs;

namespace ShoppingCart.Entitys.Interfaces.Users
{
    public interface ICreateClientRepository
    {
        public Client Create(CreateClientDTO user);
    }
}
