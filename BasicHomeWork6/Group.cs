using System;
using System.Collections.Generic;
using System.Text;

namespace BasicHomeWork6
{
    enum TypeOfReport
    {
        AverageMark,
        AllMark,
    }


    class Group
    {
        public string NumberOfGroup { get; }

        private List<Student> ListOfStudent { get; set; }

        public Group(string nuberOfGroup)
        {
            this.NumberOfGroup = nuberOfGroup;

            this.ListOfStudent = new List<Student>();
        }

        public string ShowAverageMarksOrAllMarksAllStudent(TypeOfReport typeOfReport)
        {
            string listAverageMarks = string.Empty;

            if (this.ListOfStudent.Count != 0)
            {
                foreach (var item in ListOfStudent)
                {
                    listAverageMarks += typeOfReport == TypeOfReport.AllMark ? $"{item.FirstName,0}{item.SecodName,8}\tОценки =>{item.ShowAllMarks(),3}\n" :
                                                                               $"{item.FirstName,0}{item.SecodName,8}\tСредний бал =>{item.ShowAverageMark(),3}\n";

                }

            }
            else
            {
                listAverageMarks += "В группе нет студентов!!";
            }

            return listAverageMarks;
        }

        public void AddStudentInGroup(Student student)
        {
            if (student != null)
            {
                this.ListOfStudent.Add(student);

                student.AddToGrop(this);
            }

        }

        public Student TransferToAnotheGroup(string secondName)
        {
            Student selectedStudent = null;

            foreach (var item in this.ListOfStudent)
            {
                if (item.SecodName == secondName)
                {
                    selectedStudent = item;
                }

            }

            ListOfStudent.Remove(selectedStudent);

            return selectedStudent;
        }

    }
}
