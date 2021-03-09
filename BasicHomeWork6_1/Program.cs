using System;

namespace BasicHomeWork6_1
{
    class Program
    {
        static void Main(string[] args)
        {
            // просто пример использования класса MyString / Не стал заграмождать метод Console.Writeline() всякими текстовыми описаниями

            MyString str1 = new MyString("hello");// параметр конструктора string
            MyString str2 = new MyString('w', 'o', 'r', 'l', 'd');// параметр конструктора char[]
            MyString str3 = new MyString("! hello! ");

            MyString result = str1 + str3 + str2;// 

            Console.WriteLine(result);//вывод на экран
            result.Show();//вывод на экран альтернатива

            // для проверки метода Contain
            MyString pattern1 = new MyString('l', 'l', 'o');
            Console.WriteLine(result.Contains(pattern1));
            Console.WriteLine(result.Contains('o', 'r'));
            Console.WriteLine(result.Contains('A'));

            // для проверки метода Contain + количество включений
            Console.WriteLine($"{result.Contains(out int amount, pattern1)}\t{amount}");
            Console.WriteLine($"{result.Contains(out int amount1, 'l')}\t{amount1}");

            //для проверки метода IndexOf
            MyString pattern2 = new MyString('l', 'l', 'o');
            Console.WriteLine(result.IndexOf('w', 'o'));
            Console.WriteLine(result.IndexOf(pattern2));
        }
    }
}
