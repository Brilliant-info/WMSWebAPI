namespace WMSWebAPI.Models.V1.Request
{
    public class GetPackingMasterListRequest
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }
        public string UserId { get; set; }
        public string Type { get; set; }
    }
    public class SavePackingMasterDetailRequest
    {
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public string Type { get; set; }
        public string label { get; set; }
        public string Number { get; set; }

    }
}
