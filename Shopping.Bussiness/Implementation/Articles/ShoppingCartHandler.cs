using ShoppingCart.Bussiness.Interfaces.Articles;
using ShoppingCart.Entitys.DTOs.Articles;
using ShoppingCart.Entitys.Interfaces;
using ShoppingCart.Entitys.Interfaces.Articles;

namespace ShoppingCart.Bussiness.Implementation.Articles
{
    public class ShoppingCartHandler
        : IShoppingCartInputPort
    {
        private readonly IShoppingCartRepository shoppingCartRepository;
        private readonly IUnitOfWork unitOfWork;

        public ShoppingCartHandler(IShoppingCartRepository shoppingCartRepository,
                                   IUnitOfWork unitOfWork)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(List<ShoppingCartDTO> dto)
        {
            shoppingCartRepository.ShoppingCart(dto);

            int Result = await unitOfWork.SaveChangesAsync();

            return Result;

        }
    }
}
