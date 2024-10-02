using System.ComponentModel.DataAnnotations;

namespace WMSWebAPI.Models.V1.Request
{
    //public class GetStagingListRequest
    //{
    //    public string CurrentPage { get; set; }
    //    public string recordLimit { get; set; }
    //    public string CustomerId { get; set; }
    //    public string WarehouseId { get; set; }
    //    public string UserId { get; set; }
    //    public string Object { get; set; }

    //    [DisplayFormat(ConvertEmptyStringToNull = false)]
    //    public string whereFilterCondtion { get; set; }

    //    [DisplayFormat(ConvertEmptyStringToNull = false)]
    //    public string SearchValue { get; set; }
    //    public string ClientId { get; set; }
    //}
    //public class GetStagingSOListRequest
    //{
    //    public string CustomerId { get; set; }
    //    public string WarehouseId { get; set; }
    //    public string UserId { get; set; }
    //    public string BatchID { get; set; }
    //    public Int64 QCId { get; set; }
    //}
    //public class GetStagingSODetailRequest
    //{
    //    public string CustomerId { get; set; }
    //    public string WarehouseId { get; set; }
    //    public string UserId { get; set; }
    //    public string BatchID { get; set; }
    //    public string SOID { get; set; }
    //    public Int64 PickupId { get; set; }
    //}
    //public class GetShippingPalletRequest
    //{
    //    public string CustomerId { get; set; }

    //    [DisplayFormat(ConvertEmptyStringToNull = false)]
    //    public string SKey { get; set; }
    //    public string OrderId { get; set; }
    //}
    //public class GetStagingSKUListRequest
    //{
    //    public string OrderID { get; set; }

    //    [DisplayFormat(ConvertEmptyStringToNull = false)]
    //    public string skey { get; set; }
    //    public string qcid { get; set; }
    //    public string userId { get; set; }
    //}
    //public class GetStagingSKUDetailRequest
    //{
    //    public string OrderID { get; set; }
    //    public string SKUID { get; set; }

    //    [DisplayFormat(ConvertEmptyStringToNull = false)]
    //    public string Lot { get; set; }
    //    public Int64 QCId { get; set; }

    //}
    //public class SaveStagingSKUDetailRequest
    //{
    //    public string CustomerId { get; set; }
    //    public string WarehouseId { get; set; }
    //    public string UserId { get; set; }
    //    public string BatchID { get; set; }
    //    public string OrderID { get; set; }
    //    public string PalletID { get; set; }
    //    public string Pallet { get; set; }
    //    public string SKUID { get; set; }
    //    public string StagingQty { get; set; }
    //    public string NoOfBox { get; set; }
    //    public string Height { get; set; }
    //    public string Width { get; set; }
    //    public string Length { get; set; }
    //    public string Weight { get; set; }

    //    [DisplayFormat(ConvertEmptyStringToNull = false)]
    //    public string Notes { get; set; }

    //    [DisplayFormat(ConvertEmptyStringToNull = false)]
    //    public string remark { get; set; }
    //    public string obj { get; set; }
    //    public string UOMID { get; set; }

    //    [DisplayFormat(ConvertEmptyStringToNull = false)]
    //    public string Lotttable { get; set; }

    //    public long PackingLocationId { get; set; }
    //    public long PickupId { get; set; }
    //}
    //public class RemveSkuRequest
    //{
    //    public string PackingNo { get; set; }
    //    public string OrderId { get; set; }
    //    public string PalletId { get; set; }
    //    public string ProdId { get; set; }
    //    public string UserId { get; set; }
    //}
    //public class FinalSavePackingRequest
    //{
    //    public string PackingNo { get; set; }
    //    public string OrderId { get; set; }
    //    public string UserId { get; set; }
    //    public Int64 QCID { get; set; }
    //}
    //public class DirectPackingOrdersRequest
    //{
    //    public Int64 CompanyId { get; set; }
    //    public Int64 custid { get; set; }
    //    public Int64 wrid { get; set; }
    //    public Int64 PickQAId { get; set; }
    //    public Int64 uid { get; set; }

    //}
    //public class transportList
    //{
    //    public string UserID { get; set; }
    //    public string CustomerId { get; set; }
    //    public string WarehouseId { get; set; }
    //    public string VenodrId { get; set; }
    //    public string CompanyId { get; set; }
    //}
    //public class TranspoteUpdate
    //{
    //    public string PackingId { get; set; }
    //    public string UserId { get; set; }
    //    public string CustomerId { get; set; }
    //    public string WarehouseId { get; set; }
    //    public string CompanyId { get; set; }
    //    public string TransportId { get; set; }
    //}
    //public class GetPackingLocationRequest
    //{
    //    public string CustomerId { get; set; }

    //    [DisplayFormat(ConvertEmptyStringToNull = false)]
    //    public string SKey { get; set; }
    //    public string WarehouseId { get; set; }
    //    public string UserId { get; set; }
    //}
}
