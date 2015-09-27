using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace JogodaForca
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FACULDADE DE TECNOLOGIA DA ZONA SUL\n");
            Console.WriteLine("ANÁLISE E DESENVOLVIMENTO DE SISTEMAS\n");
            Console.WriteLine("TRABALHO DE INTERLIGÊNCIA ARTIFICIAL\n");
            Console.WriteLine("***********************************");
            Console.WriteLine("Robô do Jogo da Forca");
            Console.WriteLine("Este algoritmo analisa a letra com maior probabilidade de existir na palavra que você digitar abaixo para tentar advinhar qual é esta palavra");
            Console.WriteLine("Digite a palavra que será usada no jogo: \n");
            string word = Console.ReadLine();
            Console.WriteLine("\nDigite quantas tentativas o Algoritmo vai ter para descobrir a palavra digitada: ");
            int tentativas = Convert.ToInt32(Console.ReadLine());
            Game game = new Game(tentativas);
            game.Play(word);
        }
    }
}
