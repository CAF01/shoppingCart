namespace ShoppingCart.Entitys.Interfaces
{
    public interface IAuthenticationManager
    {
        string GetTokenAsync(string user);
    }
}
