using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOfKurtovoKonare
{
    class MainClass
    {
        static void Main(string[] args)
        {
            Deposit first= new Deposit(new Customer("Ivan", "Ivanov", AccountType.Individuals), 1500, 0.05m);
            Deposit second = new Deposit(new Customer("Petar", "Petrov", AccountType.Individuals), 2500, 0.02m);
            Loan third = new Loan(new Customer("Kiril", "Kirilov", AccountType.Individuals), 3650, 0.03m);
            Loan fourth = new Loan(new Customer("Dimitar", "Dimitrov", AccountType.Companies), 13650, 0.01m);
            Mortgage fifth = new Mortgage(new Customer("Stoian", "Stoianov", AccountType.Companies), 33650, 0.01m);
            first.CalcInterestRate(9);
            fourth.CalcInterestRate(7);
            Console.WriteLine(first.Balance);
            Console.WriteLine(fourth.Balance);
            fourth.DepositMoney(600);
            Console.WriteLine(fourth.Balance);
            Console.WriteLine(fifth.Balance);
            fifth.CalcInterestRate(9);
            Console.WriteLine(fifth.Balance);
            fifth.DepositMoney(25000);
            Console.WriteLine(fifth.Balance);
        }
    }
}
