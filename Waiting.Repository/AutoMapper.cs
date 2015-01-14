using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Waiting.Repository
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.CreateMap<WaitTime, DynamoWait>().
                ForMember(x => x.Id, opt => opt.Ignore());

            Mapper.AssertConfigurationIsValid();
        }
    }
}
