using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.ComponentModel;
namespace POSSEDQI.Behaviors
{
    public static class PlaceholderBehavior
    {
        public static readonly DependencyProperty PlaceholderTextProperty =
            DependencyProperty.RegisterAttached(
                "PlaceholderText",
                typeof(string),
                typeof(PlaceholderBehavior),
                new PropertyMetadata(string.Empty, OnPlaceholderChanged));

        public static string GetPlaceholderText(TextBox textBox) =>
            (string)textBox.GetValue(PlaceholderTextProperty);

        public static void SetPlaceholderText(TextBox textBox, string value) =>
            textBox.SetValue(PlaceholderTextProperty, value);

        private static void OnPlaceholderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is not TextBox textBox) return;

            // إزالة المعالجات القديمة لمنع التكرار
            textBox.GotFocus -= RemovePlaceholder;
            textBox.LostFocus -= ShowPlaceholder;
            textBox.Loaded -= InitializePlaceholder;

            // إضافة المعالجات الجديدة
            textBox.GotFocus += RemovePlaceholder;
            textBox.LostFocus += ShowPlaceholder;
            textBox.Loaded += InitializePlaceholder;

            // التهيئة الفورية
            InitializePlaceholder(textBox, null);
        }

        private static void InitializePlaceholder(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = GetPlaceholderText(textBox);
                textBox.Foreground = Brushes.Gray;
            }
        }

        private static void RemovePlaceholder(object sender, RoutedEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (textBox.Text == GetPlaceholderText(textBox))
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }

        private static void ShowPlaceholder(object sender, RoutedEventArgs e)
        {
            var textBox = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = GetPlaceholderText(textBox);
                textBox.Foreground = Brushes.Gray;
            }
        }
    }
}