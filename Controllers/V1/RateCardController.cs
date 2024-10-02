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
    public class RateCardController : ControllerBase
    {
        RateCardUtility obj = new RateCardUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.RateCard.GetRateCardList)]
        public async Task<ResponceList> GetRateCardList(GetRateCardListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.RateCardList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.RateCard.GetRateCardList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.RateCard.GetUnitType)]
        public async Task<ResponceList> GetUnitType(GetUnitTypeRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.UnitTypeBillingMethod(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.RateCard.GetUnitType, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.RateCard.GetAccName)]
        public async Task<ResponceList> GetAccountName(GetAccNameRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.AccountName(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.RateCard.GetAccName, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.RateCard.GetActivityType)]
        public async Task<ResponceList> GetActivityType(GetActivtyTypeRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.ActivityTypeList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.RateCard.GetActivityType, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.RateCard.GetObjectZone)]
        public async Task<ResponceList> GetObjectZone(GetObjectZoneRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.ObjectZone(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.RateCard.GetObjectZone, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.RateCard.GetZone)]
        public async Task<ResponceList> GetZone(GetObjectZoneRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.Zone(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.RateCard.GetZone, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.RateCard.AddZone)]
        public async Task<Responce> AddZone(AddZoneRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.AddZone(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.RateCard.AddZone, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.RateCard.AddRateCard)]
        public async Task<Responce> AddRateCard(AddRateCardRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.AddRateCard(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.RateCard.AddRateCard, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.RateCard.GetRateDetailById)]
        public async Task<ResponceList> GetRateDetailById(GetRateDetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetRateDetailByID(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.RateCard.GetRateDetailById, Int64.Parse(ReqPara.ID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.RateCard.UpdateRateGroup)]
        public async Task<Responce> UpdateRateGroup(UpdateRateGroupRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.UpdateRateGroup(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.RateCard.UpdateRateGroup, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.RateCard.RemoveRateGroup)]
        public async Task<Responce> RemoveRateGroup(UpdateRateGroupRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.RemoveRateGroup(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.RateCard.RemoveRateGroup, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.RateCard.UpdateRateActive)]
        public async Task<Responce> UpdateRateActive(UpdateRateActiveRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.UpdateRateActive(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.RateCard.UpdateRateActive, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.RateCard.GetRateParameterList)]
        public async Task<ResponceList> GetRateParameterList(GetRateParameterListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.RateParameterList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.RateCard.GetRateParameterList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.RateCard.GetRateParameter)]
        public async Task<ResponceList> GetRateParameter(GetRateParameterRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.RateParameter(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.RateCard.GetRateParameter, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.RateCard.AddRateParameter)]
        public async Task<Responce> AddRateParameter(AddRateParameterRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.AddRateParameter(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.RateCard.AddRateParameter, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.RateCard.GetRateParameterById)]
        public async Task<ResponceList> GetRateParameterById(GetRateParameterbyIdRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.RateParameterById(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.RateCard.GetRateParameterById, Int64.Parse(ReqPara.ID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.RateCard.GetRateHistory)]
        public async Task<ResponceList> GetRateHistory(GetRateHistoryRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.RateHistory(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.RateCard.GetRateHistory, Int64.Parse(ReqPara.RateID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.RateCard.UpdateActivityActive)]
        public async Task<Responce> UpdateActivityActive(UpdateRateActiveRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.UpdateActivityActive(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.RateCard.UpdateActivityActive, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.RateCard.AddRateActivity)]
        public async Task<Responce> AddRateActivity(AddRateActivtyRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.AddRateActivity(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.RateCard.AddRateActivity, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
    }
}
