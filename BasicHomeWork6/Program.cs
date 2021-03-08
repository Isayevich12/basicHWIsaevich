using System;

namespace BasicHomeWork6
{
    class Program
    {
        static void Main(string[] args)
        {
            // не стал делать какую-то менюшку. просто для примера вручную в мейне какойто функционал классов реализовал. 

            // создали 2 группы
            Group group1 = new Group("grA");
            Group group2 = new Group("grB");
            
            //посмотрели статистику студентов этих групп (они пустые)
            Console.WriteLine($"Оценки всех учеников грруппы:{group1.NumberOfGroup}\n{group1.ShowAverageMarksOrAllMarksAllStudent(TypeOfReport.AllMark)}");
            Console.WriteLine($"Средний бал всех учеников грруппы:{group2.NumberOfGroup}\n{group2.ShowAverageMarksOrAllMarksAllStudent(TypeOfReport.AverageMark)}");

            // создали 3 персонов и сразу привели их к студентам
            Student student1 = new Person("Ivan", "Ivanov");
            Student student2 = new Person("Petr", "Petrov");
            Student student3 = new Person("Sidor", "Sidorov");

            // добавили всех трих в group1 
            group1.AddStudentInGroup(student1);
            group1.AddStudentInGroup(student2);
            group1.AddStudentInGroup(student3);

            //посмотрели статистику студентов  группы 1 
            Console.WriteLine(new string('_', 50));
            Console.WriteLine($"Оценки всех учеников грруппы:{group1.NumberOfGroup}\n{group1.ShowAverageMarksOrAllMarksAllStudent(TypeOfReport.AllMark)}");
            Console.WriteLine($"Средний бал всех учеников грруппы:{group1.NumberOfGroup}\n{group1.ShowAverageMarksOrAllMarksAllStudent(TypeOfReport.AverageMark)}");

            // расставили оценки студентам
            group1.GiveMarksToAllStudent();

            //посмотрели статистику студентов  группы 1 
            Console.WriteLine(new string('_', 50));
            Console.WriteLine($"Оценки всех учеников грруппы:{group1.NumberOfGroup}\n{group1.ShowAverageMarksOrAllMarksAllStudent(TypeOfReport.AllMark)}");
            Console.WriteLine($"Средний бал всех учеников грруппы:{group1.NumberOfGroup}\n{group1.ShowAverageMarksOrAllMarksAllStudent(TypeOfReport.AverageMark)}");

            // перевели ivanova и petrova в группу 2 
            group2.AddStudentInGroup(group1.TransferToAnotheGroup("Ivanov"));// группа перевела
            group2.AddStudentInGroup(student2.LeaveCurrentGroup());// сам перешел


            //посмотрели статистику студентов  группы 1 
            Console.WriteLine(new string('_', 50));
            Console.WriteLine($"Оценки всех учеников грруппы:{group1.NumberOfGroup}\n{group1.ShowAverageMarksOrAllMarksAllStudent(TypeOfReport.AllMark)}");
            Console.WriteLine($"Средний бал всех учеников грруппы:{group1.NumberOfGroup}\n{group1.ShowAverageMarksOrAllMarksAllStudent(TypeOfReport.AverageMark)}");

            //посмотрели статистику студентов  группы 2 
            Console.WriteLine(new string('_', 50));
            Console.WriteLine($"Оценки всех учеников грруппы:{group2.NumberOfGroup}\n{group2.ShowAverageMarksOrAllMarksAllStudent(TypeOfReport.AllMark)}");
            Console.WriteLine($"Средний бал всех учеников грруппы:{group2.NumberOfGroup}\n{group2.ShowAverageMarksOrAllMarksAllStudent(TypeOfReport.AverageMark)}");

            // Посмотрели к каким группам принадлежат студенты
            Console.WriteLine(new string('_', 50));
            Console.WriteLine($"{student1.SecodName} состоит в группе->{student1.CurrentGroup}\n" +
                $"{student2.SecodName} состоит в группе->{student2.CurrentGroup}\n" +
                $"{student3.SecodName} состоит в группе->{student3.CurrentGroup}");

        }


    }
}
