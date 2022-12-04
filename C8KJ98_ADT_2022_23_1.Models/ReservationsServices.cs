using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace C8KJ98_ADT_2022_23_1.Models
{
    [Table("ConnectorTable")]

    public class ReservationsServices
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(Reservations))]
        public int? ReservationId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Reservations Reservations { get; set; }

        [ForeignKey(nameof(Services))]
        public int? ServiceId { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Services Services { get; set; }

        public override string ToString()
        {
            return $"{this.Id,3} | {this.ReservationId,5}\t {this.ServiceId,10}";
        }
    }
}
