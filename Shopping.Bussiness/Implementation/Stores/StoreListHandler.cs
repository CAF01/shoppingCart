using ShoppingCart.Bussiness.Interfaces.Stores;
using ShoppingCart.Entitys.DTOs.Stores;
using ShoppingCart.Entitys.Interfaces.Stores;

namespace ShoppingCart.Bussiness.Implementation.Stores
{
    public class StoreListHandler
        : IStoreListInputPort
    {
        private readonly IStoreListRepository storeListRepository;

        public StoreListHandler(IStoreListRepository storeListRepository)
        {
            this.storeListRepository = storeListRepository;
        }

        public Task<IEnumerable<StoreListDTO>> Handle()
        {
            return storeListRepository.GetStoresAsync();
        }
    }
}
