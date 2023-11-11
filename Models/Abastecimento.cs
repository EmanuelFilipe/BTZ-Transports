using BTZ_Transports.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BTZ_Transports.Models
{
    [Table("abastecimento")]
    public class Abastecimento : BaseEntity
    {
        [Column("data")]
        [Required]
        public DateTime Data { get; set; }

        [Column("qtd_abastecida")]
        [Required]
        public int QuantidadeAbastecida { get; set; }

        [Column("valor_total")]
        public decimal ValorTotal { get; set; }

		// Relacionamento com Veiculo
		[ForeignKey("Veiculo")]
		public int VeiculoId { get; set; }
		public virtual Veiculo Veiculo { get; set; }

		// Relacionamento com Motorista
		[ForeignKey("Motorista")]
		public int MotoristaId { get; set; }
		public virtual Motorista Motorista { get; set; }

		// Relacionamento com Combustivel
		[ForeignKey("Combustivel")]
		public int CombustivelId { get; set; }
		public virtual Combustivel Combustivel { get; set; }
	}
}
