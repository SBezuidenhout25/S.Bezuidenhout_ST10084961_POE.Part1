using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjPOE
{
    public abstract class Expense
    {
        //Required variables for the abstract class
        public double[] expenses;
        public double availableMoney;
        public double income;
        public double deposit;
        public double interest;
        public double months;
        
        //Relevent getter and setter methods for variables
        private double[] Expenses { get => expenses; set => expenses = value; }
        private double Income { get => income; set => income = value; }
        private double Deposit { get => deposit; set => deposit = value; }
        private double Interest { get => interest; set => interest = value; }
        private double Months { get => months; set => months = value; }

        //Methods that are to be overrided in child classes
        public abstract void calculate(double price);
        public abstract string ToString();       
    }
}
