using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
//using System.Web.Http;
using WMSWebAPI.Models.V1.Request;
using WMSWebAPI.Models.V1.Responce;
using WMSWebAPI.Route;
using WMSWebAPI.Utility.V1;

namespace WMSWebAPI.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        TransferUtility obj = new TransferUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.Transfer.GetTransferList)]
        public async Task<ResponceList> GetTransferList(GetTransferListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.TransferList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transfer.GetTransferList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transfer.GetLocation)]
        public async Task<ResponceList> GetLocation(LocationDetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetLocation(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transfer.GetLocation, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //To Location List
        [HttpPost]
        [Route(APIRoute.Transfer.GetToLocation)]
        public async Task<ResponceList> GetToLocation(ToLocationReq ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetToLocList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transfer.GetToLocation, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transfer.GetPallet)]
        public async Task<ResponceList> GetPallet(PalletDetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetPallet(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transfer.GetPallet, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transfer.GetSkuList)]
        public async Task<ResponceList> GetSkuList(SkuDetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetSkuList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transfer.GetSkuList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transfer.GetLottableList)]
        public async Task<ResponceList> GetLotabledetail(LotableListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetLotabledetail(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transfer.GetLottableList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transfer.getTRIDTO)]
        public async Task<ResponceList> getTRIDTO(ReqTRIDTO ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getTRIDTO(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transfer.GetLottableList, ReqPara.FrTrID);
            }
            return Response;
        }

        //Save Head
        [HttpPost]
        [Route(APIRoute.Transfer.SaveHeadInternalTrans)]
        public async Task<Responce> SaveHead(SaveTransferHeadRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string[] res = obj.SaveHeadInternalTran(ReqPara).Split('|');
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transfer.SaveHeadInternalTrans, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //--Save Detail--
        [HttpPost]
        [Route(APIRoute.Transfer.saveDetailList)]
        public async Task<Responce> saveTransferData(saveTransferDetails ReqPara)
        {
            Responce responce = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.saveTransferDetail(ReqPara);

                    if (result == "success")
                    {
                        responce = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        responce = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    responce = ResponceResult.ErrorResponse("Fail To Save..!!");
                }
            }
            catch (Exception ex)
            {
                responce = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transfer.saveDetailList, Int64.Parse(ReqPara.UserId));
            }
            return responce;
        }

        //Get Transfer Head List
        [HttpPost]
        [Route(APIRoute.Transfer.getHeadList)]
        public async Task<ResponceList> getSaveTransferHead(reqTransferSaveHead ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetSaveHeadTransfer(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transfer.getHeadList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //Get Transfer Details
        [HttpPost]
        [Route(APIRoute.Transfer.getTransferDetails)]
        public async Task<ResponceList> getTransferDetails(TransferDetailsRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetTransferDetails(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transfer.getTransferDetails, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transfer.getTransferSkuList)]
        public async Task<ResponceList> getTransferSkuList(reqTransferSkulist reqPara)
        {
            ResponceList Response = new ResponceList();
            JsonElement result;
            try
            {
                if (reqPara != null)
                {
                    result = await obj.skuTransferList(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transfer.getTransferSkuList, Int64.Parse(reqPara.TransferId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transfer.viewTransferList)]
        public async Task<ResponceList> viewTransferList(reqViewTransfer reqPara)
        {
            ResponceList Responce = new ResponceList();
            JsonElement result;
            try
            {
                if (reqPara != null)
                {
                    result = await obj.getViewTransferList(reqPara);
                    Responce = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Responce = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Responce = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(),
                APIRoute.Transfer.viewTransferList, Int32.Parse(reqPara.UserId));
            }
            return Responce;
        }

        [HttpPost]
        [Route(APIRoute.Transfer.checkTransfBusinessRule)]
        public async Task<ResponceList> checkTransfBusinessRule(reqIntTranfBusinessRule reqPara)
        {
            ResponceList Responce = new ResponceList();
            JsonElement result;
            try
            {
                if (reqPara != null)
                {
                    result = await obj.CheckBusinessRuleTranf(reqPara);
                    Responce = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Responce = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Responce = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(),
                APIRoute.Transfer.checkTransfBusinessRule, Int32.Parse(reqPara.UserId));
            }
            return Responce;
        }


        [HttpPost]
        [Route(APIRoute.Transfer.ddlTransferLocationList)]
        public async Task<ResponceList> ddlTransferLocList(reqDDLLocationList ReqPara)
        {
            ResponceList Response = new ResponceList();
            JsonElement result;
            try
            {
                if (ReqPara != null)
                {
                    result = await obj.getLocationTypeList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);

                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record Not Found..!!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transfer.ddlTransferLocationList, 0);
                return Response;
            }
            return Response;
        }

    }
}
