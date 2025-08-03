using POSSEDQI.Services;
using POSSEDQI.Helpers;
using POSSEDQI.Models;
using System.Behaviors;
using System.Windows.Input;

namespace POSSEDQI.ViewModels
{
    public class AddCategoryViewModel
    {
        private readonly CategoryService _categoryService;

        // خاصية لربطها مع TextBox في الواجهة
        private string _categoryName = ""; // تأكد من تهيئته كسلسلة فارغة

        public string CategoryName
        {
            get => _categoryName;
            set
            {
                _categoryName = value;
                OnPropertyChanged(nameof(CategoryName));
            }
        }

        // الأمر الخاص بالحفظ
        public ICommand SaveCommand { get; }

        public AddCategoryViewModel()
        {
            _categoryService = new CategoryService();
            SaveCommand = new RelayCommand(SaveCategory, CanSaveCategory);
        }

        // دالة الحفظ
        private void SaveCategory(object parameter)
        {
            var newCategory = new Category { Name = CategoryName };
            _categoryService.AddCategory(newCategory);

            // إغلاق النافذة بعد الحفظ (سنربطها لاحقًا)
            if (parameter is System.Windows.Window window)
                window.Close();
        }



        // التحقق من إمكانية التنفيذ
        private bool CanSaveCategory(object parameter)
        {
            return !string.IsNullOrWhiteSpace(CategoryName);
        }
    }
}