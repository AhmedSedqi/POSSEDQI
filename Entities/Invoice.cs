using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSEDQI.Entities
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }

        [Required]
        public DateTime InvoiceDate { get; set; }

        public decimal TotalAmount { get; set; }

        public decimal PaidAmount { get; set; }

        public decimal RemainingAmount { get; set; }

        [Required]
        public string Status { get; set; } // "مدفوعة", "غير مدفوعة", "مدفوعة جزئيا"

        // العلاقة مع الزبون
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }

        // العلاقة مع تفاصيل الفاتورة
        public List<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
