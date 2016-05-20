using System.Collections.Generic;
using System.Linq;

namespace Analytics.Web.Api.Models
{
    //public enum UserRoles { }
    
    public sealed class User
    {
        private long _userId;
        public long Id { get { return _userId; } }

        private string _userName;
        public string Name { get { return _userName; } }

        //private UserRoles _userRole;

        private IEnumerable<Subdivision> _userSubdivisions;
        public IEnumerable<Subdivision> Subdivisions
        {
            get
            {
                return _userSubdivisions.ToList().AsReadOnly();
            }
        }

        public User(long userId, string userName, IEnumerable<Subdivision> userSubdivisions)
        {
            _userId = userId;
            _userName = userName;
            _userSubdivisions = userSubdivisions;
        }
    }
}
