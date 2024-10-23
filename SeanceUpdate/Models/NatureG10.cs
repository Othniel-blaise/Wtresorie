using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SeanceUpdate.Models
{
    public class NatureG10
    {
        [Key]
        public int NatCode { get; set; }

        [Required]
        [Column(TypeName = "Varchar(50)")]
        [DisplayName("Nature Designation")]
        [MaxLength(255)]
        public string NatDesignation { get; set; } = "";
    }
}
