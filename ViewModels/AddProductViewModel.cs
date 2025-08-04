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
                window.Close();
            }
        }

        private bool CanSaveProduct(object parameter)
        {
            return !string.IsNullOrWhiteSpace(ProductName) &&
                   !ProductName.Equals("أدخل اسم المنتج") &&
                   !string.IsNullOrWhiteSpace(PurchasePrice) &&
                   !PurchasePrice.Equals("أدخل ثمن الشراء") &&
                   !string.IsNullOrWhiteSpace(Quantity) &&
                   !Quantity.Equals("أدخل الكمية المتاحة") &&
                   SelectedCategory != null;
        }

        private void SaveProduct(object parameter)
        {
            if (!decimal.TryParse(PurchasePrice, out decimal price) ||
                !int.TryParse(Quantity, out int quantity))
            {
                MessageBox.Show("الرجاء إدخال قيم صحيحة للسعر والكمية", "خطأ",
                              MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var newProduct = new Product
            {
                Name = ProductName,
                Description = Description,
                Price = price,
                Quantity = quantity,
                CategoryId = SelectedCategory.CategoryId,
                ImagePath = ImagePath
            };

            _productService.AddProduct(newProduct);

            if (parameter is Window window)
            {
                window.DialogResult = true;
                window.Close();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}