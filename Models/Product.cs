using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSEDQI.Entities
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public decimal Quantity { get; set; }  // الكمية يمكن أن تكون عشرية

        [Required]
        public decimal Price { get; set; }     // الثمن

        [Required]
        public int CategoryId { get; set; }   // مفتاح خارجي للفئة

        public Category? Category { get; set; } // علاقة بالفئة

        public string ImagePath { get; set; } // مسار الصورة للمنتج

    }
}
