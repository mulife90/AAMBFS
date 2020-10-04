using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AAMBFS.Models
{
    public partial class Occupation
    {
        public Occupation()
        {
            Client = new HashSet<Client>();
        }

        [Key]
        public int OccupationId { get; set; }
        [StringLength(60)]
        public string OccupationName { get; set; }

        [InverseProperty("Occupation")]
        public virtual ICollection<Client> Client { get; set; }
    }
}
