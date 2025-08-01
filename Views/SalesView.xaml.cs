using POSSEDQI.Data;
using POSSEDQI.Views.Windows;
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
    /// Interaction logic for SalesView.xaml
    /// </summary>
    public partial class SalesView : UserControl
    {
        public SalesView()
        {
            InitializeComponent();
            LoadCategories();
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            var addCategoryWindow = new AddCategoryWindow
            {
                Owner = Window.GetWindow(this) // تعيين النافذة الأم
            };

            bool? result = addCategoryWindow.ShowDialog();

            if (result == true)
            {
                // إعادة تحميل أو تحديث شريط الفئات بعد إضافة فئة جديدة
                LoadCategories();
            }
        }

        // مثال طريقة لتحميل الفئات في شريط الفئات (حسب تطبيقك)
        private void LoadCategories()
        {
            CategoriesPanel.Children.Clear();

            using (var db = new AppDbContext())
            {
                var categories = db.Categories.ToList();

                foreach (var category in categories)
                {
                    var button = new Button
                    {
                        Content = category.Name,
                        Margin = new Thickness(5),
                        Padding = new Thickness(10, 5, 10, 5),
                        Background = new SolidColorBrush(Color.FromRgb(56, 190, 248)), // لون أزرق فاتح حسب تصميمك
                        Foreground = Brushes.White,
                        BorderThickness = new Thickness(0),
                        Tag = category.CategoryId
                    };

                    // لاحقًا نربط هذا الحدث لتصفية المنتجات
                    button.Click += CategoryButton_Click;

                    CategoriesPanel.Children.Add(button);
                }
            }
        }

        private void CategoryButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            int categoryId = (int)button.Tag;

            // لاحقًا: فلترة المنتجات حسب categoryId
            MessageBox.Show($"الفئة المختارة: {button.Content} (ID: {categoryId})");
        }


    }
}
