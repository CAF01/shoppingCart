using ShoppingCart.Data.EFC.DataContext;
using ShoppingCart.Entitys.DTOs.Articles;
using ShoppingCart.Entitys.Interfaces.Articles;
using ShoppingCart.Entitys.POCOs;

namespace ShoppingCart.Data.EFC.Articles
{
    public class ShoppingCartRepository
        : IShoppingCartRepository
    {
        private readonly ShoppingCartContext context;

        public ShoppingCartRepository(ShoppingCartContext context)
        {
            this.context = context;
        }

        public void ShoppingCart(List<ShoppingCartDTO> data)
        {
            foreach (var item in data)
            {
                context.RelClientArticles.Add(new RelClientArticle
                {
                    IdArticle = item.IdArticle,
                    IdClient = item.IdClient
                });
            }

            foreach (var IdArticle in data.DistinctBy(p => p.IdArticle).Select(p => p.IdArticle))
            {
                int count = data.Count(i => i.IdArticle == IdArticle);

                Article article = context.Articles.Find(IdArticle);
                article.Stock -= count;
            }
        }
    }
}
