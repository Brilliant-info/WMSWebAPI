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
    public class EmailSMSController : ControllerBase
    {

        SysException exe = new SysException();
        EmailSmsUtility obj = new EmailSmsUtility();


        [HttpPost]
        [Route(APIRoute.EmailSmSNotification.EmailSmSList)]
        public async Task<ResponceList> EmailSmSList(getEmailSmsList reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.getEmailSmSList(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.EmailSmSNotification.EmailSmSList, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.EmailSmSNotification.EmailSmsActive)]
        public async Task<ResponceList> EmailSmsActive(getEmailSmSActive reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.getEmailSmSActive(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.EmailSmSNotification.EmailSmsActive, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.EmailSmSNotification.EmailSMSTemplate)]
        public async Task<ResponceList> EmailSmsActive(getEmailSMSTemplate reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.getEmailSMSTemplate(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.EmailSmSNotification.EmailSMSTemplate, 0);
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.EmailSmSNotification.SaveEmailSMS)]
        public Responce SaveEmailSMS(GetSaveEmailSMS ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.GetSaveEmailSMS(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.EmailSmSNotification.SaveEmailSMS, Int64.Parse(ReqPara.EmailTemplateID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.EmailSmSNotification.GetroleSaveEmailSMS)]
        public Responce GetroleSaveEmailSMS(GetroleSaveEmailSMS ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.GetroleSaveEmailSMS(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.EmailSmSNotification.SaveEmailSMS, Int64.Parse(ReqPara.EmailTemplateID));
            }
            return Response;
        }
        //RemoveRoleEmailSMS
        [HttpPost]
        [Route(APIRoute.EmailSmSNotification.RemoveRoleEmailSMS)]
        public Responce RemoveRoleEmailSMS(GetRoleRemoveEmailSMS ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.RemoveRoleEmailSMS(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.EmailSmSNotification.RemoveEmailSMS, Int64.Parse(ReqPara.EmailTemplateID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.EmailSmSNotification.RemoveEmailSMS)]
        public Responce RemoveEmailSMS(GetRemoveEmailSMS ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.GetRemoveEmailSMS(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.EmailSmSNotification.RemoveEmailSMS, Int64.Parse(ReqPara.EmailTemplateID));
            }
            return Response;
        }
    }
}
