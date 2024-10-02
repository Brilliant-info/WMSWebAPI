using System.ComponentModel.DataAnnotations;

namespace WMSWebAPI.Models.V1.Request
{
    public class GetIOTConfigRequest
    {
        public string Currentpage { get; set; }
        public string Recordlimit { get; set; }
        public string CustomerID { get; set; }
        public string WarehouseID { get; set; }
        public string UserID { get; set; }
        public string CompanyID { get; set; }
        public string Search { get; set; }
        public string Filter { get; set; }

    }
    public class GetSaveIOTConfigRequest
    {
        public string CustomerID { get; set; }
        public string WarehouseID { get; set; }
        public string UserID { get; set; }
        public string CompanyID { get; set; }
        public string Locationtype { get; set; }
        public string Pathway { get; set; }
        public string Section { get; set; }
        public string Shelf { get; set; }
        public string devicetype { get; set; }
        public string devicecode { get; set; }
        public string minTemp { get; set; }
        public string maxTemp { get; set; }
        public string minhumidity { get; set; }
        public string maxhumidity { get; set; }
        public string Currtemp { get; set; }
        public string CurrHumidity { get; set; }
        public string Active { get; set; }
        public string IOTConfigID { get; set; }
    }
    public class GetLocationTypeIOTConfigRequest
    {
        public string UserID { get; set; }
        public string WarehouseID { get; set; }
        public string LocationType { get; set; }
        public string CompanyID { get; set; }
        public string CustomerID { get; set; }


    }
    public class GetdeviceTypeIOTConfigRequest
    {
        public string UserID { get; set; }
    }
    public class GetIOTConfigTempRequest
    {
        public string ID { get; set; }
        public string CustId { get; set; }
        public string WhId { get; set; }
        public string UserId { get; set; }
        public string CompId { get; set; }
        public string deviceId { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Date { get; set; }

        public string obj { get; set; }


    }
    public class GetIOTConfigReportRequest
    {
        public string ID { get; set; }
        public string CustId { get; set; }
        public string WhId { get; set; }
        public string UserId { get; set; }
        public string CompId { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string fromDate { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string toDate { get; set; }

    }
    public class GetIOTLocbindRequest
    {
        public string LocID { get; set; }
        public string CustId { get; set; }
        public string WhId { get; set; }
        public string UserId { get; set; }
        public string CompId { get; set; }

    }
    public class GetIOTdeviceIDbindRequest
    {
        public string ID { get; set; }
        public string CustId { get; set; }
        public string WhId { get; set; }
        public string UserId { get; set; }
        public string CompId { get; set; }

    }
}
