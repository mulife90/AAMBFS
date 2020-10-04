using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AAMBFS.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderLine = new HashSet<OrderLine>();
        }

        [Key]
        public int ProductId { get; set; }
        [StringLength(80)]
        public string ProductName { get; set; }
        [Column(TypeName = "smallmoney")]
        public decimal? Price { get; set; }
        public bool? Active { get; set; }
        [Column(TypeName = "numeric(18, 3)")]
        public decimal? Stock { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
