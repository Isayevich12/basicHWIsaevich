using System;
using System.Collections.Generic;
using System.Text;

namespace BasicHomeWork3
{
    class FinderPrimeNumbers
    {
        // эта пергрузка не используется
        public static string GetPrimeNumbersInRange(int rangeBorderMax)//для нахождения простых чисел в диапазоне от 0 до rangeBorderMax
        {
            string sequenseOfPrimeNubers = rangeBorderMax >= 2 ? "2 " : " В данном диапазоне нет простых чисел";

            int numberForChecking = 0;

            while (numberForChecking <= rangeBorderMax)
            {
                string buffer = string.Empty;

                for (int i = 2; i < numberForChecking; i++)
                {
                    if (numberForChecking % i != 0)
                    {
                        buffer = numberForChecking.ToString();
                        continue;
                    }
                    else
                    {
                        buffer = string.Empty;
                        break;
                    }
                }

                sequenseOfPrimeNubers += buffer != string.Empty ? buffer + " " : string.Empty;

                numberForChecking++;
            }
            return sequenseOfPrimeNubers;
        }

        public static string GetPrimeNumbersInRange(int rangeBorderMin, int rangeBorderMax)// для нахождения простых чисел в диапазоне от rangeBorderMin до rangeBorderMax
        {
            string sequenseOfPrimeNubers = rangeBorderMax >= 2 ? (rangeBorderMin > 2) ? string.Empty : "2 " : string.Empty;

            int numberForChecking = rangeBorderMin;

            while (numberForChecking <= rangeBorderMax)
            {
                string buffer = string.Empty;

                for (int i = 2; i < numberForChecking; i++)
                {
                    if (numberForChecking % i != 0)
                    {
                        buffer = numberForChecking.ToString();
                        continue;
                    }
                    else
                    {
                        buffer = string.Empty;
                        break;
                    }
                }

                sequenseOfPrimeNubers += buffer != string.Empty ? buffer + " " : string.Empty;

                numberForChecking++;
            }

            sequenseOfPrimeNubers = sequenseOfPrimeNubers == string.Empty ? $"В диапазоне от {rangeBorderMin} до {rangeBorderMax} нет простых чисел" :
                                                                            $"В диапазоне  от {rangeBorderMin} до {rangeBorderMax} имеютя простые числа ->\n {sequenseOfPrimeNubers}";

            return sequenseOfPrimeNubers;
        }


    }
}
