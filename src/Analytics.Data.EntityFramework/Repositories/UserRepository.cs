using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

using Analytics.Web.Api.Models.Entities;
using Analytics.Web.Api.Models.Repositories;

namespace Analytics.Data.EntityFramework.Repositories
{
    internal class UserRepository : Repository<User>, IUserRepository
    {
        internal UserRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public User FindByUserName(string username)
        {
            return Set.FirstOrDefault(x => x.UserName == username);
        }

        public async Task<User> FindByUserNameAsync(string username)
        {
            return await Set.FirstOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<User> FindByUserNameAsync(System.Threading.CancellationToken cancellationToken, string username)
        {
            return await Set.FirstOrDefaultAsync(x => x.UserName == username, cancellationToken);
        }
    }
}
