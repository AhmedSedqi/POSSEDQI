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
    /// Interaction logic for InvoicesView.xaml
    /// </summary>
    public partial class InvoicesView : UserControl
    {
        public InvoicesView()
        {
            InitializeComponent();
        }

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text == "ابحث برقم الفاتورة")
            {
                SearchBox.Text = "";
                SearchBox.Foreground = Brushes.Black;
            }
        }

        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SearchBox.Text))
            {
                SearchBox.Text = "ابحث برقم الفاتورة";
                SearchBox.Foreground = Brushes.Gray;
            }
        }


    }
}
