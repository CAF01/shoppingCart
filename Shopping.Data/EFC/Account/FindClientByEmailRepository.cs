using Microsoft.EntityFrameworkCore;
using ShoppingCart.Data.EFC.DataContext;
using ShoppingCart.Entitys.Exceptions;
using ShoppingCart.Entitys.Interfaces.Account;
using ShoppingCart.Entitys.POCOs;

namespace ShoppingCart.Data.EFC.Account
{
    public class FindClientByEmailRepository
        : IFindClientByEmail
    {
        private readonly ShoppingCartContext context;

        public FindClientByEmailRepository(ShoppingCartContext context)
        {
            this.context = context;
        }

        public async Task<Client> GetClientByEmailAsync(string email)
        {
            Client client = await context.Clients.FirstOrDefaultAsync(usr => usr.Email == email);

            if (client == null)
            {
                throw new GeneralException("The email account does not exist.");
            }

            return client;
        }
    }
}
