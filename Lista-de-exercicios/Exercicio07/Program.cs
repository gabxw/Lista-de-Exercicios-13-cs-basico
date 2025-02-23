using System;

namespace Exercicio02
{
    public class Program
    {
        public static void Main()
        {
            Banco minhaConta = new Banco();
            bool continuar = true;

            while (continuar)
            {
                Console.WriteLine("========== Banco - Menu Principal ==========");
                Console.WriteLine("1 - Abrir Conta");
                Console.WriteLine("2 - Depositar");
                Console.WriteLine("3 - Sacar");
                Console.WriteLine("4 - Fechar Conta");
                Console.WriteLine("5 - Ver Saldo e ID");
                Console.WriteLine("6 - Sair");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        minhaConta.AbrirConta();
                        Console.WriteLine("========== Conta Aberta ==========");
                        Console.WriteLine($"ID da conta: {minhaConta.NumeroConta}");
                        Console.WriteLine($"Saldo: {minhaConta.Saldo}");
                        break;

                    case "2":
                        Console.Write("Digite o valor para depositar: ");
                        double valorDeposito = double.Parse(Console.ReadLine());
                        minhaConta.Depositar(valorDeposito);
                        Console.WriteLine($"Novo saldo: {minhaConta.Saldo}");
                        break;

                    case "3":
                        Console.Write("Digite o valor para sacar: ");
                        double valorSaque = double.Parse(Console.ReadLine());
                        minhaConta.Sacar(valorSaque);
                        Console.WriteLine($"Novo saldo: {minhaConta.Saldo}");
                        break;

                    case "4":
                        minhaConta.FecharConta();
                        break;

                    case "5":
                        if (minhaConta.EstaAberta()) // Verifica se a conta está aberta
                        {
                            Console.WriteLine($"ID da conta: {minhaConta.NumeroConta}");
                            Console.WriteLine($"Saldo: {minhaConta.Saldo}");
                        }
                        else
                        {
                            Console.WriteLine("A conta não está aberta! Abra uma conta primeiro.");
                        }
                        break;

                    case "6":
                        Console.WriteLine("Finalizando sessão...");
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

    public class Banco
    {
        // Atributos
        public double Saldo { get; private set; }
        private bool estaAberta; // Note que mudei para minúsculo por convenção
        public int NumeroConta { get; private set; }

        // Construtor
        public Banco()
        {
            Saldo = 0.0;
            estaAberta = false;
            Random random = new Random();
            NumeroConta = random.Next(1000, 9999);
        }

        // Método para verificar se a conta está aberta
        public bool EstaAberta()
        {
            return estaAberta;
        }

        // Métodos
        public void AbrirConta()
        {
            if (!estaAberta)
            {
                estaAberta = true;
                Console.WriteLine("Conta aberta com sucesso!");
            }
            else
            {
                Console.WriteLine("A conta já está aberta!");
            }
        }

        public void Depositar(double valor)
        {
            if (estaAberta && valor > 0)
            {
                Saldo += valor;
                Console.WriteLine("Depósito realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Não foi possível depositar. Verifique se a conta está aberta e o valor é válido.");
            }
        }

        public void Sacar(double valor)
        {
            if (estaAberta && valor > 0 && Saldo >= valor)
            {
                Saldo -= valor;
                Console.WriteLine("Saque realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Não foi possível sacar. Verifique saldo, valor ou estado da conta.");
            }
        }

        public void FecharConta()
        {
            if (estaAberta)
            {
                estaAberta = false;
                Console.WriteLine("Conta fechada com sucesso!");
            }
            else
            {
                Console.WriteLine("A conta já está fechada!");
            }
        }
    }
}