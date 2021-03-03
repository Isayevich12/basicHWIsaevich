using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BasicHomeWork5
{
    class Task4
    {
        public static string NameTask { get; } = "Задача №4. Найти количество гласных букв во введеном тексте";

        private string ChekeddString { get; set; }

        private string Pattern { get; } = @"а|у|о|ы|и|э|я|ю|ё|е|А|У|О|Ы|И|Э|Я|Ю|Ё|Е";

        private Regex Regex { get; set; }

        public Task4(string chekedString)
        {
            this.ChekeddString = chekedString;
        }
        /// <summary>
        /// Выводит все глассные символы и их количество во введенном предложении
        /// </summary>
        /// <returns></returns>
        public string FindAmountVolweLetters()
        {
            string answer = string.Empty;

            Regex = new Regex(Pattern);

            MatchCollection matches = Regex.Matches(ChekeddString);

            foreach (Match item in matches)
            {
                answer += " " + item.Value;
            }

            return $"В введенном выражении ->\nиспользуемые гдасные{answer}\nИх количество->{matches.Count}";
        }

    }
}
