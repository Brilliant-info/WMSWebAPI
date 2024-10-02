using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WMSWebAPI.Models.V1.Request
{
    public class GetOutboundListRequest
    {
        public string CurrentPage { get; set; }
        public string recordLimit { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string ClientId { get; set; }
        public string UserId { get; set; }
        public string Object { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string filtercol { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string filterval { get; set; }
    }
    public class SaveSOOrderHeadRequest
    {
        public string Soid { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string Object { get; set; }
        public string RequestedDate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CustomerPO { get; set; }
        public string Client { get; set; }
        public string ClientId { get; set; }
        public string BillToAddress { get; set; }
        public string BillToAddressId { get; set; }
        public string ShipToAddress { get; set; }
        public string ShipToAddressId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Remark { get; set; }
        public string Priority { get; set; }
        public string DeliveryType { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SAPOrderNo { get; set; }
        public string FinalSave { get; set; }
        public string OrderFrom { get; set; }
    }
    public class SaveSOSKUDetailRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public string SkuId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string CurrentStock { get; set; }
        public string ReserveQty { get; set; }
        public string RequestedQty { get; set; }
        public string UOM { get; set; }
        public string UOMId { get; set; }
        public string OrderQty { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Lottable { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string InitScopeQty { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Projectcode { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ProjectName { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string LogSpaceCode { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string LogSpaceName { get; set; }


    }
    public class RemoveSOSKURequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public string Id { get; set; }
    }
    public class CancelSORequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
    }
    public class HoldnReleaseRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
    }
    public class SOSKUSuggestionRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public string ClientId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string skey { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string isSuggestionList { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string portal { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Object { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Lot { get; set; }
    }
    public class SOSKUUOMRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public string OrderType { get; set; }
        public string SkuId { get; set; }
    }
    public class SOSearchSKUSRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public string OrderType { get; set; }
        public string skey { get; set; }
    }
    public class SODetailRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
    }
    public class OutboundOrderDetails
    {
        public string Id { get; set; }
        public string SkuId { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string CurrentStock { get; set; }
        public string ReserveQty { get; set; }
        public string RequestedQty { get; set; }
        public string UOM { get; set; }
        public string UOMId { get; set; }
        public string OrderQty { get; set; }
        public string Lottable { get; set; }

        public List<UomList> UomList;
        public int IsEdit { get; set; } // 0 is read and 1 is not read 
        public string InitScopeQty { get; set; }
        public string Projectcode { get; set; }
        public string ProjectName { get; set; }
        public string LogSpaceCode { get; set; }
        public string LogSpaceName { get; set; }
    }
    public class GetStagingDetailRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public string OrderType { get; set; }
    }
    public class SaveStagingDetailRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public string OrderType { get; set; }
        public string DiapatchID { get; set; }
        public string ShipAddress { get; set; }
        public string AppointDetail { get; set; }
        public string AppointDate { get; set; }
        public string Trailer { get; set; }
        public string TransportName { get; set; }
        public string TransportRemark { get; set; }
        public string DockNo { get; set; }
        public string AirBillNo { get; set; }
        public string ShipType { get; set; }
        public string ShipDate { get; set; }
        public string ExpShipDate { get; set; }
        public string LRNo { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
        public string Driver { get; set; }
        public string SealNo { get; set; }
        public string BOL { get; set; }
        public string PRONo { get; set; }
        public string FreightCharge { get; set; }
        public string MasterBOL { get; set; }
        public string CODAmt { get; set; }
        public string feeTerm { get; set; }
        public string TrailerLoadBy { get; set; }
        public string FrieghtCountBy { get; set; }
        public string CountBy { get; set; }
        public string DispatchPlan { get; set; }
        public string TrackingNo { get; set; }
    }
    public class GetSuggestedClientRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchKey { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string isSuggestionList { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Object { get; set; }
    }
    public class GetSuggestedClientAddrRequest
    {
        public string ClientID { get; set; }
        public string UserId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchKey { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string isSuggestionList { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Object { get; set; }
    }
    public class SKUSuggestList
    {
        public string ID { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UPCBarcode { get; set; }
        public string CurrentStock { get; set; }
        public string ResurveQty { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string GroupSet { get; set; }
        public string ImagePath { get; set; }
        public string SKey { get; set; }
        public string Lottables { get; set; }

        public List<UOM> UOM;

        public List<Lottable> Lottable;
    }
    public class UOM
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string UnitValue { get; set; }
        public string isSelected { get; set; }
    }
    public class Lottable
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
        public string isSelected { get; set; }
        public string IsPartofOutward { get; set; }
    }
    public class SaveSkuKeyWardRequest
    {
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Key { get; set; }
        public string ProdID { get; set; }
        public string ClientID { get; set; }
        public string CustomerId { get; set; }
        public string UserId { get; set; }
        public string WarehouseId { get; set; }
    }
    public class RemoveSkuKeyWardRequest
    {
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Key { get; set; }
        public string ProdID { get; set; }
        public string ClientID { get; set; }
        public string CustomerId { get; set; }
        public string UserId { get; set; }
        public string WarehouseId { get; set; }
    }
    public class DeAllocateOrderRequest
    {
        public string UserId { get; set; }
        public string OrderId { get; set; }
    }

    public class EditSOSKURequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string Id { get; set; }
        public decimal InitialScopeQty { get; set; }

        public decimal RequestedQty { get; set; }
        public decimal OrderQty { get; set; }
        public string projcode { get; set; }
        public string projname { get; set; }

        public string logiccode { get; set; }
        public string logicname { get; set; }
    }
}
