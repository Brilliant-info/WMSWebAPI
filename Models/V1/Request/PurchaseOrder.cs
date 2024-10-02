
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WMSWebAPI.Models.V1.Request
{
    public class SaveOrderHeadRequest
    {
        public string Poid { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Object { get; set; }
        public string InboundReceiptDate { get; set; }
        public string ExpectedDeliveryDate { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CustomerRefNo { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Remark { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string VendorId { get; set; }

    }
    public class SavePOSKUDetailRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public string SkuId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string RequestedQty { get; set; }
        public string UOM { get; set; }
        public string UOMId { get; set; }
        public string OrderQty { get; set; }
        public string Lottables { get; set; }
        public string CaseNetWeight { get; set; }
        public string CaseGrossWeight { get; set; }
        public string TotalCarton { get; set; }
    }
    public class RemovePOSKURequest
    {

        public string OrderId { get; set; }
        public string Id { get; set; }
        public string obj { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string POIDDT { get; set; }
    }
    public class closePOpopup
    {
        public string orderID { get; set; }
    }
    public class GetInboundListRequest
    {
        public string CurrentPage { get; set; }
        public string recordLimit { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string Object { get; set; }
        public string Activetab { get; set; }
        public string searchFilter { get; set; }
        public string searchValue { get; set; }
    }
    public class POSKUSuggestionRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public string skuobject { get; set; }
        public string skey { get; set; }
    }
    public class POSKUUOMRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }

        public string SkuId { get; set; }
    }
    public class POSearchSKUSRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public string skey { get; set; }
    }
    public class PODetailRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
    }
    public class PurchaseOrderDetails
    {
        public string Id { get; set; }
        public string SkuId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public string RequestedQty { get; set; }
        public string UOM { get; set; }
        public string UOMId { get; set; }
        public string OrderQty { get; set; }
        public string Lot1 { get; set; }
        public string CaseNetWeight { get; set; }
        public string CaseGrossWeight { get; set; }
        public string TotalCarton { get; set; }
        public string isfinal { get; set; }

        public List<UomList> UomList;
        public string RemainingQty { get; set; }
        public string orderfrom { get; set; }
    }
    public class UomList
    {
        public string Id { get; set; }
        public string Uom { get; set; }
        public string UnitQty { get; set; }
    }
    public class POHeadRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public string OrderType { get; set; }
    }
    public class qualitycheckreq
    {
        [DataMember(IsRequired = true, Order = 0)]
        public string customerID { get; set; }
    }
    public class UpdatePostatus
    {

        public string OrderID { get; set; }

    }
    public class GetVendorRequest
    {
        public long CompanyId { get; set; }
        public long WarehouseId { get; set; }
        public long CustomerId { get; set; }
        public long UserId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Object { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Skey { get; set; }
    }
    public class reqOrderDetails
    {
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyId { get; set; }
        public string CustomerId { get; set; }
    }
    public class ReqTaskComplete
    {
        public int CurrentPage { get; set; }
        public int recordLimit { get; set; }
        public long UserID { get; set; }
        public long CustomerID { get; set; }
        public long warehouseID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string searchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string searchValue { get; set; }
    }

    public class ReqTaskCompleteSKULst
    {
        public int CurrentPage { get; set; }
        public int recordLimit { get; set; }
        public long OrderID { get; set; }
        public string ObjectName { get; set; }
        public long UserID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string searchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string searchValue { get; set; }
    }
}
