using System.ComponentModel.DataAnnotations;

namespace WMSWebAPI.Models.V1.Request
{
    public class CommFunAPI
    {

    }
    public class ReqPalletList
    {
        public Int64 CompanyId { get; set; }
        public Int64 userId { get; set; }
        public Int64 whId { get; set; }
        public Int64 custId { get; set; }
        public string PalletName { get; set; }
        public string obj { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public Int64 grnId { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public Int64 POID { get; set; }

    }
    public class SKUSuggestionRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public string skuobject { get; set; }
        public string skey { get; set; }
        public string orderobj { get; set; }
    }

    public class ScanSuggestionRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public string obj { get; set; }
        public string currentpg { get; set; }
        public string recordlmt { get; set; }
    }
    public class SKUUOMRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }

        public string SkuId { get; set; }
    }

    public class scanrequest
    {
        public string value { get; set; }

        public string companyID { get; set; }
        public string obj { get; set; }
        public string orderID { get; set; }

    }
    public class lottablereq
    {

        public string prodID { get; set; }
        public string orderID { get; set; }
        public string obj { get; set; }

        public string GrnID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string palletname { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string lottable { get; set; }
    }

    public class userlist
    {
        public string companyID { get; set; }
    }
    public class assinguserRequest
    {
        public string obj { get; set; }
        public string type { get; set; }
        public string orderID { get; set; }
        public string UserID { get; set; }
        public string date { get; set; }

        public string time { get; set; }
        public string companyID { get; set; }
        public string customerID { get; set; }
        public string createdBy { get; set; }
    }

    public class directPickupOrder
    {
        public string OrderID { get; set; }
    }
    #region devlop by Yashartha for Suggestion List 
    public class POOSKUSuggestionRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public string ClientId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string skey { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string isSuggestionList { get; set; }
        public string lastSeqno { get; set; }

    }


    public class SKUSuggestionRequestInQC
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string OrderId { get; set; }
        public string skuobject { get; set; }

        public string orderobj { get; set; }
    }
    public class SKUCommanFunSuggestList
    {
        public string ID { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UPCBarcode { get; set; }
        public string CurrentStock { get; set; }
        public string ResurveQty { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string GroupSet { get; set; }
        public string ImagePath { get; set; }
        public string SKey { get; set; }
        public string Lottables { get; set; }

        public List<UOMCommanFun> UOM;

        public List<LottableCommanFun> Lottable;
    }
    public class UOMCommanFun
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string UnitValue { get; set; }
        public string isSelected { get; set; }
    }
    public class LottableCommanFun
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string DataType { get; set; }
        public string isSelected { get; set; }
    }
    #endregion
}
