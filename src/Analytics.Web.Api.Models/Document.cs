using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analytics.Web.Api.Models
{
    public sealed class Document
    {
        private int _documentId;
        
        //private int _supplierId;
        private Supplier _supplier;

        private DateTime _documentCreateDate;
        private DateTime _documentEditDate;
        private DateTime _documentPayDate;
        private DateTime _documentPayFactDate;
        
        private int _documentDelayDays;

        private decimal _documentNdsPrice;
        private decimal _documentOrderPrice;
        private decimal _documentRetailPrice;
        private decimal _documentDiscount;

        private string _documentComment;
    }
}
