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
    public class CommFunAPIController : ControllerBase
    {
        CommFunAPIUtility obj = new CommFunAPIUtility();
        SysException exe = new SysException();
        // GET api/<controller>
        [HttpPost]
        [Route(APIRoute.CommFunAPI.PalletList)]
        public async Task<ResponceList> PalletList(ReqPalletList ReqPara)
        {
            ResponceList Response = new ResponceList();

            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.Get_PalletList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.CommFunAPI.PalletList, 0);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.CommFunAPI.getLottablevalues)]
        public async Task<ResponceList> getLottablevalues(lottablereq ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getLottablevalue(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PO.getLottablevalues, 0);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.CommFunAPI.GetSKUSuggest)]
        public async Task<ResponceList> GetSKUSuggest(SKUSuggestionRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.SKUSuggestionList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.CommFunAPI.GetSKUSuggest, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.CommFunAPI.GetSKUUOM)]
        public async Task<ResponceList> GetPOSKUUOM(SKUUOMRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.POSKUUOMList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.CommFunAPI.GetSKUUOM, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.CommFunAPI.GetScanSuggest)]
        public async Task<ResponceList> GetScanSuggest(ScanSuggestionRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.ScanSuggestionList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.CommFunAPI.GetScanSuggest, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.CommFunAPI.ScanInbound)]
        public async Task<ResponceList> ScanInbound(scanrequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.Scaninbound(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.CommFunAPI.GetScanSuggest, 0);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.CommFunAPI.AssingUserlist)]
        public async Task<ResponceList> getassingUserList(userlist ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.userListList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.CommFunAPI.GetScanSuggest, 0);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.CommFunAPI.saveAssingment)]
        public async Task<Responce> saveAssingment(assinguserRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.saveAssingment(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.SaveGRNSKUDetail, 0);
            }
            return Response;
        }
        #region Developed By Yashartha For Suggestion List
        [HttpPost]
        [Route(APIRoute.CommFunAPI.GetPOSKUSuggest)]
        public async Task<ResponceList> GetPOSKUSuggest(POOSKUSuggestionRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.POSKUSuggestionList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.CommFunAPI.GetPOSKUSuggest, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.CommFunAPI.GetSKUSuggestInQC)]
        public async Task<ResponceList> GetSKUSuggestInQC(SKUSuggestionRequestInQC ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.SKUSuggestionListInQC(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.CommFunAPI.GetSKUSuggest, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        #endregion
    }
}
