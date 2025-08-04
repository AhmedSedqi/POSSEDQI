using POSSEDQI.Helpers;
using POSSEDQI.Models;
using POSSEDQI.Services;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace POSSEDQI.ViewModels
{
    public class AddProductViewModel : INotifyPropertyChanged
    {
        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;
        private readonly ImageService _imageService;

        // الخصائص المعدلة - التهيئة الفارغة أساسية
        private string _productName = string.Empty;
        private string _description = string.Empty;
        private string _purchasePrice = string.Empty;
        private string _quantity = string.Empty;
        private Category _selectedCategory;
        private string _imagePath = "/Images/default.png";

        public string ProductName
        {
            get => _productName;
            set
            {
                _productName = value;
                OnPropertyChanged(nameof(ProductName));
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public string PurchasePrice
        {
            get => _purchasePrice;
            set
            {
                _purchasePrice = value;
                OnPropertyChanged(nameof(PurchasePrice));
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public string Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged(nameof(Quantity));
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public Category SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public string ImagePath
        {
            get => _imagePath;
            set
            {
                _imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }

        public List<Category> Categories { get; }

        public ICommand SaveCommand { get; }
        public ICommand SelectImageCommand { get; }
        public ICommand CloseWindowCommand { get; }

        public AddProductViewModel()
        {
            _productService = new ProductService();
            _categoryService = new CategoryService();
            _imageService = new ImageService();

            Categories = new List<Category>(_categoryService.GetAllCategories());

            SaveCommand = new RelayCommand(SaveProduct, CanSaveProduct);
            SelectImageCommand = new RelayCommand(SelectImage);
            CloseWindowCommand = new RelayCommand(CloseWindow);
        }

        private void SelectImage(object obj)
        {
            var imagePath = _imageService.SelectProductImage();
            if (!string.IsNullOrEmpty(imagePath))
            {
                ImagePath = imagePath;
            }
        }

        private void CloseWindow(object obj)
        {
            if (obj is Window window)
            {
                window.DialogResult = false; // تم التغيير إلى false للإلغاء
                window.Close();
            }
        }

        private bool CanSaveProduct(object parameter)
        {
            bool isValid = !string.IsNullOrWhiteSpace(ProductName) &&
                          !string.IsNullOrWhiteSpace(PurchasePrice) &&
                          !string.IsNullOrWhiteSpace(Quantity) &&
                          SelectedCategory != null;

            // تحقق إضافي لمنع النصوص النائبة
            if (isValid)
            {
                isValid = !ProductName.Equals("أدخل اسم المنتج") &&
                         !PurchasePrice.Equals("أدخل ثمن الشراء") &&
                         !Quantity.Equals("أدخل الكمية المتاحة");
            }

            return isValid;
        }

        private void SaveProduct(object parameter)
        {
            // التحقق من صحة السعر
            if (!decimal.TryParse(PurchasePrice, out decimal price) || price <= 0)
            {
                MessageBox.Show("يجب أن يكون ثمن الشراء رقمًا موجبًا", "خطأ في المدخلات",
                              MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // التحقق من صحة الكمية (عدد عشري غير سالب)
            if (!decimal.TryParse(Quantity, out decimal quantity) || quantity < 0)
            {
                MessageBox.Show("يجب أن تكون الكمية رقمًا عشريًا موجبًا (مثال: 1.5)", "خطأ في المدخلات",
                              MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // إنشاء المنتج الجديد
            var newProduct = new Product
            {
                Name = ProductName.Trim(),
                Description = Description?.Trim(),
                Price = price,
                Quantity = quantity,
                CategoryId = SelectedCategory.CategoryId,
                ImagePath = string.IsNullOrWhiteSpace(ImagePath) ? "/Images/default.png" : ImagePath
            };

            // محاولة الحفظ
            try
            {
                _productService.AddProduct(newProduct);

                // إغلاق النافذة بنجاح مع إعادة تعيين الحقول
                if (parameter is Window window)
                {
                    // إعادة تعيين الخصائص
                    ProductName = string.Empty;
                    Description = string.Empty;
                    PurchasePrice = string.Empty;
                    Quantity = string.Empty;
                    SelectedCategory = null;
                    ImagePath = "/Images/default.png";

                    window.DialogResult = true;
                    window.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"حدث خطأ أثناء الحفظ: {ex.Message}", "خطأ",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}