using System;
using System.Collections.Generic;
using System.Text;

namespace BasicHomeWork6
{
    enum TypeOfReport// для выбора в методе показать все оценки либо средний балл
    {
        AverageMark,
        AllMark,
    }
  

    class Group : ICommunicateStudentWithGroup
    {
        public string NumberOfGroup { get; }

        private List<Student> ListOfStudent { get; set; }// список тудентов. list заюзал для динамической длинны списка и удобного добавления и удаления. (чтоб не городить велосипед с "динамическим" int[])))


        public Group(string nuberOfGroup)// при создании группа будет иметь лишь название и пустой список студентов
        {
            this.NumberOfGroup = nuberOfGroup;

            this.ListOfStudent = new List<Student>();

        }

        public string ShowAverageMarksOrAllMarksAllStudent(TypeOfReport typeOfReport)// показать оценки либо средний бал(в зависимости от параметра метоа) для всех студентов  в группе
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

        public void AddStudentInGroup(Student student)//метод для добавления студентов в группу
        {
            if (student != null)
            {
                this.ListOfStudent.Add(student);

                
                student.CommunicateStudentWithGroup = this;
                student.AddToGroup();


                student.StudentTransferHandler += TransferToAnotheGroup;
            }
         
        }


        public Student TransferToAnotheGroup(string secondName)// для удаления студета из группы(можно и для переводо в другую группу)
        {
            Student selectedStudent = null;

            foreach (var item in this.ListOfStudent)
            {
                if (item.SecodName == secondName)
                {
                    selectedStudent = item;
                }

            }

            if (selectedStudent != null)
            {
                ListOfStudent.Remove(selectedStudent);
            }         
            
            return selectedStudent;
        }

        public void GiveMarksToAllStudent()
        {

            foreach (var item in ListOfStudent)
            {
                for (int i = 0; i < item.MarksOfStudent.Length; i++)
                {
                    item.MarksOfStudent[i] = new Random().Next(1, 10);
                }
            }
        }

    }
}
