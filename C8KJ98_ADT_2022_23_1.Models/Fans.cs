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
    [Table("fans")]
    public class Fans
    {
        public Fans()
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
        public string City { get; set; }


        [Required]
        public int PhoneNumber { get; set; }

        [MaxLength(100)]
        [Required]
        public string Email { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Reservations> Reservations { get; }

        public override string ToString()
        {
            return $"\n{this.Id,3} | {this.Name,-20} {this.Email,-28} {this.PhoneNumber,10}  \t {this.City}";
        }
    }
}

