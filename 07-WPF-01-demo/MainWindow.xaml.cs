using System.Windows;

namespace _07_WPF_01_demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isHello = true;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Hello.Content = isHello ? "Dobrý den" : "Naschledanou";
            isHello = !isHello;
        }
    }
}