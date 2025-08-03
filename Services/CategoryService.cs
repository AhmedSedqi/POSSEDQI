using POSSEDQI.Data;
using POSSEDQI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return _context.Categories.ToList();
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
    }
}
