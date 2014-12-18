using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _06.Calculator
{
    public partial class Calculator : System.Web.UI.Page
    {
        private static double result = 0;
        private static string operation = string.Empty;
        private static bool isNew = false;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Number_Command(object sender, CommandEventArgs e)
        {
            if (isNew)
            {
                this.Screen.Text = string.Empty;
                isNew = false;
            }

            this.Screen.Text += e.CommandName;
        }

        protected void Operation_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "sqrt")
            {
                if (this.Screen.Text == string.Empty)
                {
                    this.Screen.Text = "0";
                }

                result = Math.Sqrt(double.Parse(this.Screen.Text));
            }
            else
            {
                switch (operation)
                {
                    case "+":
                        result += double.Parse(this.Screen.Text);
                        break;
                    case "-":
                        result -= double.Parse(this.Screen.Text);
                        break;
                    case "X":
                        result *= double.Parse(this.Screen.Text);
                        break;
                    case "/":
                        result /= double.Parse(this.Screen.Text);
                        break;
                    default:
                        if (this.Screen.Text != string.Empty)
                        {
                            result = double.Parse(this.Screen.Text);
                        }
                        else
                        {
                            result = 0;
                        }

                        break;
                }

                operation = e.CommandName;
            }

            this.Screen.Text = result.ToString();
            isNew = true;
        }

        protected void Equals_Click(object sender, EventArgs e)
        {
            if (this.Screen.Text == string.Empty)
            {
                this.Screen.Text = "0";
            }
            var operand = double.Parse(this.Screen.Text);
            switch (operation)
            {
                case "+":
                    this.Screen.Text = (result + operand).ToString();
                    break;
                case "-":
                    this.Screen.Text = (result - operand).ToString();
                    break;
                case "X":
                    this.Screen.Text = (result * operand).ToString();
                    break;
                case "/":
                    this.Screen.Text = (result / operand).ToString();
                    break;
            }

            result = 0;
            operation = string.Empty;
            isNew = true;
        }

        protected void Clear_Click(object sender, EventArgs e)
        {
            result = 0;
            operation = string.Empty;
            this.Screen.Text = string.Empty;
        }
    }
}