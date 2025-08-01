using Microsoft.EntityFrameworkCore;
using POSSEDQI.Entities;
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

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Invoice> Invoices { get; set; }

        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }

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
