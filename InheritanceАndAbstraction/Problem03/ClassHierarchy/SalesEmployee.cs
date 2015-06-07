using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem03
{
    internal class SalesEmployee : RegularEmployee, ISalesEmployee
    {
        private List<Sale> sales;

        public SalesEmployee(string firstName, string lastName, long id, decimal salary, Departments department,List<Sale>sales)
            : base(firstName, lastName, id, salary, department)
        {
            this.Sales = sales;
        }

        public List<Sale> Sales
        {
            get { return this.sales; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException();
                }
                this.sales = value;
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Sales:");
            foreach (var sale in sales)
            {
                sb.AppendLine(sale.ToString());
            }
            return base.ToString() + sb.ToString();
        }
    }
}
