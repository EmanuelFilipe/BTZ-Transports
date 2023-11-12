using BTZ_Transports.ViewModels;

namespace BTZ_Transports.Repository
{
	public interface IAbastecimentoRepository
	{
		IEnumerable<AbastecimentoViewModel> GetAll();
		AbastecimentoViewModel GetById(int id);
		void Add(AbastecimentoViewModel viewModel);
	}
}
