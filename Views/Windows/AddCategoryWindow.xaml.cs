using POSSEDQI.Entities;
using POSSEDQI.Services;
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
        }
        private void CategoryNameTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (CategoryNameTextBox.Text == "اسم الفئة")
            {
                CategoryNameTextBox.Text = "";
                CategoryNameTextBox.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void CategoryNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(CategoryNameTextBox.Text))
            {
                CategoryNameTextBox.Text = "اسم الفئة";
                CategoryNameTextBox.Foreground = System.Windows.Media.Brushes.Gray;
            }
        }



    }
}
