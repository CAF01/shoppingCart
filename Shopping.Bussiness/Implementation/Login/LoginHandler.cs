using FluentValidation;
using hoppingCart.Bussiness.Helpers;
using ShoppingCart.Bussiness.Helpers;
using ShoppingCart.Bussiness.Interfaces.Account;
using ShoppingCart.Entitys.DTOs.Account;
using ShoppingCart.Entitys.Exceptions;
using ShoppingCart.Entitys.Interfaces;
using ShoppingCart.Entitys.Interfaces.Account;

namespace ShoppingCart.Bussiness.Implementation.Login
{
    public class LoginHandler
        : ILoginInputPort
    {
        private readonly IFindClientByEmail findClientByEmail;
        private readonly IAuthenticationManager jwtService;
        private readonly IEnumerable<IValidator<LoginDTO>> validators;

        public LoginHandler(IFindClientByEmail findClientByEmail,
                            IAuthenticationManager jwtService,
                            IEnumerable<IValidator<LoginDTO>> validators)
        {
            this.findClientByEmail = findClientByEmail;
            this.jwtService = jwtService;
            this.validators = validators;
        }

        public async Task<LoginResponseDTO> Handle(LoginDTO dto)
        {
            Validator<LoginDTO>.Validate(dto, validators);

            var Account = await findClientByEmail.GetClientByEmailAsync(dto.Email);

            if(!Utils.CompareHash(dto.Password, Account.Password))
            {
                throw new GeneralException("Email or Password no valid.");
            }

            var Response = new LoginResponseDTO
            {
                FullName = $"{Account.Name} {Account.LastName}",
                Email = dto.Email,
                Token = jwtService.GetTokenAsync(dto.Email),
                IdClient = Account.IdClient
            };

            return Response;

        }
    }
}
