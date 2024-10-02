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
    public class BusinessRuleController : ControllerBase
    {
        BusinessRuleUtility obj = new BusinessRuleUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.BusinessRule.GetBusinessRuleList)]
        public async Task<ResponceList> BusinessRuleList(GetBusinessRule ReqPara)
        {

            ResponceList Response = new ResponceList();
            try
            {

                if (ReqPara != null)
                {
                    JsonElement result = await obj.BusinessRuleList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.BusinessRule.GetBusinessRuleList, Int64.Parse(ReqPara.CreatedBy));
            }
            return Response;
        }

        [HttpPost]

        [Route(APIRoute.BusinessRule.SaveBusinessRule)]
        public async Task<Responce> SaveBusinessRule(AddBusinessRuleRequest ReqPara)
        {

            string result = "";
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    result = obj.setBusinessRule(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.BusinessRule.SaveBusinessRule, Int64.Parse(ReqPara.BusinessCode));
            }
            return Response;
        }

    }
}
