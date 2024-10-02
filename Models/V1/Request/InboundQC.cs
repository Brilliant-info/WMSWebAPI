using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WMSWebAPI.Models.V1.Request
{
    public class QCDetailRequest
    {

        public string OrderId { get; set; }
        public int UserID { get; set; }
        public int customerID { get; set; }

    }
    public class QCHeadRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string grnID { get; set; }
        public string qcID { get; set; }
        public string OrderType { get; set; }
        public string pageObj { get; set; }

    }

    public class grnidreq
    {
        [DataMember(IsRequired = true, Order = 0)]
        public string grnid { get; set; }
        public string pageObj { get; set; }
    }
    public class QCRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public string ordertype { get; set; }

    }
    public class QCResponce
    {
        [DataMember(IsRequired = true, Order = 0)]
        public string Status { get; set; }

        [DataMember(IsRequired = true, Order = 1)]
        public string StatusCode { get; set; }

        [DataMember(Order = 2)]
        public string QCOrderDetails { get; set; }
    }


    public class SaveQCDetailRequest
    {
        public long CustomerId { get; set; }
        public long WarehouseId { get; set; }
        public long companyID { get; set; }
        public long UserId { get; set; }
        public long poID { get; set; }
        public string obj { get; set; }
        public long grnID { get; set; }
        public string qcDate { get; set; }
        public long qcID { get; set; }
        public long prodID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string palletname { get; set; }
        public long reasonID { get; set; }
        public string RequestedQty { get; set; }
        public string GRNQty { get; set; }
        public string qcQty { get; set; }
        public string rejectedQty { get; set; }
        public string UOMId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Lottables { get; set; }
        public string type { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public long PalletID { get; set; }
    }
    public class SaveQCResponce
    {
        [DataMember(IsRequired = true, Order = 0)]
        public string Status { get; set; }

        [DataMember(IsRequired = true, Order = 1)]
        public string StatusCode { get; set; }

        [DataMember(Order = 2)]
        public string Description { get; set; }
        [DataMember(Order = 3)]
        public string grnID { get; set; }

    }
    public class QCReasonRequest
    {
        [DataMember(IsRequired = true, Order = 0)]
        public string CustomerId { get; set; }

        [DataMember(IsRequired = true, Order = 1)]
        public string CompanyID { get; set; }


    }

    public class UpdatQCStatus
    {
        public string poID { get; set; }
        public string GRNID { get; set; }
        public string pageObj { get; set; }
    }
    public class ReciveNotification
    {
        public string OrderReferenceNO { get; set; }
        public string MaterialDoc { get; set; }
        public string RecieptDate { get; set; }
        public string Fiscalyear { get; set; }
        public string DocDate { get; set; }

        public List<GoodRecieptItemSet> GoodRecieptItemSet;

        public List<ReturnMessageSet> ReturnMessageSet;
    }
    public class GoodRecieptItemSet
    {
        public string MovementIndicator { get; set; }
        public string OrderReferenceNO { get; set; }
        public string ItemNo { get; set; }
        public string CustomerNo { get; set; }
        public string SKUcode { get; set; }
        public string MoveType { get; set; }
        public string Plant { get; set; }
        public string WareHouseCode { get; set; }
        public string Quantity { get; set; }
        public string Uom { get; set; }
    }


    public class Recivenotificationlog
    {
        public string materialdoc { get; set; }
        public string fiscalyear { get; set; }
        public string type { get; set; }
        public string number { get; set; }
        public string message { get; set; }
        public string Id { get; set; }
        public string docyear { get; set; }
    }

    public class RemoveQCSKURequest
    {
        public string QCid { get; set; }
        public string recordID { get; set; }
        public string obj { get; set; }
    }
}
