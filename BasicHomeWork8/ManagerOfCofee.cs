using System;
using System.Collections.Generic;
using System.Text;

namespace BasicHomeWork8
{
    enum CoffeeDispensingMode// режимы выдачи кофе
    {
        Queue,
        Stack,
        MyQueue
    }
    /// <summary>
    /// класс который принимает задачи студентов и выдает кофе
    /// </summary>
    class ManagerOfCofee
    {

        private Stack<Student> ReciveStack { get; set; } // для реализации выдачи кофе по правилам стека
        private Queue<Student> ReciveQueue { get; set; }// для реализации выдачи кофе по правилам очереди
        private MyQueue<Student> ReciveMyQueue { get; set; }// для реализации выдачи кофе по правилам самодельной очереди

        public string ReciveReport { get; private set; } // отчет по принятым задачам от студентов
        public string GiveOutCoffeeReport { get; private set; }// отчет по выдаче кофе студентам

        /// <summary>
        ///  событе происходящее при приеме задачи от студента (можно и без этого, чисто потрениться + удобно можно разные хендлыры прикручивать)
        /// </summary>
        private event Action<Student> AccepTaskFromStudent;

        public ManagerOfCofee()
        {
            this.ReciveStack = new Stack<Student>();
            this.ReciveQueue = new Queue<Student>();
            this.ReciveMyQueue = new MyQueue<Student>();

            this.AccepTaskFromStudent += AccepTaskFromStudentHandler;// подписываем обработчик на событые приема задачи от студента
        }

        /// <summary>
        ///  в данном случае выводит на консоль сообщение о приеме задачи от студента + формирует отчет о приеме
        /// </summary>
        /// <param name="student"></param>
        private void AccepTaskFromStudentHandler(Student student)
        {
            //Console.WriteLine($"Task from {student.Name} {student.Surname} is recived");
            ReciveReport += $"Task from {student.Name} {student.Surname} is recived\n";
        }


        /// <summary>
        /// метод имитирующий прием задачи от студента ( Использует Sender)
        /// </summary>
        /// <param name="student"></param>
        public void AcceptTaskFromStudent(Student student)
        {
            this.ReciveQueue.Enqueue(student);
            this.ReciveStack.Push(student);
            this.ReciveMyQueue.Enqueue(student);

            this.AccepTaskFromStudent.Invoke(student);
        }

        /// <summary>
        /// метод формирующий список выдачи кофе + выдает кофе (по параметру типа выдачи кофе)
        /// </summary>
        /// <param name="coffeeDispensingMode"></param>
        public void GiveOutCoffee(CoffeeDispensingMode coffeeDispensingMode)
        {
            GiveOutCoffeeReport = string.Empty;
            ReciveReport = string.Empty;

            switch (coffeeDispensingMode)
            {
                case CoffeeDispensingMode.Queue:
                    {
                        GiveOutCoffeeReport = $"{CoffeeDispensingMode.Queue}\n";
                        var buff = ReciveQueue.Count;
                        for (int i = 0; i < buff; i++)
                        {
                            GiveOutCoffeeReport += $"{ReciveQueue.Peek().Name + " " + ReciveQueue.Peek().Surname} got a cup of coffee\n";
                            ReciveQueue.Dequeue();
                            ReciveStack.Clear();
                            ReciveMyQueue.Clear();
                        }

                    }

                    break;
                case CoffeeDispensingMode.Stack:
                    {
                        GiveOutCoffeeReport = $"{CoffeeDispensingMode.Stack}\n";
                        var buff = ReciveStack.Count;
                        for (int i = 0; i < buff; i++)
                        {
                            GiveOutCoffeeReport += $"{ReciveStack.Peek().Name + " " + ReciveStack.Peek().Surname} got a cup of coffee\n";
                            ReciveStack.Pop();
                            ReciveQueue.Clear();
                            ReciveMyQueue.Clear();
                        }
                    }

                    break;
                case CoffeeDispensingMode.MyQueue:
                    {
                        GiveOutCoffeeReport = $"{CoffeeDispensingMode.MyQueue}\n";
                        var buff = ReciveMyQueue.Count;
                        for (int i = 0; i < buff; i++)
                        {
                            GiveOutCoffeeReport += $"{ReciveMyQueue.Peek().Name + " " + ReciveMyQueue.Peek().Surname} got a cup of coffee\n";
                            ReciveMyQueue.Dequeue();
                            ReciveStack.Clear();
                            ReciveQueue.Clear();
                        }
                    }

                    break;
                default:
                    break;
            }

            //Console.WriteLine(GiveOutCoffeeReport);

        }



    }
}
