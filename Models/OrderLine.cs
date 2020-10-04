using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AAMBFS.Models
{
    public partial class OrderLine
    {
        [Key]
        public int OrderId { get; set; }
        [Key]
        public int LineNumber { get; set; }
        public int ProductId { get; set; }
        [Column(TypeName = "numeric(18, 3)")]
        public decimal Qty { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal LineTotal { get; set; }

        [ForeignKey(nameof(OrderId))]
        [InverseProperty("OrderLine")]
        public virtual Order Order { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("OrderLine")]
        public virtual Product Product { get; set; }
    }
}
