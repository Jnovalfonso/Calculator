using Microsoft.Maui.Graphics;

namespace Calculator
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

        }

        // ALL CLEAR METHOD
        public void AcClicked (object sender, EventArgs e)
        {
            // Set Calculator to '0'
            result.Text = "0";
            firstNumber = 0;
            isOperatorClicked = false;
        }

        // CHANGE SYMBOL METHOD
        public void ChangeSymbolClicked (object sender, EventArgs e)
        {
            // Multiply 'number' by -1 to change its symbol
            float number = float.Parse(result.Text);
            number *= -1;
            result.Text = number.ToString();
        }

        // PERCENTAGE METHOD
        public void PercentageClicked (object sender, EventArgs e)
        {
            float number = float.Parse(result.Text);
            number /= 100;

            if (operatorSymbol == "+" || operatorSymbol == "_")
            {
                number = firstNumber * number;
            }
            

            result.Text = number.ToString();
           
        }

        // OPERATORS METHOD

        bool isOperatorClicked = false;
        string operatorSymbol = "";
        float firstNumber = 1;

        public void OperatorClicked (object sender, EventArgs e)
        {
            Button clickedOperator = (Button)sender;

            if (operatorSymbol != "")
            {
                EqualClicked(this, null);
            }

            switch (clickedOperator.Text)
            {
                case "/":
                    operatorSymbol = "/";
                    break;
                case "X":
                    operatorSymbol = "X";
                    break;
                case "_":
                    operatorSymbol = "_";
                    break;
                case "+":
                    operatorSymbol = "+";
                    break;
            }
            firstNumber = float.Parse(result.Text);
            isOperatorClicked = true;
            
        }

        // EQUAL METHOD

        public void EqualClicked (object sender, EventArgs e)
        {
            float secondNumber = float.Parse(result.Text);
            switch (operatorSymbol)
            {
                case "":
                    result.Text = secondNumber.ToString();
                    break;
                case "/":
                    if (secondNumber == 0)
                    {
                        DisplayAlert("Math Error:", "You can't divide by zero!", "OK");
                        break;
                    }
                    float division = firstNumber / secondNumber;
                    result.Text = division.ToString();
                    break;
                case "X":
                    float multiplication = firstNumber * secondNumber;
                    result.Text = multiplication.ToString();
                    break;
                case "_":
                    float subtraction = firstNumber - secondNumber;
                    result.Text = subtraction.ToString();
                    break;
                case "+":
                    float addition = firstNumber + secondNumber;
                    result.Text = addition.ToString();
                    break;
            }
            operatorSymbol = "";
            isOperatorClicked = true;
        }

        // NUMBER CLICKED METHOD
        public void NumberClicked(object sender, EventArgs e)
        {
            // Save sender 
            Button clickedNumber = (Button)sender;

            switch (clickedNumber.Text) 
            {
                // Don't allow multiple commas in the result and it can't lead the result without a number
                case ",":
                    if (!result.Text.Contains(",") && !(result.Text == ""))
                    {
                        result.Text += clickedNumber.Text;
                    }
                    break;

                default:
                    // Don't allow more than one leading zero and/or number if the first 
                    if (result.Text == "0" || isOperatorClicked)
                    {
                        result.Text = clickedNumber.Text;
                        isOperatorClicked = false;
                        break;
                    }
                    result.Text += clickedNumber.Text;
                    break;

            }
        }

    }

}
