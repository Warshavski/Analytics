using System;

namespace Analytics.Web.Api.Models
{
    public struct DocumentSummary
    {
        private decimal _documentDiscount;
        public decimal Discount { get { return _documentDiscount; } }

        private decimal _documentNdsPrice;
        public decimal NdsPrice { get { return _documentNdsPrice; } }

        private decimal _documentOrderPrice;
        public decimal OrderPrice {  get { return _documentOrderPrice; } }

        private decimal _documentRetailPrice;
        public decimal RetailPrice { get { return _documentRetailPrice; } }

       public DocumentSummary(decimal documentDiscount, decimal documentNdsPrice,
           decimal documentOrderPrice, decimal documentRetailPrice)
        {
            _documentDiscount = documentDiscount;
            _documentNdsPrice = documentNdsPrice;
            _documentOrderPrice = documentOrderPrice;
            _documentRetailPrice = documentRetailPrice;
        }
    }

    public struct DocumentDates
    {
        private DateTime _documentCreateDate;
        public DateTime Create { get { return _documentCreateDate; } }

        private DateTime _documentEditDate;
        public DateTime Edit { get { return _documentEditDate; } }

        private DateTime _documentPayDate;
        public DateTime Pay { get { return _documentPayDate; } }
        
        private DateTime _documentPayFactDate;
        public DateTime PayFact { get { return _documentPayFactDate; } }

        public DocumentDates(DateTime documentCreateDate, DateTime documentEditDate,
            DateTime documentPayDate, DateTime documentPayFactDate)
        {
            _documentCreateDate = documentCreateDate;
            _documentEditDate = documentEditDate;
            _documentPayDate = documentPayDate;
            _documentPayFactDate = documentPayFactDate;
        }
    }

    public sealed class Document
    {
        private int _documentId;
        public int Id { get { return _documentId; } }

        private int _documentDelayDays;
        public int DelayDays { get { return _documentDelayDays; } }

        private string _documentComment;
        public string Comment { get { return _documentComment; } }

        private Supplier _supplier;
        public Supplier Supplier { get { return _supplier; } }

        /*
        private DocumentSummary _documentPricesSummary;
        public DocumentSummary PricesSummary { get { return _documentPricesSummary; } }

        private DocumentDates _documentDates;
        public DocumentDates Dates { get { return _documentDates; } }
        */

        private DocumentSummary _documentPricesSummary;
        public DocumentSummary PricesSummary { get; set; }

        private DocumentDates _documentDates;
        public DocumentDates Dates { get; set; }

        public Document(int documentId, int documentDelayDays, string documentComment, Supplier supplier)
        {
            _documentId = documentId;
            _documentDelayDays = documentDelayDays;
            _documentComment = documentComment;
            _supplier = supplier;
        }

        /*
        public Document(int documentId, int documentDelayDays, string documentComment, 
            Supplier supplier, DocumentSummary documentPricesSummary, DocumentDates documentDates)
        {
            _documentId = documentId;
            _documentDelayDays = documentDelayDays;
            _documentComment = documentComment;
            _supplier = supplier;
            _documentPricesSummary = documentPricesSummary;
            _documentDates = documentDates; 
        }
        */
    }
}
