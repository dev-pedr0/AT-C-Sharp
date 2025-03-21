using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    private static void Main(string[] args)
    {
        bool repetir = true;
        while (repetir)
        {
            double num1 = double.NaN;
            double num2 = double.NaN;
            double resultado = double.NaN;

            int operacao = 0;
            int repetirOpcao = 0;

            bool isnum1 = false;
            bool isnum2 = false;
            bool operacaoValida = false;
            bool repetirValido = false;

            while (!isnum1)
            {
                Console.WriteLine("Digite o primeiro número:");
                string input = Console.ReadLine();

                if (double.TryParse(input, out num1))
                {
                    isnum1 = true;
                }
                else
                {
                    Console.WriteLine("Número inválido. Tente novamente.\n");
                }
            }

            Console.WriteLine("");

            while (!isnum2)
            {
                Console.WriteLine("Digite o segundo número:");
                string input = Console.ReadLine();

                if (double.TryParse(input, out num2))
                {
                    isnum2 = true;
                }
                else
                {
                    Console.WriteLine("Número inválido. Tente novamente.\n");
                }
            }

            Console.WriteLine("");

            while (!operacaoValida)
            {
                Console.WriteLine("Selecione o tipo de operação, digitando o número correspondente:");
                Console.WriteLine("1 - adição");
                Console.WriteLine("2 - subtração");
                Console.WriteLine("3 - multiplicação");
                Console.WriteLine("4 - divisão");
                string input = Console.ReadLine();

                if (int.TryParse(input, out operacao))
                {
                    if (operacao >= 1 && operacao <= 4)
                    {
                        operacaoValida = true;
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida. Tente novamente.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente.\n");
                }
            }

            Console.WriteLine("");

            switch (operacao)
            {
                case 1:
                    resultado = num1 + num2;
                    resultado = Math.Round(resultado, 2);
                    Console.WriteLine("A soma de " + num1 + " e " + num2 + "  é igual a " + resultado + ".");
                    break;
                case 2:
                    resultado = num1 - num2;
                    Console.WriteLine("A subtração de " + num1 + " e " + num2 + "  é igual a " + resultado + ".");
                    break;
                case 3:
                    resultado = num1 * num2;
                    Console.WriteLine("A multiplicação de " + num1 + " e " + num2 + "  é igual a " + resultado + ".");
                    break;
                case 4:
                    resultado = num1 % num2;
                    if (num2 == 0)
                    {
                        Console.WriteLine("Não é possível dividir por zero!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("A soma de " + num1 + " e " + num2 + "  é igual a " + resultado + ".");
                        break;
                    }
                default:
                    Console.WriteLine("Operação Falhou. Tente novamente.");
                    break;
            }

            while (!repetirValido)
            {
                Console.WriteLine("\nFazer outra operação?");
                Console.WriteLine("1 - Sim");
                Console.WriteLine("2 - Não");
                string input = Console.ReadLine();

                if (int.TryParse(input, out repetirOpcao))
                {
                    if (repetirOpcao >= 1 && repetirOpcao <= 2)
                    {
                        repetirValido = true;
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida. Tente novamente.");
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                }
            }

            if (repetirOpcao == 1)
            {
                repetir = true;
                Console.WriteLine("");
            }
            else
            {
                repetir = false;
            }
        }
        
    }
}