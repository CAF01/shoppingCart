namespace ShoppingCart.Entitys.DTOs.Stores
{
    public class StoreListDTO
    {
        public int IdStore { get; set; }
        public string Branch { get; set; } = default!;
        public string Address { get; set; } = default!;
    }
}
