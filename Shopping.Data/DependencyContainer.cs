using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShoppingCart.Data.Dapper.Articles;
using ShoppingCart.Data.Dapper.Stores;
using ShoppingCart.Data.EFC;
using ShoppingCart.Data.EFC.Account;
using ShoppingCart.Data.EFC.Articles;
using ShoppingCart.Data.EFC.Clients;
using ShoppingCart.Data.EFC.DataContext;
using ShoppingCart.Data.EFC.Stores;
using ShoppingCart.Entitys.Interfaces;
using ShoppingCart.Entitys.Interfaces.Account;
using ShoppingCart.Entitys.Interfaces.Articles;
using ShoppingCart.Entitys.Interfaces.Stores;
using ShoppingCart.Entitys.Interfaces.Users;
using System.Data;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddDatabaseProviders
            (this IServiceCollection services,
             IConfiguration configuration)
        {
            var ConnectionString = configuration.GetConnectionString("ShoppingCartDB");

            services.AddDbContext<ShoppingCartContext>(options =>
            {
                options.UseSqlServer(ConnectionString);
            });

            services.AddScoped<IDbConnection>(provider =>
                                    new SqlConnection(ConnectionString));


            //Clients
            services.AddScoped<ICreateClientRepository, CreateClientRepository>();

            //Account
            services.AddScoped<IFindClientByEmail, FindClientByEmailRepository>();

            //Store
            services.AddScoped<ICreateStoreRepository, CreateStoreRepository>();
            services.AddScoped<IStoreListRepository, StoreListRepository>();

            //Articles
            services.AddScoped<ICreateArticleRepository, CreateArticleRepository>();
            services.AddScoped<IArticleListRepository, ArticlesListRepository>();
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
