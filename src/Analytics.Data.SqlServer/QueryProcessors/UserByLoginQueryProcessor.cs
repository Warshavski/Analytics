using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Analytics.Data.Entities;
using Analytics.Data.QueryProcessors;

namespace Analytics.Data.SqlServer.QueryProcessors
{
    public sealed class UserByLoginQueryProcessor : IUserByLoginQueryProcessor
    {
        private readonly DbContext _context;

        public UserByLoginQueryProcessor(DbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserAsync(string login)
        {
            var user = await _context.Set<User>().FirstOrDefaultAsync(u => u.Login == login);
            return user;
        }
    }
}
