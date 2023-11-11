using BTZ_Transports.Repository;
using BTZ_Transports.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BTZ_Transports.Controllers
{
    public class MotoristaController : Controller
    {
        private readonly IMotoristaRepository _motoristaRepository;

        public MotoristaController(IMotoristaRepository motoristaRepository)
        {
            _motoristaRepository = motoristaRepository;
        }

        public IActionResult Index()
        {
            return View(_motoristaRepository.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MotoristaViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                _motoristaRepository.Add(viewModel);

                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

		public IActionResult Details(int id)
		{
            var motorista = _motoristaRepository.GetById(id);
			return View(motorista);
		}

		public IActionResult Edit(int id)
		{
			var motorista = _motoristaRepository.GetById(id);
			return View(motorista);
		}

		[HttpPost]
		public IActionResult Edit(MotoristaViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				_motoristaRepository.Update(viewModel);
                TempData["MSG_SUCCESS"] = "Motorista atualizado com sucesso!";
                return RedirectToAction(nameof(Index));
			}

			return View(viewModel);
		}

		public IActionResult Delete(int? id)
		{
			if (id == null) return NotFound();

			//if (CustomValidationBeforeDelete((int)id))
			//{
			//	TempData["MSG_ERRO"] = "Esta Marca esta sendo utilizada na tabela de Veículos!";
			//	return RedirectToAction(nameof(Index));
			//}

			_motoristaRepository.Delete(id.Value);
			return RedirectToAction(nameof(Index));
		}
	}
}
