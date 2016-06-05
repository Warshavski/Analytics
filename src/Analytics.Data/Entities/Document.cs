using System;

namespace Analytics.Data.Entities
{
    [Serializable]
    public class Document
    {
        public virtual int Id { get; set; }

        public virtual int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        public virtual long SubdivisionId { get; set; }
        public virtual Subdivision Subdivision { get; set; }

        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime EditDate { get; set; }
        public virtual DateTime PayDate { get; set; }
        public virtual DateTime PayFactDate { get; set; }

        public virtual int DelayDays { get; set; }

        public virtual decimal SumNdsPrice { get; set; }
        public virtual decimal SumOrderPrice { get; set; }
        public virtual decimal SumRetailPrice { get; set; }
        public virtual decimal SumDiscount { get; set; }

        public virtual string Comment { get; set; }
    }
}
