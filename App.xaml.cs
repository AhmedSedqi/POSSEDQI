﻿using System.Configuration;
using System.Data;
using System.Windows;
using POSSEDQI.Data;


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
        }
    }

    

}
