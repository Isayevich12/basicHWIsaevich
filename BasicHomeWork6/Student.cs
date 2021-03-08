using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace BasicHomeWork6
{
    delegate Student StudentTransferHandler(string secondName);

    abstract class Student //чтоб нельзя было "делать" студентов с нуля (только upcast например person ) и сокрыть все не нужное состояние и поведение person в группе
    {
        public string FirstName { get; }
        public string SecodName { get; }
        public int?[] MarksOfStudent { get; set; } = new int?[5];// чтоб не заморачиваться делаю что есть всего 5 оценок (5 предметов), использовал nulable type чтоб можно было показать отсутствие оценок
        public event StudentTransferHandler StudentTransferHandler;// событие для выхода студента из группы по своей инициативе
        public string CurrentGroup { get; private set; }

        public ICommunicateStudentWithGroup CommunicateStudentWithGroup { get;  set; }// для того чтобы студент знал номер группы в которой состоит и больше ничего не знал о группе
    

        public Student(string firstName, string secondName)
        {
            this.FirstName = firstName;

            this.SecodName = secondName;

            this.CurrentGroup = "Не состоит ни в какой группе";
        }

        public float? ShowAverageMark()// средний бал студента
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

        public string ShowAllMarks()// показать все оценки
        {
            string allMarks = string.Empty;

            foreach (var item in this.MarksOfStudent)
            {
                allMarks += item != null ? $"{item}\t" : $"Нет оценки\t";
            }


            return allMarks;
        }     

        public void AddToGroup()// этот метод вызывается в Group когда группа доавляет студента
        {
            this.CurrentGroup = CommunicateStudentWithGroup.NumberOfGroup;
                    

        }


        public  Student LeaveCurrentGroup()//метод для самостоятелного выхода из группы (студент сам покидает группу)
        {
            this.StudentTransferHandler?.Invoke(this.SecodName);// удаление студента из группы
            this.CurrentGroup = "Не состоит ни в какой группе";
            this.CommunicateStudentWithGroup = null;


            return this;
        }



    }
}
