using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieRentalApp.Models
{
    public class Renter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RenterId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public int Postcode { get; set; }

        [MaxLength(200)]
        public string City { get; set; }

        [MaxLength(200)]
        public string Street { get; set; }

        [MaxLength(200)]
        public string HouseNumber { get; set; }

        public DateTime MembershipStart { get; set; }

        public DateTime MembershipEnd { get; set; }

        public int RentId { get; set; }

        public virtual Rent Rent { get; set; }

        public Renter()
        {

        }
    }
}
