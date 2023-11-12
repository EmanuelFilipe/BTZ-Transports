using AutoMapper;
using BTZ_Transports.Data;
using BTZ_Transports.Models;
using BTZ_Transports.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BTZ_Transports.Repository
{
	public class AbastecimentoRepository : IAbastecimentoRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;

		public AbastecimentoRepository(ApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public IEnumerable<AbastecimentoViewModel> GetAll()
		{
			var abastecimentos = _context.Abastecimentos
										 .Include(a => a.Veiculo)
										 .Include(v => v.Combustivel)
										 .Include(a => a.Motorista)
										 .ToList();

			return _mapper.Map<List<AbastecimentoViewModel>>(abastecimentos);
		}

		public AbastecimentoViewModel GetById(int id)
		{
			var abastecimentos = _context.Abastecimentos
													 .Include(a => a.Veiculo)
													 .Include(v => v.Combustivel)
													 .Include(a => a.Motorista)
													 .ToList();

			var aux = _mapper.Map<List<AbastecimentoViewModel>>(abastecimentos);

			return aux.FirstOrDefault();
		}

		public void Add(AbastecimentoViewModel viewModel)
		{
			var abastecimento = _mapper.Map<Abastecimento>(viewModel);

			_context.Abastecimentos.Add(abastecimento);
			_context.SaveChanges();
		}

		
	}
}
