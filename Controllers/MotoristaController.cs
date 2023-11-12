using BTZ_Transports.Repository;
using BTZ_Transports.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BTZ_Transports.Controllers
{
	[Authorize]
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

		[ValidateAntiForgeryToken]
		[HttpPost]
        public IActionResult Create(MotoristaViewModel viewModel)
        {
            if(ModelState.IsValid)
            {
                _motoristaRepository.Add(viewModel);

                TempData["MSG_SUCCESS"] = "Motorista criado com sucesso!";
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

		[ValidateAntiForgeryToken]
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
			if (id == null)
                TempData["MSG_ERRO"] = "Ocorreu um erro ao realizar a exclusão!";
            else
            {
                var status = _motoristaRepository.Delete(id.Value);

                if (!status)
                    TempData["MSG_ERRO"] = "Ocorreu um erro ao realizar a exclusão!";
                else
                    TempData["MSG_SUCCESS"] = "Motorista excluído com sucesso!";
            }
            
            return RedirectToAction(nameof(Index));
        }
	}
}
