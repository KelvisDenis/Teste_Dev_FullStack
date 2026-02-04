namespace Teste_Dev_FullStack.Infraestructure.UnityOfWork
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
        Task RoolbackAsync();
    }
}
