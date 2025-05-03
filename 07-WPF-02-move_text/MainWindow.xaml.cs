using System.Windows;
using System.Windows.Input;

namespace _07_WPF_02_move_text
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            output.Text = inputTB.Text;
            inputTB.Text = string.Empty;
            inputTB.Focus();
        }

        private void inputTB_KeyDown(object sender, RoutedEventArgs e)
        {
           

        }



    }
}