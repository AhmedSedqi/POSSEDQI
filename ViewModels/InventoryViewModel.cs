using POSSEDQI.Helpers;
using POSSEDQI.Services;
using POSSEDQI.Views.Windows;
using System.Windows;
using System.Windows.Input;

namespace POSSEDQI.ViewModels
{
    public class InventoryViewModel
    {
        private readonly ProductService _productService;

        public ICommand OpenAddProductCommand { get; }

        public InventoryViewModel()
        {
            _productService = new ProductService();
            OpenAddProductCommand = new RelayCommand(OpenAddProductWindow);
        }

        private void OpenAddProductWindow(object parameter)
        {
            var addProductWindow = new AddProductWindow
            {
                Owner = Application.Current.MainWindow
            };

            if (addProductWindow.ShowDialog() == true)
            {
                // يمكنك تحديث قائمة المنتجات هنا إذا لزم الأمر
                MessageBox.Show("تمت إضافة المنتج بنجاح!", "نجاح",
                              MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}