using POSSEDQI.Models;
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

namespace POSSEDQI.Controls
{
    public partial class ProductCardControl : UserControl
    {
        // تعريف خاصية Product
        public static readonly DependencyProperty ProductProperty =
        DependencyProperty.Register("Product", typeof(Product), typeof(ProductCardControl));

        public Product Product
        {
            get => (Product)GetValue(ProductProperty);
            set => SetValue(ProductProperty, value);
        }

        public ProductCardControl()
        {
            InitializeComponent();

        }
    }
}
