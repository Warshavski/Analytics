using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Analytics.Web.Api.Repositories;
using Analytics.Data.Entities;
using System.Threading.Tasks;

namespace Analytics.Web.Api.Controllers
{
    public class SubdivisionController : ApiController
    {
        private readonly ISubdivisionsRepository _repository;

        public SubdivisionController(ISubdivisionsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Subdivision>> GetSubdivisions()
        {
            var subdivisions = await _repository.GetSubdivisionsAsync();

            return subdivisions;
        }
    }
}
