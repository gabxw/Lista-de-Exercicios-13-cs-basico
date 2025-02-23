using System;

namespace Exercicio03
{
    class Program
    {
        public static void Main()
        {
            Produto produto = new Produto();
            produto.calculo();
            Console.ReadKey();
        }
    }

    public class Produto
    {
        private double Preco { get; set; }
        private double Quantidade { get; set; }

        public Produto()
        {
            Preco = 100.0;
            Quantidade = 5.0;
        }

        public void calculo()
        {
            if(Quantidade <= 10)
            {
                double escassez = Preco * 0.10;
                double novoPreco = Preco + escassez;
                Console.WriteLine($"O produto está em escassez, o preço é: {novoPreco}");
            }
            else
            {
                Console.WriteLine($"O produto custa: {Preco}");
            }
        }
    }
}