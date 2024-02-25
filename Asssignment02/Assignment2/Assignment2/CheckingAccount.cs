using System;

namespace Assignment2
{
    internal class CheckingAccount : Account
    {
        private decimal transactionFee;
        public CheckingAccount(decimal transactionFee, string accNumber, decimal accBalance, string lastName, string firstName)
            : base(accNumber, accBalance, lastName, firstName)
        {
            TransactionFee = transactionFee;
        }

        public CheckingAccount() { }

        public decimal TransactionFee
        {
            get
            {
                return transactionFee;
            }
            set
            {
                transactionFee = value > 0.0m ? value : 1.5m;
                if (value <= 0.0m) Console.WriteLine("Transaction Fee should be a positive value.");
            }
        }

        public override decimal Credit(decimal amount)
        {
            base.Credit(amount);
            return Balance -= TransactionFee;
        }

        public override bool Debit(decimal amount)
        {
            bool success = base.Debit(amount);
            if (success)
            {
                if (Balance >= TransactionFee)
                {
                    Balance -= TransactionFee;
                }
                else
                {
                    Console.WriteLine("Insufficient funds to cover the transaction fee after withdrawal.");
                }
            }
            return success;
        }

        public override void DisplayAccount()
        {
            DrawLine();
            Console.WriteLine($"| {"Checking Account",36} {"|",43}");
            DrawLine();
            Console.WriteLine($"| {"Account Number",-15} | {AccNumber,60} |");
            DrawLine();
            Console.WriteLine($"| {"Balance Amount",-15} | {"$" + Balance,60} |");
            DrawLine();
            Console.WriteLine($"| {"Last Name",-15} | {LastName,-60} |");
            DrawLine();
            Console.WriteLine($"| {"First Name",-15} | {FirstName,-60} |");
            DrawLine();
            Console.WriteLine($"| {"Transaction Fee",-15} | {"$" + TransactionFee,60} |");
            DrawLine();
        }
    }
}
