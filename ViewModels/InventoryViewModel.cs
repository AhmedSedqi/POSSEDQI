using POSSEDQI.Helpers;
using POSSEDQI.Models;
using POSSEDQI.Services;
using POSSEDQI.Views.Windows;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

        public ObservableCollection<Product> Products { get; set; }

        public async Task LoadProducts()
        {
            var products = await _productService.GetAllProducts();
            Products = new ObservableCollection<Product>(products);
            OnPropertyChanged(nameof(Products));
        }
    }
}