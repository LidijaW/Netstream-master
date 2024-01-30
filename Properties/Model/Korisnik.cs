using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netstream.Properties.Model
{
    public class Korisnik
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Ime { get; set; }

        [Required]
        [StringLength(255)]
        public string Prezime { get; set; }

        [Required]
        [StringLength(255)]
        public string Korisnicko_ime { get; set; }

        [Required]
        [StringLength(255)]
        public string Lozinka { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        public bool Aktivan { get; set; }

        public int Razina_ID { get; set; }

        [ForeignKey("Razina_ID")]
        public virtual Razina Razina { get; set; }
    }

}
