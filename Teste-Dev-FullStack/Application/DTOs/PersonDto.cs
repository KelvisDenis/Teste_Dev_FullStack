namespace Teste_Dev_FullStack.Application.DTOs
{
    public record CreatePersonDto(string Name,int Age);
    public record PersonDto(Guid Id,string Name,int Age);
    public record PersonTotalsDto(Guid PersonId, string Name, decimal TotalIncome, decimal TotalExpense, decimal TotalBalance);

}
