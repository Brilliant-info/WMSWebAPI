namespace WMSWebAPI.Models.V1.Request
{
    public class GetBillingGroupRequest
    {
        public string CustomerId { get; set; }
    }
    public class GetTransactionListRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string Status { get; set; }
        public string Group { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string RateId { get; set; }
    }
    public class GetRateListRequest
    {
        public string CustomerId { get; set; }
    }
    public class GetTransactionDetailRequest
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string RateId { get; set; }
    }
    public class Save3PLDataRequest
    {
        public string RateID { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
    public class GetPreBillRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
    }
    public class UpdateBillRequest
    {
        public string Paramater { get; set; }
        public string ID { get; set; }
        public string Rate { get; set; }
        public string Qty { get; set; }
        public string UserId { get; set; }
    }
    public class SaveInvoiceRequest
    {
        public string CustomerId { get; set; }
        public string Total { get; set; }
        public string Tax { get; set; }
        public string CompanyId { get; set; }
        public string BillAddress { get; set; }
        public string ShipAddress { get; set; }
        public string UserId { get; set; }
    }
    public class GetInvoiceListRequest
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }
        public string CustomerId { get; set; }
        public string UserId { get; set; }
        public string Filter { get; set; }
        public string Search { get; set; }
    }
    public class PaymentBookingRequest
    {
        public string InvoiceID { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentAmount { get; set; }
        public string DocRefNo { get; set; }
        public string Perticular { get; set; }
        public string Credit { get; set; }
        public string Debit { get; set; }
        public string UserId { get; set; }
        public string CustomerID { get; set; }
        public string CompanyID { get; set; }
        public string Transtype { get; set; }
    }
    public class PaymentDetailRequest
    {
        public string InvoiceID { get; set; }
    }

    // 3pl object API//

    public class ValueAddRequest
    {
        public string Object { get; set; }
        public string OrderId { get; set; }
    }

    public class GetActivtyTypeRequest3pl
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }
        public string CustomerId { get; set; }
        public string UserId { get; set; }
        public string Search { get; set; }
        public string Filter { get; set; }
    }

    public class AddRateActivtyRequest3plobject
    {
        public string ObjectID { get; set; }
        public string ActivityName { get; set; }
        public string Remark { get; set; }
        public string ZoneId { get; set; }
        public string CustomerId { get; set; }
        public string UserId { get; set; }
        public string CompanyId { get; set; }
    }
    public class SaveValueAddRequest
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string ActivityId { get; set; }
        public string ActivityName { get; set; }
        public string Rate { get; set; }
        public string UnitId { get; set; }
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public string Object { get; set; }
        public string OrderId { get; set; }
        public string OrderNo { get; set; }
        public string Quantity { get; set; }
        public string WarehouseId { get; set; }
        public string Remark { get; set; }
    }

}
