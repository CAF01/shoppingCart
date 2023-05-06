namespace ShoppingCart.Entitys.POCOs
{
    public partial class RelClientArticle
    {
        public int IdRelClientArticle { get; set; }

        public int IdClient { get; set; }

        public int IdArticle { get; set; }

        public DateTime Date { get; set; }

        public virtual Article IdArticleNavigation { get; set; } = null!;

        public virtual Client IdClientNavigation { get; set; } = null!;
    }
}
