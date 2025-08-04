using Microsoft.Win32;
using System.Windows;

namespace POSSEDQI.Services
{
    public class ImageService
    {
        public string SelectProductImage()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "ملفات الصور (*.jpg, *.png)|*.jpg;*.png",
                Title = "اختر صورة للمنتج"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }
            return "/Images/default.png";
        }
    }
}