using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WMSWebAPI.Models.V1.Request;
using System.Text.Json;

namespace WMSWebAPI.Utility.V1
{
    public class TaskAssingmentUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public TaskAssingmentUtility()
        {
            obj = new DBActivity();
        }

        public async Task<JsonElement> getTaskList(getTaskListByObj req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Obj",req.obj),
                        new SqlParameter("@type",req.type),
                        new SqlParameter("@OrderID", req.orderID),
                        new SqlParameter("@customerID", req.customerID),
                        new SqlParameter("@warehouseID", req.warehouseID),
                        new SqlParameter("@userID", req.userID),
                        new SqlParameter("@searchFilter", req.searchFilter),
                        new SqlParameter("@searchValue", req.searchValue),
                        new SqlParameter("@currentpg", req.currentpg),
                        new SqlParameter("@recordlmt", req.recordlmt)

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_getTaskList", param));
        }
        public string CreateAssingment(TaskAssingment req)
        {
            string result = "";
            param = new SqlParameter[]
                    {

                new SqlParameter("@OrderID",req.OrderID),
                new SqlParameter("@OrderdetailID",req.OrderdetailID),
                new SqlParameter("@type",req.AssingType),
                new SqlParameter("@Object", req.Object),
                new SqlParameter("@assingmentdate",req.Assingdate),
                new SqlParameter("@time",req.AssingTime),
                new SqlParameter("@createdby",Convert.ToInt64(req.CreatedBy)),
                new SqlParameter("@companyID",Convert.ToInt64(req.companyID)),
                new SqlParameter("@customerID",req.customerID),
                new SqlParameter("@userID",Convert.ToInt64(req.userID)),
                new SqlParameter("@warehouseID",Convert.ToInt64(req.warehouseID)),
                new SqlParameter("@skuID",req.Items)
                    };
            result = obj.Return_ScalerValue("sp_CreateAssingment", param);
            if (result == "Success")
            {

            }
            return result;
        }
        public async Task<JsonElement> AssinguserList(Getuserlist req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@companyID", Int64.Parse(req.companyID)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.Customer)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.Warehouse)),
                        new SqlParameter("@TaskCode", req.taskcode),
                        new SqlParameter("@Obj", (req.Obj))

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_AssingUserList", param));
        }
        public async Task<JsonElement> getAssingmentTaskList(GetAssingmentList req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@currentpg",req.CurrentPage),
                        new SqlParameter("@recordlmt",req.recordLimit),
                        new SqlParameter("@custid",req.CustomerId),
                        new SqlParameter("@wrid",req.WarehouseId),
                        new SqlParameter("@uid",req.UserId),
                        new SqlParameter("@obj", req.Object),
                        new SqlParameter("@tabfileter", req.Activetab),
                        new SqlParameter("@searchfilter",req.searchFilter),
                        new SqlParameter("@searchvalue", req.searchValue)

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_getAssingmentTaskList", param));
        }
        public async Task<JsonElement> getAssingmentGroupList(AssingmentGroupList req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@obj",req.obj),
                        new SqlParameter("@companyID",req.companyID),
                        new SqlParameter("@customerID",req.customerID),
                        new SqlParameter("@userID",req.userID),
                        new SqlParameter("@warehouseID", req.warehouseID),
                        new SqlParameter("@filtervalue",req.filtervalue),
                        new SqlParameter("@filtercol", req.filtercol),
                        new SqlParameter("@currentpg", req.currentpg),
                        new SqlParameter("@recordlmt", req.recordlmt),

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("getAssingOrderList", param));
        }
        public async Task<JsonElement> getUsersuggetion(gerUserSuggetionList req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@companyID", req.companyID),
                        new SqlParameter("@skey", req.skey)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetUserSuggetionlist", param));
        }
        public async Task<JsonElement> getOrderValidation(validAssingorder req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@orderID", req.orderid),
                        new SqlParameter("@Obj", req.Obj)

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_getOrderAsingvalidation", param));
        }
        public string ReassignTaskToUser(reassignTask req)
        {
            param = new SqlParameter[]
                    {

                        new SqlParameter("@TaskCode",req.TaskCode),
                        new SqlParameter("@UserId",Convert.ToInt64(req.UserID)),
                        new SqlParameter("@CustomerID", req.CustomerId),
                        new SqlParameter("@WarehouseId",req.WarehouseId),
                        new SqlParameter("@TaskStatus",req.TaskStatus)

                    };
            return obj.Return_ScalerValue("dbo.sp_reassginTask", param);
        }

        public string RemoveAssingment(RemoveTaskAssingment req)
        {
            string result = "";
            param = new SqlParameter[]
                    {

                new SqlParameter("@OrderID",req.OrderID),
                new SqlParameter("@TaskCode",req.TaskCode),
                new SqlParameter("@UserId",Convert.ToInt64(req.UserID))
                    };
            result = obj.Return_ScalerValue("sp_RemoveTaskAssingment", param);
            if (result == "Success")
            {

            }
            return result;
        }

        public string checkTaskAssignment(checkTaskAssignment req)
        {
            string result = "";
            param = new SqlParameter[]
                    {

                new SqlParameter("@CustomerId",req.CustomerId),
                new SqlParameter("@UserId",req.UserId)

                    };
            result = obj.Return_ScalerValue("sp_CheckTaskAssingment", param);
            if (result == "Success")
            {

            }
            return result;
        }

        public async Task<JsonElement> GetTaskAssignmentPOHead(TaskAssignmentPOHeadRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@orderid", Int64.Parse(req.OrderId)),
                        new SqlParameter("@Object", req.Object)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetTaskAssignmentPOHead", param));
        }
    }
}
