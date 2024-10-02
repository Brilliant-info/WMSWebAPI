using System.ComponentModel.DataAnnotations;

namespace WMSWebAPI.Models.V1.Request
{
    public class GetCompanyListRequest
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public string Filter { get; set; }
        public string Search { get; set; }
    }
    public class GetEmailConfigList
    {

        public Int64 CompanyId { get; set; }
        public Int64 CustomerId { get; set; }
        public Int64 WarehouseId { get; set; }
        public Int64 UserId { get; set; }

    }
    public class EmailConfigSave
    {

        public Int64 EmailConfigId { get; set; }
        public Int64 CompanyId { get; set; }
        public Int64 CustomerId { get; set; }
        public Int64 WarehouseId { get; set; }
        public Int64 UserId { get; set; }
        public string DefaultsenderID { get; set; }
        public string Protocol { get; set; }
        public string Hostname { get; set; }
        public string EmailPort { get; set; }
        public string SecurityMode { get; set; }
        public string CustomerKey { get; set; }
        public string CustomerValue { get; set; }
        public string EmailPassword { get; set; }
        public string Active { get; set; }
        public string EmailOTP { get; set; }
        public string VerifiedOTP { get; set; }


    }
    public class AddCompanyRequest
    {
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Address { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Zipcode { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Landmark { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Website { get; set; }
        public string Active { get; set; }
        public string logopath { get; set; }
        public byte[] logo { get; set; }
    }

    public class EditCompanyRequest
    {
        public string UserId { get; set; }
        public string CID { get; set; }
    }
    /*  public class ShowWarehouseRequest
      {
          public string CompanyId { get; set; }
          public string UserId { get; set; }
          public string CustomerId { get; set; }
          public string Skey { get; set; }



      }
      public class SelectWarehouseRequest
      {
          public string CompanyId { get; set; }
          public string UserId { get; set; }
          public string WarehouseId { get; set; }
          public string CustomerId { get; set; }

      }
      public class RemoveWarehouseRequest
      {
          public string CompanyId { get; set; }
          public string UserId { get; set; }
          public string WarehouseId { get; set; }
          public string CustomerId { get; set; }

      }
      public class EditCustomerRequest
      {
          public string UserId { get; set; }
          public string CID { get; set; }
      }

      public class AssginCustomerWarehouseRequest
      {
          public string UserId { get; set; }
          public string CustomerID { get; set; }
          public string CompanyId { get; set; }
          public string WarehouseId { get; set; }
      }*/
    public class RequestGetholidayList
    {
        public string ObjectType { get; set; }
        public string ReferenceId { get; set; }
        public string CompanyID { get; set; }
    }
    public class reqSaveholidaylist
    {
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ObjectType { get; set; }
        public string ReferenceID { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Date { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Description { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Remark { get; set; }
        public string CustomerId { get; set; }
        public string CompanyId { get; set; }
        public string WarehouseId { get; set; }
    }
    public class reqSaveTaxlist
    {
        public string CompanyId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseID { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ReferenceID { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string TaxName { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Value { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string objectName { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Remark { get; set; }
    }
    public class RequestGetTaxList
    {
        public string CompanyId { get; set; }
        public string CustomerID { get; set; }
        public string WarehouseID { get; set; }
        public string ReferenceID { get; set; }
        public string UserID { get; set; }
    }
    public class reqEditTax
    {
        public string CompanyId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseID { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string RefID { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string TaxName { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Value { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Ramark { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string UserID { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string rowno { get; set; }
    }
}
