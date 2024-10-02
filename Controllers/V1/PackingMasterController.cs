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
    public class PackingMasterController : ControllerBase
    {

        PackingMasterUtility obj = new PackingMasterUtility();
        SysException exe = new SysException();


        [HttpPost]
        [Route(APIRoute.PackingMaster.GetPackingMasterList)]
        public async Task<ResponceList> PackingMasterList(GetPackingMasterListRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.PackingMasterList(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PackingMaster.GetPackingMasterList, Int64.Parse(reqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.PackingMaster.SavePackingMaster)]
        public Responce PackingMasterDetail(SavePackingMasterDetailRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.PackingMasterDetail(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PackingMaster.SavePackingMaster, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
    }
}
