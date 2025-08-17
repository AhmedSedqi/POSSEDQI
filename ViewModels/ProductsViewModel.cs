using POSSEDQI.Models;
using POSSEDQI.Services;
using System.Collections.ObjectModel;
using System.Linq;

namespace POSSEDQI.ViewModels
{
    public class ProductsViewModel
    {
        public ObservableCollection<Product> Products { get; }
        public ObservableCollection<Category> Categories { get; }

        private readonly ProductService _productService;
        private readonly CategoryService _categoryService;

        public ProductsViewModel()
        {
            _productService = new ProductService();
            _categoryService = new CategoryService();

            Products = new ObservableCollection<Product>(_productService.GetAllProducts());
            Categories = new ObservableCollection<Category>(_categoryService.GetAllCategories());
        }

        public void FilterByCategory(int? categoryId)
        {
            Products.Clear();
            var filtered = categoryId == null
                ? _productService.GetAllProducts()
                : _productService.GetProductsByCategory(categoryId.Value);

            foreach (var product in filtered)
                Products.Add(product);
        }
    }
}
