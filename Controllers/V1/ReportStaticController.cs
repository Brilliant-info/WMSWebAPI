using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;

//using System.Web.Http;
using WMSWebAPI.Models.V1;
using WMSWebAPI.Models.V1.Request;
using WMSWebAPI.Models.V1.Responce;
using WMSWebAPI.Route;
using WMSWebAPI.Utility.V1;

namespace WMSWebAPI.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportStaticController : ControllerBase
    {
        ReportStaticUtility obj = new ReportStaticUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.ReportStatic.PurchaseOrderReport)]

        public async Task<ResponceList> getPurchaseList(reqPurchaseOrderList ReqPara)
        {


            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GlobalReportList(ReqPara);


                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.PurchaseOrderReport, Int64.Parse(ReqPara.UserId));
            }

            return Response;
        }

        //GRN List
        [HttpPost]
        [Route(APIRoute.ReportStatic.GRNListReport)]
        public async Task<ResponceList> getGRNListReport(reqGrnList ReqPara)
        {

            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GRNList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.GRNListReport, Int64.Parse(ReqPara.UserId));
            }

            return Response;
        }

        //QC List
        [HttpPost]
        [Route(APIRoute.ReportStatic.QCReport)]

        public async Task<ResponceList> getQCReportList(reqQCList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getQCList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.QCReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //PutIn List
        [HttpPost]
        [Route(APIRoute.ReportStatic.PutInReport)]

        public async Task<ResponceList> getPutInReportList(reqPutInList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getPutInList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.PutInReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //Allocation List
        [HttpPost]
        [Route(APIRoute.ReportStatic.AllocationReport)]

        public async Task<ResponceList> getAllocationReportList(reqAllocationList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getAllocationList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.AllocationReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }


        //PickUp List
        [HttpPost]
        [Route(APIRoute.ReportStatic.PickUpReport)]

        public async Task<ResponceList> getPickUpReportList(reqPickuplist ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getPickupList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.PickUpReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //QCOut List
        [HttpPost]
        [Route(APIRoute.ReportStatic.QCOutReport)]

        public async Task<ResponceList> getQCOutReportList(reqQCOutlist ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getQCOutList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.QCOutReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //Packing List
        [HttpPost]
        [Route(APIRoute.ReportStatic.PackingReport)]

        public async Task<ResponceList> getPackingReportList(reqPackinglist ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getPackingList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.PackingReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //Dispatch List
        [HttpPost]
        [Route(APIRoute.ReportStatic.DispatchReport)]

        public async Task<ResponceList> getDispatchReportList(reqDispatchlist ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getDispatchList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.DispatchReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //Internal Transfer List
        [HttpPost]
        [Route(APIRoute.ReportStatic.InternalTransferReport)]

        public async Task<ResponceList> getInternalTransferReportList(reqInternalTransferList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getInternalTransferList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.InternalTransferReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //Cycle Count List
        [HttpPost]
        [Route(APIRoute.ReportStatic.CycleCountReport)]

        public async Task<ResponceList> getCycleCountReportList(reqCycleCountList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getCycleCountList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.CycleCountReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //So List
        [HttpPost]
        [Route(APIRoute.ReportStatic.SoReport)]
        public async Task<ResponceList> getSoReportList(reqSOList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getSoList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.SoReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //AllocationShrotge List
        [HttpPost]
        [Route(APIRoute.ReportStatic.AllocatonShrotage)]
        public async Task<ResponceList> getAllocatonShrotageReportList(reqAlocationShrotage ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getAllocationShrtageList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.AllocatonShrotage, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //NearExpairy List
        [HttpPost]
        [Route(APIRoute.ReportStatic.NearexpairyReport)]

        public async Task<ResponceList> getNearexpairyReportList(reqNearexpairyReport ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                { 
                    JsonElement result = await obj.getNearexpairyReportList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.NearexpairyReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //ABCAnalysis List
        [HttpPost]
        [Route(APIRoute.ReportStatic.ABCAnalysisReport)]

        public async Task<ResponceList> getABCAnalysisReportList(reqABCAnalysisReport ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result =  await obj.getABCAnalysisReportList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.ABCAnalysisReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //SalesReturn List
        [HttpPost]
        [Route(APIRoute.ReportStatic.SalesReturnReport)]

        public async Task<ResponceList> getSalesReturnReportList(reqSalesReturnReport ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getSalesReturnReportList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.SalesReturnReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //Product List
        [HttpPost]
        [Route(APIRoute.ReportStatic.ProductlistReport)]

        public async Task<ResponceList> getProductlistReportList(reqProductlistReport ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getProductlistReportList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.ProductlistReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //location List
        [HttpPost]
        [Route(APIRoute.ReportStatic.locationlistReport)]

        public async Task<ResponceList> getlocationReportList(reqlocationlistReport ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getlocationReportList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.locationlistReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //Emptylocation List
        [HttpPost]
        [Route(APIRoute.ReportStatic.EmptylocationlistReport)]

        public async Task<ResponceList> getEmptylocationReportList(reqEmptylocationlist ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getEmptylocationReportList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.EmptylocationlistReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //Daily Stock List
        [HttpPost]
        [Route(APIRoute.ReportStatic.DailyStockReport)]

        public async Task<ResponceList> getDailyStockReportList(reqDailyStocklist ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getDailyStockReportList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.DailyStockReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //StockSummary List
        [HttpPost]
        [Route(APIRoute.ReportStatic.StockSummaryReport)]

        public async Task<ResponceList> getStockSummaryReportList(reqStockSummarylist ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getStockSummaryReportList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.StockSummaryReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //DatewiseEmail List
        [HttpPost]
        [Route(APIRoute.ReportStatic.DatewiseEmailReport)]

        public async Task<ResponceList> getDatewiseEmailReportList(reqDatewiseEmaillist ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getDatewiseEmailReportList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.DatewiseEmailReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //Movement List
        [HttpPost]
        [Route(APIRoute.ReportStatic.MovementReport)]

        public async Task<ResponceList> getMovemetReportList(reqMovementlist ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getMovementReportList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.MovementReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ReportStatic.ClientReport)]

        public async Task<ResponceList> getClientList(reqClientlist ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getClientList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.ClientReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //Vendor List

        [HttpPost]
        [Route(APIRoute.ReportStatic.VendorReport)]

        public async Task<ResponceList> getVendorList(reqVendorlist ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getVendorList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.VendorReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //Current Stock Report List

        [HttpPost]
        [Route(APIRoute.ReportStatic.CurrentStockReport)]

        public async Task<ResponceList> getCurrentStockList(reqCurrentStocklist ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getCurrentStockList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.CurrentStockReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //Occupency DropDown

        [HttpPost]
        [Route(APIRoute.ReportStatic.OccupencyDropDown)]

        public async Task<ResponceList> getOccupencyDropDown(reqOccupencyDropDown ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getOccupencyDropDown(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.OccupencyDropDown, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }


        // FSN Line Report 

        [HttpPost]
        [Route(APIRoute.ReportStatic.getWHOccupancy)]

        public async Task<ResponceList> WHOccupancy(getWHOccupancy ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.WHOccupancy(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.getWHOccupancy, Int64.Parse(ReqPara.WhId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.ReportStatic.getSelfLifeAgingReport)]

        public async Task<ResponceList> SelfLifeAgingReport(getSelfLifeAgingReport ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.SelfLifeAgingReport(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.getSelfLifeAgingReport, Int64.Parse(ReqPara.WhId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.ReportStatic.getInventoryAgingReport)]

        public async Task<ResponceList> InventoryAgingReport(getInventoryAgingReport ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.InventoryAgingReport(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.getInventoryAgingReport, Int64.Parse(ReqPara.WhId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ReportStatic.getInventoryDropdown)]

        public async Task<ResponceList> InventoryDropdown(getInventoryDropdown ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.InventoryDropdown(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.getInventoryDropdown, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ReportStatic.getOrderwiseSummaryReport)]

        public async Task<ResponceList> OrderwiseSummaryReport(getOrderwiseSummary ReqPara)
        {
            string getFromDate = ReqPara.fromDate;
            string getToDate = ReqPara.toDate;
            if (getFromDate == "-")
            {
                ReqPara.fromDate = "";
                ReqPara.toDate = "";
            }
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.OrderwiseSummary(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.getOrderwiseSummaryReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ReportStatic.getStockledgerReport)]

        public async Task<ResponceList> StockledgerReport(getStockledgerReport ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.StockledgerReport(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.getStockledgerReport, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ReportStatic.getFSNReport)]

        public async Task<ResponceList> getFSNReport(getFSNReport ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getFSNReport(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.getFSNReport, Int64.Parse(ReqPara.WhId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.ReportStatic.getStockledgerSkuDropdown)]

        public async Task<ResponceList> StockledgerReport(getStockledgerSkuDropdown ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.StockledgerSkuDropdown(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.getStockledgerSkuDropdown, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ReportStatic.getLocationlTypeList)]
        public async Task<ResponceList> getLocationList(getLocaionddl ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getLocationListddl(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Error Found..!!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.getLocationlTypeList, Int64.Parse(ReqPara.Customerid));
            }

            return Response;
        }
        [HttpPost]
        [Route(APIRoute.ReportStatic.getCustomerSummary)]
        public async Task<ResponceList> getCustomerSummary(getCustomerSummary ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getCustomerSummary(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Error Found..!!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.getCustomerSummary, Int64.Parse(ReqPara.UserId));
            }

            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ReportStatic.InwardDetailList)]

        public async Task<ResponceList> InwardDetailList(reqInwardDetailList ReqPara)
        {


            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.InwardDetailList(ReqPara);


                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.InwardDetailList, Int64.Parse(ReqPara.UserId));
            }

            return Response;
        }


        // OutwardDetailList
        [HttpPost]
        [Route(APIRoute.ReportStatic.OutwardDetailList)]

        public async Task<ResponceList> OutwardDetailList(reqOutwardDetailList ReqPara)
        {


            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.OutwardDetailList(ReqPara);


                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.OutwardDetailList, Int64.Parse(ReqPara.UserId));
            }

            return Response;
        }
        [HttpPost]
        [Route(APIRoute.ReportStatic.AssetReportlist)]

        public async Task<ResponceList> AssetReportlist(reqAssetReportlist ReqPara)
        {


            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.AssetReportlist(ReqPara);


                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.AssetReportlist, Int64.Parse(ReqPara.UserId));
            }

            return Response;
        }


        //AssetReportDropdown
        [HttpPost]
        [Route(APIRoute.ReportStatic.AssetReportDropdown)]

        public async Task<ResponceList> AssetReportDropdown(reqAssetReportDropdown ReqPara)
        {


            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.AssetReportDropdown(ReqPara);


                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.ReportStatic.AssetReportDropdown, Int64.Parse(ReqPara.UserId));
            }

            return Response;
        }
    }
}
