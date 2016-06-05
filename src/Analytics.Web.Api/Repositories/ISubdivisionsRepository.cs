using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Analytics.Data.Entities;

namespace Analytics.Web.Api.Repositories
{
    public interface ISubdivisionsRepository
    {
        Task<IEnumerable<Subdivision>> GetSubdivisionsAsync();
    }
}
