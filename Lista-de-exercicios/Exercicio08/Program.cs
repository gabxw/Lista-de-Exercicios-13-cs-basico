using System;

namespace Exercicio08
{
    class Program
    {
        public static void Main()
        {
            Triangulo triangulo = new Triangulo(5, 5, 5);
            triangulo.EhEquilatero();
            triangulo.EhIsosceles();
            triangulo.EhEscaleno();

            Console.WriteLine("-----");

            Triangulo triangulo2 = new Triangulo(5, 5, 3);
            triangulo2.EhEquilatero();
            triangulo2.EhIsosceles();
            triangulo2.EhEscaleno();

            Console.WriteLine("-----");

            Triangulo triangulo3 = new Triangulo(3, 4, 5);
            triangulo3.EhEquilatero();
            triangulo3.EhIsosceles();
            triangulo3.EhEscaleno();

            Console.ReadKey();
        }
    }

    public class Triangulo
    {
        private double lado1;
        private double lado2;
        private double lado3;

        public Triangulo(double l1, double l2, double l3)
        {
            lado1 = l1;
            lado2 = l2;
            lado3 = l3;
        }

        public bool EhTrianguloValido()
        {
            return (lado1 + lado2 > lado3) &&
                   (lado2 + lado3 > lado1) &&
                   (lado1 + lado3 > lado2);
        }

        public void EhEquilatero()
        {
            if (!EhTrianguloValido())
            {
                Console.WriteLine("Os lados não formam um triângulo válido!");
                return;
            }
            if (lado1 == lado2 && lado2 == lado3)
            {
                Console.WriteLine("O triângulo é Equilátero!");
            }
            else
            {
                Console.WriteLine("O triângulo NÃO é Equilátero.");
            }
        }

        public void EhIsosceles()
        {
            if (!EhTrianguloValido())
            {
                Console.WriteLine("Os lados não formam um triângulo válido!");
                return;
            }
            if ((lado1 == lado2 && lado1 != lado3) ||
                (lado2 == lado3 && lado2 != lado1) ||
                (lado1 == lado3 && lado1 != lado2))
            {
                Console.WriteLine("O triângulo é Isósceles!");
            }
            else
            {
                Console.WriteLine("O triângulo NÃO é Isósceles.");
            }
        }

        public void EhEscaleno()
        {
            if (!EhTrianguloValido())
            {
                Console.WriteLine("Os lados não formam um triângulo válido!");
                return;
            }
            if (lado1 != lado2 && lado2 != lado3 && lado1 != lado3)
            {
                Console.WriteLine("O triângulo é Escaleno!");
            }
            else
            {
                Console.WriteLine("O triângulo NÃO é Escaleno.");
            }
        }
    }
}