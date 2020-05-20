using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace TestDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Seja bem vindo!!!");
            ReadFile();
            GetOperations();
            GetUserInput();
        }

        public static void GetOperations()
        {
            Console.WriteLine("");
            Console.WriteLine("Operações permitidas:");
            Console.WriteLine("Soma");
            Console.WriteLine("Subtração");
            Console.WriteLine("Multiplicação");
            Console.WriteLine("Divisão");
            Console.WriteLine("Média");
            Console.WriteLine("Somar números pares");
            Console.WriteLine("");
            Console.WriteLine("Informe o nome da operação desejada e os valores separados por ';' e pressione Enter.");
            Console.WriteLine("Exemplo:Soma;1;1");
            Console.WriteLine("");
        }

        public static void GetUserInput()
        {
            try
            {
                var userInput = Console.ReadLine();
                var operation = new Operation(userInput);
                operation.ExecuteOperation();
                Console.WriteLine($"Resultado: {operation.Result}");
                Console.WriteLine("");
                RestartMenu();
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
                RestartMenu();
            }
        }

        public static void RestartMenu()
        {
            Console.WriteLine("Pressione qualquer tecla para continuar ou ESC para sair");
            var input = Console.ReadKey(true);
            if (input.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("Obrigado por utilizar nossa calculadora");
                Thread.Sleep(2000);
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                GetOperations();
                GetUserInput();
            }
        }

        public static void ReadFile()
        {
            var fileDictionaryList = new List<FileDictionary>();
            var lines = File.ReadAllLines("../../../TestDotNet.txt");
            foreach (var line in lines)
            {
                if (line.Trim() != "")
                {
                    var inputs = line.Split(";");
                    var name = inputs[0];
                    var defaultInput = line.Substring(line.IndexOf(";") + 1);
                    var operation = new Operation(defaultInput);
                    operation.ExecuteOperation();
                    fileDictionaryList.Add(new FileDictionary()
                    {
                        Name = name,
                        Result = operation.Result
                    });
                }
            }

            foreach (var fileDictionary in fileDictionaryList)
                Console.WriteLine($"{fileDictionary.Name};{fileDictionary.Result}");
        }
    }
}
