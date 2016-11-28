using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;

using Analytics.Web.Api.Models;

using Entities = Analytics.Web.Api.Models.Entities;

namespace Analytics.Web.Api.Identity
{
    public class UserStore : 
        IUserLoginStore<IdentityUser, Guid>, 
        IUserClaimStore<IdentityUser, Guid>, 
        IUserRoleStore<IdentityUser, Guid>, 
        IUserPasswordStore<IdentityUser, Guid>, 
        IUserSecurityStampStore<IdentityUser, Guid>, 
        IUserStore<IdentityUser, Guid>, IDisposable
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserStore(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region IUserStore<IdentityUser, Guid> Members

        public async Task CreateAsync(IdentityUser identityUser)
        {
            if (identityUser == null)
            {
                throw new ArgumentNullException("user");
            }

            var userEntity = GetUser(identityUser);

            _unitOfWork.UserRepository.Add(userEntity);

            var result = await _unitOfWork.SaveChangesAsync();
            //return _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(IdentityUser identityUser)
        {
            if (identityUser == null)
            {
                throw new ArgumentNullException("user");
            }

            var userEntity = GetUser(identityUser);

            _unitOfWork.UserRepository.Remove(userEntity);

            var result = await _unitOfWork.SaveChangesAsync();
            //return _unitOfWork.SaveChangesAsync();
        }

        public async Task<IdentityUser> FindByIdAsync(Guid userId)
        {
            var userEntity = await _unitOfWork.UserRepository.FindByIdAsync(userId);

            return GetIdentityUser(userEntity);
            //return Task.FromResult<IdentityUser>(GetIdentityUser(userEntity));
        }

        public async Task<IdentityUser> FindByNameAsync(string userName)
        {
            var userEntity = await _unitOfWork.UserRepository.FindByUserNameAsync(userName);

            return GetIdentityUser(userEntity);
            //return Task.FromResult<IdentityUser>(GetIdentityUser(userEntity));
        }

        public async Task UpdateAsync(IdentityUser identityUser)
        {
            if (identityUser == null)
            {
                throw new ArgumentException("user");
            }

            var userEntity = await _unitOfWork.UserRepository.FindByIdAsync(identityUser.Id);
            if (userEntity == null)
            {
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");
            }

            PopulateUser(userEntity, identityUser);

            _unitOfWork.UserRepository.Update(userEntity);

            var result = await _unitOfWork.SaveChangesAsync();
            //return _unitOfWork.SaveChangesAsync();
        }

        #endregion IUserStore<IdentityUser, Guid> Members
        //---------------------------------------------------------------------


        #region IDisposable Members

        public void Dispose()
        {
            // Dispose does nothing since we want Unity to manage the lifecycle of our Unit of Work
        }

        #endregion IDisposable Members
        //---------------------------------------------------------------------


        #region IUserClaimStore<IdentityUser, Guid> Members

        public async Task AddClaimAsync(IdentityUser identityUser, Claim claim)
        {
            if (identityUser == null)
            {
                throw new ArgumentNullException("user");
            }
                
            if (claim == null)
            {
                throw new ArgumentNullException("claim");
            }

            var userEntity = await _unitOfWork.UserRepository.FindByIdAsync(identityUser.Id);
            if (userEntity == null)
            {
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");
            }
            
            var claimEntity = new Entities.Claim
            {
                ClaimType = claim.Type,
                ClaimValue = claim.Value,
                User = userEntity
            };
            userEntity.Claims.Add(claimEntity);

            _unitOfWork.UserRepository.Update(userEntity);

            var result = await _unitOfWork.SaveChangesAsync();

            //return _unitOfWork.SaveChangesAsync();
        }

        public async Task<IList<Claim>> GetClaimsAsync(IdentityUser identityUser)
        {
            if (identityUser == null)
            {
                throw new ArgumentNullException("user");
            }

            var userEntity = await _unitOfWork.UserRepository.FindByIdAsync(identityUser.Id);
            if (userEntity == null)
            {
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");
            }
            return (IList<Claim>)userEntity.Claims.Select(x =>
                new Claim(x.ClaimType, x.ClaimValue)).ToList();
            //return Task.FromResult<IList<Claim>>(userEntity.Claims.Select(x => 
            //    new Claim(x.ClaimType, x.ClaimValue)).ToList());
        }

        public async Task RemoveClaimAsync(IdentityUser identityUser, Claim claim)
        {
            if (identityUser == null)
            {
                throw new ArgumentNullException("user");
            }
                
            if (claim == null)
            {
                throw new ArgumentNullException("claim");
            }
            
            var userEntity = await _unitOfWork.UserRepository.FindByIdAsync(identityUser.Id);
            if (userEntity == null)
            {
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");
            }
            
            var claimEntity = userEntity.Claims.FirstOrDefault(x => 
                x.ClaimType == claim.Type && 
                x.ClaimValue == claim.Value);

            userEntity.Claims.Remove(claimEntity);

            _unitOfWork.UserRepository.Update(userEntity);
            var result = await _unitOfWork.SaveChangesAsync();
            //return _unitOfWork.SaveChangesAsync();
        }

        #endregion IUserClaimStore<IdentityUser, Guid> Members
        //---------------------------------------------------------------------


        #region IUserLoginStore<IdentityUser, Guid> Members

        public async Task AddLoginAsync(IdentityUser identityUser, UserLoginInfo login)
        {
            if (identityUser == null)
            {
                throw new ArgumentNullException("user");
            }
                
            if (login == null)
            {
                throw new ArgumentNullException("login");
            }

            var userEntity = await _unitOfWork.UserRepository.FindByIdAsync(identityUser.Id);
            if (userEntity == null)
            {
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");
            }
            
            var externalLogin = new Entities.ExternalLogin
            {
                LoginProvider = login.LoginProvider,
                ProviderKey = login.ProviderKey,
                User = userEntity
            };
            userEntity.Logins.Add(externalLogin);

            _unitOfWork.UserRepository.Update(userEntity);
            var result = await _unitOfWork.SaveChangesAsync();
            //return _unitOfWork.SaveChangesAsync();
        }

        public async Task<IdentityUser> FindAsync(UserLoginInfo login)
        {
            if (login == null)
            {
                throw new ArgumentNullException("login");
            }
            
            var identityUser = default(IdentityUser);

            var externalLogin = await _unitOfWork.ExternalLoginRepository.
                GetByProviderAndKeyAsync(login.LoginProvider, login.ProviderKey);

            if (externalLogin != null)
            {
                identityUser = GetIdentityUser(externalLogin.User);
            }

            return identityUser;

            //return Task.FromResult<IdentityUser>(identityUser);
        }

        public async Task<IList<UserLoginInfo>> GetLoginsAsync(IdentityUser identityUser)
        {
            if (identityUser == null)
            {
                throw new ArgumentNullException("user");
            }

            var userEntity = await _unitOfWork.UserRepository.FindByIdAsync(identityUser.Id);
            if (userEntity == null)
            {
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");
            }

            return (IList<UserLoginInfo>)userEntity.Logins.Select(x =>
                new UserLoginInfo(x.LoginProvider, x.ProviderKey)).ToList();

            //return Task.FromResult<IList<UserLoginInfo>>(userEntity.Logins.Select(x => 
            //    new UserLoginInfo(x.LoginProvider, x.ProviderKey)).ToList());
        }

        public async Task RemoveLoginAsync(IdentityUser identityUser, UserLoginInfo login)
        {
            if (identityUser == null)
            {
                throw new ArgumentNullException("user");
            }

            if (login == null)
            {
                throw new ArgumentNullException("login");
            }

            var userEntity = await _unitOfWork.UserRepository.FindByIdAsync(identityUser.Id);
            if (userEntity == null)
            {
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");
            }
            
            var externalLogin = userEntity.Logins.FirstOrDefault(x => 
                x.LoginProvider == login.LoginProvider && 
                x.ProviderKey == login.ProviderKey);

            userEntity.Logins.Remove(externalLogin);

            _unitOfWork.UserRepository.Update(userEntity);

            var result = await _unitOfWork.SaveChangesAsync();
            //return _unitOfWork.SaveChangesAsync();
        }

        #endregion IUserLoginStore<IdentityUser, Guid> Members
        //---------------------------------------------------------------------


        #region IUserRoleStore<IdentityUser, Guid> Members

        public async Task AddToRoleAsync(IdentityUser identityUser, string roleName)
        {
            if (identityUser == null)
            {
                throw new ArgumentNullException("user");
            }
                
            if (string.IsNullOrWhiteSpace(roleName))
            {
                throw new ArgumentException("Argument cannot be null, empty, or whitespace: roleName.");
            }
            
            var userEntity = await _unitOfWork.UserRepository.FindByIdAsync(identityUser.Id);
            if (userEntity == null)
            {
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");
            }
                
            var roleEntity = await _unitOfWork.RoleRepository.FindByNameAsync(roleName);
            if (roleEntity == null)
            {
                throw new ArgumentException("roleName does not correspond to a Role entity.", "roleName");
            }

            userEntity.Roles.Add(roleEntity);
            _unitOfWork.UserRepository.Update(userEntity);

            var result = await _unitOfWork.SaveChangesAsync();

            //return _unitOfWork.SaveChangesAsync();
        }

        public async Task<IList<string>> GetRolesAsync(IdentityUser identityUser)
        {
            if (identityUser == null)
            {
                throw new ArgumentNullException("user");
            }

            var userEntity = await _unitOfWork.UserRepository.FindByIdAsync(identityUser.Id);
            if (userEntity == null)
            {
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");
            }

            return (IList<string>)userEntity.Roles.Select(x => x.Name).ToList();

            //return Task.FromResult<IList<string>>(userEntity.Roles.Select(x => x.Name).ToList());
        }

        public async Task<bool> IsInRoleAsync(IdentityUser identityUser, string roleName)
        {
            if (identityUser == null)
            {
                throw new ArgumentNullException("user");
            }
                
            if (string.IsNullOrWhiteSpace(roleName))
            {
                throw new ArgumentException("Argument cannot be null, empty, or whitespace: role.");
            }

            var userEntity = await _unitOfWork.UserRepository.FindByIdAsync(identityUser.Id);
            if (userEntity == null)
            {
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");
            }

            return (bool)userEntity.Roles.Any(x => x.Name == roleName);

            //return Task.FromResult<bool>(userEntity.Roles.Any(x => x.Name == roleName));
        }

        public async Task RemoveFromRoleAsync(IdentityUser identityUser, string roleName)
        {
            if (identityUser == null)
            {
                throw new ArgumentNullException("user");
            }
                
            if (string.IsNullOrWhiteSpace(roleName))
            {
                throw new ArgumentException("Argument cannot be null, empty, or whitespace: role.");
            }

            var userEntity =  await _unitOfWork.UserRepository.FindByIdAsync(identityUser.Id);
            if (userEntity == null)
            {
                throw new ArgumentException("IdentityUser does not correspond to a User entity.", "user");
            }

            var roleEntity = userEntity.Roles.FirstOrDefault(x => x.Name == roleName);
            userEntity.Roles.Remove(roleEntity);

            _unitOfWork.UserRepository.Update(userEntity);
            
            var result = await _unitOfWork.SaveChangesAsync();

            //return _unitOfWork.SaveChangesAsync();
        }

        #endregion IUserRoleStore<IdentityUser, Guid> Members
        //---------------------------------------------------------------------


        #region IUserPasswordStore<IdentityUser, Guid> Members

        public Task<string> GetPasswordHashAsync(IdentityUser identityUser)
        {
            if (identityUser == null)
            {
                throw new ArgumentNullException("user");
            }

            return Task.FromResult<string>(identityUser.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(IdentityUser identityUser)
        {
            if (identityUser == null)
            {
                throw new ArgumentNullException("user");
            }

            return Task.FromResult<bool>(!string.IsNullOrWhiteSpace(identityUser.PasswordHash));
        }

        public Task SetPasswordHashAsync(IdentityUser identityUser, string passwordHash)
        {
            identityUser.PasswordHash = passwordHash;
            return Task.FromResult(0);
        }

        #endregion IUserPasswordStore<IdentityUser, Guid> Members
        //---------------------------------------------------------------------


        #region IUserSecurityStampStore<IdentityUser, Guid> Members

        public Task<string> GetSecurityStampAsync(IdentityUser identityUser)
        {
            if (identityUser == null)
            {
                throw new ArgumentNullException("user");
            }

            return Task.FromResult<string>(identityUser.SecurityStamp);
        }

        public Task SetSecurityStampAsync(IdentityUser identityUser, string stamp)
        {
            identityUser.SecurityStamp = stamp;
            return Task.FromResult(0);
        }

        #endregion
        //---------------------------------------------------------------------


        #region Private Methods

        private Entities.User GetUser(IdentityUser identityUser)
        {
            if (identityUser == null)
            {
                return null;
            }
            
            var userEntity = new Entities.User();
            PopulateUser(userEntity, identityUser);

            return userEntity;
        }

        private void PopulateUser(Entities.User userEntity, IdentityUser identityUser)
        {
            userEntity.UserId = identityUser.Id;
            userEntity.UserName = identityUser.UserName;
            userEntity.PasswordHash = identityUser.PasswordHash;
            userEntity.SecurityStamp = identityUser.SecurityStamp;
        }

        private IdentityUser GetIdentityUser(Entities.User userEntity)
        {
            if (userEntity == null)
            {
                return null;
            }
            
            var identityUser = new IdentityUser();
            PopulateIdentityUser(identityUser, userEntity);

            return identityUser;
        }

        private void PopulateIdentityUser(IdentityUser identityUser, Entities.User userEntity)
        {
            identityUser.Id = userEntity.UserId;
            identityUser.UserName = userEntity.UserName;
            identityUser.PasswordHash = userEntity.PasswordHash;
            identityUser.SecurityStamp = userEntity.SecurityStamp;
        }

        #endregion
        //---------------------------------------------------------------------
    }
}