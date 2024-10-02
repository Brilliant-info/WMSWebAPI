namespace WMSWebAPI.Models.V1.Request
{
    public class GetCommunicationRequest
    {
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public string ObjectName { get; set; }
    }
    public class SaveCommunicationRequest
    {
        public string Message { get; set; }
        public string FilePath1 { get; set; }
        public string FilePath2 { get; set; }
        public string OrderId { get; set; }
        public string ObjectName { get; set; }
        public string UserId { get; set; }
        public string tableName { get; set; }
    }
    public class RemoveCommunicationRequest
    {
        public string CommId { get; set; }
        public string FilePath1 { get; set; }
        public string UserId { get; set; }
    }
}
