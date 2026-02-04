using Teste_Dev_FullStack.Application.DTOs;
using Teste_Dev_FullStack.Domain.ResultPattern;

namespace Teste_Dev_FullStack.Application.Services.Interfaces
{
    public interface IPersonService
    {
        Task<Result<PersonDto>> CreateAsync(CreatePersonDto dto);
        Task<Result<IEnumerable<PersonDto>>> GetAllAsync();
        Task<Result<bool>> DeleteAsync(Guid id);
    }

}
