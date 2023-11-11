using BTZ_Transports.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTZ_Transports.Models
{
    [Table("veiculo")]
    public class Veiculos : BaseEntity
    {
        [Column("placa")]
        [StringLength(7)]
        public string Placa { get; set; }

        [Column("nome_veiculo")]
        [StringLength(20)]
        public string NomeVeiculo { get; set; }

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
