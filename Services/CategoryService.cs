using POSSEDQI.Data;
using POSSEDQI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace POSSEDQI.Services
{
    public class CategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService()
        {
            _context = new AppDbContext();
        }

        // جلب كل الفئات
        public List<Category> GetAllCategories()
        {
            try
            {
                return _context.Categories.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في جلب الفئات: {ex.Message}");
                return new List<Category>();
            }
        }

        // إضافة فئة جديدة
        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        // تحديث فئة موجودة
        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        // حذف فئة
        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        //التحقق من وجود فئة
        public bool CategoryExists(string categoryName)
        {
            return _context.Categories
                .Any(c => c.Name.ToLower().Trim() == categoryName.ToLower().Trim());
        }
    }
}
