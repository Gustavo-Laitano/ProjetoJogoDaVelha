using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaVelha
{
    public class Player
    {
        public string Nome { get; set; }
        public char Marcador { get; set; } 

        public Player(string nome, char marcador)
        {
            Nome = nome;
            Marcador = marcador;
        }

        public int FazerJogada()
        {
            Console.Write($"{Nome}, é a sua vez de jogar. Escolha uma posição (1-9: ");
            if(int.TryParse(Console.ReadLine(), out int escolha))
            {
                return escolha;
            }
            else
            {
                Console.WriteLine("Entrada inválida. Tente novamente.");
                return FazerJogada();
            }
        }
    }
}
