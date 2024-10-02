namespace WMSWebAPI.Models.V1.Request
{
    #region Start Rahul Patil Demand Portal Approval code
    public class GetApproverListRequest
    {
        public string UserId { get; set; }
        public string OrderID { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string OrderType { get; set; }
    }
    public class SaveApprovalRequest
    {
        public string RequestID { get; set; }
        public string ApprovalStatus { get; set; }
        public string APL { get; set; }
        public string ApprovalRemark { get; set; }
        public string Reasoncode { get; set; }
        public string UserId { get; set; }
    }
    public class GetOrderParameterRequest
    {
        public string UserId { get; set; }
        public string OrderID { get; set; }
        public string obj { get; set; }
    }

    #endregion Start Rahul Patil Demand Portal Approval code


    #region Start Main Approval master Code 
    public class GetApplicationReq
    {
        public long CompanyID { get; set; }
        public long CustomerID { get; set; }
        public long UserID { get; set; }
    }

    public class GetObjectReq
    {
        public string Application { get; set; }
        public long CompanyID { get; set; }
        public long CustomerID { get; set; }
        public long UserID { get; set; }
    }

    public class GetEventReq
    {
        public string Object { get; set; }
        public string Application { get; set; }
        public long CompanyID { get; set; }
        public long CustomerID { get; set; }
        public long UserID { get; set; }
    }

    public class GetApproverReq
    {
        public long CompanyID { get; set; }
        public long CustomerID { get; set; }
        public long WarehouseID { get; set; }
        public int ApproHeadID { get; set; }
        public string Level { get; set; }
        public long UserID { get; set; }
    }

    public class AddMApprovalHeadReq
    {
        public string Application { get; set; }
        public string Object { get; set; }
        public string Event { get; set; }
        public string ApproLevel { get; set; }
        //  public string Condition { get; set; }
        public string Active { get; set; }
        public long CompanyID { get; set; }
        public long CustomerID { get; set; }
        public long WarehouseID { get; set; }
        public long UserID { get; set; }

    }

    public class AddMApprovalDetailReq
    {
        public int ApHeadID { get; set; }
        public string ApproLevel { get; set; }
        public long ApproverID { get; set; }
        public long UserID { get; set; }
        public string Event { get; set; }
        public string Condition { get; set; }
    }

    public class GetMApproheadReq
    {
        public long Customerid { get; set; }
        public long warehouseid { get; set; }
        public long UserID { get; set; }
    }

    public class GetMApprodetailReq
    {
        public int ApprovHeadID { get; set; }
        public long UserID { get; set; }
    }

    public class RemoveApproUserReq
    {
        public int ApprovalHeadID { get; set; }
        public string Level { get; set; }
        public long ApproverID { get; set; }
        public long ModifiedByID { get; set; }
    }

    public class SaveCancelApproReq
    {
        public string Param { get; set; }
        public long ApproHeadID { get; set; }
        public long UserID { get; set; }

    }

    #endregion End Main Approval master Code 

    #region Start Main Approval Transaction Code 
    public class SaveApprovalTransReq
    {
        public string Object { get; set; }
        public long ReferenceID { get; set; }
        public long CustomerID { get; set; }
        public long WarehouseID { get; set; }
        public long UserID { get; set; }
    }

    public class GetApprovalTransReq
    {
        public string Object { get; set; }
        public long ReferenceID { get; set; }
        public long UserID { get; set; }
        public long CustomerID { get; set; }
        public long WarehouseID { get; set; }
    }

    public class UpdateApprovalTransReq
    {
        public long CustomerID { get; set; }
        public long WarehouseID { get; set; }
        public string Object { get; set; }
        public long ReferenceID { get; set; }
        public string Remark { get; set; }
        public long ApproverID { get; set; }
        public string Status { get; set; }
        public string ApproLevel { get; set; }
        public long UserID { get; set; }
        public string AppEvent { get; set; }

    }

    public class InsertApprovalTransReq
    {
        public string Object { get; set; }
        public long ReferenceID { get; set; }
        public string ApproEvent { get; set; }
        public long Customerid { get; set; }
        public long UserID { get; set; }
        public long warehouseID { get; set; }
    }


    #endregion End Main Approval Transaction Code 
}
