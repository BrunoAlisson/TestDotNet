using System;

namespace TestDotNet
{
    public class CustomFormatException : FormatException
    {
        public CustomFormatException(string value) : base($"O valor informado é inválido: {value}")
        {
        }
    }

    public class InvalidOperationException : FormatException
    {
        public InvalidOperationException(string value) : base($"A operação selecionada é inválida: {value}")
        {
        }
    }

    public class ZeroDivisionException : FormatException
    {
        public ZeroDivisionException() : base("Divisão por zero")
        {
        }
    }

    public class InvalidParametersException : FormatException
    {
        public InvalidParametersException() : base("Parâmetros inválidos.")
        {
        }
    }
}
