using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace SeanceUpdate.Models
{
    public class OperationG10
    {
        [Key]
        public int OperRef { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        [DisplayName("Operation Date")]
        public DateTime OperDate { get; set; }

        [Required]
        [Column(TypeName = "Varchar(255)")]
        [DisplayName("Operation Libelle")]
        public string OperLibelle { get; set; } = "";

        [Required]
        [Column(TypeName = "Decimal(18,2)")]
        [DisplayName("Montant Debit")]
        public decimal OperMontDebit { get; set; }

        [Required]
        [Column(TypeName = "Decimal(18,2)")]
        [DisplayName("Montant Credit")]
        public decimal OperMontCredit { get; set; }

        [Column(TypeName = "Decimal(18,2)")]
        [DisplayName("Solde")]
        public decimal OperSolde { get; set; }

        [Column(TypeName = "Varchar(255)")]
        [DisplayName("Beneficiaire")]
        public string OperBeneficiaire { get; set; } = "";

        [Column(TypeName = "Varchar(255)")]
        [DisplayName("Executant")]
        public string OperExecutant { get; set; } = "";

        [Column(TypeName = "Varchar(255)")]
        [DisplayName("Observation")]
        public string OperObserva { get; set; } = "";

        // Clé étrangère pour la nature de l'opération
        [Required]
        [DisplayName("Code Nature")]
        public int NatCode { get; set; }

        [ForeignKey("NatCode")]
        [ValidateNever]
        public NatureG10 NatureG10 { get; set; }

        // Clé étrangère pour le compte de trésorerie
        [Required]
        [DisplayName("Id Compte")]
        public int CptNumero { get; set; }

        [ForeignKey("CptNumero")]
        [ValidateNever]
        public CompteDetresoG10 Compte { get; set; }

        // Clé étrangère pour l'ordonnateur
        [Required]
        [DisplayName("Id Ordonnateur")]
        public int OrdCode { get; set; }

        [ForeignKey("OrdCode")]
        [ValidateNever]
        public OrdonateurG10 Ordonateur { get; set; }
    }
}
