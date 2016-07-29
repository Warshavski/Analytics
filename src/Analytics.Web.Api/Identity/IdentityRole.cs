using System;

using Microsoft.AspNet.Identity;

namespace Analytics.Web.Api.Identity
{
    public class IdentityRole : IRole<Guid>
    {
        #region Properties

        public Guid Id { get; set; }
        
        public string Name { get; set; }

        #endregion Properties
        //---------------------------------------------------------------------


        #region Constructors

        public IdentityRole()
        {
            this.Id = Guid.NewGuid();
        }

        public IdentityRole(string name)
            : this()
        {
            this.Name = name;
        }

        public IdentityRole(string name, Guid id)
        {
            this.Name = name;
            this.Id = id;
        }

        #endregion Constructors
        //---------------------------------------------------------------------
    }
}