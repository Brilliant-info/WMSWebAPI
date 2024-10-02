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
    public class POController : ControllerBase
    {
        POUtility obj = new POUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.PO.SavePOHead)]
        public async Task<Responce> SavePOHead(SaveOrderHeadRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string[] res =  obj.SavePOHead(ReqPara).Split('|');
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
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PO.SavePOHead, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.PO.SavePOSKUDetail)]
        public Responce SavePOSKUDetail(SavePOSKUDetailRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.SavePOSKUDetail(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PO.SavePOSKUDetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.PO.RemovePOSKU)]
        public Responce RemovePOSKU(RemovePOSKURequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.RemovePOSKU(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PO.RemovePOSKU, 100);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.PO.closePOPopUP)]
        public Responce closePOpopup(closePOpopup ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.closePOpopup(ReqPara);
                    if (result == "Found")
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PO.closePOPopUP, 100);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.PO.GetInboundList)]
        public async Task<ResponceList> GetInboundList(GetInboundListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetInboundList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PO.GetInboundList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.PO.GetPOSearchSKU)]
        public async Task<ResponceList> GetPOSearchSKU(POSearchSKUSRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.POSearchSKU(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PO.GetPOSearchSKU, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.PO.GetPODetail)]
        public async Task<ResponceList> GetPODetail(PODetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetPODetail(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PO.GetPODetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.PO.DispPODetail)]
        public async Task<ResponceList> DispPODetail(PODetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.DispPODetail(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PO.GetPODetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.PO.GetPOHead)]
        public async Task<ResponceList> GetPOHead(POHeadRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.POHead(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PO.GetPOHead, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.PO.getQualityvalues)]
        public async Task<ResponceList> getQualityvalues(qualitycheckreq ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getQualitycheck(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PO.GetPOHead, 0);
            }
            return Response;
        }

        [HttpPost]

        [Route(APIRoute.PO.UpdatePOStatus)]
        public async Task<Responce> UpdateGrn(UpdatePostatus ReqPara)
        {

            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.updatePO(ReqPara);
                    if (result != "fail")
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PO.UpdatePOStatus, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.PO.GetVendorList)]
        public async Task<ResponceList> GetVendorList(GetVendorRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetVendorList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PO.GetVendorList, ReqPara.UserId);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.PO.cancelPO)]
        public async Task<Responce> cancelPOOrder(reqOrderDetails ReqPara)
        {
            Responce res = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.cancelPOOrder(ReqPara);
                    if (result == "success")
                    {
                        res = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        res = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    res = ResponceResult.ErrorResponse("Record not found..!!");
                    return res;
                }

            }
            catch (System.Exception ex)
            {
                res = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PO.cancelPO, 0);
            }
            return res;
        }
        [HttpPost]
        [Route(APIRoute.PO.completeReceving)]
        public async Task<Responce> completeReceving(reqOrderDetails ReqPara)
        {
            Responce res = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.markCompletedRece(ReqPara);
                    if (result != "Fail")
                    {
                        res = ResponceResult.SuccessResponse(result);

                    }
                    else
                    {
                        res = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    res = ResponceResult.ErrorResponse("Record not found..!!");
                    return res;
                }
            }
            catch (System.Exception ex)
            {
                res = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PO.cancelPO, 0);
            }
            return res;
        }
        [HttpPost]
        [Route(APIRoute.PO.GetTaskComplete)]
        public async Task<ResponceList> GetTaskComplete(ReqTaskComplete ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetINTaskComplete(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PO.GetTaskComplete, ReqPara.UserID);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.PO.GetTaskCompleteSKULst)]
        public async Task<ResponceList> GetTaskCompleteSKULst(ReqTaskCompleteSKULst ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetINTaskCompleteSKULst(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PO.GetTaskComplete, ReqPara.UserID);
            }
            return Response;
        }
    }
}
