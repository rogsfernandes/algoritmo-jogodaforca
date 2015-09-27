using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace JogodaForca
{
    static class Words
    {
        public static string[] ReadWords()
        {
            //array com as palavras que o programa conhece

            string[] words = File.ReadAllLines("palavras.txt");

            for (int i = 0; i < words.Length; i++)
            {
                words[i] = words[i].ToUpper();
            }
            return words;
        }

        //EXTENSION METHOD - metodo que recebe uma string e procura ele em outra string
        public static bool Like(this string toSearch, string toFind)
        {
            if (toSearch != null)
            {
                return new Regex(@"\A" + new Regex(@"\.|\$|\{|\[|\(|\||\)|\*|\+|\?|\\").Replace(toFind, ch => @"\" + ch).Replace('_', '.').Replace("%", ".*") + @"\z", RegexOptions.Singleline).IsMatch(toSearch);
            }
            else
            {
                return false;
            }
        }
    }
}
