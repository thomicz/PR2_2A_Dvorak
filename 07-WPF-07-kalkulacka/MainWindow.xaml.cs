using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace _07_WPF_07_kalkulacka
{
    enum Operation { Add, Substract, Multiply, Divide, None }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Operation operation = Operation.None;
        private double lastNumber = 0;


        public string DisplayNumber
        {
            get { return (string)GetValue(DisplayNumberProperty); }
            set { SetValue(DisplayNumberProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DisplayNumber.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DisplayNumberProperty =
            DependencyProperty.Register("DisplayNumber", typeof(string), typeof(MainWindow), new PropertyMetadata("0"));


        private string decimalDot = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumBtnClick(object sender, RoutedEventArgs e)
        {
            Button pressed = (Button)sender;
            string digit = pressed.Content.ToString()!;

            if (DisplayTB.Text == "0")
            {
                DisplayTB.Text = digit;
            }
            else
            {
                DisplayTB.Text += digit;
            }
        }

        private void ACBtnClick(object sender, RoutedEventArgs e)
        {
            DisplayTB.Text = "0";
        }

        private void plusMinusBtnClick(object sender, RoutedEventArgs e)
        {
            string current = DisplayTB.Text;

            if (current.IndexOf('-') == 0)
            {
                DisplayTB.Text = DisplayTB.Text[1..];
            }
            else
            {
                DisplayTB.Text = "-" + DisplayTB.Text;
            }
        }

        private void decimalBtnClick(object sender, RoutedEventArgs e)
        {
            if (!DisplayTB.Text.Contains(decimalDot))
            {
                DisplayTB.Text += decimalDot;
            }

        }

        private void percentBtnClick(object sender, RoutedEventArgs e)
        {
            double number = double.Parse(DisplayTB.Text);
            number = number / 100;

            DisplayTB.Text = number.ToString();
        }

        private void OperationBtn_Click(object sender, RoutedEventArgs e)
        {
            lastNumber = double.Parse(DisplayNumber);
            DisplayNumber = "0";

            if (sender == plusBtn)
            {
                operation = Operation.Add;
            }
            else if (sender == minusbtn)
            {
                operation = Operation.Substract;
            }
            else if (sender == timesBtn)
            {
                operation = Operation.Multiply;
            }
            else if (sender == DivideBtn)
            {
                operation = Operation.Divide;
            }
        }

        private void equalsBtn_Click(object sender, RoutedEventArgs e)
        {
            double number = double.Parse(DisplayNumber);
            double result = operation switch
            {
                Operation.Add => number + lastNumber,
                Operation.Substract => number - lastNumber,
                Operation.Multiply => number * lastNumber,
                Operation.Divide => number / lastNumber,
                _ => 0
            };

            lastNumber = 0;
            DisplayNumber = result.ToString();
            operation = Operation.None;
        }
    }
}