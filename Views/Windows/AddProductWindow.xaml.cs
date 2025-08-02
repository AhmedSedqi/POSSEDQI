using Microsoft.Win32;
using POSSEDQI.Data;
using POSSEDQI.Entities;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace POSSEDQI.Views.Windows
{
    public partial class AddProductWindow : Window
    {
        private string selectedImagePath = null!;
        private readonly string defaultImageName = "default.png";
        private readonly string imagesFolder = "Images";

        public AddProductWindow()
        {
            InitializeComponent();
            LoadCategories();

            
        }

        private void LoadCategories()
        {
            using (var db = new AppDbContext())
            {
                var categories = db.Categories.ToList();
                CategoryComboBox.ItemsSource = categories;
                CategoryComboBox.DisplayMemberPath = "Name";
            }
        }

        private void ChangeImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Images|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "اختر صورة للمنتج"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                selectedImagePath = openFileDialog.FileName;
                ProductImage.Source = new BitmapImage(new Uri(selectedImagePath));
            }
        }

        private void SaveProduct_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // التحقق من الحقول الضرورية
                if (string.IsNullOrWhiteSpace(NameTextBox.Text))
                    throw new Exception("يرجى إدخال اسم المنتج.");

                if (!double.TryParse(PurchasePriceTextBox.Text, out double price) || price < 0)
                    throw new Exception("يرجى إدخال ثمن صالح.");

                if (!double.TryParse(QuantityTextBox.Text, out double quantity) || quantity < 0)
                    throw new Exception("يرجى إدخال كمية صالحة.");

                var selectedCategory = CategoryComboBox.SelectedItem as Category;
                if (selectedCategory == null)
                    throw new Exception("يرجى اختيار فئة للمنتج.");

                string imageFileName;

                // حفظ الصورة المختارة (أو الصورة الافتراضية) في مجلد Images
                string imagesPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, imagesFolder);
                if (!Directory.Exists(imagesPath))
                    Directory.CreateDirectory(imagesPath);

                if (selectedImagePath != null && File.Exists(selectedImagePath))
                {
                    imageFileName = System.IO.Path.GetFileName(selectedImagePath);
                    string destinationPath = System.IO.Path.Combine(imagesPath, imageFileName);

                    // إذا كانت الصورة مختارة وليست الصورة الافتراضية، انسخها
                    if (!selectedImagePath.Contains("default.png") && !File.Exists(destinationPath))
                        File.Copy(selectedImagePath, destinationPath, true);
                }
                else
                {
                    imageFileName = defaultImageName;
                }

                // إنشاء المنتج
                var product = new Product
                {
                    Name = NameTextBox.Text.Trim(),
                    Description = DescriptionTextBox.Text.Trim(),
                    Price = price,
                    Quantity = quantity,
                    CategoryId = selectedCategory.CategoryId,
                    ImagePath = System.IO.Path.Combine(imagesFolder, imageFileName)
                };

                // الحفظ في قاعدة البيانات
                using (var db = new AppDbContext())
                {
                    db.Products.Add(product);
                    db.SaveChanges();
                }

                MessageBox.Show("تم حفظ المنتج بنجاح!", "نجاح", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطأ", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
