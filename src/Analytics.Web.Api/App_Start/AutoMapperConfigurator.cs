using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using Analytics.Common.TypeMapping;

namespace Analytics.Web.Api
{
    public sealed class AutoMapperConfigurator
    {
        public void Configure(IEnumerable<IAutoMapperTypeConfigurator> autoMapperTypeConfigurations)
        {
            autoMapperTypeConfigurations.ToList().ForEach(x => x.Configure());

            Mapper.AssertConfigurationIsValid();
        }
    }
}