using System.ComponentModel.DataAnnotations;

namespace WMSWebAPI.Models.V1.Request
{
    public class GetcontactListRequest
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string Filter { get; set; }
        public string Search { get; set; }
        public string Object { get; set; }
        public string ObjectId { get; set; }
    }
    public class SaveContactRequest
    {
        public string ContactID { get; set; }
        public string ObjectName { get; set; }
        public string ReferenceID { get; set; }
        public string ContactName { get; set; }
        public string EmailID { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string MobileNo { get; set; }
        public string Address { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Country { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string State { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string City { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string PostalCode { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Active { get; set; }
        public string CompanyID { get; set; }
        public string CreatedBy { get; set; }
        public string clientIsOwner { get; set; }

        /* public string CompanyId { get; set; }
         public string CustomerId { get; set; }
         public string WarehouseId { get; set; }
         public string UserId { get; set; }
         public string ContactId { get; set; }
         public string AddressId { get; set; }
         public string ContactType { get; set; }
         public string ContactName { get; set; }
         public string EmailId { get; set; }
         public string MobileNo { get; set; }
         public string Address { get; set; }
         public string Country { get; set; }
         public string State { get; set; }
         public string City { get; set; }
         public string PostalCode { get; set; }
         public string Active { get; set; }
         public string ObjectName { get; set; }*/
    }
}
