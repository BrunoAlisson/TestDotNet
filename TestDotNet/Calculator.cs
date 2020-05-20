using System;
using System.Collections.Generic;
using System.Linq;

namespace TestDotNet
{
    public static class Calculator
    {
        public static float Sum(List<float> values)
        {
            try
            {
                float result = 0;

                foreach (var value in values)
                    result += value;

                return result;
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        public static float SumOnlyEven(List<float> values)
        {
            try
            {
                float result = 0;

                foreach (var value in values)
                    result += value % 2 == 0 ? value : 0;

                return result;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static float Subtract(float firstNumber, float secondNumber)
        {
            try
            {
                return firstNumber - secondNumber;
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        public static float Multiply(float firstNumber, float secondNumber)
        {
            try
            {
                return firstNumber * secondNumber;
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        public static float Divide(float firstNumber, float secondNumber)
        {
            try
            {
                if (secondNumber == 0)
                    throw new ZeroDivisionException();
                
                return firstNumber / secondNumber;
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        public static float Average(List<float> values)
        {
            try
            {
                return values.Average();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
