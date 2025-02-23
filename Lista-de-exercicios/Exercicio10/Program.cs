using System;

namespace Exercicio10
{
    class Program
    {
        public static void Main()
        {
            CarrinhoDeCompras carrinho = new CarrinhoDeCompras();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("========== Carrinho de Compras ==========");
                Console.WriteLine("1 - Adicionar produto ao carrinho");
                Console.WriteLine("2 - Calcular valor total");
                Console.WriteLine("3 - Exibir itens do carrinho");
                Console.WriteLine("4 - Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Digite o nome do produto: ");
                        string nome = Console.ReadLine();
                        Console.Write("Digite o preço do produto: ");
                        double preco;
                        while (!double.TryParse(Console.ReadLine(), out preco) || preco < 0)
                        {
                            Console.Write("Preço inválido! Digite novamente: ");
                        }
                        carrinho.AdicionarProduto(nome, preco);
                        break;

                    case "2":
                        Console.Clear();
                        carrinho.CalcularValorTotal();
                        break;

                    case "3":
                        Console.Clear();
                        carrinho.ExibirItens();
                        break;

                    case "4":
                        Console.WriteLine("Saindo...");
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }

    public class CarrinhoDeCompras
    {
        private string[] nomesProdutos;
        private double[] precos;
        private int quantidadeItens;

        public CarrinhoDeCompras()
        {
            nomesProdutos = new string[10];
            precos = new double[10];
            quantidadeItens = 0;
        }

        public void AdicionarProduto(string nome, double preco)
        {
            if (quantidadeItens < nomesProdutos.Length)
            {
                nomesProdutos[quantidadeItens] = nome;
                precos[quantidadeItens] = preco;
                quantidadeItens++;
                Console.WriteLine($"Produto '{nome}' (R$ {preco}) adicionado ao carrinho!");
            }
            else
            {
                Console.WriteLine("O carrinho está cheio!");
            }
        }

        public void CalcularValorTotal()
        {
            double total = 0;
            for (int i = 0; i < quantidadeItens; i++)
            {
                total += precos[i];
            }
            Console.WriteLine($"Valor total da compra: R$ {total:F2}");
        }

        public void ExibirItens()
        {
            if (quantidadeItens == 0)
            {
                Console.WriteLine("O carrinho está vazio!");
            }
            else
            {
                Console.WriteLine("Itens no carrinho:");
                for (int i = 0; i < quantidadeItens; i++)
                {
                    Console.WriteLine($"{i + 1}. {nomesProdutos[i]} - R$ {precos[i]:F2}");
                }
            }
        }
    }
}