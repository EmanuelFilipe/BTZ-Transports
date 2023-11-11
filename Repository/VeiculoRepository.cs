using AutoMapper;
using BTZ_Transports.Data;
using BTZ_Transports.Models;
using BTZ_Transports.ViewModels;

namespace BTZ_Transports.Repository
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public VeiculoRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<VeiculoViewModel> GetAll()
        {
            var veiculos = _context.Veiculos.ToList();
            return _mapper.Map<List<VeiculoViewModel>>(veiculos);
        }

        public VeiculoViewModel GetById(int id)
        {
            var veiculo = _context.Veiculos.Find(id);
            return _mapper.Map<VeiculoViewModel>(veiculo);
        }

        public void Add(VeiculoViewModel model)
        {
            Veiculo veiculo = _mapper.Map<Veiculo>(model);
            _context.Veiculos.Add(veiculo);
            _context.SaveChanges();
        }

        public void Update(VeiculoViewModel model)
        {
            Veiculo veiculo = _mapper.Map<Veiculo>(model);
            _context.Veiculos.Update(veiculo);
            _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            var veiculo = _context.Veiculos.Find(id);

            if (veiculo != null)
            {
                _context.Veiculos.Remove(veiculo);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}