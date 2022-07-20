using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace BusinessObject.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        [Required]
        [RegularExpression(@"[a-zA-Z][a-zA-Z ]*", ErrorMessage = "Product name consist only of letters and space")]
        public string ProductName { get; set; }
        public string Weight { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitslnStock { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
