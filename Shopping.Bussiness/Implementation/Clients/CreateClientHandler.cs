using FluentValidation;
using hoppingCart.Bussiness.Helpers;
using ShoppingCart.Bussiness.Helpers;
using ShoppingCart.Bussiness.Interfaces.Clients;
using ShoppingCart.Entitys.DTOs.Users;
using ShoppingCart.Entitys.Interfaces;
using ShoppingCart.Entitys.Interfaces.Users;
using ShoppingCart.Entitys.POCOs;

namespace ShoppingCart.Bussiness.Implementation.Clients
{
    public class CreateClientHandler
        : ICreateClientInputPort
    {
        private readonly ICreateClientRepository createClient;
        private readonly IUnitOfWork unitOfWork;
        private readonly IEnumerable<IValidator<CreateClientDTO>> validators;

        public CreateClientHandler(
            ICreateClientRepository createClient,
            IUnitOfWork unitOfWork,
            IEnumerable<IValidator<CreateClientDTO>> validators)
        {
            this.createClient = createClient;
            this.unitOfWork = unitOfWork;
            this.validators = validators;
        }

        public async Task<int> Handle(CreateClientDTO dto)
        {
            Validator<CreateClientDTO>.Validate(dto, validators);

            dto.Password = Utils.GenerateHash(dto.Password);

            Client NewUser = createClient.Create(dto);

            await unitOfWork.SaveChangesAsync();

            return NewUser.IdClient;
        }
    }
}
