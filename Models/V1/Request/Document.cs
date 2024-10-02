namespace WMSWebAPI.Models.V1.Request
{
    public class GetDocumentList
    {
        public string CompanyId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string ReferenceID { get; set; }
        public string ObjectName { get; set; }

    }
    public class RemoveDocumentRequest
    {
        public string CustomerHeadId { get; set; }
        public string UserId { get; set; }
        public string RefferenceId { get; set; }
        public string ObjectName { get; set; }
    }
    public class SavedocumentRequest
    {
        public string ObjectName { get; set; }
        public string CompanyId { get; set; }
        public string CustomerID { get; set; }
        public string UserId { get; set; }
        public string ReferenceID { get; set; }
        public string DocumentName { get; set; }
        public string Description { get; set; }
        public string DocumentType { get; set; }
        public string FileType { get; set; }
        public string DocumentDownloadPath { get; set; }
        public string DocumentSavePath { get; set; }
    }
    public class ReqUploadDocument
    {
        public string CustomerHeadId { get; set; }
        public string ReferenceID { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public Byte[] file { get; set; }
        public string objectName { get; set; }
        public string DocDownload { get; set; }

    }
}
