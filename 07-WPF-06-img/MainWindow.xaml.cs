using Microsoft.Win32;
using System.Windows;
using System.Windows.Media.Imaging;

namespace _07_WPF_06_img
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

        private void OpenBtn_Click(object sender, RoutedEventArgs e)
        {
            //Nachystám dialog
            OpenFileDialog ofd = new();
            ofd.Title = "Selected pisture";
            ofd.Filter = "JPEG (*.jpeg; *.jpg)|*.jpeg;*.jpg";

            if (ofd.ShowDialog() != true)
            {
                return; //uživatel zrušil
            }

            string filename = ofd.FileName;

            FileNameTB.Text = filename;

            try
            {
                Uri uri = new Uri(filename);
                BitmapImage img = new BitmapImage(uri);
                ImageCtrl.Source = img;
            }
            catch
            {
                MessageBox.Show("Error opening file", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }
    }
}