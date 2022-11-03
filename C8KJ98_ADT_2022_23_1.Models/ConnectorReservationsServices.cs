﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace C8KJ98_ADT_2022_23_1.Models
{
    [Table("ConnectorsReservationsServices")]

    public class ConnectorReservationsServices
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey(nameof(Reservations))]
        public int? ReservationId { get; set; }

        public virtual Reservations Reservations { get; set; }

        [ForeignKey(nameof(Services))]
        public int? ServiceId { get; set; }

        public virtual Services Services { get; set; }
        public override string ToString()
        {
            return $"{this.Id,3} | {this.Reservations?.Id,5}\t {this.Services?.Name ?? "N/A",-40} {this.Services?.Price ?? 0,10} Mad";
        }
    }
}
