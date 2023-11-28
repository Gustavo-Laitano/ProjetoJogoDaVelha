using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    public class Game
    {
        private char[] tabuleiro;
        private Player jogador1, jogador2;
        private Player jogadorAtual;
        private bool jogoAcabou;

        public Game(string nomeJogador1, string nomeJogador2)
        {
            tabuleiro = new char[9] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            jogador1 = new Player(nomeJogador1, 'X');
            jogador2 = new Player(nomeJogador2, '0');
            jogadorAtual = jogador1;
            jogoAcabou = false;
        }

        public void IniciarJogo()
        {
            Console.WriteLine("Bem vindo ao Jogo da Velha!");
            ExibirTabuleiro();

            while (!jogoAcabou)
            {
                int escolha = jogadorAtual.FazerJogada();
                if (EscolhaValida(escolha))
                {
                    FazerJogada(escolha);
                    ExibirTabuleiro();
                    if (VerificarVitoria() || TabuleiroCheio())
                    {
                        TerminarJogo();
                    }
                    else
                    {
                        jogadorAtual = (jogadorAtual == jogador1) ? jogador2 : jogador1;
                    }
                }
                else
                {
                    Console.WriteLine("Posição inválida. Tente novamente");
                }
            }
        }

        private void ExibirTabuleiro()
        {
            Console.WriteLine($" {tabuleiro[0]} | {tabuleiro[1]} | {tabuleiro[2]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {tabuleiro[3]} | {tabuleiro[4]} | {tabuleiro[5]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {tabuleiro[6]} | {tabuleiro[7]} | {tabuleiro[8]} ");
            Console.WriteLine();
        }

        private bool EscolhaValida(int escolha)
        {
            return escolha >= 1 && escolha <= 9 && tabuleiro[escolha - 1] != 'X' && tabuleiro[escolha - 1] != 'O';
        }

        private void FazerJogada(int escolha)
        {
            tabuleiro[escolha - 1] = jogadorAtual.Marcador;
        }

        private bool VerificarVitoria()
        {
            for (int i = 0; i < 3; i++)
            {
                int linha = i * 3;
                if (tabuleiro[linha] == tabuleiro[linha + 1] && tabuleiro[linha] == tabuleiro[linha + 2])
                {
                    return true;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (tabuleiro[i] == tabuleiro[i + 3] && tabuleiro[i] == tabuleiro[i + 6])
                {
                    return true;
                }
            }

            if ((tabuleiro[0] == tabuleiro[4] && tabuleiro[0] == tabuleiro[8]) || (tabuleiro[2] == tabuleiro[4] && tabuleiro[2] == tabuleiro[6]))
            {
                return true;
            }
            return false;
        }

        private bool TabuleiroCheio()
        {
            return !Array.Exists(tabuleiro, celula => celula != 'X' && celula != 'O');
        }

        private void TerminarJogo()
        {
            ExibirTabuleiro();
            if (VerificarVitoria())
            {
                Console.WriteLine($"{jogadorAtual.Nome} venceu! Parabéns pela vitória!");
            }
            else
            {
                Console.WriteLine("O jogo terminou empatado!");
            }

            jogoAcabou = true;
        }
    }
}
