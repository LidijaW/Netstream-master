using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netstream.Properties.Model
{
    [Table("korisnik")]
    public class Korisnik
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Ime { get; set; }

        [Required]
        [StringLength(255)]
        public string Prezime { get; set; }

        [Required]
        [StringLength(255)]
        [Column("Korisnicko_ime")]
        public string KorisnickoIme { get; set; }

        [Required]
        [StringLength(255)]
        public string Lozinka { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        public bool Aktivan { get; set; }

        [ForeignKey("Razina")]
        [Column("Razina_ID")]
        public int RazinaId { get; set; }

        public virtual Razina Razina { get; set; }
    }
}