namespace WMSWebAPI.Models.V1.Request
{
    public class DashboardTopInwardOutwardRequest
    {
        public string WarehouseID { get; set; }
        public string VendorID { get; set; }
        public string UserID { get; set; }
        public string ClientID { get; set; }
        public string CustomerID { get; set; }

    }
    public class DashboardTopInventoryRequest
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string CompanyID { get; set; }
    }
    public class CounterDashboardRequest
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string CompanyID { get; set; }
        public string ClientID { get; set; }
        public string WarehouseID { get; set; }

    }
    public class InwardBarchartRequest
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string CompanyID { get; set; }
        public string VendorID { get; set; }
        public string WarehouseID { get; set; }

    }
    public class OutwardPieChartRequest
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string CompanyID { get; set; }
        public string ClientID { get; set; }
        public string WarehouseID { get; set; }
    }
    public class DispatchCountLast4MonthRequest
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string CompanyID { get; set; }
        public string ClientID { get; set; }
        public string WarehouseID { get; set; }

    }
}
