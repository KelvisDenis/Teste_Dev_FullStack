using Teste_Dev_FullStack.Domain.Erros;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Teste_Dev_FullStack.Domain.ResultPattern
{
    public sealed class Result<T> : ResultBase
    {
        public T? Value { get; }

        private Result(bool isSuccess, T? value, GeneralExcept error)
            : base(isSuccess, error)
        {
            Value = value;
        }

        public static Result<T> Success(T value)
            => new(true, value, GeneralExcept.None);

        public static Result<T> Failure(GeneralExcept error)
            => new(false, default, error);
    }


}
