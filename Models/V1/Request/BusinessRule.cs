namespace WMSWebAPI.Models.V1.Request
{
    public class GetBusinessRule
    {
        public string CompanyID { get; set; }
        public string CustomerID { get; set; }
        public string WarehouseID { get; set; }
        public string CreatedBy { get; set; }
    }


    public class AddBusinessRuleRequest
    {
        public string CompanyID { get; set; }
        public string CustomerID { get; set; }
        public string WarehouseID { get; set; }
        public string CreatedBy { get; set; }
        public string BusinessCode { get; set; }
        public string Active { get; set; }
    }

}
