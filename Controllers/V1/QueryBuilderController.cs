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
    public class QueryBuilderController : ControllerBase
    {
        QueryBuilderUtility obj = new QueryBuilderUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.QueryBuilder.QueryBuilderList)]
        public async Task<ResponceList> QueryBuilderList(QueryBuilderListRequest ReqPara)

        {
            ResponceList Response = new ResponceList();
            try

            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.QueryBuilderList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.QueryBuilder.QueryBuilderList, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.QueryBuilder.QueryBuilderExec)]
        public async Task<ResponceList> QueryBuilderExec(QueryBuilderExecRequest ReqPara)

        {
            ResponceList Response = new ResponceList();
            try

            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.QueryBuilderExec(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.QueryBuilder.QueryBuilderExec, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.QueryBuilder.QueryBuilderObject)]
        public async Task<ResponceList> QueryBuilderObject(QueryBuilderObjectRequest ReqPara)

        {
            ResponceList Response = new ResponceList();
            try

            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.QueryBuilderObject(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.QueryBuilder.QueryBuilderObject, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.QueryBuilder.QueryBuilderAddUpdateDetail)]
        public async Task<Responce> QueryBuilderAddUpdateDetail(QueryBuilderAddUpdateDetailRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.QueryBuilderAddUpdateDetail(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.QueryBuilder.QueryBuilderAddUpdateDetail, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.QueryBuilder.QueryBuilderAddUpdateNotifications)]
        public async Task<Responce> QueryBuilderAddUpdateNotifications(QueryBuilderAddUpdateNotificationsRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.QueryBuilderAddUpdateNotifications(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.QueryBuilder.QueryBuilderAddUpdateNotifications, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.QueryBuilder.QueryBuilderNotificationSave)]
        public async Task<Responce> QueryBuilderNotificationSave(QueryBuilderNotificationSaveRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.QueryBuilderNotificationSave(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.QueryBuilder.QueryBuilderNotificationSave, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.QueryBuilder.QueryBuilderRemoveNotification)]
        public async Task<Responce> QueryBuilderRemoveNotification(QueryBuilderNotificationRemoveRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.QueryBuilderNotificationRemove(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.QueryBuilder.QueryBuilderRemoveNotification, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.QueryBuilder.QueryExecButton)]
        public async Task<ResponceList> QueryExecButton(QueryExecButtonRequest ReqPara)

        {
            ResponceList Response = new ResponceList();
            try

            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.QueryExecButton(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.QueryBuilder.QueryExecButton, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.QueryBuilder.QueryBuilderObjectCol)]
        public async Task<ResponceList> QueryBuilderObjectCol(QueryBuilderObjectColRequest ReqPara)

        {
            ResponceList Response = new ResponceList();
            try

            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.QueryBuilderObjectCol(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.QueryBuilder.QueryBuilderObjectCol, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.QueryBuilder.QueryBuilderQuerySave)]
        public async Task<ResponceList> QueryBuilderQuerySave(SaveQueryRequest ReqPara)

        {
            ResponceList Response = new ResponceList();
            try

            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.SaveQuery(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.QueryBuilder.QueryBuilderQuerySave, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.QueryBuilder.QueryBuilderQueryFlag)]
        public async Task<ResponceList> QueryBuilderQueryFlag(FlagQueryRequest ReqPara)

        {
            ResponceList Response = new ResponceList();
            try

            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.QueryFlag(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.QueryBuilder.QueryBuilderQueryFlag, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }
    }
}
