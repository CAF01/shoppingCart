using ShoppingCart.Entitys.DTOs.Account;

namespace ShoppingCart.Bussiness.Interfaces.Account
{
    public interface ILoginInputPort
        :IPort<LoginDTO, LoginResponseDTO>
    {
    }
}
