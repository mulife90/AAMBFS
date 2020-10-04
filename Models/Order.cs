using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AAMBFS.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderLine = new HashSet<OrderLine>();
        }

        [Key]
        public int OrderId { get; set; }
        public int? ClientId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }
        [Column(TypeName = "numeric(18, 2)")]
        public decimal? OrderTotal { get; set; }
        [StringLength(1)]
        public string OrderStatus { get; set; }

        [ForeignKey(nameof(ClientId))]
        [InverseProperty("Order")]
        public virtual Client Client { get; set; }
        [InverseProperty("Order")]
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
