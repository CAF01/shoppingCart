using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ShoppingCart.Bussiness.Interfaces.Articles;
using ShoppingCart.Entitys.Exceptions;

namespace ShoppingCart.Bussiness.Implementation.Articles
{
    public class UploadArticlePhotoHandler
        : IUploadArticlePhotoInputPort
    {
        private readonly Cloudinary cloudinary;

        public UploadArticlePhotoHandler(IConfiguration configuration)
        {

            Account account = new Account(configuration["Cloudinary:Cloud"],
                                      configuration["Cloudinary:ApiKey"],
                                      configuration["Cloudinary:Secret"]);

            cloudinary = new Cloudinary(account);
        }

        public async Task<string> Handle(IFormFile dto)
        {

            ImageUploadParams Upload = new ImageUploadParams()
            {
                File = new FileDescription(dto.Name, dto.OpenReadStream()),
                Folder = "Products"
            };

            var Response = await cloudinary.UploadAsync(Upload);

            if (Response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new GeneralException("Upload image failed");
            }

            return Response.SecureUrl.AbsoluteUri;
        }
    }
}
