using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BTZ_Transports.Models.Base;
using System.ComponentModel;

namespace BTZ_Transports.ViewModels
{
    public class CombustivelViewModel : BaseEntity
    {
        [StringLength(8)]
        public string Nome { get; set; }

        [DisplayName("Preço")]
        [StringLength(14)]
        public decimal Preco { get; set; }
    }
}
