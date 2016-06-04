using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analytics.Web.Api.Models;

using System.Data.Entity;

namespace Analytics.Web.Api.Repositories
{
    public class SubdivisionsRepository : ISubdivisionsRepository
    {
        private readonly DbContext _context;

        public SubdivisionsRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Subdivision>> GetSubdivisionsAsync()
        {
            var subdivisions = await _context.Set<Subdivision>().ToListAsync();

            return subdivisions;
        }
    }
}
