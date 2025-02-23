using System;

namespace Exercicio05
{
    class Program
    {
        public static void Main()
        {
            Livro livro = new Livro("Livro de Romance", 5); 
            livro.VerificarDisponibilidade();               
            livro.RealizarEmprestimo();                    
            livro.VerificarDisponibilidade();              
            Console.ReadKey();
        }
    }

    class Livro
    {
        
        private bool emprestimo;    
        private int quantidade;     
        private string nomeLivro;   

        
        public bool Emprestimo { get { return emprestimo; } }   
        public int Quantidade { get { return quantidade; } }    
        public string NomeLivro { get { return nomeLivro; } }   

        // Construtor
        public Livro(string nome, int qtdInicial)
        {
            nomeLivro = nome;
            quantidade = qtdInicial;
            emprestimo = false; 
        }

        
        public void VerificarDisponibilidade()
        {
            if (quantidade > 0)
            {
                Console.WriteLine($"O livro '{nomeLivro}' está disponível para empréstimo! Quantidade: {quantidade}");
            }
            else
            {
                Console.WriteLine($"O livro '{nomeLivro}' não está disponível para empréstimo!");
            }
        }

       
        public void RealizarEmprestimo()
        {
            if (quantidade > 0)
            {
                quantidade--;          
                emprestimo = true; 
                Console.WriteLine($"Empréstimo do livro '{nomeLivro}' realizado com sucesso! Restam: {quantidade}");
            }
            else
            {
                Console.WriteLine($"Não há exemplares de '{nomeLivro}' disponíveis para empréstimo!");
            }
        }
    }
}