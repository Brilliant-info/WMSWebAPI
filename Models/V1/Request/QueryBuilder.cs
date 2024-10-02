using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WMSWebAPI.Models.V1.Request
{
    public class QueryBuilderListRequest
    {
        public string CustomerID { get; set; }
        public string CompanyID { get; set; }
        public string UserID { get; set; }
        public string RoleID { get; set; }
    }
    public class QueryBuilderExecRequest
    {
        public string CustomerID { get; set; }
        public string CompanyID { get; set; }
        public string UserID { get; set; }
        public string RoleID { get; set; }
        public string QueryID { get; set; }
        public string WarehouseID { get; set; }

    }
    public class QueryBuilderObjectRequest
    {
        public string CustomerID { get; set; }
        public string CompanyID { get; set; }
        public string UserID { get; set; }
        public string RoleID { get; set; }

    }
    public class QueryBuilderAddUpdateDetailRequest
    {
        public string CustomerID { get; set; }
        public string WarehouseID { get; set; }
        public string UserID { get; set; }
        public string QueryID { get; set; }
        public string ObjectName { get; set; }
        public string SqlQuery { get; set; }
        public string SqlHtmlObj { get; set; }
        public string SqlTitle { get; set; }
        public string DefaultCriteria { get; set; }
        public string Type { get; set; }
    }
    public class QueryBuilderAddUpdateNotificationsRequest
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string NotificationTo { get; set; }
        public string Interval { get; set; }
        public string SendAt { get; set; }
        public string NotiDayOfWeek { get; set; }
        public string NotiDayOfMonth { get; set; }
        public string UserID { get; set; }
        public string ObjectName { get; set; }
        public string QueryId { get; set; }
        public string NotificationId { get; set; }
        public string msgbody { get; set; }


    }
    public class QueryBuilderNotificationSaveRequest
    {
        public string EmailTemplateID { get; set; }
        public string WarehouseID { get; set; }
        public string CustomerID { get; set; }
        public string UserID { get; set; }
        public string QueryId { get; set; }
        public string NotificationId { get; set; }
        public string AddEmail { get; set; }

    }
    public class QueryBuilderNotificationRemoveRequest
    {
        public string EmailTemplateID { get; set; }
        public string WarehouseID { get; set; }
        public string CustomerID { get; set; }
        public string UserID { get; set; }
        public string QueryId { get; set; }
        public string NotificationId { get; set; }
        public string AddEmail { get; set; }

    }
    public class QueryExecButtonRequest
    {
        public string UserID { get; set; }
        public string SqlQry { get; set; }
        public string frDate { get; set; }
        public string ToDate { get; set; }
        public string Obj { get; set; }
        public string CustId { get; set; }
        public string WId { get; set; }
        public string QueryID { get; set; }

    }
    public class QueryBuilderObjectColRequest
    {
        public string UserID { get; set; }
        public string QueryID { get; set; }

    }

    public class SaveQueryRequest
    {
        public string SqlQuery { get; set; }
        public string titleName { get; set; }
        public string QueryId { get; set; }
        public string UserId { get; set; }
        public string RoleID { get; set; }
        public string CustomerID { get; set; }
        public string CompanyID { get; set; }
        public string warehouseID { get; set; }

    }
    public class FlagQueryRequest
    {
        public string UserID { get; set; }
        public string RoleID { get; set; }
        public string CustomerID { get; set; }
        public string CompanyID { get; set; }
        public string WarehouseID { get; set; }
        public string QueryID { get; set; }
        public string Flag { get; set; }

    }
}
