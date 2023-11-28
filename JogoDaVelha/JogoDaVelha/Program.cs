using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JogoDaVelha;

namespace JogoDaVelha
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool jogarNovamente;
            do
            {
                Console.Write("Digite o nome do Jogador 1: ");
                string nomeJogador1 = Console.ReadLine();
                Console.Write("Digite o nome do Jogador 2: ");
                string nomeJogador2 = Console.ReadLine();

                Console.WriteLine();

                JogoDaVelha.Game jogo = new JogoDaVelha.Game(nomeJogador1, nomeJogador2);
                jogo.IniciarJogo();

                Console.WriteLine("Obrigado por jogar!");

                Console.Write("Deseja jogar novamente? (S/N): ");
                string resposta = Console.ReadLine();
                jogarNovamente = (resposta.Equals("S", StringComparison.OrdinalIgnoreCase));

            } while (jogarNovamente);
        }
    }
}