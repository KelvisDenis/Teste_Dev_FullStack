using Teste_Dev_FullStack.Domain.Erros;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Teste_Dev_FullStack.Domain.ResultPattern
{
    public abstract class ResultBase : IResult
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public GeneralExcept Error { get; }

        protected ResultBase(bool isSuccess, GeneralExcept error)
        {
            IsSuccess = isSuccess;
            Error = error;
        }
    }

}
