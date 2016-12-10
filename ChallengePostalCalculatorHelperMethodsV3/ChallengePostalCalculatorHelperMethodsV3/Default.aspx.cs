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

        private class Parcel
        {
            public double Width { get; set; }
            public double Heigth { get; set; }
            public double Length { get; set; }

            public double Volume
            {
                get
                {
                    return Width * Heigth * Length;
                }
            }
        }

        private void arrangeFunctionCalls()
        {
            double width;
            double height;
            double length;

            //check if values exist 
            // Thomas - I don't like this code. I can't tell you why... I need to think about it... Maybe because it repeats so much.
            if (!double.TryParse(this.widthTextBox.Text, out width)) return;
            if (!double.TryParse(this.heightTextBox.Text, out height)) return;
            if (!double.TryParse(this.lengthTextBox.Text, out length)) length = 1; //why default to 1?

            if (isShippingMethodSelected())
            {
                var parcel = new Parcel
                {
                    Width = width,
                    Heigth = height,
                    Length = length
                };

                double costToShip = this.calculateCostToShip(parcel);
                this.printCostToShip(costToShip);
            };
        }

        private bool isShippingMethodSelected()
        {
            if (groundRadioButton.Checked || airRadioButton.Checked || nextDayRadioButton.Checked)
            {
                return true;
            }

            return false;
        }

        private double calculateCostToShip(Parcel parcel)
        {
            double multiplier = .45;

            if (this.groundRadioButton.Checked) multiplier = .15;
            else if (this.airRadioButton.Checked) multiplier = .25;

            return parcel.Volume * multiplier;
        }

        private void printCostToShip(double costToShip)
        {
            this.resultLabel.Text = String.Format("Your parcel will cost {0:C} to ship.", costToShip);
        }
    }
}