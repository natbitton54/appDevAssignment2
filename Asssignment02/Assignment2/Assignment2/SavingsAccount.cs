using System;

namespace Assignment2
{
    internal class SavingsAccount : Account
    {
        private decimal interestRate;

        public SavingsAccount(decimal interestRate, string accNumber, decimal accBalance, string lastName, string firstName)
            : base(accNumber, accBalance, lastName, firstName)
        {
            InterestRate = interestRate;
        }

        public SavingsAccount() { }

        public decimal InterestRate
        {
            get
            {
                return interestRate;
            }
            set
            {
                interestRate = value > 0.0m ? value : 0.05m;
                if (value <= 0.0m) Console.WriteLine("Interest rate should be a positive number.");
            }
        }


        public decimal CalculateInterestRate()
        {

            decimal rateInDecimal = InterestRate / 100;
            return Math.Round(Balance * rateInDecimal, 2);
        }

        public override void DisplayAccount()
        {
            DrawLine();
            Console.WriteLine($"| {"Saving Account",36} {"|",43}");
            DrawLine();
            Console.WriteLine($"| {"Account Number",-15} | {AccNumber,60} |");
            DrawLine();
            Console.WriteLine($"| {"Balance Amount",-15} | {"$" + Balance,60} |");
            DrawLine();
            Console.WriteLine($"| {"Last Name",-15} | {LastName,-60} |");
            DrawLine();
            Console.WriteLine($"| {"First Name",-15} | {FirstName,-60} |");
            DrawLine();
            Console.WriteLine($"| {"Interest Rate",-15} | {"$" + InterestRate,60} |");
            DrawLine();
            Console.WriteLine($"| {"Interest Amount",-15} | {"$" + CalculateInterestRate(),60} |");
            DrawLine();
        }

    }
}
