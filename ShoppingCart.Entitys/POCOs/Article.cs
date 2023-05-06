namespace ShoppingCart.Entitys.POCOs
{
    public partial class Article
    {
        public int IdArticle { get; set; }

        public string Code { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string Image { get; set; } = null!;

        public int Stock { get; set; }

        public virtual ICollection<RelArticlesInStore> RelArticlesInStores { get; set; } = new List<RelArticlesInStore>();

        public virtual ICollection<RelClientArticle> RelClientArticles { get; set; } = new List<RelClientArticle>();

        public void Add(int idArticle, int idStore) => RelArticlesInStores.Add(new RelArticlesInStore
        {
            IdArticle = idArticle,
            IdStore = idStore
        });

    }
}
