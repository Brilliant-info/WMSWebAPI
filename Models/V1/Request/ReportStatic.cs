using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WMSWebAPI.Models.V1.Request
{

    //Purchase Class
    public class reqPurchaseOrderList
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompnayId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string OrderType { get; set; }
    }

    public class getCustomerSummary
    {
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyID { get; set; }

        public string UserId { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }


    }
    //GRN Class
    public class reqGrnList
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompnayId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string OrderType { get; set; }
    }

    //QC Class
    public class reqQCList
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompnayId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string OrderType { get; set; }
    }

    //PutInlist
    public class reqPutInList
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompnayId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string OrderType { get; set; }
    }

    //Allocationlist
    public class reqAllocationList
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompnayId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string OrderType { get; set; }
    }

    //Pickuplist
    public class reqPickuplist
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompnayId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string OrderType { get; set; }
    }

    //Pickuplist
    public class reqQCOutlist
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompnayId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string OrderType { get; set; }
    }

    //Packinglist
    public class reqPackinglist
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string OrderType { get; set; }
    }

    //Dispatchlist
    public class reqDispatchlist
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string OrderType { get; set; }
    }

    //Internal Transfer List
    public class reqInternalTransferList
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string ordertype { get; set; }
    }

    //Cycle Count List
    public class reqCycleCountList
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
    }

    //So List
    public class reqSOList
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string OrderType { get; set; }
    }

    //Allocation Shrotage List
    public class reqAlocationShrotage
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string OrderType { get; set; }
    }

    //Nearexpairy List
    public class reqNearexpairyReport
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string lastSeqno { get; set; }
        public string filterLottable { get; set; }

    }

    //Nearexpairy List
    public class reqABCAnalysisReport
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
    }

    //SalesReturn List
    public class reqSalesReturnReport
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
    }

    //Product List
    public class reqProductlistReport
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string filterLottable { get; set; }
    }

    //location List
    public class reqlocationlistReport
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }

        //[DisplayFormat(ConvertEmptyStringToNull = false)]
        //public string loctype { get; set; }
    }

    //EmptyLocation list

    public class reqEmptylocationlist
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
    }

    //Daily stock Report list
    public class reqDailyStocklist
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string fromDate { get; set; }
        public string filterLottable { get; set; }

    }

    //StockSummary Report list
    public class reqStockSummarylist
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }

    }

    //DatewiseEmail Report list
    public class reqDatewiseEmaillist
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string OrderType { get; set; }
    }

    //Movement Report list
    public class reqMovementlist
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string lastSeqno { get; set; }
    }
    // Client  Report List
    public class reqClientlist
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }

    }

    //Vendor  Report List
    public class reqVendorlist
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }

    }

    //Current Stock Report List
    public class reqCurrentStocklist
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyID { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string filterLottable { get; set; }

    }

    public class reqOccupencyDropDown
    {
        public string WarehouseId { get; set; }
        public string CompID { get; set; }
        public string CustId { get; set; }
        public string UserId { get; set; }
    }

    public class getInventoryAging
    {

    }
    public class getWHOccupancy
    {
        public string CustId { get; set; }
        public string WhId { get; set; }
        public string UserId { get; set; }
        public string CompId { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string Section { get; set; }
        public string Passage { get; set; }
        public string Rack { get; set; }
        public string RptFilter { get; set; }

        public string LocationID { get; set; }
    }

    public class getSelfLifeAgingReport
    {
        public string CustId { get; set; }
        public string WhId { get; set; }
        public string UserId { get; set; }
        public string CompId { get; set; }
        public string ProdGrpId { get; set; }
        public string PrdId { get; set; }
        public string LocId { get; set; }
        public string AgingDay { get; set; }
        public string filterLottable { get; set; }
    }

    public class getInventoryAgingReport
    {
        public string CustId { get; set; }
        public string WhId { get; set; }
        public string UserId { get; set; }
        public string CompId { get; set; }
        public string ProdGrpId { get; set; }
        public string PrdId { get; set; }
        public string LocId { get; set; }
        public string AgingDay { get; set; }
        public string filterLottable { get; set; }
    }

    public class getInventoryDropdown
    {
        public string CustId { get; set; }
        public string WhId { get; set; }
        public string UserId { get; set; }
        public string CompId { get; set; }

    }
    //OrderwiseSummary Report list
    public class getOrderwiseSummary
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompnayId { get; set; }
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
    }

    //Stockledger Report list
    public class getStockledgerReport
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyID { get; set; }
        public string skuId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
    }

    public class getFSNReport
    {
        public string CustId { get; set; }
        public string WhId { get; set; }
        public string UserId { get; set; }
        public string CompanyId { get; set; }
        public string FrmDate { get; set; }
        public string ToDate { get; set; }
        public string skuid { get; set; }

    }
    public class getStockledgerSkuDropdown
    {
        public string companyId { get; set; }
        public string custId { get; set; }
        public string whId { get; set; }
        public string UserId { get; set; }

    }

    public class getLocaionddl
    {
        public string Companyid { get; set; }
        public string Customerid { get; set; }
        public string Warehouseid { get; set; }
    }
    public class reqInwardDetailList
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompnayId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string OrderType { get; set; }
    }


    // OutwardDetailList
    public class reqOutwardDetailList
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompnayId { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchFilter { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string SearchValue { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string OrderType { get; set; }
    }
    public class reqAssetReportlist
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyId { get; set; }
        public string DepartmentType { get; set; }
        public string ProjectName { get; set; }
        public string Location { get; set; }
        public string EmpID { get; set; }
        public string BUHead { get; set; }
        public string Title { get; set; }
        public string flag { get; set; }
    }
    public class reqAssetReportDropdown
    {
        public string UserId { get; set; }
        public string CustomerId { get; set; }
        public string WarehouseId { get; set; }
        public string CompanyId { get; set; }
    }
}
