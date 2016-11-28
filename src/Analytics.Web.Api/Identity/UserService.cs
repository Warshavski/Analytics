using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Analytics.Web.Api.Identity
{
    public sealed class UserService : UserManager<IdentityUser, Guid>
    {
        private readonly IUserStore<IdentityUser, Guid> _userRepository;

        public UserService(IUserStore<IdentityUser, Guid> userRepository)
            : base(userRepository)
        {
            _userRepository = userRepository;
        }
    }
}