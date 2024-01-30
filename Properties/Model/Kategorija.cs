using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Netstream.Properties.Model
{
    public class Kategorija
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string Naziv { get; set; }

        // Dodajte ostale propertije za Kategoriju ako ih ima
    }
}




