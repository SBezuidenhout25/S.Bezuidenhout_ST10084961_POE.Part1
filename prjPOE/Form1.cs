using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjPOE
{
    public partial class Form1 : Form
    {
        //Array to store expenses
        double[] expenses = new double[5];
        double income, price, deposit, interest, months;

        public Form1()
        {
            InitializeComponent();
        }

       //Method checks if buy radio butten is selected and
       //makes the required changes to the form, (Only makes
       //relevant text boxes visible)
        private void rbtBuy_CheckedChanged(object sender, EventArgs e)
        {
            lblPriceRent.Text = "Purchase Price:";
            lblPriceRent.Visible = true;
            txtPriceRent.Visible = true;

            lblDeposit.Visible = true;
            txtDeposit.Visible = true;
            lblInterest.Visible = true;
            txtInterest.Visible = true;
            lblMonths.Visible = true;
            txtMonths.Visible = true;
        }

        //Method checks if buy radio butten is selected and
        //makes the required changes to the form, (Only makes
        //relevant text boxes visible)
        private void rbtRent_CheckedChanged(object sender, EventArgs e)
        {
            lblPriceRent.Text = "Monthly Rent:";
            lblPriceRent.Visible = true;
            txtPriceRent.Visible = true;
            

            lblDeposit.Visible = false;
            txtDeposit.Visible = false;
            lblInterest.Visible = false;
            txtInterest.Visible = false;
            lblMonths.Visible = false;
            txtMonths.Visible = false;           
        }

        //Runs when calculate button is clicked
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            addValues();

            //If checks which radio button option is selected
            //and sets values to the applied class
            if (rbtBuy.Checked == true)
            {
                Expense buy = new HomeLoan();
                buy.income = income;
                buy.expenses = expenses;
                buy.deposit = deposit;
                buy.interest = interest;
                buy.months = months;
                buy.calculate(price);

                //Displays the output
                lblOutput.Text = buy.ToString();
            }
            else if (rbtRent.Checked == true)
            {
                Expense rent = new Rent();
                rent.income = income;
                rent.expenses = expenses;
                rent.calculate(price);
               
                //Display the output
                lblOutput.Text = rent.ToString();
            }
            //Only runs if the user has not selected to buy or rent
            else
            {
                MessageBox.Show("Please select if you are renting or buying a property.");
            }
        }

        //Method stores user input
        private void addValues()
        {
            var error = checkInput();

            //Try Catch to store input and throw exceptions
            //depending on error type
            try
            {
                if (error == true)
                {
                    throw new ArgumentNullException();
                }
                price = Convert.ToDouble(txtPriceRent.Text);
                income = Convert.ToDouble(txtIncome.Text);
                expenses[0] = Convert.ToDouble(txtGroceries.Text);
                expenses[1] = Convert.ToDouble(txtWaterLights.Text);
                expenses[2] = Convert.ToDouble(txtTravel.Text);
                expenses[3] = Convert.ToDouble(txtPhone.Text);
                expenses[4] = Convert.ToDouble(txtOther.Text);

                lblOutput.Visible = true;

                //If statement stores buy values only if buy 
                //option is selected
                if (rbtBuy.Checked == true)
                {
                    deposit = Convert.ToDouble(txtDeposit.Text);
                    interest = Convert.ToDouble(txtInterest.Text) / 100;
                    months = Convert.ToDouble(txtMonths.Text);
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Please enter all fields");
                lblOutput.Visible = false;
            }
            catch(FormatException)
            {
                MessageBox.Show("Please only enter numeric values");
                lblOutput.Visible = false;
            }
            
        }

        //Method checks user input for errors and changes
        //color of text boxes with missing input
        private bool checkInput()
        {
            var error = false;
            foreach(TextBox t in Controls.OfType<TextBox>())
            {
                if (t.TextLength == 0 && t.Visible == true)
                {
                    error = true;
                    t.BackColor = Color.Tomato;
                }
                else
                {
                    t.BackColor = Color.White;
                }
            }
            return error;           
        }
    }
}
