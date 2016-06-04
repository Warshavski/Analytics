using System.Threading.Tasks;

using Analytics.Web.Api.Models;
using System.Collections.Generic;

namespace Analytics.Web.Api.Repositories
{
    public interface IDocumentsRepository
    {
        Task<Document> GetDocumentAsync();
        Task<IEnumerable<Document>> GetDocumentsAsync();
    }
}
