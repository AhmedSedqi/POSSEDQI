using Microsoft.EntityFrameworkCore;
using POSSEDQI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSEDQI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // تعيين مسار قاعدة البيانات SQLite (داخل مجلد التطبيق)
            optionsBuilder.UseSqlite("Data Source=possedqi.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // إعدادات إضافية للعلاقات لو احتجناها هنا لاحقًا
            base.OnModelCreating(modelBuilder);
        }
    }
}
