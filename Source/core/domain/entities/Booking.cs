using domain.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


#nullable disable

namespace Hotel_Management_System.Model
{
    [Table("Booking")]
    public partial class Booking:IEntity
    {
        [Key]
        public Guid BookingId { get; set; }

        public Guid HotelId { get; set; }
        [Column(TypeName = "date")]


        public DateTime? FromDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ToDate { get; set; }
        [StringLength(500)]
        public string Remarks { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal? Price { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ModifiedDate { get; set; }

        public bool Active { get; set; }

    }
}
