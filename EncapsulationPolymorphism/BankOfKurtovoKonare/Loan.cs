namespace BankOfKurtovoKonare
{
    class Loan : Account
    {
        public Loan(Customer customer, decimal balance, decimal interestRate)
        {
            base.Customer = customer;
            base.Balance = balance;
            base.InterestRate = interestRate;
        }

        public override void CalcInterestRate(int months)
        {
            switch (base.Customer.Type)
            {
                case AccountType.Individuals:
                    months -= 3;
                    break;
                case AccountType.Companies:
                    months -= 2;
                    break;
            }
            if (months < 0)
            {
                months = 0;
            }
            base.Balance-= base.Balance * (1 + base.InterestRate * months);           
        }   
    }
}
