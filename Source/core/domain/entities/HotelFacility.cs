using domain.entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


#nullable disable

namespace Hotel_Management_System.Model
{
    public partial class HotelFacility:IEntity
    {
        [Key]
        public int Id { get; set; }
        public int? FacilityId { get; set; }
        public int? HotelId { get; set; }
        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ModifiedDate { get; set; }
    }
}
