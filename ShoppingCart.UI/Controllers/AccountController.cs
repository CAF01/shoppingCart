using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Bussiness.Interfaces.Account;
using ShoppingCart.Bussiness.Interfaces.Clients;
using ShoppingCart.Entitys.DTOs.Account;
using ShoppingCart.Entitys.DTOs.Users;

namespace ShoppingCart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILoginInputPort loginInputPort;
        private readonly ICreateClientInputPort createClientInputPort;

        public AccountController(ILoginInputPort loginInputPort,
             ICreateClientInputPort createClientInputPort)
        {
            this.loginInputPort = loginInputPort;
            this.createClientInputPort = createClientInputPort;
        }

        [HttpPost("login")]
        public async Task<LoginResponseDTO> Login(LoginDTO info)
        {
            var Response = await loginInputPort.Handle(info);

            return Response;
        }

        [HttpPost]
        public async Task<int> CreateClient(CreateClientDTO client)
        {
            var Response = await createClientInputPort.Handle(client);

            return Response;
        }

    }
}
