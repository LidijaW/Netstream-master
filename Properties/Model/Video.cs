using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netstream.Properties.Model
{
    [Table("video")] 
    public class Video
    {
        [Key]
        [Column("ID")] 
        public int Id { get; set; }

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

        [ForeignKey("Kategorija")]
        public int KategorijaId { get; set; } 

        public virtual Kategorija Kategorija { get; set; }
    }

    public enum TipVideo
    {
        Film,
        Serija
    }
}
