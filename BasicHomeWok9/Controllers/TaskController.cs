using BasicHomeWok9.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasicHomeWok9.Controllers
{
    class TaskController
    {
        public RepositoryUnit RepositoryUnit { get; set; } = new RepositoryUnit();

        public TaskController()// захардкодил в конструкторе чтоб было удобно смотреть результат чтоб руками не вводить
        {

            this.RepositoryUnit.Teachers.Add(new Teacher { Name = "Kiril", Surname = "Kirilov", Category = "4" });
            this.RepositoryUnit.Teachers.Add(new Teacher { Name = "Ignat", Surname = "Ignatov", Category = "2" });
            this.RepositoryUnit.Teachers.Add(new Teacher { Name = "Lidia", Surname = "petrovna", Category = "5" });
            this.RepositoryUnit.Teachers.Add(new Teacher { Name = "Juli", Surname = "Topor", Category = "1" });

            this.RepositoryUnit.Subjects.AllSubjects.Add("математика");
            this.RepositoryUnit.Subjects.AllSubjects.Add("физика");
            this.RepositoryUnit.Subjects.AllSubjects.Add("физкультура");
            this.RepositoryUnit.Subjects.AllSubjects.Add("биология");


            this.RepositoryUnit.Groups.Add(new Group { NameOfGroup = "A" });
            this.RepositoryUnit.Groups.Add(new Group { NameOfGroup = "B" });
            this.RepositoryUnit.Groups.Add(new Group { NameOfGroup = "C" });
            this.RepositoryUnit.Groups.Add(new Group { NameOfGroup = "D" });
            this.RepositoryUnit.Groups.Add(new Group { NameOfGroup = "E" });
            this.RepositoryUnit.Groups.Add(new Group { NameOfGroup = "F" });

            this.AddStudentToGroup("Ivan", "Ivanov", "A");
            this.AddStudentToGroup("Petr", "Petrov", "A");
            this.AddStudentToGroup("Sidor", "Sidorov", "A");

            this.AddStudentToGroup("Ivan1", "Ivanov1", "B");
            this.AddStudentToGroup("Petr1", "Petrov1", "B");
            this.AddStudentToGroup("Sidor1", "Sidorov1", "B");

            this.AddStudentToGroup("Ivan2", "Ivanov2", "C");
            this.AddStudentToGroup("Petr2", "Petrov2", "C");
            this.AddStudentToGroup("Sidor2", "Sidorov2", "C");

            this.AddStudentToGroup("Ivan2", "Ivanov2", "D");
            this.AddStudentToGroup("Petr2", "Petrov2", "D");
            this.AddStudentToGroup("Sidor2", "Sidorov2", "D");

            this.AddStudentToGroup("Ivan2", "Ivanov2", "E");
            this.AddStudentToGroup("Petr2", "Petrov2", "E");
            this.AddStudentToGroup("Sidor2", "Sidorov2", "E");

            this.AddStudentToGroup("Ivan2", "Ivanov2", "F");
            this.AddStudentToGroup("Petr2", "Petrov2", "F");
            this.AddStudentToGroup("Sidor2", "Sidorov2", "F");

            this.SetAllMarksAllStudent();


            this.LinkTeacherToGroup();

        }


        /// <summary>
        /// метод распределяющий всех учителей в разные группы без учителей
        /// </summary>
        private void LinkTeacherToGroup()
        {
            Teacher[] bufferTeacherarray = new Teacher[RepositoryUnit.Teachers.Count()];// 
            RepositoryUnit.Teachers.CopyTo(bufferTeacherarray);
            var bufferTeacherList = bufferTeacherarray.ToList();// ,буферная коллекция (копия коллекции учителей)

            int position = -1;// 
            foreach (var group in RepositoryUnit.Groups)
            {
                if (bufferTeacherList.Count() > 0)
                {
                    group.Teacher = bufferTeacherList.Last();

                    bufferTeacherList.Remove(bufferTeacherList.Last());


                    var query = RepositoryUnit.Teachers.Where((n, pos) =>
                    {
                        if (n.Name + n.Surname == group.Teacher?.Name + group.Teacher?.Surname) { position = pos; }
                        return n.Name + n.Surname == group.Teacher?.Name + group.Teacher?.Surname;
                    }).ToList();

                    if (position != -1)
                    {
                        RepositoryUnit.Teachers[position].NumberOfGroup = group.NameOfGroup;
                    }
                }
            }

        }

        /// <summary>
        /// показать всех существующих учителей
        /// </summary>
        /// <returns></returns>
        public string ShowAllTeachers()
        {
            string result = string.Empty;

            foreach (var teacher in RepositoryUnit.Teachers)
            {
                result += $"Учитель: {teacher.Name} {teacher.Surname} группа: {teacher.NumberOfGroup} категория: {teacher.Category}\n ";
            }

            return result;
        }


        /// <summary>
        /// Создать группу
        /// </summary>
        /// <param name="nameOfGroup"></param>
        /// <returns></returns>
        public string CreateGroup(string nameOfGroup)
        {

            RepositoryUnit.Groups.Add(new Group { NameOfGroup = nameOfGroup });
            return $"Группа {nameOfGroup} - создана!!";

        }

        /// <summary>
        /// проверяет существует ли группа (по ее названию)
        /// </summary>
        /// <param name="nameOfGroup"></param>
        /// <returns></returns>
        public bool CheckGroup(string nameOfGroup)
        {

            var currentGroup = FindeGroupByName(nameOfGroup);

            return currentGroup.Item2 != null ? true : false;

        }

        /// <summary>
        /// удалить группу
        /// </summary>
        /// <param name="nameOfGroup"></param>
        /// <returns></returns>
        public string DeleteGroup(string nameOfGroup)// удалить группу
        {
            var currentGroup = FindeGroupByName(nameOfGroup);

            if (currentGroup.Item2 != null)
            {
                foreach (var student in RepositoryUnit.Students)// удалить у студента группу
                {
                    if (student.GroupOfStudent == currentGroup.Item2.NameOfGroup)
                    {
                        student.GroupOfStudent = string.Empty;
                    }

                }

                RepositoryUnit.Groups.Remove(currentGroup.Item2);

                return $"Группа {nameOfGroup} - удалена!!";
            }
            else
            {
                return $"Группа {nameOfGroup} не существует!!!";
            }
        }


        /// <summary>
        /// создает учителя и добляет его в группу без учителя.. если нет групп без учителя не создает учителя
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public string CreateTeacher(string name, string surname, string category)
        {
            string result = "группы без учителей отсутствуют. Учитель не добавлен!";

            foreach (var group in RepositoryUnit.Groups)
            {
                if (group.Teacher == null)
                {
                    var newTeacher = new Teacher { Name = name, Surname = surname, Category = category, NumberOfGroup = group.NameOfGroup };
                    RepositoryUnit.Teachers.Add(newTeacher);
                    group.Teacher = newTeacher;
                    result = $"Учитель {newTeacher.Name + " " + newTeacher.Surname} добавлен в группу {group.NameOfGroup}";
                    break;
                }
            }
            return result;
        }


        /// <summary>
        /// Проверяет и выводит группу с ее позицией в репозитории, по введенному пользователем названию
        /// </summary>
        /// <param name="nameOfGroup"></param>
        /// <returns></returns>
        public (int, Group) FindeGroupByName(string nameOfGroup)
        {
            int position = -1;
            var requestGroup = RepositoryUnit.Groups.Where((n, pos) => { if (n.NameOfGroup == nameOfGroup) position = pos; return n.NameOfGroup == nameOfGroup; }).LastOrDefault();
            return (position, requestGroup);
        }

        /// <summary>
        /// Проверяет и выводит студента с его позицией в репозитории, по введенному пользователем имени ученика
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public (int, Student) FindeStudentByName(string fullName)
        {
            int position = -1;
            var requestGroup = RepositoryUnit.Students.Where((n, pos) => { if (n.Name + n.Surname == fullName) position = pos; return n.Name + n.Surname == fullName; }).LastOrDefault();
            return (position, requestGroup);
        }


        /// <summary>
        /// добавляет студента в группу
        /// </summary>
        /// <param name="student"></param>
        /// <param name="nameOfGroup"></param>
        /// <returns></returns>
        public string AddStudentToGroup(string name, string surname, string nameOfGroup)
        {
            //Student addedStudent = new Student { Name = name, Surname = surname, GroupOfStudent = nameGroup };

            var currentGroup = FindeGroupByName(nameOfGroup);

            if (currentGroup.Item2 != null)
            {
                Student addedStudent = new Student { Name = name, Surname = surname, GroupOfStudent = nameOfGroup };

                //currentGroup.GroupOfStudent = currentGroup.Item2.NameOfGroup;
                RepositoryUnit.Students.Add(addedStudent);
                RepositoryUnit.Groups[currentGroup.Item1].Students.Add(addedStudent);

                return $"Студент {addedStudent.Name + " " + addedStudent.Surname} добавлен в группу {nameOfGroup}";
            }
            else
            {
                return $"Группа {nameOfGroup} не существует!!!";
            }
        }

        /// <summary>
        /// Выставить всем ученикам рандомные оценки
        /// </summary>
        /// <returns></returns>
        public string SetAllMarksAllStudent()
        {
            foreach (var group in RepositoryUnit.Groups)
            {
                foreach (var student in group.Students)
                {
                    foreach (var subject in RepositoryUnit.Subjects.AllSubjects)
                    {
                        student.StudentMarks[subject] = new Random().Next(3, 10);
                    }
                }
            }
            return $"оценки выставлены";
        }


        /// <summary>
        /// Показать статистику(номер группы, ученики с оценками, преподаватель) учеников в желаемой группе 
        /// </summary>
        /// <param name="nameOfGroup"></param>
        /// <returns></returns>
        public string ShowAllStudentInGroup(string nameOfGroup)
        {
            string result = string.Empty;

            var currentGroup = FindeGroupByName(nameOfGroup);

            if (currentGroup.Item2 != null)
            {
                result += $"Группа {currentGroup.Item2.NameOfGroup} Преподаватель {currentGroup.Item2.Teacher.Name} {currentGroup.Item2.Teacher.Surname} :\n";
                foreach (var student in currentGroup.Item2.Students)
                {
                    result += $"{student.Name + " " + student.Surname}\n";

                    foreach (var mark in student.StudentMarks)
                    {
                        result += $" {mark.Key}\t{mark.Value}\n ";
                    }
                    result += $"\n";
                }

                return result;
            }
            else
            {
                return $"Группа {nameOfGroup} не существует!!!";
            }

        }


        /// <summary>
        /// удалить ученика из группы
        /// </summary>
        /// <param name="fullNameStudent"></param>
        /// <param name="nameOfGroup"></param>
        /// <returns></returns>
        public string DeleteStudentFromGroup(string fullNameStudent, string nameOfGroup)
        {
            string result = string.Empty;

            var currentGroup = FindeGroupByName(nameOfGroup);
            var currentStudent = FindeStudentByName(fullNameStudent);

            if (currentStudent.Item2 != null)
            {
                bool deletedStudentConsistInCurrentGroup = false;

                RepositoryUnit.Students.Remove(currentStudent.Item2);

                foreach (var studentFromCurrentGroup in currentGroup.Item2.Students)
                {
                    if (studentFromCurrentGroup.Name + studentFromCurrentGroup.Surname == currentStudent.Item2.Name + currentStudent.Item2.Surname)
                    {
                        deletedStudentConsistInCurrentGroup = true;
                    }
                }

                if (deletedStudentConsistInCurrentGroup)
                {
                    foreach (var group in RepositoryUnit.Groups)
                    {
                        group.Students.Remove(currentStudent.Item2);

                    }
                    result += $"Студент {currentStudent.Item2.Name} {currentStudent.Item2.Surname} удален";
                }

                return result;
            }
            else
            {
                return result = $"нет такого студента";
            }
        }

        /// <summary>
        /// Выводит всех студентов отсортированных по среднему балу (в группе) + лучший в группе + самый лучший в школе
        /// </summary>
        /// <returns></returns>
        public string ShowBestStudent() // показать лучшего ученика по среднему баллу
        {

            string result = $"Рейтинг студентов по всем группам:\n";
            int position = 0;
            (string, double?, string) theBestStudent = (string.Empty, 0, string.Empty);
            foreach (var group in RepositoryUnit.Groups)
            {
                var query = group.Students.Select(n => new { Name = n.Name + " " + n.Surname, Aver = n.StudentMarks.Average(m => m.Value), NumbOfGroup = n.GroupOfStudent }).OrderBy(k => k.Aver);
                foreach (var item in query)
                {
                    result += $"{++position} {item.Name}  средний бал:{item.Aver}  группа:{item.NumbOfGroup}\n";

                }
                var res = query.Reverse().Take(1).ToList();



                foreach (var item in res)
                {
                    if (theBestStudent.Item2 < item.Aver)
                    {
                        theBestStudent = (item.Name, item.Aver, item.NumbOfGroup);
                    }
                    result += $"Лучший студент в группе {item.Name} cредний балл: {item.Aver}\n";
                }


                result += $"{new string('_', 50)}\n";
            }

            result += $"{new string('*', 50)}\nЛучший из лучших: {theBestStudent.Item1}\tСредний бал: {theBestStudent.Item2}\tгруппа :{theBestStudent.Item3} ";

            return result;
        }


        /// <summary>
        /// показать учеников с их средними баллами в выбранной группе отсортированный по возрастанию среднего бала
        /// </summary>
        /// <param name="nameOfGroup"></param>
        /// <returns></returns>
        public string ShowAverageMarkStudentsInGroup(string nameOfGroup)
        {
            string result1 = string.Empty;

            var currentGroup = FindeGroupByName(nameOfGroup);

            if (currentGroup.Item2 != null)
            {
                result1 += $"Группа {currentGroup.Item2.NameOfGroup}:\n";

                var query = currentGroup.Item2.Students.Select(n => new { Name = n.Name + n.Surname, Aver = n.StudentMarks.Average(m => m.Value) }).OrderBy(k => k.Aver);


                foreach (var item in query)
                {
                    result1 += $"{item.Name }\tСредний бал:{item.Aver}\n";

                }

                return result1;
            }
            else
            {
                return $"Группа {nameOfGroup} не существует!!!";
            }

        }





        /// <summary>
        /// показать все существующие группы с их учениками и пркподавателями
        /// </summary>
        /// <returns></returns>
        public string ShowAllGroupsWithStudents()
        {
            string result = string.Empty;

            if (RepositoryUnit.Groups.Count() != 0)
            {
                foreach (var group in RepositoryUnit.Groups)
                {
                    result += group.Students.Count() == 0 ? $"В группе {group.NameOfGroup} нет студентов" : $"Студенты группы  {group.NameOfGroup} (Преподаватель {group.Teacher?.Name} {group.Teacher?.Surname}):\n";

                    foreach (var student in group.Students)
                    {
                        result += $"{student.Name + " " + student.Surname} \n";
                    }
                    result += $"\n{new string('_', 50)}\n";
                }
            }
            else
            {
                result = "Группы отсутствуют!!";
            }

            return result;
        }



    }
}
