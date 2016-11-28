using System.Threading;
using System.Threading.Tasks;

using Analytics.Web.Api.Models.Entities;

namespace Analytics.Web.Api.Models.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Role FindByName(string roleName);
        Task<Role> FindByNameAsync(string roleName);
        Task<Role> FindByNameAsync(CancellationToken cancellationToken, string roleName);
    }
}
