using System;

namespace basicHWIsaevich
{

    class Program
    {
        static void Main(string[] args)
        {
            ///явное преобразование типов c проверкой на переполнение и отловом исключения    
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
            




        }
    }
}
