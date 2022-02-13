using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using domain.entities;


#nullable disable

namespace Hotel_Management_System.Model
{
    [Table("Hotel")]
    public partial class Hotel:IEntity
    {
        [Key]
        public Guid HotelId { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Price { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(500)]
        public string ProfilePicture { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ModifiedDate { get; set; }

        public bool Active { get; set; }
    }
}
