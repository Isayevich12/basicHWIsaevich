using System;
using System.Collections.Generic;
using System.Text;

namespace BasicHomeWork2
{
    class CreditCalculator
    {
        public int RequiredAmount { get; set; }
        public float Procent { get; set; }
        private int Period { get; set; }

        public CreditCalculator(int requiredAmount, float procent)
        {
            this.RequiredAmount = requiredAmount;
            this.Procent = procent;
            this.Period = 12;

        }

        public void DifferentiatedPayment()
        {
            decimal basicPaYment = (decimal)this.RequiredAmount / (decimal)Period;
            decimal sum = 0;
            decimal monthlyPayment;

            Console.WriteLine("Выплаты по месяцам:");

            for (int i = 1; i <= Period; i++)
            {
                monthlyPayment = basicPaYment + (((decimal)(RequiredAmount) - (basicPaYment * (decimal)i)) * (decimal)Procent / (100m * 12m));

                Console.WriteLine($"{i} Месяц : {monthlyPayment:#.##} Руб.");

                sum += monthlyPayment;
            }

            Console.WriteLine($"Общая выплата составит->{sum:#.##} Руб.");
        }


        public void AnnuityPayments()
        {
            decimal sum = 0;
            decimal monthlyPayment;

            decimal koef = 0.01m + ((decimal)Procent/(decimal)12) / (((decimal)(Math.Pow((1 + Procent/12), (double)this.Period)) - 1));

            Console.WriteLine("Выплаты по месяцам:");

            for (int i = 1; i <= Period; i++)
            {
                monthlyPayment = (decimal)RequiredAmount * koef;

                Console.WriteLine($"{i} месяц ->{monthlyPayment:#.##}");

                sum += monthlyPayment;
            }
            Console.WriteLine($"Общая выплата составит->{sum:#.##} Руб.");
        }

    }
}
