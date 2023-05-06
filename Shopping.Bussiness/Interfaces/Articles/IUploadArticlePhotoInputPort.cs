using Microsoft.AspNetCore.Http;

namespace ShoppingCart.Bussiness.Interfaces.Articles
{
    public interface IUploadArticlePhotoInputPort
        : IPort<IFormFile, string>
    {
    }
}
