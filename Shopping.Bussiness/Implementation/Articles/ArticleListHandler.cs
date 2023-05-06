using ShoppingCart.Bussiness.Interfaces.Articles;
using ShoppingCart.Entitys.DTOs.Articles;
using ShoppingCart.Entitys.Interfaces.Articles;

namespace ShoppingCart.Bussiness.Implementation.Articles
{
    public class ArticleListHandler
        : IArticleListInputPort
    {
        private readonly IArticleListRepository articleListRepository;

        public ArticleListHandler(IArticleListRepository articleListRepository)
        {
            this.articleListRepository = articleListRepository;
        }

        public Task<IEnumerable<ArticleDTO>> Handle(int dto)
        {
            return articleListRepository.GetArticlesAsync(dto);
        }
    }
}
