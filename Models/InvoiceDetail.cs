using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSSEDQI.Entities
{
    public class InvoiceDetail
    {
        [Key]
        public int InvoiceDetailId { get; set; }

        public int InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]
        public Invoice Invoice { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public double Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Total => (decimal)Quantity * UnitPrice;
    }
}
