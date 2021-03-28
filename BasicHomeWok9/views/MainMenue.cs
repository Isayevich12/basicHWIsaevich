using BasicHomeWok9.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Views
{
    class MainMenue
    {
        TaskController controller = new TaskController();


        public void Start()// главное меню
        {
            Console.WriteLine("Приложение 'Школа'");

            while (true)
            {
                Console.WriteLine($"\n1 - Просмотреть имеющиеся группы с учениками\n2 - Добавить группу\n3 - Удалить группу\n4 - Войти в группу\n" +
                    $"5 - Поставить всем студентам оценки\n6 - Показать всех учителей\n7 - Создать учителя + добавить его в группу без учителя\n" +
                    $"8 - рейтинг всех студентов по среднему баллу\n9 - полный отчет по ученикам\n" +
                    $"10 - полный отчет по учителям\n11 - Инфо по имени фамилии\n22 -Выйти из программы");

                int.TryParse(Console.ReadLine(), out int modeOfMenue);

                switch (modeOfMenue)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine(controller.ShowAllGroupsWithStudents());

                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.WriteLine("Введите название группы");
                            Console.WriteLine(controller.CreateGroup(Console.ReadLine()));

                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            Console.WriteLine("Введите название группы");
                            Console.WriteLine(controller.DeleteGroup(Console.ReadLine()));

                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            SubmenueStudents();
                            break;
                        }
                    case 5:
                        {
                            Console.Clear();
                            Console.WriteLine(controller.SetAllMarksAllStudent());

                            break;
                        }

                    case 6:
                        {
                            Console.Clear();
                            Console.WriteLine(controller.ShowAllTeachers());

                            break;
                        }
                    case 7:
                        {
                            Console.Clear();
                            Console.WriteLine("Введите имя учителя");
                            string name = Console.ReadLine();
                            Console.WriteLine("Введите фамилию учителя");
                            string surname = Console.ReadLine();
                            Console.WriteLine("Введите категорию учителя");
                            string category = Console.ReadLine();
                            Console.WriteLine(controller.CreateTeacher(name, surname, category));
                            break;
                        }
                    case 8:
                        {
                            Console.Clear();
                            Console.WriteLine(controller.ShowBestStudent());

                            break;
                        }
                    case 9:
                        {
                            Console.Clear();
                            Console.WriteLine(controller.ShowAllInfoAboutStudents());

                            break;
                        }
                    case 10:
                        {
                            Console.Clear();
                            Console.WriteLine(controller.ShowAllInfoAboutTeachers());

                            break;
                        }
                    case 11:
                        {
                            Console.Clear();
                            Console.WriteLine("Введите имя ");
                            string name = Console.ReadLine();
                            Console.WriteLine("Введите фамилию ");
                            string surname = Console.ReadLine();
                            Console.WriteLine(controller.ShowInformationByName(name + surname));
                            break;
                        }


                    case 22:
                        {
                            return;
                        }

                    default:
                        break;
                }


            }

        }

        public void SubmenueStudents()// подменю
        {
            Console.WriteLine("Выберите группу:");

            string nameGroup = Console.ReadLine();

            while (true)
            {
                if (controller.CheckGroup(nameGroup))
                {
                    Console.WriteLine($"\n1 - Вывести всех учеников группы\n2 - Добавить студента\n3 - Удалить студента\n4 - средний бал студента в группе\n11 - вернутся вверх по меню");

                    int.TryParse(Console.ReadLine(), out int modeOfMenue);

                    switch (modeOfMenue)
                    {
                        case 1:
                            {
                                Console.Clear();
                                Console.WriteLine(controller.ShowAllStudentInGroup(nameGroup));

                                break;
                            }
                        case 2:
                            {
                                Console.Clear();
                                Console.WriteLine("Введите имя студента");
                                string name = Console.ReadLine();
                                Console.WriteLine("Введите фамилию студента");
                                string surname = Console.ReadLine();
                                Console.WriteLine(controller.AddStudentToGroup(name, surname, nameGroup));




                                break;
                            }
                        case 3:
                            {
                                Console.Clear();
                                Console.WriteLine("Имя студента");
                                string name = Console.ReadLine();
                                Console.WriteLine("Введите фамилию студента");
                                string surname = Console.ReadLine();
                                Console.WriteLine(controller.DeleteStudentFromGroup(name + surname, nameGroup));

                                break;
                            }
                        case 4:
                            {
                                Console.Clear();
                                Console.WriteLine(controller.ShowAverageMarkStudentsInGroup(nameGroup));
                                break;
                            }

                        case 11:
                            {
                                return;
                            }

                        default:
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"группы {nameGroup} не существует");
                    return;
                }
            }
        }
    }
}
