using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Analytics.Data.SqlServer.Mappings;

namespace Analytics.Data.SqlServer
{
    public class AnalyticsContext : DbContext
    {
        public AnalyticsContext(string connectionString)
            : base(connectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserMapping());
            modelBuilder.Configurations.Add(new SubdivisionMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
