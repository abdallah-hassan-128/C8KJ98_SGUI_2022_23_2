using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace C8KJ98_ADT_2022_23_1.Models
{
    [Table("artist")]
    public class Artists
    {
        public Artists()
        {
            this.Reservations = new HashSet<Reservations>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [MaxLength(50)]
        [Required]
        public string Name { get; set; }


        [MaxLength(100)]
        [Required]
        public string Category { get; set; }


        [Required]
        public int Duration { get; set; }



        [Required]
        public int Price { get; set; }
        public override string ToString()
        {
            return $"\n{this.Id,3} |  {this.Duration} hours {this.Price,10} MAD {this.Category,10}\t {this.Name,-1}";
        }
        [NotMapped]
        public virtual ICollection<Reservations> Reservations { get; }
    }
}

