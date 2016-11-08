using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengePostalCalculatorHelperMethodsV2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void widthTextBox_TextChanged(object sender, EventArgs e)
        {
            executeFunctions();
        }

        protected void heightTextBox_TextChanged(object sender, EventArgs e)
        {
            executeFunctions();
        }

        protected void lengthTextBox_TextChanged(object sender, EventArgs e)
        {
            executeFunctions();
        }

        protected void groundRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            executeFunctions();
        }

        protected void airRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            executeFunctions();
        }

        protected void nextDayRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            executeFunctions();
        }

        private void executeFunctions()
        {
            double packageVolume = calculatePackageVolume();
            double shippingMultiplier = getShippingMethodMultiplier();
            double price = packageVolume * shippingMultiplier;

            printResult(price);
        }

        private double calculatePackageVolume()
        {
            double width = 1;
            double height = 1;
            double length = 1;

            double.TryParse(this.widthTextBox.Text, out width);
            double.TryParse(this.heightTextBox.Text, out height);
            double.TryParse(this.lengthTextBox.Text, out length);

            double volume = width * height * length;

            return volume;
        }

        private double getShippingMethodMultiplier()
        {
            if (this.groundRadioButton.Checked) return .15;
            else if (this.groundRadioButton.Checked) return .25;
            else return .45;
        }

        private void printResult(double price)
        {
            this.resultLabel.Text = String.Format("It will cost {0:C} to ship your package.", price);
        }
    }
}