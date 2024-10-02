using System.ComponentModel.DataAnnotations;

namespace WMSWebAPI.Models.V1.Request
{
    public class GetPickUpListRequest
    {
        public string CurrentPage { get; set; }
        public string recordLimit { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string Object { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string whereFilterCondtion { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string ClientId { get; set; }
    }
    public class GetPickUpDetailRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string BatchID { get; set; }
        public string PickUpID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SOID { get; set; }
    }
    public class FinalSavePickUpRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string BatchID { get; set; }
        public string Object { get; set; }
    }
    public class CancelPickUpRequest
    {
        public long CustomerId { get; set; }
        public long WarehouseId { get; set; }
        public long UserId { get; set; }
        public long PickUpId { get; set; }
        public long BatchId { get; set; }

    }
    public class MarkPackRequest
    {
        public long CustomerId { get; set; }
        public long compid { get; set; }
        public long WarehouseId { get; set; }
        public long UserId { get; set; }
        public long PickUpId { get; set; }
        public long BatchId { get; set; }
        public string OrderId { get; set; }
    }
    public class UpdatePickUpRequest
    {
        public long ID { get; set; }
        public decimal NewQty { get; set; }
        public decimal OldQty { get; set; }
        public decimal alocQty { get; set; }
        public long UserId { get; set; }
    }
    public class RevertPickUpRequest
    {
        public long batchID { get; set; }
        public long UserId { get; set; }
    }
    public class ChkAssignToRequest
    {
        public long customerid { get; set; }
        public long userid { get; set; }
        public string objectname { get; set; }
        public long referenceid { get; set; }
    }
}
