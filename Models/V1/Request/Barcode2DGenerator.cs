namespace WMSWebAPI.Models.V1.Request
{
    public class Barcode2DGeneratorRequest
    {
        public string CompanyID { get; set; }
        public string CustomerID { get; set; }
        public string WarehouseID { get; set; }
        public string BarcodeText { get; set; }
    }
}
