using System.Collections.Generic;
using System.Linq;

namespace Analytics.Web.Api.Models
{
    public sealed class Subdivision
    {
        private long _subdivId;
        public long Id { get { return _subdivId; } }

        private string _subdivAddress;
        public string Address { get { return _subdivAddress; } }

        private string _subdivShortName;
        public string ShortName { get { return _subdivShortName; } }

        private string _subdivFullName;
        public string FullName { get { return _subdivFullName; } }

        private IEnumerable<Document> _subdivDocuments;
        public IEnumerable<Document> Documents 
        { 
            get 
            { 
                return _subdivDocuments.ToList().AsReadOnly(); 
            } 
        }
        
        public Subdivision(long subdivId, string subdivAddress,
            string subdivShortName, string subdivFullName)
        {
            _subdivId = subdivId;
            _subdivAddress = subdivAddress;
            _subdivShortName = subdivShortName;
            _subdivFullName = subdivFullName;
        }

        public Subdivision(long subdivId, string subdivAddress, string subdivShortName, 
            string subdivFullName, IEnumerable<Document> subdivDocuments)
        {
            _subdivId = subdivId;
            _subdivAddress = subdivAddress;
            _subdivShortName = subdivShortName;
            _subdivFullName = subdivFullName;

            _subdivDocuments = subdivDocuments;
        }
    }
}
