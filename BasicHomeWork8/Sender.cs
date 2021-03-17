using System;
using System.Collections.Generic;
using System.Text;

namespace BasicHomeWork8
{
    static class Sender
    {

        /// <summary>
        /// имитация приема ManagerOfCofee задач от студентов 
        /// </summary>
        /// <param name="student"></param>
        /// <param name="managerOfCofee"></param>
        public static void SendSolution(Student student, ManagerOfCofee managerOfCofee)
        {
            managerOfCofee.AcceptTaskFromStudent(student);
        }
    }
}
