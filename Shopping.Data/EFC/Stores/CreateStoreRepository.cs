using ShoppingCart.Data.EFC.DataContext;
using ShoppingCart.Entitys.DTOs.Stores;
using ShoppingCart.Entitys.Interfaces.Stores;
using ShoppingCart.Entitys.POCOs;

namespace ShoppingCart.Data.EFC.Stores
{
    public class CreateStoreRepository
        : ICreateStoreRepository
    {
        private readonly ShoppingCartContext context;

        public CreateStoreRepository(ShoppingCartContext context)
        {
            this.context = context;
        }

        public Store CreateStore(CreateStoreDTO store)
        {
            Store NewStore = new Store
            {
                Branch = store.Branch,
                Address = store.Address
            };

            context.Stores.Add(NewStore);

            return NewStore;
        }
    }
}
