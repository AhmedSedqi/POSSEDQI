using POSSEDQI.Helpers;
using POSSEDQI.Models;
using POSSEDQI.Services;
using System.ComponentModel; // أضف هذا السطر
using System.Windows.Input;
using System.Windows; // لـ MessageBox


namespace POSSEDQI.ViewModels
{
    public class AddCategoryViewModel : INotifyPropertyChanged // أضف هذه الواجهة
    {
        private readonly CategoryService _categoryService;
        private string _categoryName = string.Empty; // تأكيد على قيمة فارغة

        public event PropertyChangedEventHandler PropertyChanged; // جزء من الواجهة

        public string CategoryName
        {
            get => _categoryName;
            set
            {
                if (_categoryName != value)
                {
                    _categoryName = value;
                    OnPropertyChanged(nameof(CategoryName));
                }
            }
        }

        public ICommand SaveCommand { get; }

        public AddCategoryViewModel()
        {
            _categoryService = new CategoryService();
            SaveCommand = new RelayCommand(SaveCategory, CanSaveCategory);
        }

        // دالة مساعدة لتنبيه الواجهة بالتغييرات
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void SaveCategory(object parameter)
        {
            // التحقق من التكرار أولاً
            if (_categoryService.CategoryExists(CategoryName))
            {
                MessageBox.Show("هذه الفئة موجودة بالفعل!", "تحذير",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var newCategory = new Category { Name = CategoryName.Trim() };
            _categoryService.AddCategory(newCategory);

            if (parameter is Window window)
            {
                window.DialogResult = true;
                window.Close();
            }
        }

        private bool CanSaveCategory(object parameter)
        {
            return !string.IsNullOrWhiteSpace(CategoryName) &&
                  !CategoryName.Equals("اسم الفئة") &&
                  !CategoryName.Trim().Equals("");
        }


    }
}