using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace JogodaForca
{
    class Robo
    {
        #region atributos
        //struct utilizado para rankear as letras e quantas vezes elas aparecem no conjunto de palavras analisadas
        string palavra { get; set; }

        //lista de characteres com as letras que ja foram jogadas
        List<char> LetrasJogadas { get; set; }

        public List<char> LetrasJogadasErradas { get; set; }

        public string[] Palavras { get; set; }

        string todasPalavrasJuntas { get; set; }

        int VezesJogadas { get; set; }

        public string partialWord { get; set; }

        public struct LetrasRank
        {
            public int ranking { get; set; }
            public string letter { get; set; }
        }

        #endregion

        #region construtor
        //construtor desenvolvido para o objeto da classe Robo
        public Robo(string inputedWord)
        {
            //le as palavras do txt
            palavra = inputedWord;
            Palavras = Words.ReadWords();
            LetrasJogadas = new List<char>();
            LetrasJogadasErradas = new List<char>();
            todasPalavrasJuntas = null;
            VezesJogadas = 0;
        }

        #endregion

        #region metodos
        //metodo para remover acento de uma string
        public static string RemoveAcento(string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }

        //metodo que define como o Robo analisa qual letra deve ser jogada
        public char TryLetter()
        {
            char letter;
            List<LetrasRank> letras = new List<LetrasRank>();
            int qtde = 0;
            todasPalavrasJuntas = null;
            bool naoConhece = false;

            //junta todas palavras em uma string
            while (qtde <= (Palavras.Count() - 1))
            {
                if (Palavras[qtde] != null)
                {
                    if (Palavras[qtde].Length == palavra.Length)
                    {
                        todasPalavrasJuntas += string.Concat(Palavras[qtde].ToUpper());
                    }
                }
                qtde++;
            }

            qtde = 0;

            for (qtde = 0; qtde <= (Palavras.Count() - 1); qtde++)
            {
                if (Palavras[qtde] != null)
                {
                    naoConhece = false;
                    break;
                }
                else
                {
                    naoConhece = true;
                }
            }

            if (naoConhece)
            {
                todasPalavrasJuntas = "";
            }

            string todasPalavrasSemAcento = RemoveAcento(todasPalavrasJuntas);

            //conta quantas vezes cada letra do alfabeto aparece nas palavras do base de dados
            #region rankLetras

            var hifen = new LetrasRank();
            hifen.letter = "-";
            hifen.ranking = Regex.Matches(todasPalavrasSemAcento, "-").Count;
            letras.Add(hifen);
            var a = new LetrasRank();
            a.letter = "A";
            a.ranking = Regex.Matches(todasPalavrasSemAcento, "A").Count;
            letras.Add(a);
            var b = new LetrasRank();
            b.letter = "B";
            b.ranking = Regex.Matches(todasPalavrasSemAcento, "B").Count;
            letras.Add(b);
            var c = new LetrasRank();
            c.letter = "C";
            c.ranking = Regex.Matches(todasPalavrasSemAcento, "C").Count;
            letras.Add(c);
            var d = new LetrasRank();
            d.letter = "D";
            d.ranking = Regex.Matches(todasPalavrasSemAcento, "D").Count;
            letras.Add(d);
            var e = new LetrasRank();
            e.letter = "E";
            e.ranking = Regex.Matches(todasPalavrasSemAcento, "E").Count;
            letras.Add(e);
            var f = new LetrasRank();
            f.letter = "F";
            f.ranking = Regex.Matches(todasPalavrasSemAcento, "F").Count;
            letras.Add(f);
            var g = new LetrasRank();
            g.letter = "G";
            g.ranking = Regex.Matches(todasPalavrasSemAcento, "G").Count;
            letras.Add(g);
            var h = new LetrasRank();
            h.letter = "H";
            h.ranking = Regex.Matches(todasPalavrasSemAcento, "H").Count;
            letras.Add(h);
            var i = new LetrasRank();
            i.letter = "I";
            i.ranking = Regex.Matches(todasPalavrasSemAcento, "I").Count;
            letras.Add(i);
            var j = new LetrasRank();
            j.letter = "J";
            j.ranking = Regex.Matches(todasPalavrasSemAcento, "J").Count;
            letras.Add(j);
            var k = new LetrasRank();
            k.letter = "K";
            k.ranking = Regex.Matches(todasPalavrasSemAcento, "J").Count;
            letras.Add(k);
            var l = new LetrasRank();
            l.letter = "L";
            l.ranking = Regex.Matches(todasPalavrasSemAcento, "L").Count;
            letras.Add(l);
            var m = new LetrasRank();
            m.letter = "M";
            m.ranking = Regex.Matches(todasPalavrasSemAcento, "M").Count;
            letras.Add(m);
            var n = new LetrasRank();
            n.letter = "N";
            n.ranking = Regex.Matches(todasPalavrasSemAcento, "N").Count;
            letras.Add(n);
            var o = new LetrasRank();
            o.letter = "O";
            o.ranking = Regex.Matches(todasPalavrasSemAcento, "O").Count;
            letras.Add(o);
            var p = new LetrasRank();
            p.letter = "P";
            p.ranking = Regex.Matches(todasPalavrasSemAcento, "P").Count;
            letras.Add(p);
            var q = new LetrasRank();
            q.letter = "Q";
            q.ranking = Regex.Matches(todasPalavrasSemAcento, "Q").Count;
            letras.Add(q);
            var r = new LetrasRank();
            r.letter = "R";
            r.ranking = Regex.Matches(todasPalavrasSemAcento, "R").Count;
            letras.Add(r);
            var s = new LetrasRank();
            s.letter = "S";
            s.ranking = Regex.Matches(todasPalavrasSemAcento, "S").Count;
            letras.Add(s);
            var t = new LetrasRank();
            t.letter = "T";
            t.ranking = Regex.Matches(todasPalavrasSemAcento, "T").Count;
            letras.Add(t);
            var u = new LetrasRank();
            u.letter = "U";
            u.ranking = Regex.Matches(todasPalavrasSemAcento, "U").Count;
            letras.Add(u);
            var v = new LetrasRank();
            v.letter = "V";
            v.ranking = Regex.Matches(todasPalavrasSemAcento, "V").Count;
            letras.Add(v);
            var x = new LetrasRank();
            x.letter = "X";
            x.ranking = Regex.Matches(todasPalavrasSemAcento, "X").Count;
            letras.Add(x);
            var z = new LetrasRank();
            z.letter = "Z";
            z.ranking = Regex.Matches(todasPalavrasSemAcento, "Z").Count;
            letras.Add(z);



            #endregion

            //chama o metodo que retorna a letra que tem maior reincidencia dentro das palavras analisadas
            letter = VerificaLetra(letras);

            return letter;
        }

        //verifica qual letra deve jogar, vendo se ja jogou ela ou nao
        public char VerificaLetra(List<LetrasRank> letras)
        {
            char bestLetter = 'A';

            //cria nova lista ordenada, com base no numero que acompanha a struct letra
            List<LetrasRank> orderList = letras.OrderByDescending(letra => letra.ranking).ToList();

            //percorre o struct com um ranking de letras que contem uma string com a letra e a qtde de vezes que ela apareceu nas palavras consultadas
            for (int x = 0; x <= orderList.Count - 1; x++)
            {
                bool testaLetra = false;

                //pega a letra que mais apareceu
                LetrasRank letra = orderList[x];
                bestLetter = Convert.ToChar(letra.letter);

                if (LetrasJogadas.Count > 0)
                {
                    //percorre um array de chars com as letras jogadas  
                    for (int y = 0; y <= LetrasJogadas.Count - 1; y++)
                    {
                        //compara as letras jogadas com a letra escolhida
                        if (LetrasJogadas[y].Equals(bestLetter))
                        {
                            testaLetra = true;
                        }
                    }
                }

                //se testou e a letra nao foi jogada, joga a letra
                if (testaLetra == false)
                {
                    LetrasJogadas.Add(bestLetter);
                    return bestLetter;
                }
            }
            return bestLetter;
        }

        //efetua nova filtragem de pavalhas verificando as letras que acertou ou que errou
        public string[] VerificaPorLetra(char[] PartialWordChars)
        {
            string[] tempList = new string[(this.Palavras.Count())];
            string palavraTeste = new string(PartialWordChars);

            for (int x = 0; x <= (this.Palavras.Count() - 1); x++)
            {
                string tempWord = this.Palavras[x];
                //testa se as palavras da base tem as letras que foram acertadas
                bool test = tempWord.Like(palavraTeste);

                //testa se as palavras da base tem as letras tentadas e erradas 
                foreach (char letrajogada in LetrasJogadasErradas)
                {
                    string letra = letrajogada.ToString();

                    if (this.Palavras[x] != null)
                    {
                        if (this.Palavras[x].Contains(letra))
                        {
                            test = false;
                        }
                    }
                }
                if (test)
                {
                    tempList[x] = this.Palavras[x];
                }
            }

            List<string> myList = new List<string>();

            foreach (string palavra in tempList)
            {
                if (palavra != null)
                {
                    myList.Add(palavra);
                }
            }

            return tempList;
        }

        //verifica se conhece a letra ou nao, para adiciona-la na base
        public void VerificaSeConhecePalavra(string palavra)
        {
            string[] palavrasConhecidas = File.ReadAllLines("palavras.txt");
            bool ConheceouNao = true;

            for (int x = 0; x <= (palavrasConhecidas.Length - 1); x++)
            {
                if (palavra == palavrasConhecidas[x])
                {
                    ConheceouNao = true;
                    break;
                }
                else
                {
                    ConheceouNao = false;
                }
            }


            //se nao conhecer a palavra, o algoritmo vai alterar sua base de conhecimento, adicionando a palavra
            switch (ConheceouNao)
            {
                case true:
                    Console.WriteLine("Robô: eu ja conhecia esta palavra, porém minha base de dados mostrou-me que havia maior chance de aparecerem outras letras, por isso não fui capaz de acertar!");
                    break;
                case false:
                    Console.WriteLine("Robô: Ei! Eu não conhecia esta palavra doida! Agora ela foi adicionada à minha base de dados, e devo acertar se jogar de novo! Vamos tentar?\n\n");
                    string[] novaListaDePalavras = new string[(palavrasConhecidas.Length + 1)];

                    for (int z = 0; z <= (palavrasConhecidas.Length - 1); z++)
                    {
                        novaListaDePalavras[z] = palavrasConhecidas[z];
                    }
                    novaListaDePalavras[palavrasConhecidas.Length] = palavra;

                    File.WriteAllLines("palavras.txt", novaListaDePalavras);

                    break;
            }
        }
        #endregion
    }
}
