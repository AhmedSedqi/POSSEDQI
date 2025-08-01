using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POSSEDQI.Views
{
    /// <summary>
    /// Interaction logic for ClientsView.xaml
    /// </summary>
    public partial class ClientsView : UserControl
    {
        public ClientsView()
        {
            InitializeComponent();
        }

        private void SearchClientBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchClientBox.Text == "ابحث باسم الزبون")
            {
                SearchClientBox.Text = "";
                SearchClientBox.Foreground = Brushes.Black;
            }
        }

        private void SearchClientBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchClientBox.Text))
            {
                SearchClientBox.Text = "ابحث باسم الزبون";
                SearchClientBox.Foreground = Brushes.Gray;
            }
        }

    }
}
