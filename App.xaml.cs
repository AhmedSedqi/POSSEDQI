using POSSEDQI.Data;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;


namespace POSSEDQI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            using (var db = new AppDbContext())
            {
                db.Database.EnsureCreated(); // ينشئ القاعدة إذا لم تكن موجودة
            }

            // إنشاء مجلد الصور إذا لم يكن موجوداً
            var imagesDir = Path.Combine(Directory.GetCurrentDirectory(), "Images");
            if (!Directory.Exists(imagesDir))
            {
                Directory.CreateDirectory(imagesDir);
            }

            // نسخ الصورة الافتراضية إذا لم تكن موجودة
            var defaultImage = Path.Combine(imagesDir, "default.png");
            if (!File.Exists(defaultImage))
            {
                // هنا يمكنك نسخ صورة افتراضية من مواردك
            }

            base.OnStartup(e);
        }
    }



    

}
