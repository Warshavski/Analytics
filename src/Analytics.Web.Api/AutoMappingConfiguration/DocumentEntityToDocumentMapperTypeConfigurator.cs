using AutoMapper;

using Analytics.Common.TypeMapping;

namespace Analytics.Web.Api.AutoMappingConfiguration
{
    public sealed class DocumentEntityToDocumentMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Data.Entities.Document, Models.Document>()
                .ForCtorParam("documentId", opt => opt.MapFrom(src => src.Id))
                .ForCtorParam("documentDelayDays", opt => opt.MapFrom(src => src.DelayDays))
                .ForCtorParam("documentComment", opt => opt.MapFrom(src => src.Comment))
                .ForCtorParam("supplier", opt => opt.MapFrom(src => src.Supplier))
                .ForMember(dest => dest.PricesSummary,
                    opt => opt.ResolveUsing<DocumentSummaryResolver>().ConstructedBy(() => new DocumentSummaryResolver()))
                .ForMember(dest => dest.Dates,
                    opt => opt.ResolveUsing<DocumentDatesResolver>().ConstructedBy(() => new DocumentDatesResolver()));
           
                /*s
                .ForCtorParam("documentPricesSummary", opt => opt.MapFrom(
                    src => new Models.DocumentSummary(src.SumDiscount, src.SumNdsPrice, src.SumOrderPrice, src.SumRetailPrice)))
                .ForCtorParam("documentDates", opt => opt.MapFrom(
                    src => new Models.DocumentDates(src.CreateDate, src.EditDate, src.PayDate, src.PayFactDate)))
                 */
                
        }

        internal sealed class DocumentDatesResolver : ValueResolver<Data.Entities.Document, Models.DocumentDates>
        {
            protected override Models.DocumentDates ResolveCore(Data.Entities.Document source)
            {
                return new Models.DocumentDates(source.CreateDate, source.EditDate,
                    source.PayDate, source.PayFactDate);
            }
        }

        internal sealed class DocumentSummaryResolver : ValueResolver<Data.Entities.Document, Models.DocumentSummary>
        {
            protected override Models.DocumentSummary ResolveCore(Data.Entities.Document source)
            {
                return new Models.DocumentSummary(source.SumDiscount, source.SumNdsPrice,
                    source.SumOrderPrice, source.SumRetailPrice);
            }
        }
    }
}