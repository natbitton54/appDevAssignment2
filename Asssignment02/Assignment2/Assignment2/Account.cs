using System;

namespace Assignment2
{
    internal class Account
    {
        private string accNumber;
        private decimal accBalance;
        private string lastName;
        private string firstName;

        public Account(string accNumber, decimal accBalance, string lastName, string firstName)
        {
            AccNumber = accNumber;
            Balance = accBalance;
            LastName = lastName;
            FirstName = firstName;
        }

        public Account() { }


        public string AccNumber
        {
            get
            {
                return accNumber;
            }
            set
            {
                accNumber = value;
            }
        }
        public decimal Balance
        {
            get
            {
                return accBalance;
            }
            set
            {
                if (value >= 0.0m) 
                {
                    accBalance = value;
                }
                else
                {
                    accBalance = 0.0m;
                    Console.WriteLine("Account initial balance amount should be a positive value.");
                }
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }


        public virtual decimal Credit(decimal amount)
        {
            return Balance += amount;
        }

        public virtual bool Debit(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }

            {
                Console.WriteLine("Debit amount exceeded account balance.");
                return false;
            }
        }
        public virtual void DisplayAccount()
        {
            DrawLine();
            Console.WriteLine($"| {"Account",36} {"|",43}");
            DrawLine();
            Console.WriteLine($"| {"Account Number",-15} | {AccNumber,60} |");
            DrawLine();
            Console.WriteLine($"| {"Balance Amount",-15} | {"$" + Balance,60} |");
            DrawLine();
            Console.WriteLine($"| {"Last Name",-15} | {LastName,-60} |");
            DrawLine();
            Console.WriteLine($"| {"First Name",-15} | {FirstName,-60} |");
            DrawLine();
        }

        public static void DrawLine()
        {
            Console.Write("|");
            for (int i = 0; i < 80; i++)
                Console.Write("-");
            Console.WriteLine("|");
        }
    }
}