using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;
using WMSWebAPI.Models.V1.Responce;
using WMSWebAPI.Route;
using WMSWebAPI.Utility.V1;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.IO;

namespace WMSWebAPI.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        InventoryUtility obj = new InventoryUtility();
        SysException exe = new SysException();


     

        [HttpPost]
        [Route(APIRoute.Inventory.GetInventoryList)]
        public async Task<ResponceList> GetInventoryList(GetInventoryListRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.InventoryList(reqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Inventory.GetInventoryList, Int64.Parse(reqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Inventory.GetAllocateInventoryExport)]
        public IActionResult AllocateInventoryExport(GetAllocateInventoryExportRequest ReqPara)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            Responce resp = new Responce();

            try
            {
                ds = obj.AllocateInventoryExport(ReqPara);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dt, "Inventory");
                        using (MemoryStream stream = new MemoryStream())
                        {
                            wb.SaveAs(stream);
                            stream.Seek(0, SeekOrigin.Begin);

                            return File(stream.ToArray(),
                                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                                        "Report.xlsx");
                        }
                    }
                }
                resp = ResponceResult.SuccessResponse("success");
            }
            catch (Exception ex)
            {
                resp = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Inventory.GetAllocateInventoryExport, Int64.Parse(ReqPara.UserId));
                return BadRequest(resp);
            }
            finally
            {
                ds.Dispose();
            }
            return Ok(resp);
        }


        [HttpPost]
        [Route(APIRoute.Inventory.GetAvailInventoryList)]
        public async Task<ResponceList> AvailInventoryList(GetAvailInventoryListRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.AvailInventoryList(reqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Inventory.GetAvailInventoryList, Int64.Parse(reqPara.UserId));
            }
            return Response;
        }

        


        [HttpPost]
        [Route(APIRoute.Inventory.GetHoldInventoryList)]
        public async Task<ResponceList> HoldInventoryList(GetHoldInventoryListRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.HoldInventoryList(reqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Inventory.GetHoldInventoryList, Int64.Parse(reqPara.UserId));
            }
            return Response;
        }

        
        [HttpPost]
        [Route(APIRoute.Inventory.GetAllocateInventoryList)]
        public async Task<ResponceList> AllocateInventoryList(GetAllocateInventoryListRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.AllocateInventoryList(reqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Inventory.GetAllocateInventoryList, Int64.Parse(reqPara.UserId));
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.Inventory.GetRejectedInventoryList)]
        public async Task<ResponceList> RejectedInventoryList(GetRejectedInventoryListRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.RejectedInventoryList(reqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Inventory.GetRejectedInventoryList, Int64.Parse(reqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Inventory.CreateCyclePlan)]
        public Responce CreateCyclePlan(CreateCycleRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.CreateCyclePlan(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Inventory.CreateCyclePlan, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Inventory.HoldInventory)]
        public Responce HoldInventory(HoldInventoryRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.HoldInventory(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Inventory.HoldInventory, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Inventory.GetInventoryExport)]
        public IActionResult GetInventoryExport(GetInventoryExportRequest ReqPara)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            Responce resp = new Responce();

            try
            {
                ds = obj.InventoryExport(ReqPara);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dt, "Inventory");
                        using (MemoryStream stream = new MemoryStream())
                        {
                            wb.SaveAs(stream);
                            stream.Seek(0, SeekOrigin.Begin);

                            return File(stream.ToArray(),
                                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                                        "Report.xlsx");
                        }
                    }
                }
                resp = ResponceResult.SuccessResponse("success");
            }
            catch (Exception ex)
            {
                resp = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Inventory.GetInventoryExport, Int64.Parse(ReqPara.UserId));
                return BadRequest(resp);
            }
            finally
            {
                ds.Dispose();
            }
            return Ok(resp);
        }

        [HttpPost]
        [Route(APIRoute.Inventory.DeallocateInventory)]
        public Responce DeallocateInventory(DeallocateInventoryRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.DeallocateInventory(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Inventory.DeallocateInventory, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Inventory.GetHoldInventoryExport)]
        public IActionResult HoldInventoryExport(GetHoldInventoryExportRequest ReqPara)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            Responce resp = new Responce();

            try
            {
                ds = obj.HoldInventoryExport(ReqPara);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dt, "Inventory");
                        using (MemoryStream stream = new MemoryStream())
                        {
                            wb.SaveAs(stream);
                            stream.Seek(0, SeekOrigin.Begin);

                            return File(stream.ToArray(),
                                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                                        "Report.xlsx");
                        }
                    }
                }
                resp = ResponceResult.SuccessResponse("success");
            }
            catch (Exception ex)
            {
                resp = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Inventory.GetHoldInventoryExport, Int64.Parse(ReqPara.UserId));
                return BadRequest(resp);
            }
            finally
            {
                ds.Dispose();
            }
            return Ok(resp);
        }

        [HttpPost]
        [Route(APIRoute.Inventory.ReleaseInventory)]
        public Responce ReleaseInventory(HoldInventoryRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.ReleaseInventory(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Inventory.ReleaseInventory, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Inventory.GetRejectedInventoryExport)]
        public IActionResult RejectedInventoryExport(GetRejectedInventoryExportRequest ReqPara)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            Responce resp = new Responce();

            try
            {
                ds = obj.RejectedInventoryExport(ReqPara);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        wb.Worksheets.Add(dt, "Inventory");
                        using (MemoryStream stream = new MemoryStream())
                        {
                            wb.SaveAs(stream);
                            stream.Seek(0, SeekOrigin.Begin);

                            return File(stream.ToArray(),
                                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                                        "Report.xlsx");
                        }
                    }
                }
                resp = ResponceResult.SuccessResponse("success");
            }
            catch (Exception ex)
            {
                resp = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Inventory.GetRejectedInventoryExport, Int64.Parse(ReqPara.UserId));
                return BadRequest(resp);
            }
            finally
            {
                ds.Dispose();
            }
            return Ok(resp);
        }

        [HttpPost]
        [Route(APIRoute.Inventory.AdjustInventory)]
        public Responce AdjustInventory(AdjustInventoryRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.AdjustInventory(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Inventory.AdjustInventory, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

     
        [HttpPost]
        [Route(APIRoute.Inventory.InvLocationByWare)]
        public async Task<ResponceList> InvLocationByWare(InvLocationLstTransfr reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.InvGetLocation(reqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Inventory.InvLocationByWare, Int64.Parse(reqPara.UserId));
            }
            return Response;
        }

      


        [HttpPost]
        [Route(APIRoute.Inventory.GetInvBusinessrule)]
        public async Task<ResponceList> GetInvBusinessrule(GetBusinessruleReq reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.GetBusinessrule(reqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Inventory.GetInvBusinessrule, 0);
            }
            return Response;
        }

  

        [HttpPost]
        [Route(APIRoute.Inventory.GetPallet)]
        public async Task<ResponceList> GetPallet(PalletDetailRequestTrans reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.GetPallet(reqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Inventory.GetPallet, Int64.Parse(reqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Inventory.SaveTransfer)]
        public Responce SaveTransfer(SaveINVTransferDetailRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.SaveTransfer(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Inventory.SaveTransfer, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
    }
}
