using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WMSWebAPI.Models.V1.Request
{
    public class GetProductionlistRequest
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }

        public string CompanyId { get; set; }
        public string CustomerId { get; set; }
        public string UserId { get; set; }
        //  public string Search { get; set; }
        public string Filter { get; set; }
    }

    public class ProdHeadRequest
    {
        //public string CustomerId { get; set; }
        //public string WarehouseId { get; set; }
        //public string UserId { get; set; }
        public string OrderId { get; set; }
        //public string OrderType { get; set; }
    }

    public class SaverequestHeadRequest
    {
        public string CustomerID { get; set; }
        public string CompanyID { get; set; }
        public string WarehouseID { get; set; }
        public string orderdate { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string orderrefNo { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Line { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Remark { get; set; }
    }

    public class GetSaverequestdetailRequest
    {
        public string CustomerID { get; set; }
        public string CompanyID { get; set; }
        public string PRHeadID { get; set; }
        public string SkuCode { get; set; }
        public string SkuName { get; set; }
        public string SkuDescription { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string reqQty { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string UOM { get; set; }
        public string orderQty { get; set; }
        public string Lottable { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public decimal CaseNetweight { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public decimal CaseGrossweight { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public Int64 TotalCartan { get; set; }
    }

    public class GetDispSaverequestdetailRequest
    {
        public string orderid { get; set; }
    }

    public class RemoveProdSKURequest
    {
        public string orderid { get; set; }
    }
}
