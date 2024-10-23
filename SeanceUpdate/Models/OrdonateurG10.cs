using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SeanceUpdate.Models
{
    public class OrdonateurG10
    {
        [Key]
        public int OrdCode { get; set; }

        [Required]
        [Column(TypeName = "Varchar(50)")]
        [DisplayName("Nom Ordonateur")]
        [MaxLength(255)]
        public string OrdNom { get; set; } = "";

        [Required]
        [Column(TypeName = "Varchar(50)")]
        [DisplayName("Prenom Ordonateur")]
        [MaxLength(255)]
        public string OrdPrenom { get; set; } = "";

        [Column(TypeName = "Varchar(50)")]
        [DisplayName("Fonction Ordonateur")]
        [MaxLength(255)]
        public string OrdFonction { get; set; } = "";
    }
}
