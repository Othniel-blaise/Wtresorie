using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SeanceUpdate.Models
{
    public class CompteDetresoG10
    {
        [Key]
        public int CptNumero { get; set; }

        [Required]
        [Column(TypeName = "Varchar(50)")]
        [DisplayName("Compte Designation")]
        [MaxLength(255)]
        public string CptDesignation { get; set; } = "";

        [Column(TypeName = "Varchar(255)")]
        [DisplayName("Compte Description")]
        public string CptDescription { get; set; } = "";
    }
}
