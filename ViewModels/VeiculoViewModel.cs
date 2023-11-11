using BTZ_Transports.Models;
using BTZ_Transports.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BTZ_Transports.ViewModels
{
    public class VeiculoViewModel : BaseEntity
    {
        [StringLength(7)]
		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		public string Placa { get; set; }

        [DisplayName("Nome do Veículo")]
        [StringLength(20)]
		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		public string NomeVeiculo { get; set; }

        [StringLength(50)]
		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		public string Fabricante { get; set; }

        [DisplayName("Ano de Fabricação")]
		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		public int AnoFabricacao { get; set; }


        [DisplayName("Capacidade do Tanque")]
		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		public int CapacidadeMaximaTanque { get; set; }

        [DisplayName("Observações")]
        [StringLength(2000)]
        public string Observacoes { get; set; }

		[DisplayName("Tipo Combustível")]
		public int combustivelId { get; set; }
        public virtual Combustivel Combustivel { get; set; }
    }
}
