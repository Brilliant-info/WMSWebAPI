using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using static WMSWebAPI.Models.V1.Request.Conversion;
using WMSWebAPI.Models.V1.Responce;
using WMSWebAPI.Route;
using WMSWebAPI.Utility.V1;
using System.Text.Json;

namespace WMSWebAPI.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversionController : ControllerBase
    {
        ConversionUtility obj = new ConversionUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.ConversionSKU.GetConversionSKUList)]
        public async Task<ResponceList> GetConversionSKUList(GetConversionSKUListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result =await obj.GetConversionSKUList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ConversionSKU.GetConversionSKUList, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ConversionSKU.GetConvSKUSuggestion)]
        public async Task<ResponceList> GetConvSKUSuggestion(GetConvSKUSuggestionRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetConvSKUSuggestion(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ConversionSKU.GetConvSKUSuggestion, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }



        [HttpPost]
        [Route(APIRoute.ConversionSKU.GetSkuConversionSave)]
        public async Task<Responce> GetSkuConversionSave(GetSkuConversionSaveRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                //if (ReqPara != null)
                //{

                //    string[] res = obj.GetSkuConversionSave(ReqPara).Split('|');
                //    string result = res[0].ToString();
                //    if (result == "success")
                //    {
                //        Response = ResponceResult.SuccessResponseOrder(result, res[1].ToString());
                //    }

                //}
                //else
                //{
                //    Response = ResponceResult.ErrorResponseList("No record found..!");
                //}
                if (ReqPara != null)
                {
                    string[] res = obj.GetSkuConversionSave(ReqPara).Split('|');
                    string result = res[0].ToString();
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponseOrder(result, res[1].ToString());

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
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ConversionSKU.GetSkuConversionSave, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.ConversionSKU.SaveDTConverstion)]
        public async Task<ResponceList> SaveDTConverstion(SkuConversionSaveRequestDT ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.SaveDTConverstion(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ConversionSKU.GetSkuConversionSave, ReqPara.UserId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.ConversionSKU.GetconvDetail)]
        public async Task<ResponceList> GetconvDetail(ConvDetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetconvDetail(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ConversionSKU.GetconvDetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ConversionSKU.GetconvHead)]
        public async Task<ResponceList> GetconvHead(ConvHeadRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetconvHead(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.SO.GetSODetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
    }
}
