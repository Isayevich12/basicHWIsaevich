using System;
using System.Collections.Generic;
using System.Text;

namespace BasicHomeWork2
{
    enum TypePayment
    {
        AnnuityPayments = 1,
        DifferentiatedPayment,

    }

    class CreditConsultant
    {
        private CreditCalculator CreditCalculator { get; set; }

        private event Action BeginCalculate;

        public CreditConsultant()
        {

        }

        public void Meth()
        {
            Console.WriteLine("hello");
        }

        public void CalculateCredit()
        {
            Console.WriteLine("Введите сумму кредита:");
            string requiredAmount = Console.ReadLine();
            Console.WriteLine("Выберите процентную ставку:");
            string procent = Console.ReadLine();

            try
            {
                this.CreditCalculator = new CreditCalculator(int.Parse(requiredAmount), int.Parse(procent));

                Action del1 = this.CreditCalculator.AnnuityPayments;
                Action del2 = this.CreditCalculator.DifferentiatedPayment;
                Action del3 = () => { Console.WriteLine("Нет такого кредита!!!"); };

                Console.WriteLine(@"Введите тип кредита  
 1- Аннуитетный  2 - Диффупенцированный ");

                bool type = int.TryParse(Console.ReadLine(), out int typeCred);              

                BeginCalculate += (TypePayment)typeCred == TypePayment.AnnuityPayments ? del1 : (TypePayment)typeCred == TypePayment.DifferentiatedPayment ? del2 : del3;

                // Это то же самое, но вообще не читаемо как по мне
                //BeginCalculate += (TypePayment)typeCred == TypePayment.AnnuityPayments ? new Action(this.CreditCalculator.AnnuityPayments) : (TypePayment)typeCred == TypePayment.DifferentiatedPayment ? new Action(this.CreditCalculator.DifferentiatedPayment) : (delegate() { Console.WriteLine("Нет такого кредита!!!"); });

                BeginCalculate.Invoke();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message); ;
            }
        }

    }
}
