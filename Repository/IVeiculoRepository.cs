using BTZ_Transports.ViewModels;

namespace BTZ_Transports.Repository
{
    public interface IVeiculoRepository
    {
        IEnumerable<VeiculoViewModel> GetAll();
        VeiculoViewModel GetById(int id);
        void Add(VeiculoViewModel model);
        void Update(VeiculoViewModel model);
        bool Delete(int id);
    }
}
