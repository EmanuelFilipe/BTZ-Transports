using BTZ_Transports.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BTZ_Transports.Models
{
    [Table("combustivel")]
    public class Combustivel : BaseEntity
    {
        [Column("nome")]
        [StringLength(8)]
        public string Nome { get; set; }

        [Column("preco")]
        [StringLength(14)]
        public decimal Preco { get; set; }
    }
}
