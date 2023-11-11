using BTZ_Transports.Data;
using BTZ_Transports.Models;

namespace BTZ_Transports.Repository
{
    public class CombustivelRepository : ICombustivelRepository
    {
        private readonly ApplicationDbContext _context;

        public CombustivelRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Combustivel> GetAll()
        {
            return _context.Combustiveis.ToList();
        }

        public Combustivel GetById(int id)
        {
            Combustivel combustivel = _context.Combustiveis.Find(id);
            return combustivel;
        }
    }
}
