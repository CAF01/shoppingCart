namespace ShoppingCart.Entitys.POCOs
{
    public partial class Store
    {
        public int IdStore { get; set; }

        public string Branch { get; set; } = null!;

        public string Address { get; set; } = null!;

        public virtual ICollection<RelArticlesInStore> RelArticlesInStores { get; set; } = new List<RelArticlesInStore>();
    }
}
