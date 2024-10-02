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
using WMSWebAPI.Models.V1.Request;
using WMSWebAPI.Models.V1.Responce;
using WMSWebAPI.Route;
using WMSWebAPI.Utility;
using WMSWebAPI.Utility.V1;

namespace WMSWebAPI.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        ReportUtility obj = new ReportUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.Report.GetGlobalReportList)]
        public async Task<ResponceList> GlobalReportList(GetGlobalReportListRequest ReqPara)

        {
            ResponceList Response = new ResponceList();
            try

            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GlobalReportList(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Report.GetGlobalReportList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Report.GetReportCategory)]
        public async Task<ResponceList> GetReportCategory(GetReportCategoryRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.ReportCategory(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Report.GetReportCategory, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Report.GetPurchaseorderRecieptdetail)]
        public async Task<ResponceList> GetPurchaseorderRecieptdetail(GetPurchaseorderRecieptdetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result =  await obj.PurchaseorderRecieptdetail(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Report.GetPurchaseorderRecieptdetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Report.GetReportCategoryMenu)]
        public async Task<ResponceList> GetReportCategoryMenu(GetReportCategoryMenuRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.ReportCategoryMenu(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Report.GetReportCategoryMenu, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Report.GetSaleorderdetail)]
        public async Task<ResponceList> GetSaleorderdetail(GetSalesorderdetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.Saleorderdetail(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Report.GetSaleorderdetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Report.GetDispatchorderdetail)]
        public async Task<ResponceList> GetDispatchorderdetail(GetDispatchorderdetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.Dispatchorderdetail(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Report.GetDispatchorderdetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Report.GetVariencedetail)]
        public async Task<ResponceList> GetVariencedetail(GetVariencedetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.Variencedetail(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Report.GetVariencedetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Report.GetRecivingdetail)]
        public async Task<ResponceList> GetRecivingdetail(GetRecivingdetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.Recivingdetail(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Report.GetRecivingdetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Report.GetAllocationGroupdetail)]
        public async Task<ResponceList> GetAllocationGroupdetail(GetAllocationGroupdetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.AllocationGroupDetail(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Report.GetAllocationGroupdetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Report.GetPickingdetail)]
        public async Task<ResponceList> GetPickingdetail(GetPickingdetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.Pickingdetail(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Report.GetPickingdetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Report.GetOrderHistorydetail)]
        public async Task<ResponceList> GetOrderHistorydetail(GetOrderHistorydetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.OrderHistorydetail(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Report.GetOrderHistorydetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Report.PackingOrderdetail)]
        public async Task<ResponceList> PackingOrderdetail(GetPackingdetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.PackingOrderdetail(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Report.PackingOrderdetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Report.CustomerInventory)]
        public async Task<ResponceList> CustomerInventory(GetCustomerInventoryRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.CustomerInventory(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Report.CustomerInventory, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }



        [HttpPost]
        [Route(APIRoute.Report.InwardQualityCheckDetail)]
        public async Task<ResponceList> InwardQualityCheckDetail(GetInwardQualityCheckRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.InwardQualityCheckDetail(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Report.InwardQualityCheckDetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Report.GetPutawaydetail)]
        public async Task<ResponceList> GetPutawaydetail(GetPutawaydetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetPutawaydetail(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Report.GetPutawaydetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Report.CycleCountDetail)]
        public async Task<ResponceList> GetCycleCountDetail(GetCycleCountRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.CycleCountDetail(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Report.CycleCountDetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Report.InternalTransferDetail)]
        public async Task<ResponceList> InternalTransferDetail(GetInternalTransRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.InternalTransferDetail(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Report.InternalTransferDetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Report.OutwardQualityCheckDetail)]
        public async Task<ResponceList> OutwardQualityCheckDetail(GetOutwardQualityCheckRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.OutwardQualityCheckDetail(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Report.OutwardQualityCheckDetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Report.GetSalesreturndetail)]
        public async Task<ResponceList> Salesreturndetail(GetSalesreturndetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.Salesreturndetail(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Report.GetSalesreturndetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Report.PickingDetailsExportCsv)]

        public async Task<Responce> PickingDetailsExportCsv(PickingDetailsExportCsv ReqPara)
        {
            Responce Response = new Responce();

            try
            {


                if (ReqPara != null)
                {

                    //return Response;
                    //Response.Clear();
                    //Response.Buffer = true;
                    //Response.AddHeader("content-disposition", "attachment;filename=SqlExport.csv");
                    //Response.Charset = "";
                    //Response.ContentType = "application/text";
                    //Response.Output.Write(result);
                    //Response.Flush();
                    //Response.End();
                    string result = obj.PickingDetailsExportCsv(ReqPara);


                    DateTime currentDateTime = DateTime.Now;
                    string formattedDateTime = currentDateTime.ToString("ddMMyyyyHHmmss");
                    string fileName = "PickingReport_" + formattedDateTime + ".csv";

                    //System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;

                    //response.ClearContent();
                    //response.Clear();
                    //response.ContentType = "application/vnd.ms-excel";
                    //response.AddHeader("Content-Disposition", "attachment; filename=" + fileName);
                    ////response.TransmitFile(FilePath);
                    //response.Write(result);
                    //response.Flush();
                    //response.Close();
                    //resp = Response.Result(result);

                }

            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Report.PickingDetailsExportCsv, ReqPara.UserId);
            }

            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Report.InvoiceDetail)]
        public async Task<ResponceList> InvoiceDetailReport(InvoiceDetailReportRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.InvoiceDetailReport(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Report.InvoiceDetail, ReqPara.UserId);
            }
            return Response;
        }
    }
}
