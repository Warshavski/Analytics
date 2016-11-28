using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.Web.Api.Models.Entities
{
    public class ExternalLogin
    {
        #region Fields

        private User _user;

        #endregion Fields
        //---------------------------------------------------------------------


        #region Scalar Properties

        public virtual string LoginProvider { get; set; }
        public virtual string ProviderKey { get; set; }
        public virtual Guid UserId { get; set; }

        #endregion Scalar Properties
        //---------------------------------------------------------------------


        #region Navigation Properties

        public virtual User User
        {
            get { return _user; }
            set
            {
                _user = value;
                UserId = value.UserId;
            }
        }

        #endregion Navigation Properties
        //---------------------------------------------------------------------
    }
}
