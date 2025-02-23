using System;

namespace Exercicio04
{
    class Program
    {
        public static void Main()
        {
            Aluno aluno = new Aluno("Gabriel"); 
            aluno.CalcularMedia();              
            Console.ReadKey();
        }
    }

    public class Aluno
    { 
        private double[] notas;         
        private string estudante;       
        private bool situacao;          


        public string Estudante { get { return estudante; } } 
        public bool Situacao { get { return situacao; } }  


        public Aluno(string nome)
        {
            estudante = nome;
            notas = new double[2];    
            notas[0] = 70.0;          
            notas[1] = 50.0;         
            situacao = false;         
        }

        
        public void CalcularMedia()
        {
            double soma = notas[0] + notas[1];
            double media = soma / notas.Length; 

            if (media >= 60.0) 
            {
                situacao = true;
                Console.WriteLine($"O estudante {estudante} está Aprovado com média {media}.");
            }
            else
            {
                situacao = false;
                Console.WriteLine($"O estudante {estudante} está Reprovado com média {media}.");
            }
        }
    }
}