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
    public class Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StaffId { get; set; }

        [Required]
        [MaxLength(200)]
        public string Director { get; set; }

        [MaxLength(200)]
        public string MainCharacter { get; set; }

        [Range(0, 1000)]
        public int SupportingCharacters { get; set; }

        [Range(0, 1000000000)]
        public int Cost { get; set; }

        [Required]
        [MaxLength(200)]
        public string Studio { get; set; }

        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        public Staff()
        {

        }
    }
}
