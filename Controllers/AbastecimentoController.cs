using BTZ_Transports.Models;
using BTZ_Transports.Repository;
using BTZ_Transports.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BTZ_Transports.Controllers
{
	public class AbastecimentoController : Controller
	{
		private readonly IAbastecimentoRepository _abastecimentoRepository;
        private readonly ICombustivelRepository _combustivelRepository;
        private readonly IMotoristaRepository _motoristaRepository;
        private readonly IVeiculoRepository _veiculoRepository;

        public AbastecimentoController(IAbastecimentoRepository abastecimentoRepository, 
            ICombustivelRepository combustivelRepository, 
            IMotoristaRepository motoristaRepository, 
            IVeiculoRepository veiculoRepository)
        {
            _abastecimentoRepository = abastecimentoRepository;
            _combustivelRepository = combustivelRepository;
            _motoristaRepository = motoristaRepository;
            _veiculoRepository = veiculoRepository;
        }

        public IActionResult Index()
		{
			var abastecimentos = _abastecimentoRepository.GetAll();
			return View(abastecimentos);
		}

		public IActionResult Create()
		{
            GetListas();
			return View();
		}

		[ValidateAntiForgeryToken]
		[HttpPost]
		public IActionResult Create(AbastecimentoViewModel viewModel)
		{
			if (ModelState.IsValid && CustomValidationIsValid(viewModel))
			{
				CalculaValorTotalCombustivel(viewModel);

				_abastecimentoRepository.Add(viewModel);
				TempData["MSG_SUCCESS"] = "Abastecimento registrado com sucesso!";

				return RedirectToAction(nameof(Index));
			}

			GetListas(viewModel);
			return View(viewModel);
		}

		private void CalculaValorTotalCombustivel(AbastecimentoViewModel viewModel)
		{
			var combustivel = _combustivelRepository.GetById(viewModel.combustivelId);

			viewModel.ValorTotal = viewModel.QuantidadeAbastecida * combustivel.Preco;
		}

		public IActionResult Details(int id)
		{
			var abastecimento = _abastecimentoRepository.GetById(id);
			GetListas(abastecimento);
			return View(abastecimento);
		}

		private void GetListas(AbastecimentoViewModel viewModel = null)
        {
			GetVeiculos(viewModel?.veiculoId > 0 ? viewModel.veiculoId : null);
			GetMotoristas(viewModel?.motoristaId > 0 ? viewModel.motoristaId : null);
			GetCombustivel(viewModel?.combustivelId > 0 ? viewModel.combustivelId : null);
        }

		private void GetVeiculos(int? id)
		{
			var combustiveis = _veiculoRepository.GetAll();
			var lista = new SelectList(combustiveis, "Id", "NomeVeiculo");

			if (id != null)
			{
				foreach (var item in lista)
				{
					if (int.Parse(item.Value) == id)
					{
						item.Selected = true;
						break;
					}
				}
			}

			ViewBag.ListaVeiculosSelectList = lista;
		}

		private void GetMotoristas(int? id)
		{
			var combustiveis = _motoristaRepository.GetAll();
			var lista = new SelectList(combustiveis, "Id", "Nome");

			if (id != null)
			{
				foreach (var item in lista)
				{
					if (int.Parse(item.Value) == id)
					{
						item.Selected = true;
						break;
					}
				}
			}

			ViewBag.ListaMotoristasSelectList = lista;
		}

		private void GetCombustivel(int? id)
        {
            var combustiveis = _combustivelRepository.GetAll();
            var lista = new SelectList(combustiveis, "Id", "Nome");

            if (id != null)
            {
                foreach (var item in lista)
                {
                    if (int.Parse(item.Value) == id)
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }

            ViewBag.ListaCombustiveisSelectList = lista;
        }

		private bool CustomValidationIsValid(AbastecimentoViewModel viewModel)
		{
			bool ret = true;

			var veiculoDB = _veiculoRepository.GetById(viewModel.veiculoId);

			if (viewModel.QuantidadeAbastecida > veiculoDB.CapacidadeMaximaTanque)
				ModelState.AddModelError("QuantidadeAbastecida", "A quantidade abastecida informada é maior que a capacidade máxima do veiculo selecionado.");

			if (viewModel.combustivelId > veiculoDB.combustivelId)
				ModelState.AddModelError("combustivelId", "O tipo do combustível selecionado é diferente do cadastrado para este veículo.");


			int countErros = ModelState.Values.Count(x => x.Errors.Count > 0);

			if (countErros > 0)
				ret = false;

			return ret;
		}
	}
}
