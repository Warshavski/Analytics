using System.Threading;
using System.Threading.Tasks;

using Analytics.Web.Api.Models.Entities;

namespace Analytics.Web.Api.Models.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByUserName(string username);
        Task<User> FindByUserNameAsync(string username);
        Task<User> FindByUserNameAsync(CancellationToken cancellationToken, string username);

        //User FindByEmail(string email);
        //Task<User> FindByEmailAsync(string email);
        //Task<User> FindByEmailAsync(CancellationToken cancellationToken, string email);
    }
}
