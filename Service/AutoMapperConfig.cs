using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Location;

namespace Location.Service
{
    internal class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.CreateMap<IBusinessProximity, Model.Business>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Business.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Business.Name))
                .ForMember(dest => dest.Distance, opt => opt.MapFrom(src => src.Distance));

            Mapper.AssertConfigurationIsValid();
        }
    }
}
