using BTZ_Transports.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTZ_Transports.Models
{
    [Table("veiculo")]
    public class Veiculo : BaseEntity
    {
        [Column("placa")]
        [StringLength(7)]
        [Required]
        public string Placa { get; set; }

        [Column("nome_veiculo")]
        [StringLength(20)]
        [Required]
        public string NomeVeiculo { get; set; }

        [Column("fabricante")]
        [StringLength(50)]
        [Required]
        public string Fabricante { get; set; }

        [Column("ano_fabricacao")]
        [Required]
		public int AnoFabricacao { get; set; }


        [Column("capacidade_max_tanque")]
        [Required]
        public int CapacidadeMaximaTanque { get; set; }

        [Column("observacoes")]
        [StringLength(2000)]
        public string Observacoes { get; set; }

		// Relacionamento com Combustivel
		[ForeignKey("Combustivel")]
		public int CombustivelId { get; set; }
		public virtual Combustivel Combustivel { get; set; }


		// Relacionamento com Abastecimento
		public virtual ICollection<Abastecimento> Abastecimentos { get; set; }
    }
}
