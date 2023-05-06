using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Bussiness.Interfaces.Articles;
using ShoppingCart.Entitys.DTOs.Articles;

namespace ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ArticlesController : ControllerBase
    {
        private readonly IUploadArticlePhotoInputPort uploadArticlePhotoInputPort;
        private readonly ICreateArticleInputPort createArticleInputPort;
        private readonly IArticleListInputPort articleListInputPort;
        private readonly IShoppingCartInputPort shoppingCartInputPort;

        public ArticlesController(IUploadArticlePhotoInputPort uploadArticlePhotoInputPort,
                                  ICreateArticleInputPort createArticleInputPort,
                                  IArticleListInputPort articleListInputPort,
                                  IShoppingCartInputPort shoppingCartInputPort)
        {
            this.uploadArticlePhotoInputPort = uploadArticlePhotoInputPort;
            this.createArticleInputPort = createArticleInputPort;
            this.articleListInputPort = articleListInputPort;
            this.shoppingCartInputPort = shoppingCartInputPort;
        }

        [HttpGet]
        public Task<IEnumerable<ArticleDTO>> Get(int id)
        {
            return articleListInputPort.Handle(id);
        }

        [HttpPost]
        public async Task<int> Create(CreateArticleDTO article)
        {
            var Response = await createArticleInputPort.Handle(article);

            return Response;

        }

        [HttpPost("upload-image")]
        [RequestSizeLimit(2097152)] // límite de 2 MB
        public async Task<string> UploadCode([FromForm] IFormFile formFile)
        {
            var Result = await uploadArticlePhotoInputPort.Handle(formFile);

            return Result;
        }

        [HttpPost("shopping-cart")]
        public async Task<int> ShoppingCart(List<ShoppingCartDTO> data)
        {
            int Result = await shoppingCartInputPort.Handle(data);

            return Result;
        }

    }
}
