using System;

namespace BasicHomeWork6
{
    class Program
    {
        static void Main(string[] args)
        {
            Student dima = new Student("dim", "Isa");
            Student iv = new Student("ivan", "Ivanov");

            dima.MarksOfStudent[2] = 6;
            dima.MarksOfStudent[0] = 5;
            // Console.WriteLine(dima.ShowAllMarks());

            Console.WriteLine(dima.CurrentGroup);

           // Console.WriteLine(dima.ShowAverageMark() == null ? "Оценки отсутствуют" : $"Средняя оценка =>{dima.ShowAverageMark()}");

            Group group1 = new Group("5A");
            Group group2 = new Group("5B");

            group1.AddStudentInGroup(dima);
            group1.AddStudentInGroup(iv);

            Console.WriteLine(dima.CurrentGroup);

            Console.WriteLine(group1.ShowAverageMarksOrAllMarksAllStudent(TypeOfReport.AverageMark));

            //Console.WriteLine(group1.TransferToAnotheGroup("Isa")?.FirstName);

            group2.AddStudentInGroup(group1.TransferToAnotheGroup("Isa"));

            Console.WriteLine(dima.CurrentGroup);

            Console.WriteLine(group1.ShowAverageMarksOrAllMarksAllStudent(TypeOfReport.AverageMark));
            Console.WriteLine(new string('_', 50));
            Console.WriteLine(group2.ShowAverageMarksOrAllMarksAllStudent(TypeOfReport.AverageMark));

            Console.WriteLine(dima.CurrentGroup);
        }


    }
}
