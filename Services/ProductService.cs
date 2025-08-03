using POSSEDQI.Data;
using POSSEDQI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSEDQI.Services
{
    // هذه الخدمة للتعامل مع جدول المنتجات (CRUD)
    public class ProductService
    {
        private readonly AppDbContext _context;

        // عند إنشاء الخدمة نفتح اتصال بقاعدة البيانات
        public ProductService()
        {
            _context = new AppDbContext();
        }

        // جلب كل المنتجات من قاعدة البيانات كقائمة
        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        // إضافة منتج جديد
        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        // تحديث منتج موجود
        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        // حذف منتج بناءً على كائن المنتج
        public void DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        // يمكنك إضافة المزيد من الوظائف حسب الحاجة (بحث، تصفية، إلخ)
    }
}