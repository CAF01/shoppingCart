using FluentValidation;
using ShoppingCart.Bussiness.Implementation.Articles;
using ShoppingCart.Bussiness.Implementation.Clients;
using ShoppingCart.Bussiness.Implementation.Login;
using ShoppingCart.Bussiness.Implementation.Stores;
using ShoppingCart.Bussiness.Interfaces.Account;
using ShoppingCart.Bussiness.Interfaces.Articles;
using ShoppingCart.Bussiness.Interfaces.Clients;
using ShoppingCart.Bussiness.Interfaces.Stores;
using ShoppingCart.Entitys.DTOs.Account;
using ShoppingCart.Entitys.DTOs.Articles;
using ShoppingCart.Entitys.DTOs.Users;
using ShoppingCart.Entitys.ValidatorsDTOs.Account;
using ShoppingCart.Entitys.ValidatorsDTOs.Articles;
using ShoppingCart.Entitys.ValidatorsDTOs.Clients;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddBussinessServices(
            this IServiceCollection services)
        {
            //Clients
            services.AddScoped<IValidator<CreateClientDTO>, CreateClientDTOValidator>();
            services.AddTransient<ICreateClientInputPort, CreateClientHandler>();

            //Account
            services.AddScoped<IValidator<LoginDTO>, LoginDTOValidator>();
            services.AddTransient<ILoginInputPort, LoginHandler>();

            //Store
            services.AddTransient<ICreateStoreInputPort, CreateStoreHandler>();
            services.AddTransient<IStoreListInputPort,StoreListHandler>();

            //Articles
            services.AddScoped<IValidator<CreateArticleDTO>, CreateArticleDTOValidator>();
            services.AddTransient<ICreateArticleInputPort, CreateArticleHandler>();

            services.AddTransient<IUploadArticlePhotoInputPort, UploadArticlePhotoHandler>();
            services.AddTransient<IArticleListInputPort, ArticleListHandler>();

            services.AddTransient<IShoppingCartInputPort, ShoppingCartHandler>();

            return services;
        }
    }
}
