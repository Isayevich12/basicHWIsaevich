using System;
using System.Collections.Generic;
using System.Text;

namespace BasicHomeWork6_1
{
    class MyString
    {
        private char[] myArr { get; set; }
        public int Length { get; private set; }


        public MyString(params char[] arr)
        {
            this.myArr = arr;
            this.Length = arr.Length;
        }

        public MyString(string expression)// возможно нарушение условия задачи т.к. использую string 
        {
            this.myArr = expression.ToCharArray();
            this.Length = expression.Length;
        }


        public char this[int index]// для удобства использования
        {
            get { return myArr[index]; }
            set { myArr[index] = value; }
        }




        public bool Contains(MyString check)// проверяет на вхождени  check - проверяемое выражение на вхождение..
        {
            return this.Contains(check.myArr);
        }


        public bool Contains(params char[] check)// проверяет на вхождение check - проверяемое выражение на вхождение..
        {
            int hitCounter = 0;

            for (int i = 0; i < this.Length; i++)
            {
                for (int j = hitCounter; j < check.Length;)
                {

                    if (this[i] == check[j])
                    {
                        hitCounter++;
                        break;
                    }
                    else
                    {
                        hitCounter = 0;
                        break;
                    }

                }
            }

            return hitCounter == check.Length ? true : false;
        }

        public bool Contains(out int numberOfOccurence, MyString check)// проверяет на вхождени и считает количество check - проверяемое выражение на вхождение..numberOfOccurence - количество вхождений
        {
            return this.Contains(out numberOfOccurence, check.myArr);
        }

        public bool Contains(out int numberOfOccurence, params char[] check)// проверяет на вхождени и считает количество check - проверяемое выражение на вхождение..numberOfOccurence - количество вхождений
        {
            int hitCounter = 0; // количество совпадений подряд
            numberOfOccurence = 0;// количество вхождений check  в myArr

            for (int i = 0; i < this.Length; i++)
            {
                hitCounter = hitCounter == check.Length ? 0 : hitCounter;

                if (hitCounter == check.Length)
                {
                    hitCounter = 0;
                }

                for (int j = hitCounter; j < check.Length;)
                {
                    if (this[i] == check[j])
                    {
                        hitCounter++;
                        numberOfOccurence += hitCounter == check.Length ? 1 : 0;

                        break;
                    }
                    else
                    {
                        break;
                    }

                }
            }

            return numberOfOccurence >= 1 ? true : false;
        }


        public int IndexOf(MyString check)// выдает позицию первого вхождения -1 -- нет вхождения
        {

            return this.IndexOf(check.myArr);
        }


        public int IndexOf(params char[] check)// выдает позицию первого вхождения -1 -- нет вхождения
        {
            int hitCounter = 0; // количество совпадений подряд
            int positionOfTheFirstOccurrence;// позиция первого вхождения -1 нет вхождений
            int buffPositionOfTheFirstOccurrence = -1;


            for (int i = 0; i < this.Length; i++)
            {
                hitCounter = hitCounter == check.Length ? 0 : hitCounter;

                if (hitCounter == check.Length)
                {
                    hitCounter = 0;
                }

                for (int j = hitCounter; j < check.Length;)
                {
                    if (this[i] == check[j])
                    {
                        hitCounter++;

                        if (hitCounter == 1)
                        {
                            buffPositionOfTheFirstOccurrence = i;
                        }

                        if (hitCounter == check.Length)
                        {
                            positionOfTheFirstOccurrence = buffPositionOfTheFirstOccurrence;
                            return positionOfTheFirstOccurrence;
                        }

                        break;
                    }
                    else
                    {
                        hitCounter = 0;
                        break;
                    }
                }
            }

            return -1;
        }

        public static MyString operator +(MyString a, MyString b)// перегрузка оператор +
        {
            char[] concat = new char[a.Length + b.Length];

            for (int i = 0, j = 0; i < a.Length + b.Length; i++)
            {
                if (i < a.Length)
                {
                    concat[i] = a[i];
                }
                else
                {
                    concat[i] = b[j];
                    j++;
                }


            }
            return new MyString(concat);
        }

        public override string ToString()//возможно нарушение условия задачи т.к. использую string 
        {
            string buf = string.Empty;

            for (int i = 0; i < this.Length; i++)
            {
                buf += this[i];
            }

            return buf;
        }

        public void Show()// альтернатива методу ToString
        {
            for (int i = 0; i < this.Length; i++)
            {
                Console.Write(this[i]);
            }
            Console.WriteLine();
        }
    }
}
