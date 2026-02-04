using Teste_Dev_FullStack.Application.DTOs;
using Teste_Dev_FullStack.Domain.ResultPattern;

namespace Teste_Dev_FullStack.Application.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<Result<CategoryDto>> CreateAsync(CreateCategoryDto dto);
        Task<Result<IEnumerable<CategoryDto>>> GetAllAsync();
    }
}
