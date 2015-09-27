using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JogodaForca
{
    class Word
    {
        //seta o que o usuario vai ver no lugar das letras da palavra

        const char WildCard = '_';

        //variavel que gerencia as letras da palavra do jogo

        char[] completeWordChars;

        //palavra parcial - apenas caracteres descobertos

        char[] partialWordChars;

        //palavra completa

        public string CompleteWord { get; private set; }


        //read only 
        public string PartialWord
        {
            get
            {
                //retorna palavra parcial
                return new string(partialWordChars);
            }
        }

        public bool Finished
        {
            get
            {
                //Verifica se o algoritmo acertou a palavra completa - comparando a palavra parcial com a completa
                return PartialWord == CompleteWord;
            }
        }

        //construtor da classe recebendo a palavra
        public Word(string InputedWord)
        {
            //pega a palavra digitada pelo usuario e armazena
            this.CompleteWord = InputedWord.ToUpper();

            //transforma esta palavra em chars para futura comparacao
            this.completeWordChars = this.CompleteWord.ToUpper().ToCharArray();

            //constroi a palavra parcial a ser exibida
            this.partialWordChars = new char[completeWordChars.Length];
            for (int i = 0; i < partialWordChars.Length; i++)
            {
                //monta o array de characteres, atentando-se aos espacos em branco em caso de palavra dupla
                if (completeWordChars[i] != ' ')
                {
                    partialWordChars[i] = WildCard;
                }
                else
                {
                    partialWordChars[i] = ' ';
                }
            }
        }

        //testa se a letra digitada eh encontrada
        public bool Guess(char letter, Robo robo)
        {
            bool found = false;
            List<int> posicoesLetraEncontrada = new List<int>();

            //converte para maiuscula

            letter = Char.ToUpper(letter);

            //Procura a letra na palavra
            for (int i = 0; i < completeWordChars.Length; i++)
            {
                //Se a letra for encontrada, precisa ser trocado o WildCard na palavra parcial
                //na mesma posicao da palavra completa
                if (completeWordChars[i] == letter)
                {
                    partialWordChars[i] = letter;
                    found = true;
                }
            }
            robo.Palavras = robo.VerificaPorLetra(partialWordChars);
            return found;
        }
    }
}
