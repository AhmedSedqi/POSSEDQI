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
        // تعريف خاصية CurrentProduct
        public static readonly DependencyProperty CurrentProductProperty =
            DependencyProperty.Register("CurrentProduct", typeof(Product), typeof(ProductCardControl));

        public Product CurrentProduct
        {
            get => (Product)GetValue(CurrentProductProperty);
            set => SetValue(CurrentProductProperty, value);
        }

        public ProductCardControl()
        {
            InitializeComponent();
        }
    }
}
