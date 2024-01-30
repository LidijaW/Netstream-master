using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netstream.Properties.Model
{
    public class Video
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Sifra { get; set; }

        [Required]
        [StringLength(255)]
        public string Naziv { get; set; }

        [Required]
        [StringLength(255)]
        public string Redatelj { get; set; }

        public int Godina { get; set; }

        public int Trajanje { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal Cijena { get; set; }

        [Required]
        [StringLength(255)]
        public string Url { get; set; }

        public TipVideo Tip { get; set; }

        public int Kategorija_ID { get; set; }

        [ForeignKey("Kategorija_ID")]
        public virtual Kategorija Kategorija { get; set; }
    }
}
