
namespace ShoppingCart.Entitys.POCOs
{
    public partial class Client
    {
        public int IdClient { get; set; }

        public string Name { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string Password { get; set; } = null!;

        public virtual ICollection<RelClientArticle> RelClientArticles { get; set; } = new List<RelClientArticle>();
    }
}
