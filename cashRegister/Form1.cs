using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace cashRegister
{
    public partial class Form1 : Form
    {
        //global variables
        double cookiePrice = 5.25;
        double cupcakePrice = 8.50;
        double piePrice = 15;
        double numOfcookies = 0;
        double numOfCupcakes = 0;
        double numOfPies = 0;
        double subTotal = 0;
        double taxRate = 0.13;
        double taxAmount = 0.00;
        double totalAmount = 0;
        double tendered = 0;
        double change = 0;

        public Form1()
        {
            InitializeComponent();
        }


        private void calcTotalButton_Click(object sender, EventArgs e)
        {
            try
            {
                // convert number varaibles to doubles
                numOfcookies = Convert.ToDouble(numOfCookiesInput.Text);
                numOfCupcakes = Convert.ToDouble(numOfCupcakesInput.Text);
                numOfPies = Convert.ToDouble(numOfPiesInput.Text);

                // calculate Subtotal, tax Amount and total
                subTotal = numOfcookies * cookiePrice + numOfCupcakes * cupcakePrice + numOfPies * piePrice;
                taxAmount = taxRate * subTotal;
                totalAmount = subTotal + taxAmount;

                //output totals
                subtotalOutput.Text = $"{subTotal.ToString("C")}";
                taxOutput.Text = $"{taxAmount.ToString("C")}";
                totalOutput.Text = $"{totalAmount.ToString("C")}";

                //enable button
                calcChangeButton.Enabled = true;
                printRecieptButton.Enabled = false;
                newOrderButton.Enabled = false;
            }
            catch
            {
                numOfCookiesInput.Text = "Error";
                numOfCupcakesInput.Text = "Error";
                numOfPiesInput.Text = "Error";
            }

        }

        private void calcChangeButton_Click(object sender, EventArgs e)
        {
            try
            {
                //convert to double
                tendered = Convert.ToDouble(tenderedInput.Text);

                // calculate change
                change = tendered - totalAmount;

                // output change amount
                changeOutput.Text = $"{change.ToString("C")}";

                //enable buttons
                calcTotalButton.Enabled = true;
                calcChangeButton.Enabled = true;
                printRecieptButton.Enabled = true;
                newOrderButton.Enabled = false;
            }
            //if letters put in display "Error"
            catch
            {
                tenderedInput.Text = "Error";
            }

        }

        private void printRecieptButton_Click(object sender, EventArgs e)
        {

            SoundPlayer alertPlayer = new SoundPlayer(Properties.Resources.printing_noise);
            alertPlayer.Play();

            //print reciept
            recieptOutput.Text = $"      La Patisserie";
            Refresh();
            Thread.Sleep(400);
            recieptOutput.Text += $"\n\nOrder Number 2006";
            Refresh();
            Thread.Sleep(400);
            recieptOutput.Text += $"\nOctober 4th, 2022";
            Refresh();
            Thread.Sleep(400);
            recieptOutput.Text += $"\n\nCookies    x{numOfcookies}@ {cookiePrice.ToString("C")}";
            Refresh();
            Thread.Sleep(400);
            recieptOutput.Text += $"\nCupcakes   x{numOfCupcakes}@ {cupcakePrice.ToString("C")}";
            Refresh();
            Thread.Sleep(400);
            recieptOutput.Text += $"\nPies       x{numOfPies}@ {piePrice.ToString("C")}";
            Refresh();
            Thread.Sleep(400);
            recieptOutput.Text += $"\n\nSubtotal       {subTotal.ToString("C")}";
            Refresh();
            Thread.Sleep(400);
            recieptOutput.Text += $"\nTax            {taxAmount.ToString("C")}";
            Refresh();
            Thread.Sleep(400);
            recieptOutput.Text += $"\nTotal          {totalAmount.ToString("C")}";
            Refresh();
            Thread.Sleep(400);
            recieptOutput.Text += $"\n\nTendered       {tendered.ToString("C")}";
            Refresh();
            Thread.Sleep(400);
            recieptOutput.Text += $"\nChange         {change.ToString("C")}";
            Refresh();
            Thread.Sleep(400);
            recieptOutput.Text += $"\n\n   Have a Nice day!!:)";
            Refresh();
            Thread.Sleep(400);

            //enable button
            calcTotalButton.Enabled = true;
            calcChangeButton.Enabled = true;
            printRecieptButton.Enabled = true;
            newOrderButton.Enabled = true;





        }

        private void newOrderButton_Click(object sender, EventArgs e)
        {
            //clear amount in inputs
            numOfCookiesInput.Text = $"";
            numOfCupcakesInput.Text = $"";
            numOfPiesInput.Text = $"";
            tenderedInput.Text = $"";

            //clear totals
            subtotalOutput.Text = $"";
            taxOutput.Text = $"";
            totalOutput.Text = $"";

            //clear change and tendered
            tendered = 0;
            changeOutput.Text = $"";

            //clear Varaibles
            numOfcookies = 0;
            numOfCupcakes = 0;
            numOfPies = 0;
            subTotal = 0;
            taxAmount = 0;
            totalAmount = 0;
            tendered = 0;
            change = 0;

            //clear reciept output
            recieptOutput.Text = $"";

        }
    }
}
