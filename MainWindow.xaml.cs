using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POSSEDQI
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

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private string CorrectPassword = "1210102365"; // الرمز السري المعين حاليا يمكن تغيره لاحقا

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password == CorrectPassword)
            {
                LoginPanel.Visibility = Visibility.Collapsed;
                MainContent.Visibility = Visibility.Visible;
            }
            else
            {
                LoginError.Visibility = Visibility.Visible;
            }
        }

    }
}