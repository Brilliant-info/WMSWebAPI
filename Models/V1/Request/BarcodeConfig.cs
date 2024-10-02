namespace WMSWebAPI.Models.V1.Request
{
    public class BarcodeObjectListRequest
    {
        public string CompanyID { get; set; }
        public string CustomerID { get; set; }
        public string WarehouseID { get; set; }
    }
    public class TemplateListRequest
    {
        public string ObjectID { get; set; }
        public string CompanyID { get; set; }
        public string CustomerID { get; set; }
        public string WarehouseID { get; set; }

    }
    public class SaveBarcodeConfigRequest
    {
        public string TemplateID { get; set; }
        public string CompanyID { get; set; }
        public string CustomerID { get; set; }
        public string Prefix { get; set; }
        public string LabelSize { get; set; }
        public string ObjectId { get; set; }
        public string WarehouseID { get; set; }
        public string ID { get; set; }
    }
    public class ViewBarcodeConfigRequest
    {
        public string ObjectID { get; set; }
        public string CompanyID { get; set; }
        public string CustomerID { get; set; }
        public string WarehouseID { get; set; }

    }
}
