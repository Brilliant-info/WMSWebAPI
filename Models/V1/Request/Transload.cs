using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WMSWebAPI.Models.V1.Request
{
    public class Transload
    {
    }
    public class ReqTransloadList
    {
        public Int64 recordlimit { get; set; }
        public Int64 CurrentPage { get; set; }
        public Int64 CompanyId { get; set; }
        public Int64 WhId { get; set; }
        public Int64 CustId { get; set; }
        public Int64 UserId { get; set; }
        public string SerchPara { get; set; }
        public string SerchVal { get; set; }
        public string ActiveTab { get; set; }
    }
    public class ReqTransloadListID
    {

        public Int64 CompanyId { get; set; }
        public Int64 WhId { get; set; }
        public Int64 CustId { get; set; }
        public Int64 UserId { get; set; }
        public Int64 OrderId { get; set; }
    }
    public class ReqTransloadListReceving
    {

        public Int64 CompanyId { get; set; }
        public Int64 WhId { get; set; }
        public Int64 CustId { get; set; }
        public Int64 UserId { get; set; }
        public Int64 OrderId { get; set; }
    }
    public class ReqGetDispatchDetails
    {

        public Int64 CompanyId { get; set; }
        public Int64 WhId { get; set; }
        public Int64 CustId { get; set; }
        public Int64 UserId { get; set; }
        public Int64 OrderId { get; set; }
        public Int64 OrderDTId { get; set; }
    }

    public class ReqSaveDispatchHead
    {

        public Int64 CompanyID { get; set; }
        public Int64 WarehouseId { get; set; }
        public Int64 CustomerId { get; set; }
        public Int64 UserId { get; set; }
        public Int64 TranloadDTId { get; set; }
        public Int64 DockId { get; set; }
        public Int64 PalletId { get; set; }
        public Int64 TranloadId { get; set; }
    }
    public class ReqTranloadSave
    {
        public Int64 WarehouseId { get; set; }
        public Int64 CustomerId { get; set; }
        public Int64 CompanyID { get; set; }

        public Int64 UserId { get; set; }
        public Int64 OrderId { get; set; }
        public Int64 ClientCode { get; set; }
        public Int64 Address1 { get; set; }
        //public string dt { get; set; }

        public Int64 CreatedBy { get; set; }
        public string Title { get; set; }
        public string CustrefNo { get; set; }


    }
    public class ReqTranloadSaveDT
    {
        public Int64 HeadID { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ContainerID { get; set; }
        public Int64 UOMID { get; set; }
        public decimal NoOfBoxes { get; set; }
        public decimal Weight { get; set; }
        public Int64 CreatedBy { get; set; }

    }
    public class ReqTTransload_RecDT
    {
        public Int64 HeadID { get; set; }
        public Int64 StagingId { get; set; }
        public Int64 DockId { get; set; }
        public Int64 PalletId { get; set; }
        public Int64 PalletType { get; set; }
        public decimal Noofcarton { get; set; }
        public decimal TotWeight { get; set; }
        public decimal ToWidth { get; set; }
        public decimal ToHeight { get; set; }
        public decimal Tolength { get; set; }
        public string Remark { get; set; }
        public Int64 CreatedBy { get; set; }


    }
    public class ReqRemoveTransloadDT
    {
        public Int64 WarehouseId { get; set; }
        public Int64 CustomerId { get; set; }
        public Int64 CompanyID { get; set; }

        public Int64 UserId { get; set; }
        public Int64 TranloadDTId { get; set; }

    }
    public class ReqUpdateDockIdStatus
    {
        public Int64 WarehouseId { get; set; }
        public Int64 CustomerId { get; set; }
        public Int64 CompanyID { get; set; }

        public Int64 UserId { get; set; }
        public Int64 TranloadDTId { get; set; }
        public Int64 DockID { get; set; }
        public Int64 PalletId { get; set; }
        public Int64 TranloadId { get; set; }


    }
    public class ReqRemoveDockIdStatus
    {
        public Int64 WarehouseId { get; set; }
        public Int64 CustomerId { get; set; }
        public Int64 CompanyID { get; set; }

        public Int64 UserId { get; set; }
        public Int64 TranloadDTId { get; set; }
        public Int64 DockID { get; set; }
        public Int64 PalletId { get; set; }
        public Int64 TranloadId { get; set; }


    }
    public class ReqChangeOrderType
    {
        public Int64 WhId { get; set; }
        public Int64 CustId { get; set; }
        public Int64 CompanyID { get; set; }

        public Int64 UserId { get; set; }
        public Int64 OrderId { get; set; }
        public string OrderType { get; set; }

    }
    public class ReqRemoveTL_RecDT
    {
        public Int64 WarehouseId { get; set; }
        public Int64 CustomerId { get; set; }
        public Int64 CompanyID { get; set; }

        public Int64 UserId { get; set; }
        public Int64 TranloadDTId { get; set; }

    }
    public class ReqSaveReceving
    {
        public Int64 HeadId { get; set; }
        public DateTime ReceivedDate { get; set; }
        public Int64 Statuscode { get; set; }

        public string Remark { get; set; }
        public string ReceivedBy { get; set; }
        public string OrderType { get; set; }
    }
    public class ReqClientList
    {
        public Int64 CompanyId { get; set; }
        public Int64 userId { get; set; }
        public Int64 whId { get; set; }
        public Int64 custId { get; set; }
        public string ClientName { get; set; }
    }

    //New Method Common

    public class ReqUOMList
    {
        public Int64 CompanyId { get; set; }
        public Int64 userId { get; set; }
        public Int64 whId { get; set; }
        public Int64 custId { get; set; }
    }
    public class ReqOrderTypeList
    {
        public Int64 CompanyId { get; set; } = 0;
        public Int64 userId { get; set; } = 0;
        public Int64 whId { get; set; } = 0;
        public Int64 custId { get; set; } = 0;
        public string OrderType { get; set; } = "";
    }
    public class ReqUOMSugg
    {
        public Int64 CompanyId { get; set; }
        public Int64 userId { get; set; }
        public Int64 whId { get; set; }
        public Int64 custId { get; set; }
        public string UnitName { get; set; }
    }
    public class ReqPallettypeList
    {
        public Int64 CompanyId { get; set; }
        public Int64 userId { get; set; }
        public Int64 whId { get; set; }
        public Int64 custId { get; set; }
        public string PalletType { get; set; }
    }
    public class ReqRateActivitylist
    {
        public Int64 CompanyId { get; set; }
        public Int64 userId { get; set; }
        public Int64 whId { get; set; }
        public Int64 custId { get; set; }
        public Int64 OrderID { get; set; }
        public string ObjName { get; set; }
        public string ActivityName { get; set; }
    }
    public class ReqStagingSugg
    {
        public Int64 CompanyId { get; set; }
        public Int64 userId { get; set; }
        public Int64 whId { get; set; }
        public Int64 custId { get; set; }
        public string StagingName { get; set; }
    }

    public class ReqAddressList
    {
        public Int64 CompanyId { get; set; }
        public Int64 userId { get; set; }
        public Int64 whId { get; set; }
        public Int64 custId { get; set; }
        public string AddresstName { get; set; }
    }
    public class ReqDockList
    {
        public Int64 CompanyId { get; set; }
        public Int64 userId { get; set; }
        public Int64 whId { get; set; }
        public Int64 custId { get; set; }
        public string DockName { get; set; }
    }
    public class ReqScanDataAPI
    {
        public Int64 CompanyId { get; set; }
        public Int64 userId { get; set; }
        public Int64 whId { get; set; }
        public Int64 custId { get; set; }
        public string ScanType { get; set; }
        public string InputScan { get; set; }
    }
    public class ReqMob_ScanData
    {
        public Int64 CompanyId { get; set; }
        public Int64 userId { get; set; }
        public Int64 whId { get; set; }
        public Int64 custId { get; set; }
        public string ScanData { get; set; }
        public Int64 LocationId { get; set; }
        public Int64 PalletId { get; set; }
        public string OrderType { get; set; }
    }
    public class ReqvendorList
    {
        public Int64 CompanyId { get; set; }
        public Int64 userId { get; set; }
        public Int64 whId { get; set; }
        public Int64 custId { get; set; }
        public string vendorName { get; set; }
    }
    public class ReqTransPalletList
    {
        public Int64 CompanyId { get; set; }
        public Int64 userId { get; set; }
        public Int64 whId { get; set; }
        public Int64 custId { get; set; }
        public string PalletName { get; set; }
    }
    public class ReqTLHeadDetail
    {
        public Int64 CompanyId { get; set; }
        public Int64 userId { get; set; }
        public Int64 whId { get; set; }
        public Int64 custId { get; set; }
        public Int64 OrderId { get; set; }

    }
    public class ReqOrderAdj
    {
    }
    public class ReqOrderAdjList
    {
        public Int64 CustomerId { get; set; }
        public Int64 WarehouseId { get; set; }
        public Int64 CompanyId { get; set; }
        public Int64 UserId { get; set; }
        public Int64 OrderId { get; set; }


    }
    public class ReqOrderPalletList
    {
        public Int64 CustomerId { get; set; }
        public Int64 WarehouseId { get; set; }
        public Int64 CompanyId { get; set; }
        public Int64 UserId { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SerchPara { get; set; }
        public Int64 TransloadId { get; set; }



    }
    public class ReqOrderAdjRemove
    {
        public Int64 CustomerId { get; set; }
        public Int64 WarehouseId { get; set; }
        public Int64 CompanyId { get; set; }
        public Int64 UserId { get; set; }
        public Int64 TransloadId { get; set; }
        public Int64 TransloadDTId { get; set; }


    }
    public class ReqOrderAdjSave
    {
        public Int64 CustomerId { get; set; }
        public Int64 WarehouseId { get; set; }
        public Int64 CompanyId { get; set; }
        public Int64 UserId { get; set; }
        public Int64 TransloadId { get; set; }
        public string TransloadDTId { get; set; }

    }
    public class ReqStagingTraDetail
    {
        public Int64 Id { get; set; }
        public Int64 ClientCode { get; set; }
        public Int64 Address1 { get; set; }
        public Int64 Address2 { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public Int64 ZipCode { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public string appointmentdetail { get; set; }
        public string appointmentdate { get; set; }
        public string trailerDT { get; set; }
        public string transporternameDT { get; set; }
        public string transremarkDT { get; set; }
        public string docknoDT { get; set; }
        public string airwaybillDT { get; set; }
        public string shippingtypeDT { get; set; }
        public string shippingdateDT { get; set; }
        public string expdeldateDT { get; set; }
        public string LrnoDT { get; set; }
        public string intimeDT { get; set; }
        public string outtimeDT { get; set; }
        public string drivername { get; set; }
        public string sealnoDT { get; set; }
        public string billofladingno { get; set; }
        public string pronumber { get; set; }
        public string freightchaarges { get; set; }
        public string masterbilloflading { get; set; }
        public string codamount { get; set; }
        public string feeterm { get; set; }
        public string trailerloadedby { get; set; }
        public string freightcounteby { get; set; }
        public string countedtype { get; set; }
        public string DispatchPlan { get; set; }
        public string ShipmentTrackingNo { get; set; }
        public Int64 UserId { get; set; }

    }
    public class ReqGetStagingTraDetail
    {
        public Int64 CompanyId { get; set; }
        public Int64 WhId { get; set; }
        public Int64 CustId { get; set; }
        public Int64 UserId { get; set; }
        public Int64 OrderId { get; set; }
    }

    //Transpoter Details
    public class ReqTransportDetail
    {
        public Int64 Id { get; set; }
        public string AirwaybillRT { get; set; }
        public string shippingtypeRT { get; set; }
        public string shippingdateRT { get; set; }
        public string expdeldateRT { get; set; }
        public string TransporterNameRT { get; set; }
        public string TransporterRemarkRT { get; set; }
        public string OutTimeRT { get; set; }
        public string ContainerID { get; set; }
        public string DockNoRT { get; set; }
        public string TruckNo { get; set; }
        public string LRNoRT { get; set; }
        public string InTimeRT { get; set; }
        public string Trailer { get; set; }
        public string Seal { get; set; }
        public string Carrier { get; set; }
        public string OrderType { get; set; }

        /* public string WarehouseId { get; set; }
         public string CustomerId { get; set; }
         public string CompanyID { get; set; }*/
        public Int64 UserId { get; set; }

    }

    public class ReqGetTransportDetail
    {
        public Int64 CompanyId { get; set; }
        public Int64 WhId { get; set; }
        public Int64 CustId { get; set; }
        public Int64 UserId { get; set; }
        public Int64 OrderId { get; set; }
    }
}
