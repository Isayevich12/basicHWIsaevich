using System;

namespace basicHWIsaevich
{

    class Program
    {
        static void Main(string[] args)
        {

            #region явное преобразование типов 
            #region пример1 c проверкой на переполнение и отловом исключения
            try
            {
                checked
                {
                    int a = 315;
                    byte b = (byte)a;
                    Console.WriteLine($"b=>{b}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message }");
            }
            Console.WriteLine(new string('-',20));
            #endregion
            #region пример2, пример3
            float c = 2.38f;
            int d = (int)c;
            decimal f = (decimal)c;
            Console.WriteLine($"d={d}\tf={f}");
            #endregion
            #endregion

            #region неявное преобразование типов


            #endregion




        }
    }
}
