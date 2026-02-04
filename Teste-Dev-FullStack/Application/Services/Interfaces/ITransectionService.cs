using Teste_Dev_FullStack.Application.DTOs;
using Teste_Dev_FullStack.Domain.ResultPattern;

namespace Teste_Dev_FullStack.Application.Services.Interfaces
{
    public interface ITransectionService
    {
        Task<Result<TransectionDto>> CreateAsync(CreateTransectionDto dto);
        Task<Result<IEnumerable<TransectionDto>>> GetAllAsync();
    }
}
