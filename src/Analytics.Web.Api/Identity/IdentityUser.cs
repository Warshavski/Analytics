using System;

using Microsoft.AspNet.Identity;

namespace Analytics.Web.Api.Identity
{
    public class IdentityUser : IUser<Guid>
    {
        #region Properties

        public Guid Id { get; set; }

        public string UserName { get; set; }

        public virtual string PasswordHash { get; set; }

        public virtual string SecurityStamp { get; set; }

        #endregion Properties
        //---------------------------------------------------------------------


        #region Constructors

        public IdentityUser()
        {
            this.Id = Guid.NewGuid();
        }

        public IdentityUser(string userName)
            : this()
        {
            this.UserName = userName;
        }

        #endregion Constructors
        //---------------------------------------------------------------------
    }
}