using Dapper;
using ShoppingCart.Entitys.DTOs.Articles;
using ShoppingCart.Entitys.Exceptions;
using ShoppingCart.Entitys.Interfaces.Articles;
using System.Data;

namespace ShoppingCart.Data.Dapper.Articles
{
    public class ArticlesListRepository
        : IArticleListRepository
    {
        private readonly IDbConnection connection;

        public ArticlesListRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public Task<IEnumerable<ArticleDTO>> GetArticlesAsync(int storeId)
        {
            try
            {
                string QUERY = $"SELECT A.IdArticle,A.Code,A.[Description],A.Price,A.Stock,A.[Image],S.Branch " +
                               $"FROM [dbo].[RelArticlesInStore] REL  " +
                               $"INNER JOIN [ShoppingCartDB].[dbo].[Articles] AS A " +
                               $"ON REL.IdArticle = A.IdArticle " +
                               $"INNER JOIN [ShoppingCartDB].[dbo].[Stores] AS S " +
                               $"ON REL.IdStore = S.IdStore " +
                               $"WHERE REL.IdStore = @IdStore;";

                var parameters = new DynamicParameters();

                parameters.Add("@IdStore", storeId);

                return connection.QueryAsync<ArticleDTO>(
                                                    sql: QUERY,
                                                    param: parameters,
                                                    commandType: CommandType.Text);
            }
            catch (Exception ex)
            {
                throw new GeneralException(ex.Message);
            }
        }
    }
}
