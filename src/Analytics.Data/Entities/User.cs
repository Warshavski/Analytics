using System.Collections.Generic;

namespace Analytics.Data.Entities
{
    public class User
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }

        public virtual ICollection<Subdivision> Subdivisions { get; set; }
    }
}
