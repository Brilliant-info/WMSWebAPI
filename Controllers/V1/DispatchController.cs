using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;
using WMSWebAPI.Models.V1.Responce;
using WMSWebAPI.Route;
using WMSWebAPI.Utility.V1;

namespace WMSWebAPI.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispatchController : ControllerBase
    {

        SysException exe = new SysException();
        DispatchUtility obj = new DispatchUtility();


        [HttpPost]
        [Route(APIRoute.Dispatch.GetDispatchList)]
        public async Task<ResponceList> BatchDispatchList(DispatchListRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.DispatchList(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Dispatch.GetDispatchList, 0);
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.Dispatch.BatchDispatchList)]
        public async Task<ResponceList> BatchDispatchList(BatchDispatchListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.BatchDispatchList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Dispatch.BatchDispatchList,0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Dispatch.GetBatchDispatchDetail)]
        public async Task<ResponceList> GetBatchDispatchDetail(BatchDispatchDetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetBatchDispatchDetail(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Dispatch.GetBatchDispatchDetail, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Dispatch.GetBatchDispatchEdit)]
        public async Task<ResponceList> GetBatchDispatchDetail(DispatchDetailEdit ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetBatchDispatchEdit(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Dispatch.GetBatchDispatchEdit, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Dispatch.GetBatchDispatchDetailNEW)]
        public async Task<ResponceList> GetBatchDispatchDetail(BatchDispatchDetailRequestNew ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetBatchDispatchDetailNEW(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Dispatch.GetBatchDispatchDetailNEW, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Dispatch.saveDispatchbyso)]
        public Responce SaveDetails(SaveDispatchBySORequest req)
        {
            Responce Response = new Responce();
            try
            {
                if (req != null)
                {
                    string result = obj.SaveDispatchBySO(req);
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
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Dispatch.saveDispatchbyso, long.Parse(req.UserId));
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.Dispatch.EditDispatchbyso)]
        public Responce EditDispatchbyso(EditDispatchBySORequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.EditDispatchbyso(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Dispatch.saveDispatchbyso, Convert.ToInt64(ReqPara.userId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Dispatch.CarrierList)]
        public async Task<ResponceList> CarrierList(CarrierListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.CarrierDetail(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Dispatch.CarrierList, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Dispatch.TrackingDetail)]
        public async Task<ResponceList> TrackingDetail(TrackingDetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.TrackingDetail(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Dispatch.TrackingDetail, 0);
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.Dispatch.SaveTrackingDetail)]
        public Responce SaveTrackingDetail(SaveTrackingDetailRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.SaveTrackingDetail(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Dispatch.SaveTrackingDetail, Convert.ToInt64(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Dispatch.TestMail)]
        public Responce TestMail(TestMailRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.SendDispatchMail(Convert.ToInt64(ReqPara.soid));
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Dispatch.TestMail, 0);
            }
            return Response;
        }

        //[HttpPost]
        //[Route(APIRoute.Dispatch.TestNotify)]
        //public Responce TestNotify(TestMailRequest ReqPara)
        //{
        //    Responce Response = new Responce();
        //    try
        //    {
        //        if (ReqPara != null)
        //        {
        //            string result = obj.DispatchNotification(Convert.ToInt64(ReqPara.soid), Convert.ToInt64(ReqPara.UserId));
        //            if (result == "success")
        //            {
        //                Response = ResponceResult.SuccessResponse(result);
        //            }
        //            else
        //            {
        //                Response = ResponceResult.ValidateResponse(result);
        //            }
        //        }
        //        else
        //        {
        //            Response = ResponceResult.ErrorResponse("Record Not Save..!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response = ResponceResult.ErrorResponse(ex.Message.ToString());
        //        exe.ErrorLog(ex.Message.ToString(), APIRoute.Dispatch.TestNotify, 0);
        //    }
        //    return Response;
        //}





        [HttpPost]
        [Route(APIRoute.Dispatch.SaveReturn)]
        public Responce SaveReturnOrder(SaveReturnBySORequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.SaveReturn(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Dispatch.SaveReturn, ReqPara.UserId);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Dispatch.UpdateQty)]
        public Responce UpdateQty(UpdateQtyRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.UpdateQty(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Dispatch.UpdateQty, ReqPara.UserId);
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.Dispatch.getDispatchDriverList)]
        public async Task<ResponceList> BatchDispatchList(reqDispatchDriverList reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.getDriverList(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Dispatch.getDispatchDriverList, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Dispatch.saveDispatchDriver)]
        public Responce saveDriver(saveDispatchDriverDetails ReqPara)
        {

            string getPoOrderID = ReqPara.OrderId;
            string result = "";

            string[] getOrderId = getPoOrderID.Split(',');

            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    for (int i = 0; i < getOrderId.Length; i++)
                    {
                        ReqPara.OrderId = Convert.ToString(getOrderId[i]);
                        result = obj.saveDriver(ReqPara);
                    }

                    Response = ResponceResult.SuccessResponse(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Found");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Dispatch.saveDispatchDriver, Convert.ToInt32(ReqPara.UserId));
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.Dispatch.GetdriverTransportdetail)]
        public async Task<ResponceList> GetdriverTransportdetail(driverTransportdetailRequest req)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (req != null)
                {
                    JsonElement result = await obj.driverTransportdetail(req);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Dispatch.GetdriverTransportdetail, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Dispatch.CheckDriverAssignInvoice)]
        public Responce CheckDriverAssignInvoice(ReqDriverInvoice ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.CheckDriverAssignInvoice(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record Not Removed..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Dispatch.CheckDriverAssignInvoice, Int64.Parse(ReqPara.CustomerId));
            }
            return Response;
        }

    }
}
