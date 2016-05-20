using AutoMapper;

using Analytics.Common.TypeMapping;

namespace Analytics.Web.Api.AutoMappingConfiguration
{
    public class UserEntityToUserMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Data.Entities.User, Models.User>()
                .ForCtorParam("userId", opt => opt.MapFrom(src => src.Id))
                .ForCtorParam("userName", opt => opt.MapFrom(src => src.Name))
                .ForCtorParam("userSubdivisions", opt => opt.MapFrom(src => src.Subdivisions));
        }
    }
}