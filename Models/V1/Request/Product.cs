using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WMSWebAPI.Models.V1.Request
{
    public class GetProductListRequest
    {
        public string CurrentPage { get; set; }
        public string RecordLimit { get; set; }
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string Filter { get; set; }
        public string Search { get; set; }
    }
    public class AddProductRequest
    {
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string SkuId { get; set; }
        public string SkuCode { get; set; }
        public string SkuName { get; set; }
        public string CategoryId { get; set; }
        public string SubcategoryId { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Description { get; set; }
        public string AliasSkuCode { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string PrinciplePrice { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string GroupSet { get; set; }
        public string UpcBarcode { get; set; }
        public string PickingMethod { get; set; }
        public string PickingfamilyGroup { get; set; }
        public string Active { get; set; }
        public decimal MinReplenishQty { get; set; }
        public decimal MaxReplenishQty { get; set; }
        public decimal MinOrderQty { get; set; }
        public long WarehouseID { get; set; }

    }
    public class EditProductRequest
    {
        public string ProductId { get; set; }
        public string UserId { get; set; }
    }

    public class GetCategoryListRequest
    {
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
    }
    public class AddCategoryRequest
    {
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public string Active { get; set; }
    }
    public class GetSubCategoryListRequest
    {
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string SkuCategoryId { get; set; }

    }
    public class AddSubCategoryRequest
    {
        public string CompanyId { get; set; }
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string SkuSubCategoryId { get; set; }
        public string SkuCategoryId { get; set; }
        public string Name { get; set; }
        public string Active { get; set; }
    }
    public class GetImageListRequest
    {
        public string UserId { get; set; }
        public string SkuId { get; set; }
    }
    public class AddImageRequest
    {
        public string UserId { get; set; }
        public string SkuID { get; set; }
        public string ImageId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ImageTitle { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Description { get; set; }
        public string Attachment { get; set; }
        public string Path { get; set; }
    }
    public class UploadImageRequest
    {
        public string CustomerId { get; set; }
        public string UserId { get; set; }
        public string SkuID { get; set; }
        public string ImageDownload { get; set; }
        public string fileloc { get; set; }
        public string ObjectName { get; set; }
    }
    public class RemoveImageRequest
    {
        public string UserId { get; set; }
        public string ImageId { get; set; }
    }
    public class GetUomListRequest
    {
        public string UserId { get; set; }
        public string SkuID { get; set; }
    }
    public class AddUomRequest
    {
        public string UserId { get; set; }
        public string UomId { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }
        public string SkuID { get; set; }
    }
    public class GetLottableListRequest
    {
        public string UserId { get; set; }
        public string SkuID { get; set; }
    }
    public class AddLottableRequest
    {
        public string UserId { get; set; }
        public string lottableType { get; set; }
        public string DataType { get; set; }
        public string ToRange { get; set; }
        public string FromRange { get; set; }
        public string SkuID { get; set; }
        public string Active { get; set; }
        public string Fixedlegnth { get; set; }
        public string IsPartOfInward { get; set; }
        public string IsPartOfOutward { get; set; }
        public string IsUnique { get; set; }
        public long CustomerID { get; set; }

    }
    public class RemoveLottableRequest
    {
        public string UserId { get; set; }
        public string SkuID { get; set; }
        public string LottableID { get; set; }
    }

    public class LotableDataType
    {
        public long CustomerID { get; set; }
        public long UserID { get; set; }
        public string LotableType { get; set; }
    }


    public class RemoveUomRequest
    {
        public string UserId { get; set; }
        public string SkuID { get; set; }
    }

    public class GetpackingfamilyddlRequest
    {
        public string UserId { get; set; }
    }
    public class GetUomddlRequest
    {
        public string UserId { get; set; }
    }
    public class GetLottableddlRequest
    {
        public long CompanyId { get; set; }

        public long CustomerID { get; set; }
        public long UserId { get; set; }
    }

    public class ProductInventoryAssignListRequest
    {
        public string UserId { get; set; }
        public string ProductId { get; set; }
        public string WarehouseId { get; set; }
        public string CustomerId { get; set; }
        public string CurrentPage { get; set; }
    }
    public class ProductLocationListRequest
    {
        public string Type { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Filter { get; set; }
    }

    public class AddSKULocationReq
    {
        public string SKUID { get; set; }
        public string LocationID { get; set; }
        public string WarehouseID { get; set; }
        public string CustomerID { get; set; }
        public string LocObject { get; set; }
        public string CreatedBy { get; set; }

    }

    public class RemoveSKULocRequest
    {
        public string SKUID { get; set; }
        public string LocationID { get; set; }

        public string CreatedBy { get; set; }
    }
    // API CHANGES FOR BARCODE CONFIGURATION - 27 Nov 2023
    public class SaveBarcodeRequest
    {
        public string CustomerID { get; set; }
        public string WarehouseID { get; set; }
        public string UserID { get; set; }
        public string LabelSize { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string ISdelimated { get; set; }
        public string BarcodeType { get; set; }
        public string finalbarcodeConfig { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string IsFrom { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string IsTo { get; set; }
        public string Lottable { get; set; }
        public string SkuId { get; set; }
        public string BarcodeFixLength { get; set; }
        public string BarcodeSize { get; set; }
        public string separatedBy { get; set; }
        public string Prefix { get; set; }
        public string SerialPrefix { get; set; }
        public string SerialPrefixPos { get; set; }

    }
    public class GetLottableSaveRequest
    {
        public string SkuID { get; set; }
        public string WarehouseID { get; set; }
        public string CustomerID { get; set; }
        public string UserID { get; set; }
        public string AddLottable { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string IsFrom { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string IsTo { get; set; }
    }
    public class GetLottableRemoveRequest
    {
        public string SkuID { get; set; }
        public string WarehouseID { get; set; }
        public string CustomerID { get; set; }
        public string UserID { get; set; }
        public string Lottable { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string IsFrom { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string IsTo { get; set; }
    }
    public class GetLottableDropdownRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string UserId { get; set; }
        public string SkuId { get; set; }
    }
    public class GetLottablebarcodeRequest
    {
        public string SkuID { get; set; }
        public string WarehouseID { get; set; }
        public string CustomerID { get; set; }
        public string UserID { get; set; }
    }

    public class GetPrdBarcodeConfigRequest
    {
        public string SkuID { get; set; }
        public string WarehouseID { get; set; }
        public string CustomerID { get; set; }
        public string UserID { get; set; }
    }
    // API CHANGES FOR BARCODE CONFIGURATION - 27 Nov 2023
    public class BindCategory
    {
        public string CompanyId { get; set; }
        public string CustomerID { get; set; }

        public string UserID { get; set; }
        public string WarehouseID { get; set; }

    }


    public class GetPriceList
    {
        public string CompanyId { get; set; }
        public string CustomerID { get; set; }

        public string UserID { get; set; }
        public string WarehouseID { get; set; }
        public string SkuID { get; set; }

    }

    public class SavePrice
    {
        public string CompanyId { get; set; }
        public string CustomerID { get; set; }
        public string UserID { get; set; }
        public string WarehouseID { get; set; }
        public string SkuID { get; set; }
        public string CategoryValue { get; set; }
        public string RateValue { get; set; }
        public string DiscountValue { get; set; }

    }


    public class GetGSTList
    {
        public string CompanyId { get; set; }
        public string CustomerID { get; set; }

        public string UserID { get; set; }
        public string WarehouseID { get; set; }
        public string SkuID { get; set; }

    }
    public class SaveGST
    {
        public string CompanyId { get; set; }
        public string CustomerID { get; set; }
        public string UserID { get; set; }
        public string WarehouseID { get; set; }
        public string SkuID { get; set; }
        public string GSTName { get; set; }
        public decimal Value { get; set; }
        public string Remark { get; set; }

    }
    public class GetskucodelistRequest
    {
        public string CustomerID { get; set; }
        public string WarehouseID { get; set; }
        public string CompanyID { get; set; }
        public string UserID { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string skey { get; set; }
    }
    public class GetskusaveRequest
    {
        public string CustomerID { get; set; }
        //public string WarehouseID { get; set; }
        public string CompanyID { get; set; }
        public string UserID { get; set; }
        public string MSkuId { get; set; }
        public string MUOM { get; set; }
        public string SkuId { get; set; }
        public string Qty { get; set; }
        //public string UOM { get; set; }
        public string Remark { get; set; }
    }
    public class GetskubindRequest
    {
        public string CustomerID { get; set; }
        public string WarehouseID { get; set; }
        public string CompanyID { get; set; }
        public string UserID { get; set; }
        public string ID { get; set; }
    }
    public class GetattributeSaveRequest
    {
        public string CustomerID { get; set; }
        public string WarehouseID { get; set; }
        public string CompanyID { get; set; }
        public string UserID { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public Int64 height { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public Int64 weight { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public Int64 length { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public Int64 width { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string selflife { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string packmode { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string contorging { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string packsize { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string color { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string band { get; set; }
        public string productId { get; set; }

    }
    public class GetattributebindRequest
    {
        public string CompanyId { get; set; }
        public string CustomerID { get; set; }
        public string WarehouseID { get; set; }
        public string UserID { get; set; }
        public string ProductId { get; set; }
    }
    public class GetUOMDropdownRequest
    {
        public string CustomerID { get; set; }
        public string CompanyID { get; set; }
        public string skuid { get; set; }
    }
    public class DispSkuConvDetailRequest
    {
        public string orderid { get; set; }
    }
    public class RemoveskuConvRequest
    {
        public string orderid { get; set; }
    }
    public class ddlGetGST
    {
        public string CompanyId { get; set; }
        public string CustomerID { get; set; }

        public string UserID { get; set; }
        public string WarehouseID { get; set; }

    }
    public class EditGST
    {
        public string CompanyId { get; set; }
        public string CustomerID { get; set; }
        public string UserID { get; set; }
        public string WarehouseID { get; set; }
        public string SkuID { get; set; }
        public string GSTName { get; set; }
        public string Value { get; set; }
        public string Remark { get; set; }
        public string rowno { get; set; }

    }
}
