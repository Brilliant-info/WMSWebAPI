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
using WMSWebAPI.Utility.V1;

namespace WMSWebAPI.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class PutInController : ControllerBase
    {
        PutInUtility obj = new PutInUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.PutIn.Putinlist)]
        public async Task<ResponceList> GetPutinList(GetPutInSKUListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetPutInlist(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PutIn.Putinlist, Int64.Parse(ReqPara.userID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.PutIn.GetPutinHead)]
        public async Task<ResponceList> GetPutinHead(PutinHeadRequest req)
        {
            ResponceList Response = new ResponceList();

            try
            {

                if (req != null)
                {
                    JsonElement result = await obj.PutInHead(req);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PutIn.GetPutinHead, Int64.Parse(req.UserId));
            }
            return Response;

        }


        [HttpPost]
        [Route(APIRoute.PutIn.getPutinskulist)]
        public async Task<ResponceList> GetPutinskuList(GetPutRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetPutInSKUDetail(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PutIn.getPutinskulist, Int64.Parse(ReqPara.userID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.PutIn.SavePutinDetails)]
        public Responce SavePutinDetails(SavePutInSKUListRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.SavePutinetails(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PutIn.SavePutinDetails, Int64.Parse(ReqPara.uid));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.PutIn.UpdatePutin)]
        public Responce UpdateGrn(updatePutin ReqPara)
        {

            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.Updateputin(ReqPara);
                    if (result != "fail")
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
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PutIn.UpdatePutin, 0);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.PutIn.getlocationlist)]
        public async Task<ResponceList> getlocationlist(getLocation ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetLocationlist(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PutIn.getPutinskulist, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.PutIn.updatelocatoin)]
        public Responce updatelocation(updateLocation ReqPara)
        {

            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.updateLoction(ReqPara);
                    if (result != "fail")
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
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PutIn.updatelocatoin, 0);
            }
            return Response;
        }
    }
}
