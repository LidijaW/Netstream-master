﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netstream.Properties.Model
{
    [Table("razina")] 
    public class Razina
    {
        [Key]
        [Column("ID")] 
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Naziv { get; set; }

        public virtual ICollection<Korisnik> Korisnici { get; set; }
    }
}
