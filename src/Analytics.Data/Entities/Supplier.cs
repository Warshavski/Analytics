using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.Data.Entities
{
    [Serializable]
    public class Supplier
    {
        public virtual int Id { get; set; }
        public virtual string Inn { get; set; }
        public virtual string ShortName { get; set; }
        public virtual string FullName { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
    }
}
