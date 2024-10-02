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
    public class BillofLandingController : ControllerBase
    {
        BillOfLandingUtility obj = new BillOfLandingUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.BillofLanding.UpdateData)]
        public async Task<ResponceList> UpdateData(BillofLanding ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.UpdateData(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.BillofLanding.UpdateData, ReqPara.UserId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.BillofLanding.GetData)]
        public async Task<ResponceList> GetData(BillOfLandingGetData ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetData(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.BillofLanding.GetData, ReqPara.BillORDER_ID);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.BillofLanding.MasterBOL)]
        public async Task<ResponceList> MasterBOL(reqMasterBOL ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.MasterBOL(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.BillofLanding.MasterBOL, ReqPara.customerId);
            }
            return Response;
        }
    }
}
