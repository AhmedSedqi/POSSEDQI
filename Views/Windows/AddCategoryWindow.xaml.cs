using POSSEDQI.Behaviors;
using POSSEDQI.Models;
using POSSEDQI.Services;
using POSSEDQI.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace POSSEDQI.Views.Windows
{
    /// <summary>
    /// Interaction logic for AddCategoryWindow.xaml
    /// </summary>
    public partial class AddCategoryWindow : Window
    {

        public AddCategoryWindow()
        {
            InitializeComponent();
            DataContext = new AddCategoryViewModel(); // ربط ViewModel
                                                     

        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(((AddCategoryViewModel)DataContext).CategoryName))
            {
                MessageBox.Show("لم يتم إدخال اسم الفئة!", "تحذير",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                e.Cancel = true;
            }
        }


    }
}
