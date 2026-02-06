using Teste_Dev_FullStack.Application.DTOs;
using Teste_Dev_FullStack.Domain.Entities;

namespace Teste_Dev_FullStack.Domain.Interfaces.Repositories
{
    public interface IPersonRepository: IGenericRepository<Person>
    {
        Task<IEnumerable<Person>> GetTotalsGroupedByPersonAsync();

    }
}
