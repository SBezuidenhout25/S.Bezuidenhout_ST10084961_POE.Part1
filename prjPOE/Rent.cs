using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjPOE
{
    class Rent : Expense
    {
        //Method calculates the remaining money after expenses
        public override void calculate(double price)
        {
            availableMoney = income - price;

            for (int x = 0; x < expenses.Length; x++)
            {
                availableMoney -= expenses[x];
            }
        }

        //Method returns a string for output
        public override string ToString()
        {
            String strDisplay = ("Money available = R" + Math.Round(availableMoney,2));
            return strDisplay;
        }

    }
}
