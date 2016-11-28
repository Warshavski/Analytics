using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;

using Analytics.Web.Api.Models;
using Analytics.Web.Api.Models.Entities;

namespace Analytics.Web.Api.Identity
{
    public class RoleStore : IRoleStore<IdentityRole, Guid>, IQueryableRoleStore<IdentityRole, Guid>, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleStore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        #region IRoleStore<IdentityRole, Guid> Members

        public async Task CreateAsync(IdentityRole identityRole)
        {
            if (identityRole == null)
            {
                throw new ArgumentNullException("role");
            }
            
            var roleEntity = GetRole(identityRole);

            _unitOfWork.RoleRepository.Add(roleEntity);
            var result = await _unitOfWork.SaveChangesAsync();
            //return _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(IdentityRole identityRole)
        {
            if (identityRole == null)
            {
                throw new ArgumentNullException("role");
            }

            var roleEntity = GetRole(identityRole);

            _unitOfWork.RoleRepository.Remove(roleEntity);
            var result = await _unitOfWork.SaveChangesAsync();
            //return _unitOfWork.SaveChangesAsync();
        }

        public async Task<IdentityRole> FindByIdAsync(Guid roleId)
        {
            var roleEntity = await _unitOfWork.RoleRepository.FindByIdAsync(roleId);
            return GetIdentityRole(roleEntity);
            //return Task.FromResult<IdentityRole>(GetIdentityRole(roleEntity));
        }

        public async Task<IdentityRole> FindByNameAsync(string roleName)
        {
            var roleEntity = await _unitOfWork.RoleRepository.FindByNameAsync(roleName);
            return GetIdentityRole(roleEntity);
            //return Task.FromResult<IdentityRole>(GetIdentityRole(roleEntity));
        }

        public async Task UpdateAsync(IdentityRole identityRole)
        {
            if (identityRole == null)
            {
                throw new ArgumentNullException("role");
            }

            var roleEntity = GetRole(identityRole);

            _unitOfWork.RoleRepository.Update(roleEntity);
            var result = await _unitOfWork.SaveChangesAsync();
            //return _unitOfWork.SaveChangesAsync();
        }

        #endregion IRoleStore<IdentityRole, Guid> Members
        //---------------------------------------------------------------------


        #region IDisposable Members

        public void Dispose()
        {
            // Dispose does nothing since we want Unity to manage the lifecycle of our Unit of Work
        }

        #endregion IDisposable Members
        //---------------------------------------------------------------------


        #region IQueryableRoleStore<IdentityRole, Guid> Members

        public IQueryable<IdentityRole> Roles
        {
            get
            {
                return _unitOfWork.RoleRepository
                    .GetAll()
                    .Select(x => GetIdentityRole(x))
                    .AsQueryable();
            }
        }

        #endregion IQueryableRoleStore<IdentityRole, Guid> Members
        //---------------------------------------------------------------------


        //*** use AutoMapper
        #region Private Methods

        private Role GetRole(IdentityRole identityRole)
        {
            if (identityRole == null)
            {
                return null;
            }
                
            return new Role
            {
                RoleId = identityRole.Id,
                Name = identityRole.Name
            };
        }

        private IdentityRole GetIdentityRole(Role roleEntity)
        {
            if (roleEntity == null)
            {
                return null;
            }
                
            return new IdentityRole
            {
                Id = roleEntity.RoleId,
                Name = roleEntity.Name
            };
        }

        #endregion Private Methods
        //---------------------------------------------------------------------
    }
}