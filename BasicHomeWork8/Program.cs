using System;

namespace BasicHomeWork8
{
    class Program
    {
        static void Main(string[] args)
        {
            // просто пример работы программы

            ManagerOfCofee managerOfCofee = new ManagerOfCofee();

            Sender.SendSolution(new Student("Ivan", "Ivanov"), managerOfCofee);
            Sender.SendSolution(new Student("Petr", "Petrov"), managerOfCofee);
            Sender.SendSolution(new Student("Dzmitry", "Isayevich"), managerOfCofee);

            Console.WriteLine(managerOfCofee.ReciveReport);
            managerOfCofee.GiveOutCoffee(CoffeeDispensingMode.Queue);
            Console.WriteLine(managerOfCofee.GiveOutCoffeeReport);
            Console.WriteLine("--------------------");

            Sender.SendSolution(new Student("Ivan1", "Iva"), managerOfCofee);
            Sender.SendSolution(new Student("Petr1", "Petro"), managerOfCofee);
            Sender.SendSolution(new Student("Dzmitry1", "Isay"), managerOfCofee);

            Console.WriteLine(managerOfCofee.ReciveReport);
            managerOfCofee.GiveOutCoffee(CoffeeDispensingMode.Stack);
            Console.WriteLine(managerOfCofee.GiveOutCoffeeReport);
            Console.WriteLine("--------------------");

            Sender.SendSolution(new Student("Ivan2", "Iva"), managerOfCofee);
            Sender.SendSolution(new Student("Petr2", "Petro"), managerOfCofee);
            Sender.SendSolution(new Student("Dzmitry2", "Isay"), managerOfCofee);

            Console.WriteLine(managerOfCofee.ReciveReport);
            managerOfCofee.GiveOutCoffee(CoffeeDispensingMode.MyQueue);
            Console.WriteLine(managerOfCofee.GiveOutCoffeeReport);

        }
    }
}
