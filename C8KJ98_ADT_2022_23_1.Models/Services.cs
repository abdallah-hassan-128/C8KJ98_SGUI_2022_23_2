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
    [Table("services")]
    public class Services
    {
        public Services()
        {
            this.ConnectorReservationsServices = new HashSet<ReservationsServices>();

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Range(1, 10)]
        public int Rating { get; set; }

        [Required]
        public int Price { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<ReservationsServices> ConnectorReservationsServices { get; }
        

        public override string ToString()
        {
            return $"\n{this.Id,3} | {this.Rating,2}/10 {this.Price,7} MAD \t{this.Name,-1}";
        }
    }

}

