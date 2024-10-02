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
    public class TaskAssingmetController : ControllerBase
    {
        TaskAssingmentUtility obj = new TaskAssingmentUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.TaskAssignment.CreteNewTask)]
        public async Task<Responce> CreateAssingTask(TaskAssingment ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.CreateAssingment(ReqPara);
                    if (result == "Success")
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.TaskAssignment.CreteNewTask, 0);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.TaskAssignment.TaskList)]
        public async Task<ResponceList> getassingUserList(getTaskListByObj ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getTaskList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.TaskAssignment.TaskList, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.TaskAssignment.GetAssingmentList)]
        public async Task<ResponceList> getAssingmentlist(GetAssingmentList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getAssingmentTaskList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.TaskAssignment.GetAssingmentList, 0);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.TaskAssignment.getAssingmentUserlist)]
        public async Task<ResponceList> getassingUserList(Getuserlist ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.AssinguserList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.TaskAssignment.getAssingmentUserlist, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.TaskAssignment.getAssingGrouplist)]
        public async Task<ResponceList> getassinggrouplist(AssingmentGroupList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getAssingmentGroupList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.TaskAssignment.getAssingGrouplist, 0);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.TaskAssignment.getuserSuggestlist)]
        public async Task<ResponceList> GetUsersugetion(gerUserSuggetionList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getUsersuggetion(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.TaskAssignment.getuserSuggestlist, 0);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.TaskAssignment.getOrdervalidation)]
        public async Task<ResponceList> getOrderValidation(validAssingorder ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getOrderValidation(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.TaskAssignment.getOrdervalidation, 0);
            }
            return Response;
        }
        //Reassign The Task
        [HttpPost]
        [Route(APIRoute.TaskAssignment.ReassignTask)]
        public async Task<Responce> ReassignTask(reassignTask ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.ReassignTaskToUser(ReqPara);
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
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.TaskAssignment.ReassignTask, Convert.ToInt64(ReqPara.UserID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.TaskAssignment.RemoveAssignmentTask)]
        public async Task<Responce> CreateAssingTask(RemoveTaskAssingment ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.RemoveAssingment(ReqPara);
                    if (result == "Success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else if (result == "UnAssing")
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.TaskAssignment.RemoveAssignmentTask, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.TaskAssignment.checkTaskAssignment)]
        public async Task<Responce> checkTaskAssignment(checkTaskAssignment ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.checkTaskAssignment(ReqPara);
                    if (result == "YES")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else if (result == "NO")
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
                    Response = ResponceResult.ErrorResponse("Error..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.TaskAssignment.checkTaskAssignment, 0);
            }
            return Response;
        }



        [HttpPost]
        [Route(APIRoute.TaskAssignment.GetTaskAssignmentPOHead)]
        public async Task<ResponceList> GetPOHead(TaskAssignmentPOHeadRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetTaskAssignmentPOHead(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.TaskAssignment.GetTaskAssignmentPOHead, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
    }
}
