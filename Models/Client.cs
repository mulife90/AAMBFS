using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AAMBFS.Models
{
    public partial class Client
    {
        public Client()
        {
            Order = new HashSet<Order>();
        }

        [Key]
        public int ClientId { get; set; }
        [StringLength(40)]
        public string FirstName { get; set; }
        [StringLength(40)]
        public string MiddleName { get; set; }
        [StringLength(40)]
        public string LastName { get; set; }
        [StringLength(1)]
        public string Gender { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateOfBirth { get; set; }
        public double? CreditRating { get; set; }
        [Column("XCode")]
        [StringLength(7)]
        public string Xcode { get; set; }
        public int? OccupationId { get; set; }
        [StringLength(20)]
        public string TelephoneNumber { get; set; }
        [StringLength(100)]
        public string Street1 { get; set; }
        [StringLength(100)]
        public string Street2 { get; set; }
        [StringLength(100)]
        public string City { get; set; }
        [StringLength(15)]
        public string ZipCode { get; set; }
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public string Notes { get; set; }

        [ForeignKey(nameof(OccupationId))]
        [InverseProperty("Client")]
        public virtual Occupation Occupation { get; set; }
        [InverseProperty("Client")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
