using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Bussiness.Interfaces.Stores;
using ShoppingCart.Entitys.DTOs.Stores;

namespace ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StoreController : ControllerBase
    {
        private readonly ICreateStoreInputPort createStoreInputPort;
        private readonly IStoreListInputPort storeListInputPort;

        public StoreController(ICreateStoreInputPort createStoreInputPort,
            IStoreListInputPort storeListInputPort)
        {
            this.createStoreInputPort = createStoreInputPort;
            this.storeListInputPort = storeListInputPort;
        }

        [HttpGet]
        public Task<IEnumerable<StoreListDTO>> Get()
        {
            return storeListInputPort.Handle();
        }

        [HttpPost]
        public async Task<int>Create(CreateStoreDTO store)
        {
            var Response=await createStoreInputPort.Handle(store);

            return Response;
        }

    }
}
