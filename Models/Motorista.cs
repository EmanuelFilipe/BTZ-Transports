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
        public string Nome { get; set; }

        [Column("cpf")]
        [StringLength(14)]
        public string CPF { get; set; }

        [Column("numero_cnh")]
        [StringLength(12)]
        
        public string NumeroCNH { get; set; }

        [Column("categoria_cnh")]
        [StringLength(1)]
		public string CategoriaCNH { get; set; }


        [Column("data_nascimento")]
		public DateTime DataNascimento { get; set; }

        [Column("status")]
        public int CodStatus { get; set; }
    }
}
