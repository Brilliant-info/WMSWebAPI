using System.ComponentModel.DataAnnotations;

namespace WMSWebAPI.Models.V1.Request
{
    public class APITPList
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string CompnayId { get; set; }
    }

    public class RequestAPITPSave
    {
        public string Id { get; set; }
        public string API { get; set; }
        public string Method { get; set; }
        public string APIKeys { get; set; }
        public string CompnayId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string IsActive { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }


    }

    public class RequestAPITPActiveList
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string CompnayId { get; set; }


    }

    public class RequestAPITPLogList
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string fromDate { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string toDate { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string OrderType { get; set; }


    }
    public class RequestAPITPKEY
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompnayId { get; set; }
        public string getkeyid { get; set; }


    }
    public class RequestAPIJSON
    {
        public string getapiLogId { get; set; }
        public string fileLogPath { get; set; }


    }
    public class ResponseAPIJSON
    {
        public string getapiLogId { get; set; }
        public string fileLogPath { get; set; }


    }

    public class APITPParameterlist
    {
        public string CompanyID { get; set; }
        public string CustomerID { get; set; }
        public string UserID { get; set; }
        public string ObjectID { get; set; }
    }
}
