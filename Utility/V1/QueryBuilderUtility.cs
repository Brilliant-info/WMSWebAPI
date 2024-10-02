using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using System.Web;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class QueryBuilderUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public QueryBuilderUtility()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> QueryBuilderList(QueryBuilderListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@RoleID", Int64.Parse(req.CustomerID)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_QueryBuilderList", param));
        }
        public async Task<JsonElement> QueryBuilderExec(QueryBuilderExecRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@RoleID", Int64.Parse(req.RoleID)),
                        new SqlParameter("@QueryID", Int64.Parse(req.QueryID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_QueryBuilderExec", param));
        }
        public async Task<JsonElement> QueryBuilderObject(QueryBuilderObjectRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@RoleID", Int64.Parse(req.RoleID)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GetQueryBuilderObjectNew", param));
        }
        public string QueryBuilderAddUpdateDetail(QueryBuilderAddUpdateDetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@SqlTitle", req.SqlTitle),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@QueryID", Int64.Parse(req.QueryID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@ObjectName", req.ObjectName),
                        new SqlParameter("@SqlQuery", req.SqlQuery),
                        new SqlParameter("@SqlHtmlObj", req.SqlHtmlObj),
                        new SqlParameter("@Type", req.Type),
                        new SqlParameter("@DefaultCriteria", req.DefaultCriteria),

                    };
            return obj.Return_ScalerValue("SP_QueryBuilderAddUpdateDetail", param);
        }
        public string QueryBuilderAddUpdateNotifications(QueryBuilderAddUpdateNotificationsRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Title", req.Title),
                        new SqlParameter("@Message", req.Message),
                        new SqlParameter("@NotificationTo", req.NotificationTo),
                        new SqlParameter("@Interval", req.Interval),
                        new SqlParameter("@SendAt", req.SendAt),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@ObjectName", req.ObjectName),
                        new SqlParameter("@QueryId", Int64.Parse(req.QueryId)),
                        new SqlParameter("@NotificationId", Int64.Parse(req.NotificationId)),
                        new SqlParameter("@NotiDayOfWeek", req.NotiDayOfWeek),
                        new SqlParameter("@NotiDayOfMonth", req.NotiDayOfMonth),
                        new SqlParameter("@msgbody", req.msgbody),

                    };
            return obj.Return_ScalerValue("SP_QueryBuilderAddUpdateNotifications", param);
        }

        public string QueryBuilderNotificationSave(QueryBuilderNotificationSaveRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@EmailTemplateID", Int64.Parse(req.EmailTemplateID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@QueryId", Int64.Parse(req.QueryId)),
                        new SqlParameter("@NotificationId", Int64.Parse(req.NotificationId)),
                        new SqlParameter("@AddEmail", req.AddEmail),
                    };
            return obj.Return_ScalerValue("sp_GetNotificationSave", param);
        }

        public string QueryBuilderNotificationRemove(QueryBuilderNotificationRemoveRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@EmailTemplateID", Int64.Parse(req.EmailTemplateID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@QueryId", Int64.Parse(req.QueryId)),
                        new SqlParameter("@NotificationId", Int64.Parse(req.NotificationId)),
                        new SqlParameter("@AddEmail", req.AddEmail),
                    };
            return obj.Return_ScalerValue("RemoveEmailNotification", param);
        }
        public async Task<JsonElement> QueryExecButton(QueryExecButtonRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@SqlQry",req.SqlQry),
                        new SqlParameter("@frDate",req.frDate),
                        new SqlParameter("@ToDate",req.ToDate),
                        new SqlParameter("@Obj", req.Obj),
                        new SqlParameter("@CustId",Int64.Parse(req.CustId)),
                        new SqlParameter("@WId", Int64.Parse(req.WId)),
                        new SqlParameter("@QueryID", Int64.Parse(req.QueryID)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_QueryExecbutton", param));
        }
        public async Task<JsonElement> QueryBuilderObjectCol(QueryBuilderObjectColRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@QueryID", Int64.Parse(req.QueryID)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_QueryBuilderObjectCol", param));
        }
        public async Task<JsonElement> SaveQuery(SaveQueryRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@SqlQuery",req.SqlQuery),
                        new SqlParameter("@titleName",req.titleName),
                        new SqlParameter("@QueryId", Int64.Parse(req.QueryId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@RoleID", Int64.Parse(req.RoleID)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@warehouseID", Int64.Parse(req.warehouseID)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_QueryBuilderSaveQuery", param));
        }

        public async Task<JsonElement> QueryFlag(FlagQueryRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@RoleID",Int64.Parse(req.RoleID)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@WarehouseID",Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@QueryID", Int64.Parse(req.QueryID)),
                        new SqlParameter("@Flag",req.Flag),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_QueryBuilderFlag", param));
        }
    }
}
