using ShoppingCart.Entitys.DTOs.Account;
using ShoppingCart.Entitys.POCOs;

namespace ShoppingCart.Entitys.Interfaces.Account
{
    public interface IFindClientByEmail
    {
        Task<Client> GetClientByEmailAsync(string email);
    }
}
