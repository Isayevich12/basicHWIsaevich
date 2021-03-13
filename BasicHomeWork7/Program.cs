using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicHomeWork7
{
    class Program
    {
        /// <summary>
        /// Метод вывода последнего элемента в числе в коллкции(Задача1). 
        /// </summary>
        static void Task1()
        {
            int[] myList = { 23, 7, 324, 46 };// не заморачивался вводом массива 

            var newList = myList.Select(n => n % 10).ToList();

            foreach (var item in newList)// показываем новый список
            {
                Console.Write($"{item}\t");
            }
        }

        /// <summary>
        /// Метод вывода количества одинаковых элементов в коллекции и их значения (Задача2).
        /// </summary>
        static void Task2()
        {
            List<int> myList = new List<int> { 23, 7, 324, 46, 23, 23, 7, 46, 46, 46 };// не заморачивался вводом массива

            var res = myList.GroupBy(n => n).Select(n => $"{n.First()} - {n.Count()}шт."); 

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Задача 2 второй способ (анонимный класс)
        /// </summary>
        static void Task2_ver2()
        {
            int[] myList = { 23, 7, 324, 46, 23, 23, 7, 46, 46, 46 };

            var res = myList.GroupBy(n => n).Select(n => new { amount = n.Count(), number = n.First() }).ToList();

            foreach (var item in res)
            {
                Console.WriteLine($"{item.number} - {item.amount}шт.");
            }
        }

        static void Main(string[] args)
        {
            Task1();// задача 1

            Console.WriteLine($"\n{new string('_', 50)}");// разделитель задач

            Task2();// задача 2

            Console.WriteLine($"\n{new string('_', 50)}");// разделитель задач

            Task2_ver2();
        }
    }
}
