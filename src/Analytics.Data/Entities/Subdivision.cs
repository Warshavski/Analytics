using System.Collections.Generic;

namespace Analytics.Data.Entities
{
    public class Subdivision
    {
        public virtual long Id { get; set; }
        public virtual long UserId { get; set; }
        public virtual string Address { get; set; }
        public virtual string ShortName { get; set; }
        public virtual string FullName { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}
