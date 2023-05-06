using Dapper;
using ShoppingCart.Entitys.DTOs.Stores;
using ShoppingCart.Entitys.Exceptions;
using ShoppingCart.Entitys.Interfaces.Stores;
using System.Data;

namespace ShoppingCart.Data.Dapper.Stores
{
    public class StoreListRepository
        : IStoreListRepository
    {
        private readonly IDbConnection connection;

        public StoreListRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public async Task<IEnumerable<StoreListDTO>> GetStoresAsync()
        {
            try
            {
                IEnumerable<StoreListDTO> Stores = Enumerable.Empty<StoreListDTO>();

                string Select = "SELECT IdStore,Branch,Address FROM [ShoppingCartDB].[dbo].[Stores]";

                Stores = await connection.QueryAsync<StoreListDTO>(
                   sql: Select,
                   commandType: CommandType.Text
                   );

                return Stores;
            }
            catch (Exception)
            {
                connection.Close();

                throw new GeneralException("Error Database");
            }
        }
    }
}
