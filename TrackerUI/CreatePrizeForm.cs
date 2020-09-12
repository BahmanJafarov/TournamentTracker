using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        IPrizeRequester callingForm;
        public CreatePrizeForm(IPrizeRequester caller)
        {
            InitializeComponent();

            callingForm = caller;
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                var model = new PrizeModel(
                    placeNameValueTextBox.Text, 
                    placeNumberValueTextBox.Text, 
                    prizeAmountValueTextBox.Text, 
                    prizePercentageValueTextBox.Text);

                GlobalConfig.Connection.CreatePrize(model);

                callingForm.PrizeComplete(model);

                this.Close();
                //placeNameValueTextBox.Text = "";
                //placeNumberValueTextBox.Text = "";
                //prizeAmountValueTextBox.Text = "0";
                //prizePercentageValueTextBox.Text = "0";
            }
            else
            {
                MessageBox.Show("This form has invalid information.");
            }
        }

        private bool ValidateForm()
        {
            bool output = true;

            bool placeNumberValid = int.TryParse(placeNumberValueTextBox.Text, out int placeNumber);

            if (placeNumberValid == false)
            {
                output = false;
            }

            if (placeNumber < 1)
            {
                output = false;
            }

            if (placeNameValueTextBox.Text.Length == 0)
            {
                output = false;
            }

            bool prizeAmountValid = decimal.TryParse(prizeAmountValueTextBox.Text, out decimal prizeAmount);
            bool prizePercentageValid = double.TryParse(prizePercentageValueTextBox.Text, out double prizePercentage);

            if (prizeAmountValid == false || prizePercentageValid == false)
            {
                output = false;
            }

            if (prizeAmount <= 0 && prizePercentage <= 0)
            {
                output = false;
            }

            if (prizePercentage < 0 || prizePercentage > 100)
            {
                output = false;
            }

            return output;
        }
    }
}
