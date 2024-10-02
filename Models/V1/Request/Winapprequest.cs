using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WMSWebAPI.Models.V1.Request
{
    public class Winapprequest
    {
    }
    public class GetWinInboundRequest
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }

        public string CompanyId { get; set; }
        public string UserId { get; set; }

    }
    public class GetWinInboundReqDetails
    {

        public string OrderRefNo { get; set; }
        public string POID { get; set; }
        public string UserId { get; set; }

    }
    public class GetLabelfileName
    {
        public string CompanyId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string LabelType { get; set; }
        public string LabelSize { get; set; }
        public string UserId { get; set; }

    }
    public class GetInboundPrintBarcode
    {
        public string PKID { get; set; }
        public string type { get; set; }

    }
    public class WinSaveGatePassLottableRequest
    {
        public string GetPassID { get; set; }
        public string SkuId { get; set; }
        public string Qty { get; set; }
        public string GrnId { get; set; }
        public string PackSize { get; set; }

        public string Lottable1 { get; set; }
        public string Lottable2 { get; set; }
        public string Lottable3 { get; set; }
        public string Lottable4 { get; set; }
        public string Lottable5 { get; set; }
        public string Lottable6 { get; set; }
        public string Lottable7 { get; set; }
        public string Lottable8 { get; set; }
        public string Lottable9 { get; set; }
        public string Lottable10 { get; set; }
        public string UomId { get; set; }
        public string UOM { get; set; }
        public string UserId { get; set; }
        public string WarehouseId { get; set; }
        public string CustomerId { get; set; }
        public string InwardOrderNo { get; set; }
    }
    public class WinSaveBarcodeHistoryRequest
    {
        public string SkuId { get; set; }
        public string JobOrderNo { get; set; }
        public string OperatorCode { get; set; }
        public string Scanbarcode { get; set; }

        public string Lottable1 { get; set; }
        public string Lottable2 { get; set; }
        public string Lottable3 { get; set; }
        public string Lottable4 { get; set; }
        public string Lottable5 { get; set; }
        public string Lottable6 { get; set; }
        public string Lottable7 { get; set; }
        public string Lottable8 { get; set; }
        public string Lottable9 { get; set; }
        public string Lottable10 { get; set; }
        public string Weight { get; set; }
        public string UOM { get; set; }
        public string CompanyId { get; set; }
        public string WarehouseId { get; set; }
        public string CustomerId { get; set; }
        public string UserId { get; set; }
    }
    public class GetBarcodeWthlottable
    {

        public string WHID { get; set; }
        public string customerID { get; set; }
        public string UID { get; set; }
        public string Barcode { get; set; }
        public string JobOrderNo { get; set; }
        public string OperatorCode { get; set; }
        public string Weight { get; set; }
        public string companyId { get; set; }
    }
    public class GetBOMDDL
    {

        public string WHID { get; set; }
        public string customerID { get; set; }
        public string UID { get; set; }
        public string companyId { get; set; }
    }
    public class GetFGDetails
    {
        public string UID { get; set; }
        public string BOMID { get; set; }
    }
    public class GetFGDDL
    {

        public string WHID { get; set; }
        public string customerID { get; set; }
        public string UID { get; set; }
        public string companyId { get; set; }
    }
    public class GetBOMDetails
    {
        public string UID { get; set; }
        public string BOMID { get; set; }
        public string customerID { get; set; }
        public string Barcode { get; set; }
        public string warehouseID { get; set; }
        public string companyId { get; set; }
    }
    public class GetBOMLIST
    {

        public string WHID { get; set; }
        public string customerID { get; set; }
        public string UID { get; set; }
        public string companyId { get; set; }
    }
    public class GetBOMEdit
    {

        public string WHID { get; set; }
        public string customerID { get; set; }
        public string UID { get; set; }
        public string companyId { get; set; }
        public string BOMID { get; set; }
    }
    public class GetBOMSkuList
    {

        public string WHID { get; set; }
        public string customerID { get; set; }
        public string UID { get; set; }
        public string companyId { get; set; }
    }
    public class GetBOMDetailsEdit
    {

        public string WHID { get; set; }
        public string customerID { get; set; }
        public string UID { get; set; }
        public string companyId { get; set; }
        public string BOMID { get; set; }
    }
}
