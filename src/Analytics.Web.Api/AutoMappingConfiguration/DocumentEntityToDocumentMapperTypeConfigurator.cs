using AutoMapper;

using Analytics.Common.TypeMapping;

namespace Analytics.Web.Api.AutoMappingConfiguration
{
    public class DocumentEntityToDocumentMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Data.Entities.Document, Models.Document>()
                .ForCtorParam("documentId", opt => opt.MapFrom(src => src.Id))
                .ForCtorParam("documentDelayDays", opt => opt.MapFrom(src => src.DelayDays))
                .ForCtorParam("documentComment", opt => opt.MapFrom(src => src.Comment))
                .ForCtorParam("documentPricesSummary", opt => opt.MapFrom(
                    src => new Models.DocumentSummary(src.SumDiscount, src.SumNdsPrice, src.SumOrderPrice, src.SumRetailPrice)))
                .ForCtorParam("documentDates", opt => opt.MapFrom(
                    src => new Models.DocumentDates(src.CreateDate, src.EditDate, src.PayDate, src.PayFactDate)));
        }
    }
}