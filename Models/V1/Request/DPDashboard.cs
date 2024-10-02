namespace WMSWebAPI.Models.V1.Request
{
    public class CounterDPDashboardRequest
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string CompanyID { get; set; }
        public string ClientID { get; set; }
        public string WarehouseID { get; set; }
    }
    public class DispatchCountLast4MonthDPRequest
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string CompanyID { get; set; }
        public string ClientID { get; set; }
        public string WarehouseID { get; set; }

    }
}
