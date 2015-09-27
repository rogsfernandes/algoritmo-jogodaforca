using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace JogodaForca
{
    class Game
    {

        //propriedade de quantidade de erros permitidos no jogo
        int MaxErrors { get; set; }

        //construtor que recebe a quantidade de erros para o jogo a ser jogado
        public Game(int maxErrors)
        {
            this.MaxErrors = maxErrors;
        }

        //logica do jogo
        public void Play(string inputedWord)
        {
            //retira acentos
            string newWord = Robo.RemoveAcento(inputedWord);

            //instancia um objeto da classe algoritmo
            Robo myPC = new Robo(newWord);

            //
            Word w = new Word(newWord);

            while (true)
            {
                Console.WriteLine("---COMEÇOU o JOGO DA FORCA !!---\n");
                Console.WriteLine("O Robô poderá errar no máximo {0} vezes\n", MaxErrors);

                int errors = 0;

                //armazena as letras tentadas
                HashSet<char> triedLetters = new HashSet<char>();

                while (!w.Finished && errors < MaxErrors)
                {
                    //exibe a propriedade palavra parcial do objeto w da classe word
                    Console.WriteLine("___");
                    Console.WriteLine("|  |");
                    Console.WriteLine("|  O");
                    Console.WriteLine("|");
                    Console.WriteLine(w.PartialWord);
                    Console.WriteLine("Erros = {0}", errors);
                    Thread.Sleep(4000);
                    //roda a função do algoritmo que analisa a palavra a ser jogada
                    string letter = myPC.TryLetter().ToString();

                    //Solicita a letra
                    Console.WriteLine("O computador irá jogar uma letra...");
                    Thread.Sleep(2000);
                    Console.WriteLine("Letra jogada: {0}\n", letter);
                    Thread.Sleep(2000);

                    if (triedLetters.Contains(letter[0]))
                    {
                        Console.WriteLine("A letra {0} já foi jogada\n", letter);
                        continue;
                    }
                    else
                    {
                        triedLetters.Add(letter[0]);
                    }

                    bool found = w.Guess(letter[0], myPC);

                    if (found)
                    {
                        //Se encontrou, mostra a mensagem
                        Console.WriteLine("Robô: Parabéns pra mim! Encontrei uma letra!\n");
                    }
                    else
                    {
                        //se nao encontrou, aumenta os erros e exibe mensagem
                        errors++;
                        char c = Convert.ToChar(letter);
                        myPC.LetrasJogadasErradas.Add(c);
                        Console.WriteLine("Robô: Droga! Errei =/ \n");
                    }
                }

                //se o loop acabou, é porque o computador achou a palavra ou acabou suas tentativas

                string Option = null;

                //testa porque o loop acabou - pelo numero de erros ou por acerto do algoritmo
                if (errors < MaxErrors)
                {

                    //se acertou, exibe mensagem parabenizando
                    Console.WriteLine(@"\o/");
                    Console.WriteLine(@" |");
                    Console.WriteLine(@"/ \");
                    Console.WriteLine(w.PartialWord);
                    Console.WriteLine("Erros = {0}", errors);
                    Console.WriteLine("\nO Algoritmo conseguiu adivinhar a palavra({0})! =) \nDeseja testar o algoritmo novamente? (S/N) ", w.CompleteWord);
                    //recebe a opção do usuario
                    Option = Console.ReadLine();
                }
                else
                {
                    //se for por erros, exibe mensagem
                    myPC.VerificaSeConhecePalavra(w.CompleteWord);
                    Console.WriteLine("\nO algoritmo de análise não foi capaz de advinhar a palavra, que era: {0}. \nDeseja testar o algoritmo novamente? (S/N)", w.CompleteWord);
                    //recebe a opção do usuario
                    Option = Console.ReadLine();
                }


                if (Option.Length > 0 && (Option[0] == 's' || Option[0] == 'S'))
                {
                    Console.WriteLine("Ok, vamos testar novamente o Algoritmo!!");
                    Console.WriteLine("Digite uma nova palavra:");
                    string novaPalavra = Console.ReadLine();
                    Console.WriteLine("\nDigite quantas tentativas o Algoritmo vai ter para descobrir a palavra digitada: ");
                    int tentativas = Convert.ToInt32(Console.ReadLine());
                    Option = null;
                    Game game = new Game(tentativas);
                    game.Play(novaPalavra);
                }
                else
                {
                    Console.WriteLine("Até a próxima!!");
                    break;
                }
            }
        }
    }
}
