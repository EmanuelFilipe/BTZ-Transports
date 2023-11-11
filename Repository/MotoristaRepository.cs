using AutoMapper;
using BTZ_Transports.Data;
using BTZ_Transports.Models;
using BTZ_Transports.ViewModels;

namespace BTZ_Transports.Repository
{
    public class MotoristaRepository : IMotoristaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public MotoristaRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<MotoristaViewModel> GetAll()
        {
            var motoristas = _context.Motoristas.ToList();
            return _mapper.Map<List<MotoristaViewModel>>(motoristas);
        }

        public MotoristaViewModel GetById(int id)
        {
            var motorista = _context.Motoristas.Find(id);
			return _mapper.Map<MotoristaViewModel>(motorista);
		}

        public void Add(MotoristaViewModel model)
        {
            Motorista motorista = _mapper.Map<Motorista>(model);
            _context.Motoristas.Add(motorista);
            _context.SaveChanges();
        }

        public void Update(MotoristaViewModel model)
        {
			Motorista motorista = _mapper.Map<Motorista>(model);
			_context.Motoristas.Update(motorista);
			_context.SaveChanges();
		}

        public void Delete(int id)
        {
			var motorista = _context.Motoristas.Find(id);
			motorista.CodStatus = 0;

			_context.Motoristas.Update(motorista);
			_context.SaveChanges();
		}
    }
}
