using System;

namespace CalculadoraApp
{
    public class Calculadora
    {
        public int Num1 { get; set; }
        public int Num2 { get; set; }

        // Método para somar
        public int Soma()
        {
            return Num1 + Num2;
        }

        // Método para subtrair
        public int Subtracao()
        {
            return Num1 - Num2;
        }

        // Método para dividir
        public int Divisao()
        {
            if (Num2 == 0)
            {
                throw new DivideByZeroException("Não é possível dividir por zero.");
            }
            return Num1 / Num2;
        }

        // Método para multiplicar
        public int Multiplicacao()
        {
            return Num1 * Num2;
        }
    }

    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Programa iniciado. Aguardando entrada..."); // Log de depuração

            Calculadora calculadora = new Calculadora();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("===Calculadora===\n");
                Console.WriteLine("1- Soma");
                Console.WriteLine("2- Subtração");
                Console.WriteLine("3- Divisão");
                Console.WriteLine("4- Multiplicação");
                Console.WriteLine("5- Sair");

                Console.Write("\nEscolha uma opção: ");
                int escolha;

                // Verifica se a entrada é válida
                if (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > 5)
                {
                    Console.WriteLine("Erro: opção inválida. Tente novamente.");
                    Console.ReadKey();
                    continue;
                }

                // Sair do programa
                if (escolha == 5)
                {
                    break;
                }

                // Solicita os números ao usuário
                Console.Write("Digite o primeiro número: ");
                calculadora.Num1 = int.Parse(Console.ReadLine());

                Console.Write("Digite o segundo número: ");
                calculadora.Num2 = int.Parse(Console.ReadLine());

                // Executa a operação escolhida
                try
                {
                    int resultado = 0;
                    switch (escolha)
                    {
                        case 1:
                            resultado = calculadora.Soma();
                            Console.WriteLine($"\nResultado da soma: {resultado}");
                            break;
                        case 2:
                            resultado = calculadora.Subtracao();
                            Console.WriteLine($"\nResultado da subtração: {resultado}");
                            break;
                        case 3:
                            resultado = calculadora.Divisao();
                            Console.WriteLine($"\nResultado da divisão: {resultado}");
                            break;
                        case 4:
                            resultado = calculadora.Multiplicacao();
                            Console.WriteLine($"\nResultado da multiplicação: {resultado}");
                            break;
                    }
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"\nErro: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nErro inesperado: {ex.Message}");
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}