using POSSEDQI.Services;
using POSSEDQI.Views.Windows;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace POSSEDQI.Views
{
    /// <summary>
    /// Interaction logic for InventoryView.xaml
    /// </summary>
    public partial class InventoryView : UserControl
    {
        private readonly ProductService _productService;

        public InventoryView()
        {
            InitializeComponent();
            _productService = new ProductService();

            LoadProducts();
        }
        //هذا هو الحدث الذي يتم استدعاؤه عند إضافة منتج
        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddProductWindow();
            window.ShowDialog();
            

        }

        private void LoadProducts()
        {
            var products = _productService.GetAllProducts();

            // تحديث مسارات الصور لتكون صالحة للعرض (مثلاً Images/product.jpg)
            foreach (var product in products)
            {
                if (!string.IsNullOrEmpty(product.ImagePath))
                {
                    var fullPath = Path.Combine(Directory.GetCurrentDirectory(), product.ImagePath);
                    if (File.Exists(fullPath))
                        product.ImagePath = "file:///" + fullPath.Replace('\\', '/');
                    else
                        product.ImagePath = "/Images/default.png"; // بديل افتراضي
                }
                else
                {
                    product.ImagePath = "/Images/default.png"; // بديل افتراضي
                }
            }

            ProductsItemsControl.ItemsSource = products;
        }


        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == "ابحث عن منتج...")
            {
                textBox.Text = "";
                textBox.Foreground = Brushes.Black;
            }
        }

        private void SearchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = "ابحث عن منتج...";
                textBox.Foreground = Brushes.Gray;
            }
        }
    }
}
