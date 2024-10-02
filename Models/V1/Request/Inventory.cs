



using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WMSWebAPI.Models.V1.Request
{
    public class GetInventoryListRequest
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Filter { get; set; }
    }
    public class GetInventoryExportRequest
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
    }
    public class GetAvailInventoryListRequest
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string SkuId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Filter { get; set; }
    }
    public class GetHoldInventoryListRequest
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string SkuId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Filter { get; set; }
    }
    public class GetAllocateInventoryListRequest
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string SkuId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Filter { get; set; }
    }
    public class GetRejectedInventoryListRequest
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string SkuId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Filter { get; set; }
    }
    public class CreateCycleRequest
    {
        public string Obj { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string SkuId { get; set; }
        public string PlanTitle { get; set; }
        public string PlanID { get; set; }
    }
    public class HoldInventoryRequest
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string SkuId { get; set; }
        public string locationid { get; set; }
        public string palletid { get; set; }
        public string lot1 { get; set; }
        public string lot2 { get; set; }
        public string lot3 { get; set; }
        public string lot4 { get; set; }
        public string lot5 { get; set; }
        public string lot6 { get; set; }
        public string lot7 { get; set; }
        public string lot8 { get; set; }
        public string lot9 { get; set; }
        public string lot10 { get; set; }
    }
    public class AdjustInventoryRequest
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string SkuId { get; set; }
        public string locationid { get; set; }
        public string palletid { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string lot1 { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string lot2 { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string lot3 { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string lot4 { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string lot5 { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string lot6 { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string lot7 { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string lot8 { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string lot9 { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string lot10 { get; set; }
        public string Qty { get; set; }
        public string ReasonID { get; set; }
    }
    public class GetAllocateInventoryExportRequest
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string SkuId { get; set; }
    }
    public class DeallocateInventoryRequest
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string SkuId { get; set; }
        public string locationid { get; set; }
        public string palletid { get; set; }
        public string lot1 { get; set; }
        public string lot2 { get; set; }
        public string lot3 { get; set; }
        public string soid { get; set; }
    }
    public class GetHoldInventoryExportRequest
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string SkuId { get; set; }
    }
    public class GetRejectedInventoryExportRequest
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string SkuId { get; set; }
    }

    public class GetLocationbySearch
    {
        public string CustomerID { get; set; }
        public string WarehouseID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string LocFilter { get; set; }
    }

    public class InvLocationLstTransfr
    {
        public string WarehouseId { get; set; }
        public string UserId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Filter { get; set; }
    }

    public class GetBusinessruleReq
    {
        public long warehouseid { get; set; }
        public long customerid { get; set; }
        public string UserID { get; set; }

    }

    public class PalletDetailRequestTrans
    {
        public string UserId { get; set; }
        public string WarehouseId { get; set; }
        public string LocationID { get; set; }
        public string CompanyID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Filter { get; set; }
    }

    public class SaveINVTransferDetailRequest
    {
        public string transid { get; set; }
        public string CompanyId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string Remark { get; set; }
        public string FromLocation { get; set; }
        public string FromPallet { get; set; }
        public string SkuId { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Lotable1 { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Lotable2 { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Lotable3 { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Lotable4 { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Lotable5 { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Lotable6 { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Lotable7 { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Lotable8 { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Lotable9 { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Lotable10 { get; set; }

        public Int64 FrmTRID { get; set; }
        public string Quantity { get; set; }
        public string ToLocation { get; set; }
        public string ToPallet { get; set; }
    }
}
