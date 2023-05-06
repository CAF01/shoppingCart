using ShoppingCart.Data.EFC.DataContext;
using ShoppingCart.Entitys.DTOs.Articles;
using ShoppingCart.Entitys.Interfaces.Articles;
using ShoppingCart.Entitys.POCOs;


namespace ShoppingCart.Data.EFC.Articles
{
    public class CreateArticleRepository
        : ICreateArticleRepository
    {
        private readonly ShoppingCartContext context;

        public CreateArticleRepository(ShoppingCartContext context)
        {
            this.context = context;
        }

        public Article Create(CreateArticleDTO article)
        {
            Article NewArticle = new Article
            {
                Description = article.Description,
                Code = article.Code,
                Image = article.Image,
                Price = article.Price,
                Stock = article.Stock
            };

            context.Articles.Add(NewArticle);

            NewArticle.Add(NewArticle.IdArticle, article.IdStore);

            return NewArticle;
        }
    }
}
