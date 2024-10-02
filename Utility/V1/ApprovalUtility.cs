using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class ApprovalUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public ApprovalUtility()
        {
            obj = new DBActivity();
        }

        #region Start Rahul Patil Demand Portal Approval code
        public string ApproverList(GetApproverListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@oid", req.OrderID)
                    };
            return obj.ConvertDataSetToJSON(obj.Return_DataSet("SP_ApproverList", param));
        }
        public string SaveApproval(SaveApprovalRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@reqid", req.RequestID),
                        new SqlParameter("@ApprovalLevel", req.APL),
                        new SqlParameter("@uid", req.UserId),
                        new SqlParameter("@aplstatus", req.ApprovalStatus),
                        new SqlParameter("@remark", req.ApprovalRemark),
                        new SqlParameter("@reason", req.Reasoncode)
                    };
            return obj.Return_ScalerValue("SaveApprovalNew", param);
        }
        public string OrderParameterList(GetOrderParameterRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@oid", req.OrderID),
                        new SqlParameter("@obj", req.obj)
                    };
            return obj.ConvertDataSetToJSON(obj.Return_DataSet("SP_GetOrderParameter", param));
        }

        #endregion End Rahul Patil Demand Portal Approval code

        #region Start Main Approval Code
        public async Task<JsonElement> GetApplicationUtil(GetApplicationReq req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyID",req.CompanyID),
                        new SqlParameter("@CustomerID", req.CustomerID),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("AP_GetApplication", param));
        }

        public async Task<JsonElement> GetObjectUtil(GetObjectReq req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Application",req.Application),
                        new SqlParameter("@CompanyID",req.CompanyID),
                        new SqlParameter("@CustomerID", req.CustomerID),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("AP_GetApproObject", param));
        }

        public async Task<JsonElement> GetEventUtil(GetEventReq req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Object",req.Object),
                        new SqlParameter("@Application",req.Application),
                        new SqlParameter("@CompanyID",req.CompanyID),
                        new SqlParameter("@CustomerID", req.CustomerID),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("AP_GetApproEvent", param));
        }

        public async Task<JsonElement> GetApproverlistUtil(GetApproverReq req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyID",req.CompanyID),
                        new SqlParameter("@CustomerID", req.CustomerID),
                        new SqlParameter("@WarehouseID", req.WarehouseID),
                        new SqlParameter("@ApproHeadID", req.ApproHeadID),
                        new SqlParameter("@Level", req.Level),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("AP_GetApprovalUserList", param));
        }

        public string AddApprovalHeadUtil(AddMApprovalHeadReq req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Application", req.Application),
                        new SqlParameter("@Object", req.Object),
                        new SqlParameter("@Event", req.Event),
                        new SqlParameter("@ApproLevel", req.ApproLevel),
                       // new SqlParameter("@Condition", req.Condition),
                        new SqlParameter("@Active", req.Active),
                        new SqlParameter("@CompanyID", req.CompanyID),
                        new SqlParameter("@CustomerID", req.CustomerID),
                        new SqlParameter("@WarehouseID", req.WarehouseID),
                        new SqlParameter("@UserID", req.UserID),
                    };
            return obj.Return_ScalerValue("AP_SaveMastApprovalHead", param);
        }

        public string AddMApprovalDetailUtil(AddMApprovalDetailReq req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ApHeadID", req.ApHeadID),
                        new SqlParameter("@ApproLevel", req.ApproLevel),
                        new SqlParameter("@ApproverID", req.ApproverID),
                        new SqlParameter("@UserID", req.UserID),
                        new SqlParameter("@Event", req.Event),
                        new SqlParameter("@Condition", req.Condition),
                    };
            return obj.Return_ScalerValue("AP_SaveMastApproDetail", param);
        }

        public async Task<JsonElement> GetMApproheadUtil(GetMApproheadReq req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerID", req.Customerid),
                        new SqlParameter("@WarehouseID", req.warehouseid),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("AP_GetApprovalHead", param));
        }

        public async Task<JsonElement> GetMApprodetailUtil(GetMApprodetailReq req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ApprovHeadID", req.ApprovHeadID),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("AP_GetApprovalUserDetail", param));
        }

        public string RemoveApproUserUtil(RemoveApproUserReq req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ApprovalHeadID", req.ApprovalHeadID),
                        new SqlParameter("@Level", req.Level),
                        new SqlParameter("@ApproverID", req.ApproverID),
                        new SqlParameter("@ModifiedByID", req.ModifiedByID),
                    };
            return obj.Return_ScalerValue("AP_RemoveApproverUser", param);
        }

        public string SaveCancelApproUtil(SaveCancelApproReq req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Param", req.Param),
                        new SqlParameter("@ApproHeadID", req.ApproHeadID),
                    };
            return obj.Return_ScalerValue("AP_SaveCancelApproRecord", param);
        }


        #endregion End Main Approval Code

        #region Start Main Approval Transaction Code 
        public string SaveApprovalTransUtil(SaveApprovalTransReq req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Object", req.Object),
                        new SqlParameter("@ReferenceID", req.ReferenceID),
                        new SqlParameter("@CustomerID", req.CustomerID),
                        new SqlParameter("@WarehouseID", req.WarehouseID),
                    };
            return obj.Return_ScalerValue("AP_InsertApprovalTrans", param);
        }

        public async Task<JsonElement> GetApprovalTransUtil(GetApprovalTransReq req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Object", req.Object),
                        new SqlParameter("@ReferenceID", req.ReferenceID),
                        new SqlParameter("@CustomerID", req.CustomerID),
                        new SqlParameter("@WarehouseID", req.WarehouseID),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("AP_GetApprovalTrans", param));
        }

        public string UpdateApprovalTransUtil(UpdateApprovalTransReq req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerID", req.CustomerID),
                        new SqlParameter("@WarehouseID", req.WarehouseID),
                        new SqlParameter("@Object", req.Object),
                        new SqlParameter("@ReferenceID", req.ReferenceID),
                        new SqlParameter("@Remark", req.Remark),
                        new SqlParameter("@ApproverID", req.ApproverID),
                        new SqlParameter("@Status", req.Status),
                        new SqlParameter("@ApproLevel", req.ApproLevel),
                        new SqlParameter("@UserID", req.UserID),
                        new SqlParameter("@AppEvent", req.AppEvent),
                    };
            return obj.Return_ScalerValue("AP_updateApprovalTrans", param);
        }

        public string InsertApprovalTransUtil(InsertApprovalTransReq req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@Object", req.Object),
                new SqlParameter("@ReferenceID", req.ReferenceID),
                new SqlParameter("@ApproEvent", req.ApproEvent),
                new SqlParameter("@Customerid", req.Customerid),
                new SqlParameter("@UserID", req.UserID),
                new SqlParameter("@warehouseID", req.warehouseID),
            };
            return obj.Return_ScalerValue("DP_InsertApprovalTransDetails", param);
        }

        #endregion End Main Approval Transaction Code 
    }

    
}

