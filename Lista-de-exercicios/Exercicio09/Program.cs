using System;

namespace Exercicio09
{
    class Program
    {
        public static void Main()
        {
            bool continuar = true;
            Agenda agenda = new Agenda(); 
            while (continuar)
            {
                Console.WriteLine("========== Agenda - Menu Principal ==========");
                Console.WriteLine("1 - Adicionar contato na agenda");
                Console.WriteLine("2 - Remover contato da agenda"); 
                Console.WriteLine("3 - Buscar contato por nome");   
                Console.WriteLine("4 - Exibir todos os contatos");   
                Console.WriteLine("5 - Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        Console.Write("Digite o nome do contato: ");
                        agenda.AdicionarContato(); 
                        break;

                    case "2":
                        Console.Clear();
                        Console.Write("Digite o ID do contato a remover: ");
                        try
                        {
                            int idRemover = int.Parse(Console.ReadLine());
                            agenda.RemoverContato(idRemover);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("ID inválido! Digite um número.");
                        }
                        break;

                    case "3":
                        Console.Clear();
                        Console.Write("Digite o nome do contato a buscar: ");
                        string nomeBusca = Console.ReadLine();
                        agenda.BuscarContatoPorNome(nomeBusca);
                        break;

                    case "4":
                        Console.Clear();
                        agenda.ExibirContatos();
                        break;

                    case "5":
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

    public class Agenda
    {
        public string[] Contatos;
        private Random random = new Random();
        public int[] IdContato;
        private int posicaoAtual = 0;

        public Agenda()
        {
            Contatos = new string[10]; 
            IdContato = new int[10];
        }

        public void AdicionarContato()
        {
            if (posicaoAtual < Contatos.Length)
            {
                string nome = Console.ReadLine();
                Contatos[posicaoAtual] = nome;
                IdContato[posicaoAtual] = random.Next(1, 10001);
                Console.WriteLine($"Contato '{nome}' adicionado com ID {IdContato[posicaoAtual]}!");
                posicaoAtual++;
            }
            else
            {
                Console.WriteLine("Agenda cheia! Não é possível adicionar mais contatos.");
            }
        }

        public void RemoverContato(int id)
        {
            for (int i = 0; i < posicaoAtual; i++)
            {
                if (IdContato[i] == id)
                {
                   
                    Console.WriteLine($"Removendo contato: {Contatos[i]} (ID: {IdContato[i]})");
                   
                    for (int j = i; j < posicaoAtual - 1; j++)
                    {
                        Contatos[j] = Contatos[j + 1];
                        IdContato[j] = IdContato[j + 1];
                    }
                    // Limpar a última posição
                    Contatos[posicaoAtual - 1] = null;
                    IdContato[posicaoAtual - 1] = 0;
                    posicaoAtual--;
                    return;
                }
            }
            Console.WriteLine($"Contato com ID {id} não encontrado!");
        }

        public void BuscarContatoPorNome(string nome)
        {
            bool encontrado = false;
            for (int i = 0; i < posicaoAtual; i++)
            {
                if (Contatos[i] != null && Contatos[i].Equals(nome, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Contato encontrado: {Contatos[i]} (ID: {IdContato[i]})");
                    encontrado = true;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine($"Nenhum contato com o nome '{nome}' encontrado!");
            }
        }

        public void ExibirContatos()
        {
            if (posicaoAtual == 0)
            {
                Console.WriteLine("A agenda está vazia!");
            }
            else
            {
                Console.WriteLine("Contatos na agenda:");
                for (int i = 0; i < posicaoAtual; i++)
                {
                    Console.WriteLine($"{i + 1}. {Contatos[i]} (ID: {IdContato[i]})");
                }
            }
        }
    }
}