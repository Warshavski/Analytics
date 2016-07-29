using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using Analytics.Web.Api.Models.Entities;
using Analytics.Web.Api.Models.Repositories;

namespace Analytics.Data.EntityFramework.Repositories
{
    internal class RoleRepository : Repository<Role>, IRoleRepository
    {
        internal RoleRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public Role FindByName(string roleName)
        {
            return Set.FirstOrDefault(x => x.Name == roleName);
        }

        public async Task<Role> FindByNameAsync(string roleName)
        {
            return await Set.FirstOrDefaultAsync(x => x.Name == roleName);
        }

        public async Task<Role> FindByNameAsync(System.Threading.CancellationToken cancellationToken, string roleName)
        {
            return await Set.FirstOrDefaultAsync(x => x.Name == roleName, cancellationToken);
        }
    }
}
