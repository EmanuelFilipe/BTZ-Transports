using BTZ_Transports.Models;

namespace BTZ_Transports.Repository
{
    public interface ICombustivelRepository
    {
        IEnumerable<Combustivel> GetAll();
        Combustivel GetById(int id);
    }
}
