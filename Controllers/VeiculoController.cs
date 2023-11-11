using BTZ_Transports.Repository;
using BTZ_Transports.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BTZ_Transports.Controllers
{
    public class VeiculoController : Controller
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly ICombustivelRepository _combustivelRepository;

		public VeiculoController(IVeiculoRepository repository, 
			ICombustivelRepository combustivelRepository)
		{
			_veiculoRepository = repository;
			_combustivelRepository = combustivelRepository;
		}

		public IActionResult Index()
        {
			var veiculos = _veiculoRepository.GetAll();
            return View(veiculos);
        }

		public IActionResult Create()
		{
			GetLista();
			return View();
		}

		[ValidateAntiForgeryToken]
		[HttpPost]
		public IActionResult Create(VeiculoViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				_veiculoRepository.Add(viewModel);
				TempData["MSG_SUCCESS"] = "Veículo criado com sucesso!";

				return RedirectToAction(nameof(Index));
			}

			GetLista();
			return View(viewModel);
		}

		public IActionResult Details(int id)
		{
            GetLista();
			var veiculo = _veiculoRepository.GetById(id);
            return View(veiculo);
		}

		public IActionResult Edit(int id)
		{
			var veiculo = _veiculoRepository.GetById(id);
			GetLista(veiculo.combustivelId);

			return View(veiculo);
		}

		[ValidateAntiForgeryToken]
		[HttpPost]
		public IActionResult Edit(VeiculoViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				_veiculoRepository.Update(viewModel);
				TempData["MSG_SUCCESS"] = "Veículo atualizado com sucesso!";

				return RedirectToAction(nameof(Index));
			}

			GetLista();
			return View(viewModel);
		}

		public IActionResult Delete(int? id)
		{
			if (id == null)
				TempData["MSG_ERRO"] = "Ocorreu um erro ao realizar a exclusão!";
			else
			{
				var status = _veiculoRepository.Delete(id.Value);

				if (status)
					TempData["MSG_SUCCESS"] = "Veículo excluído com sucesso!";
				else
					TempData["MSG_ERRO"] = "Veículo não encontrado!";
			}

			return RedirectToAction(nameof(Index));
		}

		private void GetLista(int? id = null)
        {
			var combustiveis = _combustivelRepository.GetAll();
			var lista = new SelectList(combustiveis, "Id", "Nome");

			if (id  != null)
			{
				foreach (var item in lista)
				{
					if (int.Parse(item.Value )== id)
					{
						item.Selected = true;
						break;
					}
				}
			}

			ViewBag.ListaCombustiveisSelectList = lista;
        }
	}
}
