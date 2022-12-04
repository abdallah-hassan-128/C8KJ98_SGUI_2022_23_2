﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace C8KJ98_ADT_2022_23_1.Models
{
    [Table("reservations")]
    public class Reservations
    {
        public Reservations()
        {
            this.ConnectorReservationsServices = new HashSet<ReservationsServices>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        public DateTime DateTime { get; set; }


        [NotMapped]
        [JsonIgnore]
        public virtual Fans Fan { get; set; }



        [ForeignKey(nameof(Fan))]
        public int? FanId { get; set; }


        [NotMapped]
        [JsonIgnore]
        public virtual Artists Artist { get; set; }



        [ForeignKey(nameof(Artist))]
        public int? ArtistId { get; set; }



        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<ReservationsServices> ConnectorReservationsServices { get; }


        public override string ToString()
        {
            return $"\n{this.Id,3} | { this.FanId,-20} {this.DateTime.Year,10}.{this.DateTime.Month}.{this.DateTime.Day} \t{this.ArtistId,15}";
        }
    }
}

