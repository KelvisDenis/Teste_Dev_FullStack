using Teste_Dev_FullStack.Domain.Entities;

namespace Teste_Dev_FullStack.Domain.Interfaces.Repositories
{
    public interface IPersonRepository: IGenericRepository<Person>
    {
        Task<bool> HasTransacoesAsync(Guid personId);
    }
}
