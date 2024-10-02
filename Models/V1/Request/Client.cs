using System.ComponentModel.DataAnnotations;

namespace WMSWebAPI.Models.V1.Request
{
    public class GetClientRequest
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }
        public string CustomerId { get; set; }
        public string UserID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Search { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Filter { get; set; }
    }
    public class AddEditClientRequest
    {
        public string ClientId { get; set; }
        public string CompanyID { get; set; }
        public string CustomerId { get; set; }
        public string UserId { get; set; }
        public string ClientName { get; set; }
        public string ClientCode { get; set; }
        public string Sector { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string LedgerNo { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Website { get; set; }
        public string Active { get; set; }
        public string SAPCode { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CLGroupCode { get; set; }
        public string CategoryId { get; set; }
        public string GSTINUIN { get; set; }

    }
    public class editclientList
    {
        public string ID { get; set; }
    }

    public class GetParameter
    {
        public string Object { get; set; }
        public string ReferenceID { get; set; }
        public string CompanyID { get; set; }
        public string CreatedBy { get; set; }
    }

    public class GetddlObjectParam
    {
        public string Object { get; set; }
        public string CompanyID { get; set; }
        public string CreatedBy { get; set; }
    }

    public class SaveEditParamRequest
    {
        public string Objectname { get; set; }
        public string StatuDetailID { get; set; }
        public string ReferenceID { get; set; }
        public string StatutoryID { get; set; }
        public string StatutoryValue { get; set; }
        public string createdBy { get; set; }
        public string CompanyID { get; set; }
    }
    public class BindClientCategory
    {
        public string CompanyId { get; set; }
        public string CustomerID { get; set; }

        public string UserID { get; set; }
        public string WarehouseID { get; set; }

    }


    public class GetBankDetails
    {

        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string Object { get; set; }
        public string ClientId { get; set; }
    }

    public class SaveBankDetails
    {

        public string CompanyID { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string Object { get; set; }
        public string clientID { get; set; }
        public string ObjectName { get; set; }
        public string AccHolderName { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string Creditlimit { get; set; }
        public string CreditDay { get; set; }
        /* public string AccNumber { get; set; }
         public string IfscCode { get; set; }
         public string SwiftCode { get; set; }*/
    }

    public class EditBankDetails
    {

        public string ID { get; set; }
        public string CompanyID { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string Object { get; set; }
        public string clientID { get; set; }
        public string ObjectName { get; set; }
        public string AccHolderName { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string Creditlimit { get; set; }
        public string CreditDay { get; set; }
        /* public string AccNumber { get; set; }
         public string IfscCode { get; set; }
         public string SwiftCode { get; set; }*/
    }
}
