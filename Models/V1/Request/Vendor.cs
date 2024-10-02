using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WMSWebAPI.Models.V1.Request
{
    public class GetVendorListRequest
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }
        public string CustomerID { get; set; }
        public string UserId { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Search { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Filter { get; set; }
    }
    public class AddEditVendorRequest
    {
        public string CompanyID { get; set; }
        public string VendorId { get; set; }
        public string CustomerId { get; set; }
        public string UserId { get; set; }
        public string VendorName { get; set; }
        public string VendorCode { get; set; }
        // public string Sector { get; set; }
        public string VendorType { get; set; }
        public string VendorEmail { get; set; }
        public string VendorContact { get; set; }
        public string LedgerNo { get; set; }
        public string Active { get; set; }
    }
}
