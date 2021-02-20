using System;

namespace BasicHomeWork1
{

    class Program
    {
        static void Main(string[] args)
        {

            #region явное преобразование типов 
            Console.WriteLine($"{new string('_', 50)}\nПриммеры явного преобразования");
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

            Console.WriteLine($"{new string('_',50)}\nПриммеры нявного преобразования");
          
            #region неявное преобразование типов 3 примера
            ulong g = 54u;
            decimal h = g;
            double j = g;
            float k = 345.678f;
            double l = k;
            Console.WriteLine($"g={g}\th={h}\tj={j}\tk={k}\tl={l} ");



            #endregion




        }
    }
}
