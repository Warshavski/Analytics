using System;
using System.Threading;
using System.Threading.Tasks;

using Analytics.Web.Api.Models.Repositories;

namespace Analytics.Web.Api.Models
{
    public interface IUnitOfWork : IDisposable
    {
        #region Properties

        IExternalLoginRepository ExternalLoginRepository { get; }
        IRoleRepository RoleRepository { get; }
        IUserRepository UserRepository { get; }

        #endregion Properties
        //---------------------------------------------------------------------


        #region Methods

        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        #endregion Methods
        //---------------------------------------------------------------------
    }
}
