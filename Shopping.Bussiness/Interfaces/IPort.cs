namespace ShoppingCart.Bussiness.Interfaces
{
    public interface IPort<T>
    {
        Task Handle(T dto);
    }

    public interface IPort<T, R>
    {
        Task<R> Handle(T dto);
    }

    public interface ISingleIport<R>
    {
        Task<R> Handle();
    }


}
