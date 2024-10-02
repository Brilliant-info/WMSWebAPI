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
    public class BarcodeConfigController : ControllerBase
    {
        BarcodeConfigUtility obj = new BarcodeConfigUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.Barcode.BarcodeObjectList)]
        public async Task<ResponceList> BarcodeObjectList(BarcodeObjectListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.BarcodeObjectList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Barcode.BarcodeObjectList, Int64.Parse(ReqPara.CustomerID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Barcode.TemplateList)]
        public async Task<ResponceList> TemplateList(TemplateListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.TemplateList(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Barcode.TemplateList, Int64.Parse(ReqPara.ObjectID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Barcode.SaveBarcodeConfig)]
        public async Task<Responce> SaveBarcodeConfig(SaveBarcodeConfigRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.SaveBarcodeConfig(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Barcode.SaveBarcodeConfig, Int64.Parse(ReqPara.ID));
            }
            return Response;

        }
        [HttpPost]
        [Route(APIRoute.Barcode.ViewBarcodeConfig)]
        public async Task<ResponceList> ViewBarcodeConfig(ViewBarcodeConfigRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.ViewBarcodeConfig(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Barcode.ViewBarcodeConfig, Int64.Parse(ReqPara.ObjectID));
            }
            return Response;
        }
    }
}
