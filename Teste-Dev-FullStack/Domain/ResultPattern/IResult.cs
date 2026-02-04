using Teste_Dev_FullStack.Domain.Erros;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Teste_Dev_FullStack.Domain.ResultPattern
{
    public interface IResult
    {
        bool IsSuccess { get; }
        bool IsFailure { get; }
        GeneralExcept Error { get; }
    }

}
