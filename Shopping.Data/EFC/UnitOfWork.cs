using ShoppingCart.Data.EFC.DataContext;
using ShoppingCart.Entitys.Interfaces;

namespace ShoppingCart.Data.EFC
{
    public class UnitOfWork
        : IUnitOfWork
    {
        private readonly ShoppingCartContext context;

        public UnitOfWork(ShoppingCartContext context)
        {
            this.context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            int Result;

            try
            {
                Result = await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return Result;

        }
    }
}
