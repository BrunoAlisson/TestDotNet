using System;
using System.Collections.Generic;

namespace TestDotNet
{
    public class Operation
    {
        public string Description { get; private set; }
        public List<float> Values { get; set; }
        public float Result { get; private set; }

        public Operation(string userInput)
        {
            var userInputList = userInput.Split(";");
            
            if (userInputList.Length < 3)
                throw new InvalidParametersException();

            Description = IsOperationValid(userInputList[0]);
            Values = new List<float>();

            for(var index = 1; index < userInputList.Length; index++)
            {
                Values.Add(IsValueValid(userInputList[index]));
            }
        }

        private float IsValueValid(string value)
        {
            try
            {
                return float.Parse(value);
            }
            catch(FormatException exception)
            {
                throw new CustomFormatException(value);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private string IsOperationValid(string value)
        {
            switch (value)
            {
                case "Soma":
                case "Subtração":
                case "Multiplicação":
                case "Divisão":
                case "Média":
                case "Somar números pares":
                    return value;
                default:
                    throw new InvalidOperationException(value);
            }
        }

        public void ExecuteOperation()
        {
            switch (Description)
            {
                case "Soma":
                    Result = Calculator.Sum(Values);
                    break;
                case "Subtração":
                    Result = Calculator.Subtract(Values[0], Values[1]);
                    break;
                case "Multiplicação":
                    Result = Calculator.Multiply(Values[0], Values[1]);
                    break;
                case "Divisão":
                    Result = Calculator.Divide(Values[0], Values[1]);
                    break;
                case "Média":
                    Result = Calculator.Average(Values);
                    break;
                case "Somar números pares":
                    Result = Calculator.SumOnlyEven(Values);
                    break;
            }
        }
    }
}
