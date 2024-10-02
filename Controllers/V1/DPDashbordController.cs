using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;
using WMSWebAPI.Models.V1.Responce;
using WMSWebAPI.Route;
using WMSWebAPI.Utility.V1;

namespace WMSWebAPI.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class DPDashbordController : ControllerBase
    {

        SysException exe = new SysException();
        DPDashbordUtility obj = new DPDashbordUtility();

        [HttpPost]
        [Route(APIRoute.DPDashboard.CounterDPDashboardList)]
        public async Task<ResponceList> CounterDPDashboard(CounterDPDashboardRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.CounterDPDashboard(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DPDashboard.CounterDPDashboardList, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.DPDashboard.DispatchCountLast4MonthDP)]
        public async Task<ResponceList> DispatchCountLast4MonthDP(DispatchCountLast4MonthDPRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.DispatchCountLast4MonthDP(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DPDashboard.DispatchCountLast4MonthDP, 0);
            }
            return Response;
        }
    }
}
