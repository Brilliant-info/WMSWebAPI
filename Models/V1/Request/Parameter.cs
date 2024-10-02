namespace WMSWebAPI.Models.V1.Request
{
    public class GetParameterListRequest
    {
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public string ObjectId { get; set; }
        public string ObjectName { get; set; }
    }
    public class AddParameterRequest
    {
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string ObjectId { get; set; }
        public string ObjectName { get; set; }
        public string ParameterName { get; set; }
        //public string ValueType { get; set; }
        public string Value { get; set; }
        public string Id { get; set; }
        public string Active { get; set; }
    }
}
