using System;
using System.Collections.Generic;
using System.Text;

namespace BasicHomeWork5
{
    class MainMenu
    {
        public static void Run()
        {
            new MainMenu().MainMenuRun();
        }



        private void MainMenuRun()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"задание №5\n\n'1' - {Task1.NameTask}\n\n'2' - {Task2.NameTask}\n\n'3' - {Task3.NameTask}\n\n'4' - {Task4.NameTask}\n\n" +
                    $"'5' - {Task5.NameTask}" +
                    $"\n\nлюбой другой символ - выйти из приложения");

                int.TryParse(Console.ReadLine(), out int positionOfMenu);

                switch (positionOfMenu)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine(Task1.NameTask);
                            Task1 task1 = new Task1();
                            Console.WriteLine($"{task1.ShowArryAndLastNegativeNumber()}\n{new string('_', 60)}");
                            break;
                        }

                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine(Task2.NameTask);
                            Console.WriteLine(new Task2().ShowArrayAndChangedArrey()); ;
                            Console.WriteLine(new string('_', 60));
                            break;
                        }

                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine(Task3.NameTask);
                            Console.WriteLine(new Task3().ShowArrayAndChangedArrey()); ;
                            Console.WriteLine(new string('_', 60));
                            break;
                        }

                    case 4:
                        {
                            Console.Clear();
                            Console.WriteLine($"{Task4.NameTask}\nВведите текст!->");
                            Console.WriteLine(new Task4(Console.ReadLine()).FindAmountVolweLetters() + $"\n{new string('_', 60)}");
                            break;
                        }

                    case 5:
                        {
                            Console.Clear();
                            Console.WriteLine($"{Task5.NameTask}\nВведите текст!->");
                            Console.WriteLine($"Отредактированный текст->{new Task5(Console.ReadLine()).ChangeAlla()}\n{new string('_', 60)}");
                            break;
                        }

                    default:
                        return;
                }

                Console.WriteLine("Продолжить? Да -> 'y'\t нет -> 'любой символ'");

                if (Console.ReadLine().Equals("y"))
                {
                    continue;
                }

                return;
            }
        }
    }
}
