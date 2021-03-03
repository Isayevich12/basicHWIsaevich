using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BasicHomeWork5
{
    class Task5
    {
        public static string NameTask { get; } = "Задача №5.Заменить все 'а' на 'А' во введенном тексте";

        private string ChekeddString { get; set; }

        private string Pattern { get; } = @"а";

        private Regex Regex { get; set; }

        public Task5(string chekedString)
        {
            this.ChekeddString = chekedString;
        }
        /// <summary>
        /// метод меняющий 'a' на 'А' во введенном тексте
        /// </summary>
        /// <returns></returns>
        public string ChangeAlla()
        {
            Regex = new Regex(Pattern);

            return Regex.Replace(ChekeddString, "А");
        }
    }
}
