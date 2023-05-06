using ShoppingCart.Data.EFC.DataContext;
using ShoppingCart.Entitys.DTOs.Users;
using ShoppingCart.Entitys.Interfaces.Users;
using ShoppingCart.Entitys.POCOs;

namespace ShoppingCart.Data.EFC.Clients
{
    public class CreateClientRepository
        : ICreateClientRepository
    {
        private readonly ShoppingCartContext context;

        public CreateClientRepository(ShoppingCartContext context)
        {
            this.context = context;
        }

        public Client Create(CreateClientDTO user)
        {
            Client NewClient = new Client
            {
                Name = user.Name,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                Password = user.Password
            };

            context.Clients.Add(NewClient);

            return NewClient;
        }
    }
}
