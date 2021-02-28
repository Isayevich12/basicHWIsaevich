using System;
using System.Collections.Generic;
using System.Text;

namespace BasicHomeWork3
{
    class UserMenu
    {
        public static void CreateMenu()
        {
            (new UserMenu()).Run();

        }

        private void Run()
        {          
            do
            {
                Console.Clear();

                Console.WriteLine("Приложение для нахождения простых чисел во введенном диапазоне!!\nПожалуйста, введите диапазон:\nНижняя граница-> ");

                bool resultInputingMinRage = int.TryParse(Console.ReadLine(), out int minRange);

                Console.WriteLine("\nВерхняя граница-> ");

                bool resultInputingMaxRage = int.TryParse(Console.ReadLine(), out int maxRange);

                Console.WriteLine(new string('_', 50));

                if (resultInputingMaxRage && resultInputingMinRage)
                {
                    Console.WriteLine(FinderPrimeNumbers.GetPrimeNumbersInRange(minRange, maxRange));                   
                }
                else
                {
                    Console.WriteLine("некорректный ввод информации!!");
                                   
                }

                Console.WriteLine(new string('_', 50));

                Console.WriteLine("Желаете продолжить? (Да-> 'y'   нет->  любой другой символ)");
              
            } while (Console.ReadLine().Equals("y",  StringComparison.CurrentCultureIgnoreCase));

        }
    }
}
