using System;
using System.Globalization;

namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // created all object for savings checking and account
            //Account account = new Account("6205857", 1000.0m, "Bitton", "Nathaniel David");
            //account.DisplayAccount();
            //SavingsAccount savings = new SavingsAccount(1.50m, "6205857", 15000.0m, "Bitton", "Nathaniel David");
            //savings.DisplayAccount();
            //CheckingAccount chequing = new CheckingAccount(1.50m, "6205857", 25000.0m, "Bitton", "Nathaniel David");
            //chequing.DisplayAccount();

            Console.WriteLine("Press 1 for Chequing or 2 for Savings");

            if (Console.ReadLine().Equals("1"))
            {
                CheckingAccount cheq = CreateChequingAccount();
                DisplayAccountInfo(cheq); // Display initial state

                Console.WriteLine("Enter deposit amount:");
                decimal depositAmounts = decimal.Parse(Console.ReadLine());
                Console.WriteLine("\nDepositing...\n");
                cheq.Credit(depositAmounts);
                Console.WriteLine($"Deposit Successful. ${depositAmounts} has been added.");
                DisplayAccountInfo(cheq); // Should now display the updated balance

                Console.WriteLine("Please Enter Withdrawal Amount:");
                decimal withDrawAmount = decimal.Parse(Console.ReadLine());
                Console.WriteLine("\nAttempting to withdraw...\n");
                if (cheq.Debit(withDrawAmount))
                {
                    Console.WriteLine($"Withdrawal Successful. ${withDrawAmount} has been withdrawn.");
                }
                else
                {
                    Console.WriteLine("Withdrawal Failed. Insufficient funds.");
                }
                DisplayAccountInfo(cheq); // Display after withdrawal

            }
            else
            {
                SavingsAccount saving = CreateSavingsAccount();
                DisplayAccountInfo(saving); // Display initial state

                Console.WriteLine("Enter deposit amount:");
                decimal depositAmounts = decimal.Parse(Console.ReadLine());
                Console.WriteLine("\nDepositing...\n");
                saving.Credit(depositAmounts);
                Console.WriteLine($"Deposit Successful. ${depositAmounts} has been added.");
                DisplayAccountInfo(saving); // Should now display the updated balance

                Console.WriteLine("Please Enter Withdrawal Amount:");
                decimal withDrawAmounts = decimal.Parse(Console.ReadLine());
                Console.WriteLine("\nAttempting to withdraw...\n");
                if (saving.Debit(withDrawAmounts))
                {
                    Console.WriteLine($"Withdrawal Successful. ${withDrawAmounts} has been withdrawn.");
                }
                else
                {
                    Console.WriteLine("Withdrawal Failed. Insufficient funds.");
                }
                DisplayAccountInfo(saving); // Display after withdrawal

            }
        }

        static CheckingAccount CreateChequingAccount()
        {
            Console.WriteLine("Please Enter Account Number:");
            string accNumber = Console.ReadLine();

            Console.WriteLine("Please Enter Account Balance:");
            decimal accBalance = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Please Enter Last Name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Please Enter First Name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Please Enter Transaction Fee:");
            decimal transactionFee = decimal.Parse(Console.ReadLine());

            return new CheckingAccount(transactionFee, accNumber, accBalance, lastName, firstName);
        }

        static SavingsAccount CreateSavingsAccount()
        {
            Console.WriteLine("Please Enter Account Number:");
            string accNumber = Console.ReadLine();

            Console.WriteLine("Please Enter Account Balance:");
            decimal accBalance = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Please Enter Last Name:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Please Enter First Name:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Please Enter Interest Rate:");
            decimal interestRate = decimal.Parse(Console.ReadLine());

            return new SavingsAccount(interestRate, accNumber, accBalance, lastName, firstName);
        }

        static void DisplayAccountInfo(Account account)
        {
            if (account is CheckingAccount)
            {
                DrawLine();
                Console.WriteLine($"| {"Checking Account",36} {"|",43}");
            } else if (account is SavingsAccount)
            {
                DrawLine();
                Console.WriteLine($"| {"Savings Account",36} {"|",43}");
            }
                DrawLine();
            Console.WriteLine($"| {"Account Number",-15} | {account.AccNumber,60} |");
            DrawLine();
            Console.WriteLine($"| {"Balance Amount",-15} | {"$" + account.Balance,60} |");
            DrawLine();
            Console.WriteLine($"| {"Last Name",-15} | {account.LastName,-60} |");
            DrawLine();
            Console.WriteLine($"| {"First Name",-15} | {account.FirstName,-60} |");
            DrawLine();

            if (account is CheckingAccount cheq)
            {
                Console.WriteLine($"| {"Transaction Fee",-15} | {"$" + cheq.TransactionFee,60} |");
                DrawLine();
            }
            else if (account is SavingsAccount saving)
            {
                Console.WriteLine($"| {"Interest Rate",-15} | {"$" + saving.InterestRate, 60} |");
                DrawLine();
                Console.WriteLine($"| {"Interest Amount",-15} | {"$" + saving.CalculateInterestRate(),60} |");
                DrawLine();
            }
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