using BTZ_Transports.Models;
using BTZ_Transports.Models.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BTZ_Transports.ViewModels
{
	public class AbastecimentoViewModel : BaseEntity
	{
		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		public DateTime Data { get; set; }

		[DisplayName("Quantidade Abastecida")]
		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		public int QuantidadeAbastecida { get; set; }

        [DisplayName("Valor Total")]
        public decimal ValorTotal { get; set; }

		[DisplayName("Veículos")]
		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		public int veiculoId { get; set; }
		public virtual Veiculo Veiculo { get; set; }

		[DisplayName("Motoristas")]
		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		public int motoristaId { get; set; }
		public virtual Motorista Motorista { get; set; }

		[DisplayName("Tipo Combustível")]
		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		public int combustivelId { get; set; }
		public virtual Combustivel Combustivel { get; set; }
	}
}
