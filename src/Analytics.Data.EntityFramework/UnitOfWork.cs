using System.Threading.Tasks;

using Analytics.Data.EntityFramework.Repositories;
using Analytics.Web.Api.Models;
using Analytics.Web.Api.Models.Repositories;

namespace Analytics.Data.EntityFramework
{
    /// <summary>
    /// Maintains an in-memory collection of changes, and
    /// Sends the changes as a single transaction to the data store.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        #region Class fields

        private readonly ApplicationDbContext _context;
        private IExternalLoginRepository _externalLoginRepository;
        private IRoleRepository _roleRepository;
        private IUserRepository _userRepository;

        #endregion Class fields
        //---------------------------------------------------------------------


        #region Constructors

        public UnitOfWork(string nameOrConnectionString)
        {
            _context = new ApplicationDbContext(nameOrConnectionString);
        }

        #endregion Constructors
        //---------------------------------------------------------------------


        #region IUnitOfWork Members

        public IExternalLoginRepository ExternalLoginRepository
        {
            get 
            { 
                return _externalLoginRepository ?? 
                    (_externalLoginRepository = new ExternalLoginRepository(_context)); 
            }
        }

        public IRoleRepository RoleRepository
        {
            get { return _roleRepository ?? (_roleRepository = new RoleRepository(_context)); }
        }

        public IUserRepository UserRepository
        {
            get { return _userRepository ?? (_userRepository = new UserRepository(_context)); }
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        #endregion IUnitOfWork members
        //---------------------------------------------------------------------


        #region IDisposable Members

        public void Dispose()
        {
            _externalLoginRepository = null;
            _roleRepository = null;
            _userRepository = null;
            _context.Dispose();
        }

        #endregion IDisposable Members
        //---------------------------------------------------------------------
    }
}
