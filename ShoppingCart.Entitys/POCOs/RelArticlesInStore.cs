namespace ShoppingCart.Entitys.POCOs
{
    public partial class RelArticlesInStore
    {
        public int IdRelArticlesInStore { get; set; }

        public int IdArticle { get; set; }

        public int IdStore { get; set; }

        public DateTime Date { get; set; }

        public virtual Article IdArticleNavigation { get; set; } = null!;

        public virtual Store IdStoreNavigation { get; set; } = null!;
    }
}
