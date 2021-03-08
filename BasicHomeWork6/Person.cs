using System;
using System.Collections.Generic;
using System.Text;

namespace BasicHomeWork6
{
    class Person : Student// просто какойто класс 
    {
        public object SomeProp { get; set; }// просто какието левые свойства персона

        public Person(string firstName, string secondName):base(firstName,secondName)
        {

        }

        public void DifferntMethds()// просто какието левые методы персона
        {
            Console.WriteLine("hello");
        }
    }
}
