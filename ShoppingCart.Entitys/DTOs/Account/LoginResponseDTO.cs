namespace ShoppingCart.Entitys.DTOs.Account
{
    public class LoginResponseDTO
    {
        public int IdClient { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string FullName { get; set; } = default!;
        public string Token { get; set; } = default!;
    }
}
