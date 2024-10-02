using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WMSWebAPI.Models.V1.Request
{
    public class GetTransferListRequest
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }
        public string CompanyId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Filter { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Search { get; set; }
    }
    public class SaveTransferHeadRequest
    {
        public string transid { get; set; }
        public string CompanyId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string TransferBy { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Remark { get; set; }

    }
    public class saveTransferDetails
    {
        public string transferId { get; set; }
        //public string fromLocationType { get; set; }
        public string fromLocationId { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string fromPallet { get; set; }
        public string skuid { get; set; }
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        //public string Lottable1 { get; set; }
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        //public string Lottable2 { get; set; }
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        //public string Lottable3 { get; set; }
        public string Lottable { get; set; }
        public string Quantity { get; set; }
        //public string ToLocationType { get; set; }
        public string ToLocationId { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ToPallet { get; set; }
        public string WarehouseId { get; set; }
        public string CustomerId { get; set; }
        public string ComapnyId { get; set; }
        public string UserId { get; set; }
        public string FromLocationType { get; set; }
        public string ToLocationType { get; set; }
        public Int64 FromTrId { get; set; }
        public Int64 ToTrId { get; set; }

    }
    public class LocationDetailRequest
    {
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string LocationType { get; set; }
        public string CompanyId { get; set; }
        public string CustomerId { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string checkLocAvl { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Filter { get; set; }
    }

    //To Location
    public class ToLocationReq
    {
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string LocationType { get; set; }
        public string CompanyId { get; set; }
        public string CustomerId { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string checkLocAvl { get; set; }
        public string obj { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Filter { get; set; }
        public Int64 FromTrId { get; set; }
    }

    public class reqTransferSaveHead
    {
        public string CustomerId { get; set; }
        public string CompanyId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string TransferId { get; set; }
    }

    public class LotableListRequest
    {
        public string UserId { get; set; }
        public string SKUId { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string PalletId { get; set; }
        public string LocationId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Filter { get; set; }
    }
    public class ReqTRIDTO
    {
        public Int64 FrTrID { get; set; }
        public Int64 FrLocId { get; set; }
        public Int64 FrPalletId { get; set; }
        public Int64 Tolocid { get; set; }
        public Int64 ToPalletId { get; set; }
    }

    public class PalletDetailRequest
    {
        public string UserId { get; set; }
        public string WarehouseId { get; set; }
        public string LocationID { get; set; }
        public string CompanyID { get; set; }
        public string Object { get; set; }
        public string SkuId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Filter { get; set; }
    }
    public class SkuDetailRequest
    {
        public string UserId { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string PalletId { get; set; }
        public string LocationID { get; set; }
        public string CustomerId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Filter { get; set; }
    }

    public class TransferDetailsRequest
    {
        public string UserId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyID { get; set; }
        public string CustomerId { get; set; }


    }
    public class reqTransferSkulist
    {
        public string TransferId { get; set; }
        public string CustomerId { get; set; }
        public string CompanyId { get; set; }
        public string WarehouseId { get; set; }
    }
    public class reqViewTransfer
    {
        public string UserId { get; set; }
        public string WarehouseId { get; set; }
        public string CustomerId { get; set; }
        public string CompanyId { get; set; }
        public string TransferId { get; set; }

    }
    public class reqIntTranfBusinessRule
    {
        public string CompanyId { get; set; }
        public string CustomerId { get; set; }
        public string UserId { get; set; }
    }
    public class reqDDLLocationList
    {
        public string UserId { get; set; }
    }
}
