using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjPOE
{
    class HomeLoan : Expense
    {
        //Only required variables in child class
        double totalLoan;
        double monthlyPayment = 0;

        //Method calculates loan value, monthly payments and
        //available money after deductions 
        public override void calculate(double price)
        {
            availableMoney = income;

            for (int x = 0; x < expenses.Length; x++)
            {
                availableMoney -= expenses[x];
            }

            totalLoan = (price - deposit) * (1 + interest * (months / 12));
            monthlyPayment = (totalLoan / months);
            availableMoney -= monthlyPayment;
        }

        //ToString method to return an output string
        public override string ToString()
        {
            String strOutput = "Available: R" + Math.Round(availableMoney,2) +
                "\nMonthly Payments: R " + Math.Round(monthlyPayment,2);

            if (monthlyPayment > (income * 0.33))
            {
                strOutput += "\nYour home loan approval is unlikely";
            }

            return strOutput;
        }
    }
}
