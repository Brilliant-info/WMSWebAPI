
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WMSWebAPI.Models.V1.Request
{
    public class TaskAssingment
    {
        public string OrderID { get; set; }
        public string OrderdetailID { get; set; }
        public string AssingType { get; set; }
        public string Object { get; set; }

        public DateTime Assingdate { get; set; }
        public string AssingTime { get; set; }
        public int CreatedBy { get; set; }
        public int companyID { get; set; }
        public int customerID { get; set; }
        public string userID { get; set; }
        public int warehouseID { get; set; }
        public string Items { get; set; }

    }
    public class Getuserlist
    {
        public string companyID { get; set; }
        public string Customer { get; set; }
        public string Warehouse { get; set; }
        public string Obj { get; set; }
        public string taskcode { get; set; }

    }
    public class getTaskListByObj
    {
        public string obj { get; set; }
        public string type { get; set; }
        public int orderID { get; set; }
        public int customerID { get; set; }
        public int warehouseID { get; set; }
        public int userID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string searchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string searchValue { get; set; }
        public string currentpg { get; set; }
        public string recordlmt { get; set; }


    }
    public class TaskAssinDetails
    {
        public int AsgID { get; set; }
        public int OrderID { get; set; }

        public string ProdID { get; set; }
        public string ProdCode { get; set; }
        public int UOMID { get; set; }
        public string UOM { get; set; }
        public string Lottable1 { get; set; }
        public string Lottable2 { get; set; }
        public string Lottable3 { get; set; }

    }
    public class GetAssingmentList
    {
        public int CurrentPage { get; set; }
        public int recordLimit { get; set; }
        public int CustomerId { get; set; }
        public int WarehouseId { get; set; }
        public int UserId { get; set; }
        public string Object { get; set; }
        public string Activetab { get; set; }
        public string searchFilter { get; set; }
        public string searchValue { get; set; }
    }

    public class AssingmentGroupList
    {
        public string obj { get; set; }
        public int companyID { get; set; }
        public int customerID { get; set; }
        public string userID { get; set; }
        public int warehouseID { get; set; }
        public string filtervalue { get; set; }
        public string filtercol { get; set; }
        public string currentpg { get; set; }
        public string recordlmt { get; set; }
    }

    public class gerUserSuggetionList
    {
        public int companyID { get; set; }
        public string skey { get; set; }
    }

    public class validAssingorder
    {
        public int orderid { get; set; }
        public string Obj { get; set; }
    }
    public class reassignTask
    {
        public string TaskCode { get; set; }
        public string UserID { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        //TaskStatus
        public string TaskStatus { get; set; }
    }


    public class RemoveTaskAssingment
    {
        public string OrderID { get; set; }
        public string TaskCode { get; set; }
        public string UserID { get; set; }
    }

    public class checkTaskAssignment
    {
        public string CustomerId { get; set; }
        public string UserId { get; set; }

    }

    public class TaskAssignmentPODetailRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
    }

    public class TaskAssignmentPOHeadRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public string Object { get; set; }
    }
}
