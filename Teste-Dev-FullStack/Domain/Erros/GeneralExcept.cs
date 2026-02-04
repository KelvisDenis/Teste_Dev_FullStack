using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Teste_Dev_FullStack.Domain.Erros
{
    public class GeneralExcept: Exception
    {
        public string Code { get; }
        public string Message { get; }

        private GeneralExcept(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public static GeneralExcept None => new("", "");

        public static GeneralExcept Validation(string message) =>
            new("VALIDATION_ERROR", message);

        public static GeneralExcept NotFound(string message) =>
            new("NOT_FOUND", message);

        public static GeneralExcept Conflict(string message) =>
            new("CONFLICT", message);

        public static GeneralExcept Unexpected(string message) =>
            new("UNEXPECTED_ERROR", message);
    }
}
