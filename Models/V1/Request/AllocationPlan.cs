using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace WMSWebAPI.Models.V1.Request
{
    public class AllocationplanSearch
    {
        [DataMember(IsRequired = true, Order = 0)]
        public string ordrid { get; set; }

        [DataMember(Order = 1)]
        public string whereFilterCondition { get; set; }
    }
    public class Rootobject
    {
        public string ordrid { get; set; }
        public string whereFilterCondition { get; set; }
    }
    //public class AllocationplanSearchResponce
    //{
    //    [DataMember(IsRequired = true, Order = 0)]
    //    public string StatusCode { get; set; }

    //    [DataMember(IsRequired = true, Order = 1)]
    //    public string Description { get; set; }

    //    [DataMember(Order = 2)]
    //    public string Allocationplansumry { get; set; }
    //}
    public class UpdateAlcQty
    {
        public string id { get; set; }
        public string orgQty { get; set; }
        public string newQty { get; set; }
        public string type { get; set; }
    }
    //public class UpdateAllocationQuantityResponce
    //{
    //    [DataMember(IsRequired = true, Order = 0)]
    //    public string Sts { get; set; }

    //    [DataMember(IsRequired = true, Order = 1)]
    //    public string StsCode { get; set; }

    //    [DataMember(IsRequired = true, Order = 2)]
    //    public string Desc { get; set; }
    //}
    public class createbtch
    {
        public string soid { get; set; }
    }
    //public class createbtchResponce
    //{
    //    [DataMember(IsRequired = true, Order = 0)]
    //    public string statuscode { get; set; }

    //    [DataMember(IsRequired = true, Order = 1)]
    //    public string Description { get; set; }

    //    [DataMember(IsRequired = true, Order = 2)]
    //    public string batchno { get; set; }
    //}
    public class cancelbatch
    {
        public string soid { get; set; }
    }
    //public class cancelbatchResponce
    //{
    //    [DataMember(IsRequired = true, Order = 0)]
    //    public string statuscode { get; set; }

    //    [DataMember(IsRequired = true, Order = 1)]
    //    public string Description { get; set; }

    //    [DataMember(IsRequired = true, Order = 2)]
    //    public string batchno { get; set; }

    //}
    public class GetBatchListRequest
    {
        public string CurrentPage { get; set; }
        public string recordLimit { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string Object { get; set; }
        public string whereFilterCondtion { get; set; }
        public string SearchValue { get; set; }
    }
    //public class GetBatchListResponce
    //{
    //    public string Status { get; set; }
    //    public string StatusCode { get; set; }
    //    public string Result { get; set; }
    //}
    public class BatchDeAllocateRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string Batchid { get; set; }
    }
    //public class BatchDeAllocateResponce
    //{
    //    public string Status { get; set; }
    //    public string StatusCode { get; set; }
    //    public string BatchID { get; set; }
    //    public string Description { get; set; }
    //}
    public class MarkAsShipRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string Batchid { get; set; }
    }
    //public class MarkAsShipResponce
    //{
    //    public string Status { get; set; }
    //    public string StatusCode { get; set; }
    //    public string BatchID { get; set; }
    //    public string Description { get; set; }
    //}
    public class searchintransitrequest
    {
        public string prdid { get; set; }
        public string soid { get; set; }
        public string whereFilterCondition { get; set; }
    }

    //public class searchintransitResponce
    //{
    //    [DataMember(IsRequired = true, Order = 0)]
    //    public string StatusCode { get; set; }

    //    [DataMember(IsRequired = true, Order = 1)]
    //    public string Description { get; set; }

    //    [DataMember(Order = 2)]
    //    public string intransitsku { get; set; }
    //}

    public class updateintransitqtyrequest
    {
        public string id { get; set; }
        public string orgQty { get; set; }
        public string newQty { get; set; }
    }

    //public class updateintransitqtyresponce
    //{
    //    [DataMember(IsRequired = true, Order = 0)]
    //    public string Status { get; set; }

    //    [DataMember(IsRequired = true, Order = 1)]
    //    public string StatusCode { get; set; }

    //    [DataMember(IsRequired = true, Order = 2)]
    //    public string Description { get; set; }

    //}
    //Bind Grid
    //public class bindskuwiseallocateddetailresponce
    //{
    //    [DataMember(IsRequired = true, Order = 0)]
    //    public string StatusCode { get; set; }

    //    [DataMember(IsRequired = true, Order = 1)]
    //    public string Description { get; set; }

    //    [DataMember(Order = 2)]
    //    public string manualallocationofsku { get; set; }
    //}

    //Search Grid
    public class searchmanualalocrequest
    {
        public string prdid { get; set; }
        public string soid { get; set; }
        public string whereFilterCondition { get; set; }
    }

    //public class searchmanualalocResponce
    //{
    //    [DataMember(IsRequired = true, Order = 0)]
    //    public string StatusCode { get; set; }

    //    [DataMember(IsRequired = true, Order = 1)]
    //    public string Description { get; set; }

    //    [DataMember(Order = 2)]
    //    public string manualallocationofsku { get; set; }
    //}

    //Update Quantity
    public class updatemanualqtyrequest
    {
        public string id { get; set; }
        public string orgQty { get; set; }
        public string newQty { get; set; }
    }

    //public class updatemanualqtyresponce
    //{
    //    [DataMember(IsRequired = true, Order = 0)]
    //    public string Status { get; set; }

    //    [DataMember(IsRequired = true, Order = 1)]
    //    public string StatusCode { get; set; }

    //    [DataMember(IsRequired = true, Order = 2)]
    //    public string Description { get; set; }

    //}
    public class saveplandirectrequest
    {
        public string ordernumber { get; set; }
        public string userid { get; set; }
        public string customerid { get; set; }
    }
    public class getallocationplansumryrequest
    {
        public string orderid { get; set; }
    }
    public class Getalcplndtlrequest
    {
        public string orderid { get; set; }
    }
    public class BatchListRequest
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
    public class allocationplandtlsearchRequest
    {
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string wherecondition { get; set; }
        public string ordrid { get; set; }
    }
    public class updateallocationplanQty
    {
        public string ID { get; set; }
        public string newqty { get; set; }
        public string originalqty { get; set; }
        public string Object { get; set; }
    }
    public class getbatchidbysoids
    {
        public string soid { get; set; }
        public string confirm { get; set; }
    }
    public class cancelbatchRequest
    {
        public string soid { get; set; }
    }
    public class GetManualAllocationofSkuRequest
    {
        public string ProdID { get; set; }
        public string soid { get; set; }
    }
    public class DeAllocateRequest
    {
        public string BatchId { get; set; }
        public string UserId { get; set; }
    }
    public class TotalShrotQtyRequest
    {
        public string OrderId { get; set; }
        public string BatchId { get; set; }
        public string BatchName { get; set; }
        public string CompId { get; set; }
        public string CustId { get; set; }
        public string whId { get; set; }
    }
}
