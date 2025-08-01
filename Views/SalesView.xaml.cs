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
                        Padding = new Thickness(5, 5, 5, 5),
                        Background = new SolidColorBrush(Color.FromRgb(2, 133, 199)), // لون أزرق سماوي حسب تصميمك
                        Foreground = Brushes.White,
                        VerticalAlignment = VerticalAlignment.Center,
                        Height = 30,
                        FontSize = 14,
                        FontWeight = FontWeights.Bold,
                        BorderThickness = new Thickness(0),
                        Tag = category.CategoryId
                    };

                    // حدث الضغط العادي - لتصفية المنتجات لاحقًا
                    button.Click += CategoryButton_Click;

                    // إنشاء قائمة عند الضغط بزر الفأرة الأيمن
                    var contextMenu = new ContextMenu();
                    var deleteItem = new MenuItem
                    {
                        Header = "حذف الفئة",
                        Tag = category.CategoryId
                    };
                    deleteItem.Click += DeleteCategory_Click;
                    contextMenu.Items.Add(deleteItem);

                    button.ContextMenu = contextMenu;

                    CategoriesPanel.Children.Add(button);
                }
            }
        }

        // الحذف انطلاقا من الضغط على الزر الأيمن
        private void DeleteCategory_Click(object sender, RoutedEventArgs e)
        {
            var menuItem = sender as MenuItem;
            if (menuItem != null && menuItem.Tag is int categoryId)
            {
                var result = MessageBox.Show("هل أنت متأكد من حذف هذه الفئة؟", "تأكيد الحذف", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    using (var db = new AppDbContext())
                    {
                        var category = db.Categories.Find(categoryId);
                        if (category != null)
                        {
                            db.Categories.Remove(category);
                            db.SaveChanges();
                        }
                    }

                    LoadCategories(); // إعادة تحميل الشريط بعد الحذف
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
