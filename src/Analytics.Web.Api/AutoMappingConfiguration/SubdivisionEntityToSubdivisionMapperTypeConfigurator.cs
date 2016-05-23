using AutoMapper;

using Analytics.Common.TypeMapping;


namespace Analytics.Web.Api.AutoMappingConfiguration
{
    public class SubdivisionEntityToSubdivisionMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Data.Entities.Subdivision, Models.Subdivision>()
                .ForCtorParam("subdivId", opt => opt.MapFrom(src => src.Id))
                .ForCtorParam("subdivAddress", opt => opt.MapFrom(src => src.Address))
                .ForCtorParam("subdivShortName", opt => opt.MapFrom(src => src.ShortName))
                .ForCtorParam("subdivFullName", opt => opt.MapFrom(src => src.FullName))
                .ForCtorParam("subdivDocuments", opt => opt.MapFrom(src => src.Documents));
        }
    }
}