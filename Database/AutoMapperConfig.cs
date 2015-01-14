using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Location;

namespace Location.Repository
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.CreateMap<IBusiness, Business>();
        }
    }
}
