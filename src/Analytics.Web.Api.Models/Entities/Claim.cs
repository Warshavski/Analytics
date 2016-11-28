using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.Web.Api.Models.Entities
{
    public class Claim
    {
        #region Fields

        private User _user;

        #endregion Fields
        //---------------------------------------------------------------------


        #region Scalar Properties

        public virtual int ClaimId { get; set; }
        public virtual Guid UserId { get; set; }
        public virtual string ClaimType { get; set; }
        public virtual string ClaimValue { get; set; }

        #endregion Scalar Properties
        //---------------------------------------------------------------------


        #region Navigation Properties

        public virtual User User
        {
            get { return _user; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                _user = value;
                UserId = value.UserId;
            }
        }

        #endregion Navigation Properties
        //---------------------------------------------------------------------
    }
}
