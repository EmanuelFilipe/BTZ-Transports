using BTZ_Transports.Models.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BTZ_Transports.ViewModels
{
    public class MotoristaViewModel : BaseEntity
    {
		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		[StringLength(100)]
		public string Nome { get; set; }

		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		[StringLength(14)]
		public string CPF { get; set; }

		[DisplayName("Número CNH")]
		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		[StringLength(12)]
		public string NumeroCNH { get; set; }

		[DisplayName("Categoria CNH")]
		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		[StringLength(1)]
		public string CategoriaCNH { get; set; }

		[DisplayName("Data Nascimento")]
		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		public DateTime DataNascimento { get; set; }

		[DisplayName("Situação")]
		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		public int CodStatus { get; set; }
    }
}
