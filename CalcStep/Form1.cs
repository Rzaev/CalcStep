using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalcStep
{
    public partial class Form1 : Form
    {
        int lastIsOperator = -1; //0-operator,1-eded
        int select = 0;
        double total = 0;
        bool firstTotal = true;
        bool isOperator = false;
        bool firstLabel = true;
        bool isEqual = false;
        bool enter = false;
        //bool myqueue = true;
        //bool firstme = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void NumberClick(object sender, EventArgs e)
        {
            

            isEqual = false;
            isOperator = false;
            if (sender is Button button)
            {
                if (lastIsOperator == -1)
                {
                    ResultTxt.Clear();
                }
                lastIsOperator = 1;
                ResultTxt.Text += button.Text;

                //Random random = new Random();
                //double value = (random.NextDouble() * (9999.99 - 0.99) + 0.99);
                //double b = Math.Round(value, 2, MidpointRounding.ToEven);



                //if (firstme)
                //    ResultTxt.Text += button.Text;
                //else if (myqueue)
                //{
                //    ResultTxt.Text += button.Text;
                //    myqueue = false;
                //}
                //else if (myqueue == false)
                //    ResultTxt.Text = total.ToString();


                //if (lastIsOperator == -1)
                //    total += Double.Parse(button.Text);


                //isOperator = false;
                //ResultTxt.Text += total;
                //ResultTxt.Text += button.Text;

            }

        }

        private void OperatorsClick(object sender, EventArgs e)
        {
           
            if (ResultTxt.Text != string.Empty)
            {

                //isEqual = false;

                lastIsOperator = -1;
                //firstme = false;

                if (sender is Button button)
                {
                    if (isOperator == false)
                    {

                        CalculateTotal();
                        firstTotal = false;
                        CallOperator(button);
                        isOperator = true;

                        //iki setir sonradan
                        ResultTxt.Clear();
                        ResultTxt.Text = total.ToString();
                    }
                    //if(lastIsOperator == 1)
                    //{
                    //    CallOperator(button);

                    //    lastIsOperator = 0;
                    //}
                }


            }

            //CalculateTotal();
            //lastIsOperator = -1;
            //firstTotal = false;
            //if (sender is Button button)
            //{
            //    if(isOperator==false)
            //    {
            //        CallOperator(button);
            //        isOperator = true;
            //    }
            //    //if(lastIsOperator == 1)
            //    //{
            //    //    CallOperator(button);

            //    //    lastIsOperator = 0;
            //    //}
            //}
        }





        #region Functions

        private void CallOperator(Button button)
        {

            ResultLbl.Text = "";
            if (firstLabel)
                ResultLbl.Text = ResultTxt.Text + button.Text;
            else if (firstLabel == false)
                ResultLbl.Text = total.ToString() + button.Text;


            if (button.Text == "+")
                select = 1;
            else if (button.Text == "-")
                select = 2;
            else if (button.Text == "*")
                select = 3;
            else
                select = 4;

            firstLabel = false;
            //ResultLbl.Text += ResultTxt.Text;
            //ResultLbl.Text += button.Text;
        }

        private void CalculateTotal()
        {
            if (Double.Parse(ResultTxt.Text) < 0 && enter==false)
            {
                ResultTxt.Text = (-Double.Parse(ResultTxt.Text)).ToString();
               
            }


            //if (firstTotal && enter==true)
            //{
            //    total -= Double.Parse(ResultTxt.Text);
            //    ResultTxt.Text = (-Double.Parse(ResultTxt.Text)).ToString();
            //}
            //if (firstTotal && enter==false)
            //    total += Double.Parse(ResultTxt.Text);


            if (firstTotal)
                total += Double.Parse(ResultTxt.Text);


            else if (select == 1)
                total += Double.Parse(ResultTxt.Text);
            else if (select == 2)
                total -= Double.Parse(ResultTxt.Text);
            else if (select == 3 && isEqual == false)
                total *= Double.Parse(ResultTxt.Text);
            else if(select==3 && isEqual==true)
            {
                total += Double.Parse(ResultTxt.Text);
            }
            else
            {
                total /= Double.Parse(ResultTxt.Text);
                int a;
            }
            //if (ResultTxt.Text == "∞")
            //{
            //    ResultTxt.Clear();
            //    ResultLbl.Text = "";
            //    Application.Exit();
            //}
            //if(total==Double.NaN)
            //{
            //    ResultTxt.Clear();
            //    ResultLbl.Text = "";
            //    Application.Exit();
            //}
            if (Double.IsInfinity(total))
            {
                ResultTxt.Clear();
                ResultLbl.Text = "";
                Application.Exit();
            }

        }

        #endregion

        private void DotBtn_Click(object sender, EventArgs e)
        {
            isEqual = false;
            if (ResultTxt.Text != string.Empty && !ResultTxt.Text.Contains(","))
            {
                ResultTxt.Text += ".";
            }
        }

        private void CBtn_Click(object sender, EventArgs e)
        {
            enter = false;
            isEqual = false;
            ResultTxt.Clear();
            ResultLbl.Text = "";
            total = 0;
        }

        private void BackSpaceBtn_Click(object sender, EventArgs e)
        {
            isEqual = false;
            if (ResultTxt.Text != "")
            {
                ResultTxt.Text = ResultTxt.Text.Substring(0, ResultTxt.Text.Length - 1);
                // ResultLbl.Text = ResultLbl.Text.Substring(0, ResultLbl.Text.Length - 1);
            }


            /////sehvdise silim sonradan yazmisam
            if(ResultTxt.Text=="")
            {
                ResultLbl.Text ="";
                total = 0;
                enter = false;
            }
        }

        private void EqualBtn_Click(object sender, EventArgs e)
        {
            enter = false;
            if (isEqual == false)
            {
                if (ResultTxt.Text != string.Empty)
                {
                    ResultLbl.Text = "";
                    CalculateTotal();
                    ResultTxt.Text = total.ToString();
                    total = 0;
                    isEqual = true;
                }

            }
        }

        private void PosNegBtn_Click(object sender, EventArgs e)
        {
            if (ResultTxt.Text != string.Empty)
            {
                if (Double.Parse(ResultTxt.Text) > 0)
                {
                    ResultTxt.Text = (-Double.Parse(ResultTxt.Text)).ToString();
                }
                else if (Double.Parse(ResultTxt.Text) < 0)
                {
                    ResultTxt.Text = (-Double.Parse(ResultTxt.Text)).ToString();
                }
                enter = true;
            }
        }
    }
}
