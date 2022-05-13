using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MovieRentalApp.Models
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(200)]
        public string Distributor { get; set; }

        [Required]
        [MaxLength(200)]
        public string Category { get; set; }

        [MaxLength(200)]
        public string Length { get; set; }

        [MaxLength(200)]
        public string Language { get; set; }

        public int RentId { get; set; }

        public virtual Rent Rent { get; set; }

        [JsonIgnore]
        public virtual ICollection<Staff> Staffs { get; set; }

        public Movie()
        {
            this.Staffs = new HashSet<Staff>();
        }
    }
}
