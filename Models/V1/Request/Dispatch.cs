
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WMSWebAPI.Models.V1.Request
{
    public class DispatchListRequest
    {
        public string CurrentPage { get; set; }
        public string recordLimit { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string Object { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string filtercol { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string filterval { get; set; }
        public string ClientId { get; set; }

    }
    public class BatchDispatchListRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string BatchID { get; set; }
    }
    public class BatchDispatchDetailRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string BatchID { get; set; }
        public string SOID { get; set; }
        public string DispId { get; set; }
    }
    public class DispatchDetailEdit
    {
        public string DispId { get; set; }
    }

    public class BatchDispatchDetailRequestNew
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string BatchID { get; set; }
        public string SOID { get; set; }
        //public string AddNew { get; set; }
        public Int64 dispId { get; set; }
    }
    public class SaveDispatchBySORequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string BatchID { get; set; }
        public string SOID { get; set; }
        public string CarrierID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string TrackingNO { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string DriverName { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string PickUpBy { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ScheduleDateTime { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ActualDateTime { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string LRNo { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string VehicleNo { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string TransportRemark { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string BOL { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string TransportName { get; set; }
        public Int64 DispId { get; set; }
    }
    public class EditDispatchBySORequest
    {
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string EditVhDateTime { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string EditRelDateTime { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string EditERPInvNo { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string EditDate { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string EditSealNo { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string EditRemark { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string TMSSTATUS { get; set; }
        public Int64 DispId { get; set; }
        public Int64 userId { get; set; }
    }
    public class SaveReturnBySORequest
    {
        public long CustomerId { get; set; }
        public long WarehouseId { get; set; }
        public long UserId { get; set; }
        public long SOID { get; set; }
        public string Data { get; set; }
    }
    public class UpdateQtyRequest
    {
        public long DispatchId { get; set; }
        public long Soid { get; set; }
        public long ProdId { get; set; }
        public long CartonId { get; set; }
        public string Lottables { get; set; }
        public decimal DispatchQty { get; set; }
        public decimal Qty { get; set; }
        public long UserId { get; set; }
    }
    public class reqDispatchDriverList
    {
        public string CustomerId { get; set; }
        public string UserId { get; set; }
        public string Object { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string searchValue { get; set; }

    }
    public class saveDispatchDriverDetails
    {
        public string CustomerId { get; set; }
        public string UserId { get; set; }
        public string Warehouseid { get; set; }
        public string DriverId { get; set; }
        public string OrderId { get; set; }
        public string Contactno { get; set; }
        public string Email { get; set; }
        public string DeviceId { get; set; }
        public string VehicleId { get; set; }

    }
    public class driverTransportdetailRequest
    {
        public string DispatchId { get; set; }

    }
    public class CarrierListRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
    }
    public class TrackingDetailRequest
    {
        public string OrderId { get; set; }
        public string BatchID { get; set; }
    }
    public class SaveTrackingDetailRequest
    {
        public string OrderId { get; set; }
        public string BatchID { get; set; }
        public string UserId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string TrackDate { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string TrackTime { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Status { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Remark { get; set; }
    }
    public class TestMailRequest
    {
        public string soid { get; set; }
        public string UserId { get; set; }
    }
    public class DispatchNotify
    {
        public string DeliveryNo { get; set; }
        public string OutBoundOrderNo { get; set; }
        public string DeliveryType { get; set; }

        public List<OutBoundItemSet> OutBoundItemSet;

        public List<OutBoundHeaderPartnerSet> OutBoundHeaderPartnerSet;

        public List<OutBoundHeaderDeadLineSet> OutBoundHeaderDeadLineSet;

        public OutBoundHeaderOrgSet OutBoundHeaderOrgSet;

        public List<OutBoundItemOrgSet> OutBoundItemOrgSet;

        public List<ReturnMessageSet> ReturnMessageSet;
    }
    public class OutBoundItemSet
    {
        public string DeliveryNo { get; set; }
        public string ItemNo { get; set; }
        public string SUkCode { get; set; }
        public string DeliveryQty { get; set; }
        public string SalesUnitIso { get; set; }
        public string SalesUnit { get; set; }
    }
    public class OutBoundHeaderPartnerSet
    {
        public string DeliveryNo { get; set; }
        public string PartnerRole { get; set; }
        public string PartnerNo { get; set; }
    }
    public class OutBoundHeaderDeadLineSet
    {
        public string DeliveryNo { get; set; }
        public string Timetype { get; set; }
        public string TimestampUtc { get; set; }
        public string Timezone { get; set; }
    }
    public class OutBoundHeaderOrgSet
    {
        public string ShipPoint { get; set; }
        public string SalesOrg { get; set; }
    }
    public class OutBoundItemOrgSet
    {
        public string DeliveryNo { get; set; }
        public string ItemNumber { get; set; }
        public string Distribution_Channel { get; set; }
        public string Division { get; set; }
        public string Plant { get; set; }
    }
    public class ReturnMessageSet
    { }

    public class ReqDriverInvoice
    {
        public string CustomerId { get; set; }
        public string OrderId { get; set; }
    }
}