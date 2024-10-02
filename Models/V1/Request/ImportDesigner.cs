namespace WMSWebAPI.Models.V1.Request
{
    public class ImportDesignerListRequest
    {
        public string CustomerID { get; set; }
        public string CompanyID { get; set; }
        public string UserID { get; set; }
    }

    //change API
    public class ImportDesignerObjectListRequest
    {
        public string UserID { get; set; }
        //public string ViewName { get; set; } //change parameter
    }
    public class ImpDesignTableColoumRequest
    {
        public string UserID { get; set; }
        public string ImportID { get; set; }
        public string TableNM { get; set; }

    }
    public class ImpDesignTblColoumDataTypeRequest
    {

        public string ObjectID { get; set; }

        public string CompanyID { get; set; }

        public string CustomerID { get; set; }

        public string UserID { get; set; }






    }
    public class ImportDesignerSaveRequest
    {
        public string ColumnData { get; set; }
        // public string ObjectName { get; set; }
        public string ViewName { get; set; }
        public string CompanyID { get; set; }
        public string CustomerID { get; set; }
        public string ImpID { get; set; }
        public string UserID { get; set; }

    }
    public class ImportDesignerViewListRequest
    {
        public string CustomerID { get; set; }
        public string CompanyID { get; set; }
        public string UserID { get; set; }
    }

    public class CustomImportDetailSavedataRequest
    {
        public string CustomerID { get; set; }
        public string Object { get; set; }
        public string UserID { get; set; }
    }
}
