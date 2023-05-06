namespace ShoppingCart.Entitys.DTOs.Users
{
    public class CreateClientDTO
    {
        public string Name { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Address { get; set; } = default!;
    }
}
