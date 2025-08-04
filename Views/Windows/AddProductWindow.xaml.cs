using POSSEDQI.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace POSSEDQI.Views.Windows
{
    public partial class AddProductWindow : Window
    {
        public AddProductWindow()
        {
            InitializeComponent();
            DataContext = new AddProductViewModel();

            // هذا السطر السحري سيجعل النصوص النائبة تظهر فوراً
            Loaded += (s, e) =>
            {
                ProductNameTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateTarget();
                DescriptionTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateTarget();
                PurchasePriceTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateTarget();
                QuantityTextBox.GetBindingExpression(TextBox.TextProperty)?.UpdateTarget();
            };
        }
    }
}