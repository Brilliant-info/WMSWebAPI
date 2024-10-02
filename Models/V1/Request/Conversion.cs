using System.ComponentModel.DataAnnotations;

namespace WMSWebAPI.Models.V1.Request
{
    public class Conversion
    {
        public class GetConversionSKUListRequest
        {
            public string CurrentPage { get; set; }
            public string RecordLimit { get; set; }
            public string CustomerID { get; set; }
            public string WarehouseID { get; set; }
            public string CompanyID { get; set; }
            public string UserID { get; set; }
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public string Search { get; set; }
            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public string Filter { get; set; }
        }
        public class GetConvSKUSuggestionRequest
        {
            public string CurrentPage { get; set; }
            public string RecordLimit { get; set; }
            public string CustomerId { get; set; }
            public string WarehouseId { get; set; }
            public string UserId { get; set; }
            public string OrderId { get; set; }
            public string ClientId { get; set; }

            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public string skey { get; set; }

            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public string isSuggestionList { get; set; }

            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public string portal { get; set; }

            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public string Object { get; set; }

            [DisplayFormat(ConvertEmptyStringToNull = false)]
            public string Lot { get; set; }
            public string skuid { get; set; }
        }
        public class GetSkuConversionSaveRequest
        {
            public Int64 convId { get; set; }
            public string CustomerID { get; set; }
            public string WarehouseID { get; set; }
            public string CompanyID { get; set; }
            public string UserID { get; set; }
            public string ConversionDate { get; set; }
            public string Remark { get; set; }
            public string SkuID { get; set; }
            public string Locationid { get; set; }
            public string Palletid { get; set; }
            public string Lottable { get; set; }
            public string Qty { get; set; }
            public string isFinalSave { get; set; }
            public Int64 TrId { get; set; }
            public decimal ConversionQty { get; set; }
            public decimal Conversionweight { get; set; }
        }
        public class SkuConversionSaveRequestDT
        {
            public Int64 CustomerId { get; set; }
            public Int64 WarehouseId { get; set; }
            public Int64 ClientId { get; set; }

            public Int64 ConvId { get; set; }
            public Int64 UserId { get; set; }
            public Int64 UOM { get; set; }
            public string Remark { get; set; }
            public string SkuID { get; set; }
            public string Locationcode { get; set; }
            public string Palletid { get; set; }
            public string Lottable { get; set; }
            public string Qty { get; set; }
            public string MTrId { get; set; }
            public string TrId { get; set; }
            public string weight { get; set; }
            public string cost { get; set; }
            public decimal actualyield { get; set; }
            public decimal difference { get; set; }
        }
        public class ConvDetailRequest
        {
            public string CustomerId { get; set; }
            public string WarehouseId { get; set; }
            public string UserId { get; set; }
            public string OrderId { get; set; }
        }

        public class ConversionOrderDetails
        {
            public string Id { get; set; }
            public string SkuId { get; set; }
            public string ItemCode { get; set; }
            public string ItemName { get; set; }
            public string CurrentStock { get; set; }
            public string ReserveQty { get; set; }
            public string RequestedQty { get; set; }
            public string UOM { get; set; }
            public string UOMId { get; set; }
            public string OrderQty { get; set; }
            public string Lottable { get; set; }
            public string skuWeight { get; set; }
            public string skuCost { get; set; }

            public string AYield { get; set; }
            public string diffyield { get; set; }

            public List<SKUUomList> UomList;
        }

        public class SKUUomList
        {
            public string Id { get; set; }
            public string Uom { get; set; }
            public string UnitQty { get; set; }
        }

        public class ConvHeadRequest
        {
            public string CustomerId { get; set; }
            public string WarehouseId { get; set; }
            public string UserId { get; set; }
            public string OrderId { get; set; }
        }
    }
}
