using Teste_Dev_FullStack.Domain.Enums;

namespace Teste_Dev_FullStack.Application.DTOs
{
    public record CreateTransectionDto(string Description,decimal Value,ETransectionType Type, Guid CategoryId, Guid PersonId);
    public record TransectionDto(Guid Id,string Description,decimal Value, ETransectionType Type,Guid CategoryId, Guid PersonId
);

}
