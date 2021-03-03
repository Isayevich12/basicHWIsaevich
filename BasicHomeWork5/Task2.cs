using System;
using System.Collections.Generic;
using System.Text;

namespace BasicHomeWork5
{
    class Task2
    {
        public static string NameTask { get; } = "Задача №2. В двумерном массиве в каждой строке все элементы после максимального \nэлемента в строке заменить на 0. Массив генерируется рандомно.";

        public int[,] Array { get; }// наш двумерный массив 1 Вариант     

        private int NumberOfRows { get; set; } // количество строк в массиве

        private int NumberOfColumns { get; set; }//количество столбцов в массиве

        private int[] MaxElementsInRows { get; set; } // массив из максимальных элементов в строке



        public Task2() // в конструкторе инициализируется св-во Array . Создается двумерный массив с рандомным размером и заполняется рандомными числами    
        {
            this.Array = new int[new Random().Next(5, 6), new Random().Next(7, 8)];

            this.NumberOfRows = this.Array.GetUpperBound(0) + 1;

            this.NumberOfColumns = this.Array.Length / NumberOfRows;

            this.MaxElementsInRows = new int[this.NumberOfRows];

            for (int i = 0; i < this.NumberOfRows; i++)
            {
                for (int j = 0; j < this.NumberOfColumns; j++)
                {
                    this.Array[i, j] = new Random().Next(-10, 10);

                }
            }
        }
        /// <summary>
        /// метод для просмотра массива  и параллельно для нахождения макс элементов  встроках возвращает строку визуальное представление массива
        /// </summary>
        private string ShowArrayAndFindMaxElementsInRows()
        {
            string ordinaryArray = string.Empty;

            for (int i = 0; i < this.NumberOfRows; i++)
            {
                this.MaxElementsInRows[i] = this.Array[i, 0];

                for (int j = 0; j < this.NumberOfColumns; j++)
                {
                    this.MaxElementsInRows[i] = MaxElementsInRows[i] < this.Array[i, j] ? this.Array[i, j] : MaxElementsInRows[i]; // нахождение максимальных элементов в строках и запись этих значений в отдельный массив

                    ordinaryArray += $"{this.Array[i, j],4}\t";

                }

                ordinaryArray += "\n";
            }

            return ordinaryArray;
        }

        /// <summary>
        /// метод для подстановки 0 после макс элементов в встроках
        /// </summary>
        public void ChangeArray()
        {
            for (int i = 0; i < this.NumberOfRows; i++)
            {
                int block = 0;

                for (int j = 0; j < this.NumberOfColumns; j++)
                {

                    this.Array[i, j] = block == 1 ? 0 : this.Array[i, j];

                    if (this.Array[i, j] == MaxElementsInRows[i])
                    {
                        block = 1;
                    }
                }
            }
        }
        /// <summary>
        /// Сделал данный метод для удобство отображения в классе MainMenu
        /// </summary>
        public string ShowArrayAndChangedArrey()
        {
            string solutionOfTask = $"{new string('_', 60)}\nИзначальный рандомный массив ->\n{this.ShowArrayAndFindMaxElementsInRows()}\n";

            this.ChangeArray();

            solutionOfTask += $"{new string('_', 60)}\nИзмененый массив с заменой всех элементров в\nстроке на '0' идущих после МАХ элемента ->\n{this.ShowArrayAndFindMaxElementsInRows()}\n";

            return solutionOfTask;

        }
    }
}
