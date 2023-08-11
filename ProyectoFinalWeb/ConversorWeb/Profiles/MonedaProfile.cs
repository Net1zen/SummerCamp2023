using AutoMapper;
using ConversorWeb.Utils;

namespace ConversorWeb.Profiles
{
    public class MonedaProfile : Profile
    {
        public MonedaProfile()
        {
            CreateMap<MonedaJson, MonedaJson>();
        }
    }
}
