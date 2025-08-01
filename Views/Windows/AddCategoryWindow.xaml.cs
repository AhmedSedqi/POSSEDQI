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
        private readonly CategoryService _categoryService;

        public AddCategoryWindow()
        {
            InitializeComponent();
            _categoryService = new CategoryService();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var name = CategoryNameTextBox.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("يرجى إدخال اسم الفئة.", "تنبيه", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newCategory = new Category { Name = name };
            _categoryService.AddCategory(newCategory);

            MessageBox.Show("تمت إضافة الفئة بنجاح.", "نجاح", MessageBoxButton.OK, MessageBoxImage.Information);

            this.DialogResult = true; // إشارة نجاح وإغلاق النافذة
            this.Close();
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
