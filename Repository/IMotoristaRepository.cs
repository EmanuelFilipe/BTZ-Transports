using BTZ_Transports.ViewModels;

namespace BTZ_Transports.Repository
{
    public interface IMotoristaRepository
    {
        IEnumerable<MotoristaViewModel> GetAll();
        MotoristaViewModel GetById(int id);
        void Add(MotoristaViewModel model);
        void Update(MotoristaViewModel model);
        void Delete(int id);
    }
}
