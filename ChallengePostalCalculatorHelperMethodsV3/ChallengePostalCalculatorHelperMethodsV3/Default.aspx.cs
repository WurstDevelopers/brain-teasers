using System;

namespace ChallengePostalCalculatorHelperMethodsV3
{

    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void widthTextBox_TextChanged(object sender, EventArgs e)
        {
            this.arrangeFunctionCalls();
        }

        protected void heightTextBox_TextChanged(object sender, EventArgs e)
        {
            this.arrangeFunctionCalls();
        }

        protected void lengthTextBox_TextChanged(object sender, EventArgs e)
        {
            this.arrangeFunctionCalls();
        }

        protected void groundRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.arrangeFunctionCalls();
        }

        protected void airRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.arrangeFunctionCalls();
        }

        protected void nextDayRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.arrangeFunctionCalls();
        }

        private void arrangeFunctionCalls()
        {
            double width;
            double height;
            double length;

            //check if values exist
            if (!double.TryParse(this.widthTextBox.Text, out width)) return;
            if (!double.TryParse(this.heightTextBox.Text, out height)) return;
            if (!double.TryParse(this.lengthTextBox.Text, out length)) length = 1;

            if (this.checkSelectedShippingMethod())
            {
                double productVolume = this.calculateProductVolume(width, height, length);
                double costToShip = this.calculateCostToShip(productVolume);
                this.printCostToShip(costToShip);
            };
        }

        private double calculateProductVolume(double width, double height, double length)
        {
            double volume = width * height * length;
            return volume;
        }

        private bool checkSelectedShippingMethod()
        {
            bool shippingMethodSelected;

            if (this.groundRadioButton.Checked || this.airRadioButton.Checked || this.nextDayRadioButton.Checked) shippingMethodSelected = true;
            else shippingMethodSelected = false;

            return shippingMethodSelected;
        }

        private double calculateCostToShip(double productVolume)
        {
            double multiplier;

            if (this.groundRadioButton.Checked) multiplier = .15;
            else if (this.airRadioButton.Checked) multiplier = .25;
            else multiplier = .45;

            return productVolume * multiplier;
        }

        private void printCostToShip(double costToShip)
        {
            this.resultLabel.Text = String.Format("Your parcel will cost {0:C} to ship.", costToShip);
        }
    }
}