using Teste_Dev_FullStack.Domain.Enums;

namespace Teste_Dev_FullStack.Application.DTOs
{
    public record CreateCategoryDto(Guid Id, string Description,EPurposeCategory Purpose);
    public record CategoryDto(Guid Id, string Description, EPurposeCategory Purpose);


}
