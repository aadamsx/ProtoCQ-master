using AutoMapper;
using Proto.Model.Entities;
using Proto.WebApi.Models;

namespace Proto.WebApi.Mappers
{
    public class DomainToModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "DomainToDtoMappingProfile"; }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Tenant, TenantModel>();
            Mapper.CreateMap<TenantModel, Tenant>(); //.ForMember(dest => dest.Category, opt => opt.Ignore());
        }
    }
}