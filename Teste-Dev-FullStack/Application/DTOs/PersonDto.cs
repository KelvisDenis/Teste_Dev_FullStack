namespace Teste_Dev_FullStack.Application.DTOs
{
    public record CreatePersonDto(string Name,int Age);
    public record PersonDto(Guid Id,string Name,int Age);


}
