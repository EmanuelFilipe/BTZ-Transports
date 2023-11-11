using AutoMapper;
using BTZ_Transports.Models;
using BTZ_Transports.ViewModels;

namespace BTZ_Transports.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config => {
                config.CreateMap<MotoristaViewModel, Motorista>().ReverseMap();
                config.CreateMap<VeiculoViewModel, Veiculo>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
