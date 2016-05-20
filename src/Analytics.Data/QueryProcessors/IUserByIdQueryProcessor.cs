using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Analytics.Data.Entities;

namespace Analytics.Data.QueryProcessors
{
    public interface IUserByIdQueryProcessor
    {
        Task<User> GetUserAsync(int id);
    }
}
