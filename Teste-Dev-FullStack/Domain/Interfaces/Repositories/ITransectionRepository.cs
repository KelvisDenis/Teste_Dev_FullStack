using Teste_Dev_FullStack.Domain.Entities;

namespace Teste_Dev_FullStack.Domain.Interfaces.Repositories
{
    public interface ITransectionRepository:IGenericRepository<Transection>
    {
        Task<IEnumerable<Transection>> GetByPersonIdAsync(Guid personId);
        Task<bool> HasTransacoesAsync(Guid personId);
        Task DeleteByPersonIdAsync(Guid personId);
    }
}
