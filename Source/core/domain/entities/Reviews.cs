using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain.entities
{
    class Reviews
    {
        public Guid ReviewId { get; set; }
       
        [StringLength(500)]
        public string Remarks { get; set; }

        public int stars { get; set; }

        public DateTime? CreatedDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ModifiedDate { get; set; }

        public bool Active { get; set; }
    }
}
