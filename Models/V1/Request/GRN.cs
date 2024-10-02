using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using ZXing;

namespace WMSWebAPI.Models.V1.Request
{
    public class GetGRNSKUListRequest
    {
        public string poid { get; set; }
        public string grnid { get; set; }
        public string status { get; set; }
    }
    public class SaveGRNSKUListRequest
    {
        public string obj { get; set; }
        public string oid { get; set; }
        public string uid { get; set; }
        public string batch { get; set; }
        public string prodid { get; set; }
        public string pltid { get; set; }
        public string lot { get; set; }
        public string qty { get; set; }
        public string uomid { get; set; }
        public string noofpack { get; set; }
        public string allowextra { get; set; }
    }
    public class RemoveGRNSKURequest
    {
        public string gID { get; set; }
        public string recordID { get; set; }
        public string obj { get; set; }
    }
    public class CloseGRNSKURequest
    {
        public string gID { get; set; }
        public string poID { get; set; }
    }
    public class GetGRNTransportListRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public string Object { get; set; }
    }
    public class SaveGRNTransportRequest
    {
        public Int64 GetPassID { get; set; }
        public Int64 CustomerId { get; set; }
        public Int64 WarehouseId { get; set; }
        public Int64 UserId { get; set; }
        public string OrderId { get; set; }
        public string Object { get; set; }
        public string AirwayBill { get; set; }
        public string ShippingType { get; set; }
        public string ShippingDate { get; set; }
        public string ExpDeliveryDate { get; set; }
        public string TransporterName { get; set; }
        public Int64 TransporterNameId { get; set; }
        public string TransporterRemark { get; set; }
        public string DockNo { get; set; }
        public Int64 DockId { get; set; }
        public string TruckNo { get; set; }
        public string LRNo { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }
        public string ContainerID { get; set; }
        public string Trailer { get; set; }
        public string Seal { get; set; }
        public string Carrier { get; set; }
    }

    /* SAVE GATEPASS LOTTABLE - 13 DEC 2023 */
    public class SaveGatePassLottableRequest
    {
        public string GetPassID { get; set; }
        public string SkuId { get; set; }
        public string Qty { get; set; }
        public string GrnId { get; set; }
        public string Lottable1 { get; set; }
        public string Lottable2 { get; set; }
        public string Lottable3 { get; set; }
        public string Lottable4 { get; set; }
        public string Lottable5 { get; set; }
        public string Lottable6 { get; set; }
        public string Lottable7 { get; set; }
        public string Lottable8 { get; set; }
        public string Lottable9 { get; set; }
        public string Lottable10 { get; set; }
        public string UomId { get; set; }
        public string UOM { get; set; }
        public string UserId { get; set; }
        public string WarehouseId { get; set; }
        public string CustomerId { get; set; }
        public string InwardOrderNo { get; set; }
    }
    /* SAVE GATEPASS LOTTABLE - 13 DEC 2023 */
    /* SAVE GATEPASS LOTTABLE - 15 DEC 2023 */
    public class CreateGatePassSkuSerialsRequest
    {
        public string SkuId { get; set; }
        public string SkuQty { get; set; }
        public string ObjectName { get; set; }
        public string ObjectId { get; set; }
        public string SubObjectName { get; set; }
        public string SubObjectId { get; set; }
        public string OrderId { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string forceToGenerate { get; set; }
    }
    /* SAVE GATEPASS LOTTABLE - 15 DEC 2023 */

    public class GetGRNTransportDetailtRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public string Object { get; set; }
    }
    public class GRNHeadRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }

        public string grnID { get; set; }
        public string OrderType { get; set; }
    }
    public class GRNDetailRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public string ordertype { get; set; }

    }
    public class GRNOrderDetails
    {
        public string Id { get; set; }
        public string Grndate { get; set; }
        public string Batchcode { get; set; }
        public string Createdby { get; set; }
        public string SkuId { get; set; }
        public string ItemCode { get; set; }
        public string PalletName { get; set; }
        public string UOM { get; set; }

        public string UOMId { get; set; }
        public string POQty { get; set; }


        public string GRNQty { get; set; }
        public string Lottables { get; set; }


        public List<UomList> UomList;
    }
    //public class UomList
    //{
    //    // Properties of UomList
    //}

 
    public class GRNDetailResponce
    {
        [DataMember(IsRequired = true, Order = 0)]
        public string Status { get; set; }

        [DataMember(IsRequired = true, Order = 1)]
        public string StatusCode { get; set; }

        [DataMember(Order = 2)]
        public string GRNOrderDetails { get; set; }
    }
    public class UpdatGrnStatus
    {

        public string poID { get; set; }
        public Int64 grnid { get; set; }
    }
    public class SaveGRNDetailRequest
    {
        public long CustomerId { get; set; }
        public long WarehouseId { get; set; }
        public long companyID { get; set; }
        public long UserId { get; set; }
        public long poID { get; set; }
        public string obj { get; set; }
        public long grnID { get; set; }
        public string grnDate { get; set; }
        public long prodID { get; set; }
        public long palletID { get; set; }

        public string RequestedQty { get; set; }

        public string GRNQty { get; set; }

        public string UOMId { get; set; }


        public string Lottables { get; set; }

        public string type { get; set; }
        public string directpickup { get; set; }
        public Int64 GetPassId { get; set; }
        public Int64 PODTId { get; set; }
    }
    public class poidreq
    {
        [DataMember(IsRequired = true, Order = 0)]
        public string poid { get; set; }
    }
    public class GatePassDetailRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public string grnID { get; set; }
        public string GatePassId { get; set; }
    }

    public class viewGetPass
    {
        public string getPassId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
    }
    public class getPassListById
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
    }
    /* GET BARCODE TO PRINT AS PER PATTERN - 04 DEC 2023 */
    public class getBarcodeAsPerConfig
    {
        public string SkuId { get; set; }
        public string OrderId { get; set; }
    }

    public class getBarcodePrintData
    {
        public string SkuId { get; set; }
        public string OrderId { get; set; }
        public string objectType { get; set; }
        public string objectId { get; set; }
        public string DTID { get; set; }
    }

    public class ShowGeneratedSerialList
    {
        public string SkuId { get; set; }
        public string OrderId { get; set; }
        public string ObjectType { get; set; }
        public string ObjectTypeId { get; set; }
    }
    /* GET BARCODE TO PRINT AS PER PATTERN - 19 DEC 2023 */

    /* GRN PRINT LABLE STYLE -  03 JUNE 2024 */
    public class GetGrnPrintLabelStyle
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string ObjectType { get; set; }
    }
    public class SaveGrnPrintLabelStyle
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string TemplateId { get; set; }
        public string ObjectType { get; set; }
    }
    /* GRN PRINT LABLE STYLE -  03 JUNE 2024 */

}