using ShoppingCart.Bussiness.Interfaces.Articles;
using ShoppingCart.Entitys.DTOs.Articles;
using ShoppingCart.Entitys.Interfaces;
using ShoppingCart.Entitys.Interfaces.Articles;

namespace ShoppingCart.Bussiness.Implementation.Articles
{
    public class CreateArticleHandler
        : ICreateArticleInputPort
    {
        private readonly ICreateArticleRepository createArticleRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateArticleHandler(ICreateArticleRepository createArticleRepository,
                                    IUnitOfWork unitOfWork)
        {
            this.createArticleRepository = createArticleRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateArticleDTO dto)
        {
            var NewArticle = createArticleRepository.Create(dto);

            await unitOfWork.SaveChangesAsync();

            return NewArticle.IdArticle;
        }
    }
}
