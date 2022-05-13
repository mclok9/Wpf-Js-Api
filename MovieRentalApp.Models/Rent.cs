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
    public class Rent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RentId { get; set; }

        [Required]
        public DateTime Order { get; set; }

        [Required]
        [Range(0, 50000)]
        public int Price { get; set; }

        public DateTime RentalStart { get; set; }

        public DateTime RentalEnd { get; set; }

        [Range(0, 10000)]
        public int OverrunFee { get; set; }

        [JsonIgnore]
        public virtual ICollection<Renter> Renters { get; set; }

        [JsonIgnore]
        public virtual ICollection<Movie> Movies { get; set; }

        public Rent()
        {
            this.Renters = new HashSet<Renter>();
            this.Movies = new HashSet<Movie>();
        }
    }
}
