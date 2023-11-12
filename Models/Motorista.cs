using BTZ_Transports.Models.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTZ_Transports.Models
{
    [Table("motorista")]
    public class Motorista : BaseEntity
    {
        [Column("nome")]
        [StringLength(100)]
        [Required]
        [DisplayName("Nome Motorista")]
        public string Nome { get; set; }

        [Column("cpf")]
        [StringLength(14)]
        [Required]
        public string CPF { get; set; }

        [Column("numero_cnh")]
        [StringLength(12)]
        [Required]
        public string NumeroCNH { get; set; }

        [Column("categoria_cnh")]
        [StringLength(1)]
        [Required]
        public string CategoriaCNH { get; set; }


        [Column("data_nascimento")]
        [Required]
        public DateTime DataNascimento { get; set; }

        [Column("status")]
        [Required]
        public bool CodStatus { get; set; }

        // Relacionamento com Abastecimento
        public virtual ICollection<Abastecimento> Abastecimentos { get; set; }
    }
}
