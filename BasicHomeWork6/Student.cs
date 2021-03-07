using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BasicHomeWork6
{
    class Student 
    {
        public string FirstName { get; }
        public string SecodName { get; }
        public int?[] MarksOfStudent { get; set; } = new int?[5];// чтоб не заморачиваться делаю что есть всего 5 оценок (5 предметов)
        public event StudentTransferHandler StudentTransferHandler;
        public string CurrentGroup { get; set; }

       // private ICommunicateStudentWithGroup Group { get; set; }

        public Student(string firstName, string secondName)
        {
            this.FirstName = firstName;

            this.SecodName = secondName;

            this.CurrentGroup = "Не состоит ни в какой группе";
        }

        public float? ShowAverageMark()
        {
            int? sumOfMarks = 0;
            int countOfMarks = 0;

            foreach (var item in this.MarksOfStudent)
            {
                if (item != null)
                {
                    sumOfMarks += item;

                    countOfMarks++;
                }
            }

            float? averageMark = countOfMarks > 0 ? ((float?)sumOfMarks) / countOfMarks : null;

            return averageMark;
        }

        public string ShowAllMarks()
        {
            string allMarks = string.Empty;

            foreach (var item in this.MarksOfStudent)
            {
                allMarks += item != null ? $"{item}\t" : $"Нет оценки\t";
            }


            return allMarks;
        }

        public Student TrasferYourselfToAtherGroup()
        {

            return this;
        }

        public void AddToGroup(Group group)
        {
            this.CurrentGroup = group.NumberOfGroup;
                    

        }


        public  Student LeaveCurrentGroup()
        {
            this.StudentTransferHandler?.Invoke(this.SecodName);
            this.CurrentGroup = "Не состоит ни в какой группе";

            return this;
        }



    }
}
