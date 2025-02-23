using System;

namespace Exercicio06
{
    class Program
    {
        public static void Main()
        {
            Retangulo retangulo = new Retangulo();
            retangulo.CalcularArea(5, 8);
            retangulo.CalcularPerimetro(5, 8); 

            Console.ReadKey();
        }
    }

    public class Retangulo
    {
        
        public double Altura { get; set; }
        public double Lado { get; set; } 

        
        public Retangulo()
        {
            Altura = 0;
            Lado = 0;
        }

        
        public void CalcularArea(double altura, double lado)
        {
            double contaArea = altura * lado;
            Console.WriteLine($"A área do retângulo é {contaArea}");
        }

        
        public void CalcularPerimetro(double altura, double lado)
        {
            double contaPeri = 2 * altura + 2 * lado; 
            Console.WriteLine($"O perímetro do retângulo é {contaPeri}");
        }
    }
}