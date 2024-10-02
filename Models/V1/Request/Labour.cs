using System.ComponentModel.DataAnnotations;



namespace WMSWebAPI.Models.V1.Request
{
    public class LabourGetALL
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }
        public string CustomerId { get; set; }
        public string UserId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Filter { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Search { get; set; }
    }

    public class reqLbourInsertUpdate
    {
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string LabourId { get; set; }
        public string UserId { get; set; }
        public string customerId { get; set; }
        public string companyId { get; set; }
        public string WarehouseId { get; set; }
        public string LabourName { get; set; }
        public string ChargeRate { get; set; }
        public string BilableRate { get; set; }
        public string VendorId { get; set; }
        public string LedgerCode { get; set; }
        public string ShiftId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
    public class reqShiftList
    {

        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }

    }
    public class reqLabourDetailsInsert
    {
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string TimeTrackerId { get; set; }
        public string UserId { get; set; }
        public string labourId { get; set; }
        public string ZoneId { get; set; }
        public string OrderId { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string OrderGroupName { get; set; }
        //public string startTime { get; set; }
        //public string endTime { get; set; }
        public string WarehouseId { get; set; }
        public string ActivityId { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        //public string JobId { get; set; }
        public string ActivityStartTime { get; set; }
        public string ActivityEndTime { get; set; }
        //public string OrderStartTime { get; set; }
        //public string OrderEndTime { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string CompanyId { get; set; }
        public string CustomerId { get; set; }
        public string CreationDate { get; set; }
        public string Quantity { get; set; }
        public string Elapsed { get; set; }
    }


    public class reqGetActivityList
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
    }

    public class reqaddShift
    {
        public string UserId { get; set; }
        public string CompanyId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string ShiftName { get; set; }
        public string Starttime { get; set; }
        public string EndTime { get; set; }
        public string Active { get; set; }
    }
    public class reqtVendorRequest
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
    }

    public class ReqLabourDetailsGetALL
    {
        //public string CurrentPage { get; set; }
        //public string RecordLimit { get; set; }
        public string CustomerId { get; set; }
        public string UserId { get; set; }

        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        //public string Filter { get; set; }
        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        //public string Search { get; set; }
    }

    public class reqTimeTrackingReport
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ZoneId { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ActivityId { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string OrderId { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string searchFromDate { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string searchToDate { get; set; }
    }
    public class reqRemoveLabour
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string LabourId { get; set; }
    }

}
