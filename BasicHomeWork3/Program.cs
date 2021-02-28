using System;

namespace BasicHomeWork3
{



    class Program
    {
        static string GetPrimeNumbersInRange(int rangeBorderMax)
        {
            string sequenseOfPrimeNubers = string.Empty;

            while (rangeBorderMax > 0)
            {
                for (int i = 2; i < rangeBorderMax; i++)
                {
                    if (rangeBorderMax % i == 0)
                    {
                        continue;
                    }

                    sequenseOfPrimeNubers += rangeBorderMax.ToString() + " ";

                }
                rangeBorderMax--;
            }

            return sequenseOfPrimeNubers;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(GetPrimeNumbersInRange(13));
        }
    }
}
