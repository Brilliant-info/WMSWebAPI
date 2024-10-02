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
    public class MenuPageController : ControllerBase
    {


        MenupageUtility Obj = new MenupageUtility();
        SysException exe = new SysException();


        

        [HttpPost]
        [Route(APIRoute.Menupage.GetMenu)]
        public async Task<ResponceList> Menu(MenupageRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await Obj.GetMenu(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Menupage.GetMenu, Int64.Parse(reqPara.UserID));
            }
            return Response;
        }
    }
}
