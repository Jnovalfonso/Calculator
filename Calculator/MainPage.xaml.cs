namespace Calculator
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

        }

        public void onAcClicked (object sender, EventArgs e)
        {
            result.Text = "0";
        }

        public void onChangeSymbolClicked (object sender, EventArgs e)
        {
            float number = float.Parse(result.Text);
            number *= -1;
            result.Text = number.ToString();
        }

        public void onPercentageClicked (object sender, EventArgs e)
        {
            float number = float.Parse(result.Text);
            number /= 100;
            result.Text = number.ToString();
        }

        public void onNumberClicked(object sender, EventArgs e)
        {
            Button clickedNumber = (Button)sender;

            switch (clickedNumber.Text) 
            {
                case ",":
                    if (!result.Text.Contains(",") && !(result.Text == ""))
                    {
                        result.Text += clickedNumber.Text;
                    }
                    break;

                default:
                    if (result.Text == "0")
                    {
                        result.Text = clickedNumber.Text;
                        break;
                    }
                    result.Text += clickedNumber.Text;
                    break;

            }
        }

    }

}
