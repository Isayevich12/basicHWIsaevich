using System;
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
            int[] myList = { 23, 7, 324, 46, 23, 23, 7, 46, 46, 46 };// не заморачивался вводом массива

            var res = myList.GroupBy(n => n).Select(n => $"{n.First()} - {n.Count()}шт."); 

            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            Task1();// задача 1

            Console.WriteLine($"\n{new string('_', 50)}");

            Task2();// задача 2
            
        }
    }
}
