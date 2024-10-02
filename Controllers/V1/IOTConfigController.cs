using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using WMSWebAPI.Models.V1.Request;
using WMSWebAPI.Models.V1.Responce;
using WMSWebAPI.Route;
using WMSWebAPI.Utility.V1;
using System.Text.Json;

namespace WMSWebAPI.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class IOTConfigController : ControllerBase
    {

        IOTConfigUtility obj = new IOTConfigUtility();
        SysException exe = new SysException();
        // GET: IOTConfig
  

        [HttpPost]
        [Route(APIRoute.IOTConfig.IOTConfigList)]
        public async Task<ResponceList> GetIOTConfigList(GetIOTConfigRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.IOTConfigList(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.IOTConfig.IOTConfigList, Int64.Parse(reqPara.UserID));
            }
            return Response;
        }



        [HttpPost]
        [Route(APIRoute.IOTConfig.SaveIOTConfig)]
        public async Task<ResponceList> SaveIOTConfig(GetSaveIOTConfigRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.SaveIOTConfig(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.IOTConfig.SaveIOTConfig, Int64.Parse(reqPara.UserID));
            }
            return Response;
        }

       


        [HttpPost]
        [Route(APIRoute.IOTConfig.LocationTypeIOTConfig)]
        public async Task<ResponceList> LocationTypeIOTConfig(GetLocationTypeIOTConfigRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.LocationTypeIOTConfig(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.IOTConfig.LocationTypeIOTConfig, Int64.Parse(reqPara.UserID));
            }
            return Response;
        }

    


        [HttpPost]
        [Route(APIRoute.IOTConfig.deviceTypeIOTConfig)]
        public async Task<ResponceList> deviceTypeIOTConfig(GetdeviceTypeIOTConfigRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.deviceTypeIOTConfig(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.IOTConfig.deviceTypeIOTConfig, Int64.Parse(reqPara.UserID));
            }
            return Response;
        }

  


        [HttpPost]
        [Route(APIRoute.IOTConfig.IOTConfigTemp)]
        public async Task<ResponceList> IOTConfigTemp(GetIOTConfigTempRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.IOTConfigTemp(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.IOTConfig.IOTConfigTemp, Int64.Parse(reqPara.UserId));
            }
            return Response;
        }



        [HttpPost]
        [Route(APIRoute.IOTConfig.IOTConfigReport)]
        public async Task<ResponceList> IOTConfigReport(GetIOTConfigReportRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.IOTConfigReport(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.IOTConfig.IOTConfigReport, Int64.Parse(reqPara.UserId));
            }
            return Response;
        }

   

        [HttpPost]
        [Route(APIRoute.IOTConfig.IOTLocbind)]
        public async Task<ResponceList> IOTLocbind(GetIOTLocbindRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.IOTLocbind(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.IOTConfig.IOTLocbind, Int64.Parse(reqPara.UserId));
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.IOTConfig.IOTdeviceIDbind)]
        public async Task<ResponceList> IOTdeviceIDbind(GetIOTdeviceIDbindRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.IOTdeviceIDbind(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.IOTConfig.IOTdeviceIDbind, Int64.Parse(reqPara.UserId));
            }
            return Response;
        }
    }
}
