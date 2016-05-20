
namespace Analytics.Web.Api.Models
{
    public sealed class Supplier
    {
        private int _supplierId;
        public int Id { get { return _supplierId; } }

        private string _supplierInn;
        public string Inn { get { return _supplierInn; } }

        private string _supplierShortName;
        public string ShortName { get { return _supplierShortName; } }

        private string _supplierFullName;
        public string FullName { get { return _supplierFullName; } }

        public Supplier(int supplierId, string supplierInn, 
            string supplierShortName, string supplierFullName)
        {
            _supplierId = supplierId;
            _supplierInn = supplierInn;
            _supplierShortName = supplierShortName;
            _supplierFullName = supplierFullName;
        }
    }
}
