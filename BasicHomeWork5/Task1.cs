using System;
using System.Collections.Generic;
using System.Text;

namespace BasicHomeWork5
{
    class Task1
    {
        public static string NameTask { get; } = "Задача №1. Определить значение и номер последнего элемента одномерного массива с 8 элементами.\n  Массив генерируется рандомно.";

        public int[] Array { get; }
        /// <summary>
        /// в конструкторе инициализируется св-во Array . Создается одномерный массив[8]  и заполняется рандомными числами  
        /// </summary>
        public Task1()
        {
            Array = new int[8];

            for (int i = 0; i < Array.Length; i++)
            {
                this.Array[i] = new Random().Next(-100, 100);
            }
        }


        public string ShowArryAndLastNegativeNumber()
        {
            string descriptionTasks = "Наш рандомный массив: ";

            string array = string.Empty;

            (int, int) lastNegativNumber = (1, 0);// решил попробовать кортежи 

            for (int i = 0; i < this.Array.Length; i++)
            {
                array += " " + this.Array[i];

                lastNegativNumber = this.Array[i] < 0 ? (this.Array[i], i) : lastNegativNumber;
            }

            return lastNegativNumber == (1, 0) ? $"{descriptionTasks}\n{array}\nВ этом массиве нет отрицательных чисел" :
                                                $"{descriptionTasks}\n{array}\nПоследнее отрицательное число в массиве-> {lastNegativNumber.Item1}\nПозиция этого элемента->{lastNegativNumber.Item2} ";
        }

    }
}
