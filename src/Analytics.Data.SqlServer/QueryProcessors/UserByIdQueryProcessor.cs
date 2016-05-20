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
    public class UserByIdQueryProcessor : IUserByIdQueryProcessor
    {
        private readonly DbContext _context;

        public UserByIdQueryProcessor(DbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserAsync(int id)
        {
            var user = await _context.Set<User>().FindAsync(id);
            return user;
        }
    }
}
