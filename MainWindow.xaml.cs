using POSSEDQI.Views;
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
    public partial class MainWindow : Window
    {
        // كلمة السر المسموح بها
        private string CorrectPassword = "1234";

        public MainWindow()
        {
            InitializeComponent();
        }

        // زر الدخول
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string password = PasswordBox.Password;

            if (password == "1234") // الرقم السري الذي تحدده
            {
                LoginPanel.Visibility = Visibility.Collapsed;
                MainUI.Visibility = Visibility.Visible;

                // تحميل SalesView
                MainContent.Content = new Views.SalesView();
            }
            else
            {
                LoginError.Visibility = Visibility.Visible;
            }
        }

        //زر نقطة البيع
        private void SalesButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new SalesView();
        }


        //زر المخزون
        private void InventoryButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new InventoryView();
        }
 

        //زر الفواتير
        private void InvoicesButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new InvoicesView();
        }

        //زر الزبائن
        private void ClientsButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Content = new ClientsView();
        }

        // زر الخروج
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}