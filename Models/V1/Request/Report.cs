using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WMSWebAPI.Models.V1.Request
{
    public class GetGlobalReportListRequest
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Filter { get; set; }
        public string ReportID { get; set; }
    }
    public class InvoiceDetailReportRequest
    {
        public string InvoiceId { get; set; }
        public Int64 UserId { get; set; }

    }
    public class GetReportCategoryRequest
    {
        public string UserId { get; set; }

    }
    public class GetSalesreturndetailRequest
    {
        public string ID { get; set; }
        public string UserId { get; set; }
        public string filterLottable { get; set; }

    }
    public class GetPurchaseorderRecieptdetailRequest
    {
        public string ID { get; set; }
        public string UserId { get; set; }
        public string filterLottable { get; set; }

    }
    public class GetReportCategoryMenuRequest
    {
        public string CategoryId { get; set; }
        public string RoleId { get; set; }
        public string UserId { get; set; }

    }
    public class GetSalesorderdetailRequest
    {
        public string ID { get; set; }
        public string UserId { get; set; }
        public string filterLottable { get; set; }

    }
    public class GetDispatchorderdetailRequest
    {
        public string ID { get; set; }
        public string UserId { get; set; }
        public string filterLottable { get; set; }

    }
    public class GetVariencedetailRequest
    {
        public string ID { get; set; }
        public string UserId { get; set; }

    }
    public class GetRecivingdetailRequest
    {
        public string ID { get; set; }

        public string UserId { get; set; }
        public string filterLottable { get; set; }

    }
    public class GetAllocationGroupdetailRequest
    {
        public string ID { get; set; }
        public string UserId { get; set; }
        public string filterLottable { get; set; }

    }
    public class GetPickingdetailRequest
    {
        public string ID { get; set; }
        public string UserId { get; set; }
        public string filterLottable { get; set; }

    }
    public class GetOrderHistorydetailRequest
    {
        public string ID { get; set; }
        public string UserId { get; set; }

    }
    public class GetPackingdetailRequest
    {
        public string ID { get; set; }
        public string UserId { get; set; }
        public string filterLottable { get; set; }

    }
    public class GetCustomerInventoryRequest
    {
        public string ID { get; set; }
        public string UserId { get; set; }

    }
    public class GetCustomerInventoryLocRequest
    {
        public string ID { get; set; }
        public string UserId { get; set; }

    }

    public class GetPutawaydetailRequest
    {
        public string ID { get; set; }
        public string UserId { get; set; }
        public string filterLottable { get; set; }

    }

    public class GetInwardQualityCheckRequest
    {
        public string ID { get; set; }
        public string UserId { get; set; }
        public string filterLottable { get; set; }


    }
    public class GetCycleCountRequest
    {
        public string ID { get; set; }
        public string UserId { get; set; }
        public string filterLottable { get; set; }

    }

    public class GetInternalTransRequest
    {
        public string ID { get; set; }
        public string UserId { get; set; }
        public string filterLottable { get; set; }

    }
    public class GetOutwardQualityCheckRequest
    {
        public string ID { get; set; }
        public string UserId { get; set; }
        public string filterLottable { get; set; }

    }
    public class PickingDetailsExportCsv
    {
        public string reportDetailId { get; set; }
        public Int64 UserId { get; set; }

    }
}
