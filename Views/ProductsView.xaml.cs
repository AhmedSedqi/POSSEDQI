using POSSEDQI.ViewModels;
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
    /// Interaction logic for ProductsView.xaml
    /// </summary>
    public partial class ProductsView : UserControl
    {
        private readonly ProductsViewModel _viewModel;

        public ProductsView()
        {
            InitializeComponent();
            _viewModel = new ProductsViewModel();
            DataContext = _viewModel;

            Loaded += (s, e) =>
            {
                CategoryFilter.ItemsSource = _viewModel.Categories;
                ProductsList.ItemsSource = _viewModel.Products;
            };
        }

        private void FilterProducts(object sender, RoutedEventArgs e)
        {
            _viewModel.FilterByCategory(CategoryFilter.SelectedValue as int?);
        }
    }
}
