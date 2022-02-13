using domain.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


#nullable disable

namespace Hotel_Management_System.Model
{
    public partial class Facility : IEntity
    {
        [Key]
        [Column("Facility")]
        public int Facility1 { get; set; }

        public Guid hotelId { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(500)]
        public string Icon { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ModifiedDate { get; set; }
    }
}
