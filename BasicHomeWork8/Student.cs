using System;
using System.Collections.Generic;
using System.Text;

namespace BasicHomeWork8
{
    class Student
    {
        public string Name { get; }
        public string Surname { get; }

        public Student(string name, string surname)
        {
            this.Name = name;
            this.Surname = surname;
        }
    }
}
