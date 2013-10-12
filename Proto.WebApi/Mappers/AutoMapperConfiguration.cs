using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace Proto.WebApi.Mappers
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x => x.AddProfile<DomainToModelMappingProfile>());
        }
    }
}