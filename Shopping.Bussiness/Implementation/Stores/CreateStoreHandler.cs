using ShoppingCart.Bussiness.Interfaces.Stores;
using ShoppingCart.Entitys.DTOs.Stores;
using ShoppingCart.Entitys.Interfaces;
using ShoppingCart.Entitys.Interfaces.Stores;

namespace ShoppingCart.Bussiness.Implementation.Stores
{
    public class CreateStoreHandler
        : ICreateStoreInputPort
    {
        private readonly ICreateStoreRepository createStoreRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateStoreHandler(
                                   ICreateStoreRepository createStoreRepository,
                                   IUnitOfWork unitOfWork)
        {
            this.createStoreRepository = createStoreRepository;
            this.unitOfWork = unitOfWork;
        }


        public async Task<int> Handle(CreateStoreDTO dto)
        {
           var NewStore=createStoreRepository.CreateStore(dto);

            await unitOfWork.SaveChangesAsync();

            return NewStore.IdStore;
        }
    }
}
