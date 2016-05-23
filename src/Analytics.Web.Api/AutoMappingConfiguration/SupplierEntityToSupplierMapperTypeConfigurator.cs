using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;

using Analytics.Common.TypeMapping;

namespace Analytics.Web.Api.AutoMappingConfiguration
{
    public sealed class SupplierEntityToSupplierMapperTypeConfigurator : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Data.Entities.Supplier, Models.Supplier>()
                .ForCtorParam("supplierId", opt => opt.MapFrom(src => src.Id))
                .ForCtorParam("supplierInn", opt => opt.MapFrom(src => src.Inn))
                .ForCtorParam("supplierShortName", opt => opt.MapFrom(src => src.ShortName))
                .ForCtorParam("supplierFullName", opt => opt.MapFrom(src => src.FullName));
        }
    }
}