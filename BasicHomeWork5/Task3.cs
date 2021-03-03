using System;
using System.Collections.Generic;
using System.Text;

namespace BasicHomeWork5
{
    class Task3
    {
        public static string NameTask { get; } = "Задача №3. В двумерном массиве(массив массивов) в каждой строке все элементы после максимального\n элемента в строке заменить на 0. Массив генерируется рандомно.";

        public int[][] Array { get; }// наш двумерный массив 1 Вариант     

        private int NumberOfRows { get; set; } // количество строк в массиве

        //private int NumberOfColumns { get; set; }//количество столбцов в массиве

        private int[] MaxElementsInRows { get; set; } // массив из максимальных элементов в строке



        public Task3() // в конструкторе инициализируется св-во Array . Создается зубчатый массив с рандомным размером и заполняется рандомными числами
        {
            this.Array = new int[new Random().Next(5, 10)][];

            this.NumberOfRows = this.Array.GetUpperBound(0) + 1;

            this.MaxElementsInRows = new int[this.NumberOfRows];

            for (int i = 0; i < this.NumberOfRows; i++)
            {
                this.Array[i] = new int[new Random().Next(2, 6)];
                for (int j = 0; j < this.Array[i].Length; j++)
                {
                    this.Array[i][j] = new Random().Next(-100, 100);
                }
            }
        }
        /// <summary>
        /// метод показывающий массив и заполняющий одномерный массив  MaxElementsInRows максимальными числами из строк
        /// </summary>
        private string ShowArrayAndFindMaxElementsInRows()
        {
            string ordinaryArray = string.Empty;

            for (int i = 0; i < this.NumberOfRows; i++)
            {
                for (int j = 0; j < this.Array[i].Length; j++)
                {
                    this.MaxElementsInRows[i] = MaxElementsInRows[i] < this.Array[i][j] ? this.Array[i][j] : MaxElementsInRows[i]; // нахождение максимальных элементов в строках и запись этих значений в отдельный массив

                    ordinaryArray += $"{this.Array[i][j],4}\t";

                }
                ordinaryArray += "\n";

            }

            return ordinaryArray;

        }
        /// <summary>
        /// метод для заполнения '0' всех элементов после максимального в строке
        /// </summary>
        public void ChangeArray()
        {
            for (int i = 0; i < this.NumberOfRows; i++)
            {
                int block = 0;

                for (int j = 0; j < this.Array[i].Length; j++)
                {

                    this.Array[i][j] = block == 1 ? 0 : this.Array[i][j];

                    if (this.Array[i][j] == MaxElementsInRows[i])
                    {
                        block = 1;
                    }
                }
            }
        }

        /// <summary>
        /// Метод для вывода решения задачи №3.В зубчатом массиве(массив массивов) в каждой строке все элементы после максимального элемента в строке заменить на 0.
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
