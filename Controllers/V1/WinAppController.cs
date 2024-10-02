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
    public class WinAppController : ControllerBase
    {
        WinAppUtility obj = new WinAppUtility();
        SysException exe = new SysException();


        [HttpPost]
        [Route(APIRoute._Winapp.InboundOrderNo)]
        public async Task<ResponceList> InboundOrderNo(GetWinInboundRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.InboundOrderNo(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute._Winapp.InboundOrderNo, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute._Winapp.InboundDetails)]
        public async Task<ResponceList> InboundOrderNoDetails(GetWinInboundReqDetails ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.InboundOrderNoDetails(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute._Winapp.InboundDetails, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute._Winapp.ProdOrderNo)]
        public async Task<ResponceList> ProdOrderNo(GetWinInboundRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.ProdOrderNo(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute._Winapp.ProdOrderNo, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute._Winapp.ProdDetails)]
        public async Task<ResponceList> ProdDetails(GetWinInboundReqDetails ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.ProdDetails(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute._Winapp.ProdDetails, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute._Winapp.GetLabelfileName)]
        public async Task<ResponceList> GetLabelfileName(GetLabelfileName ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetLabelfileName(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute._Winapp.GetLabelfileName, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute._Winapp.GetInboundPrintBarcode)]
        public async Task<ResponceList> GetInboundPrintBarcode(GetInboundPrintBarcode ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetInboundPrintBarcode(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute._Winapp.GetInboundPrintBarcode, Int64.Parse(ReqPara.PKID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute._Winapp.SaveGatePassLotWinapp)]
        public async Task<ResponceList> SaveGatePassLottable(WinSaveGatePassLottableRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.SaveGatePassLottable(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute._Winapp.SaveGatePassLotWinapp, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute._Winapp.SaveBarcodeHistory)]
        public async Task<ResponceList> SaveBarcodeHistory(WinSaveBarcodeHistoryRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.SaveBarcodeHistory(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute._Winapp.SaveBarcodeHistory, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute._Winapp.GetBarcodeWthlottable)]
        public async Task<ResponceList> GetBarcodeWthlottable(GetBarcodeWthlottable ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetBarcodeWthlottable(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute._Winapp.GetBarcodeWthlottable, Int64.Parse(ReqPara.UID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute._Winapp.GetBOMDDL)]
        public async Task<ResponceList> GetBOMDDL(GetBOMDDL ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetBOMDDL(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute._Winapp.GetBOMDDL, Int64.Parse(ReqPara.UID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute._Winapp.GetBOMDetails)]
        public async Task<ResponceList> GetBOMDetails(GetBOMDetails ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetBOMDetails(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute._Winapp.GetBOMDetails, Int64.Parse(ReqPara.UID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute._Winapp.GetFGDDL)]
        public async Task<ResponceList> GetFGDDL(GetFGDDL ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetFGDDL(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute._Winapp.GetFGDDL, Int64.Parse(ReqPara.UID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute._Winapp.GetFGDetails)]
        public async Task<ResponceList> GetFGDetails(GetFGDetails ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetFGDetails(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute._Winapp.GetFGDetails, Int64.Parse(ReqPara.UID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute._Winapp.GetBOMLIST)]
        public async Task<ResponceList> GetBOMLIST(GetBOMLIST ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetBOMLIST(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute._Winapp.GetBOMLIST, Int64.Parse(ReqPara.UID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute._Winapp.GetBOMSkuList)]
        public async Task<ResponceList> GetBOMSkuList(GetBOMSkuList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetBOMSkuList(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute._Winapp.GetBOMSkuList, Int64.Parse(ReqPara.UID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute._Winapp.GetBOMDetailsEdit)]
        public async Task<ResponceList> GetBOMDetailsEdit(GetBOMDetailsEdit ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetBOMDetailsEdit(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute._Winapp.GetBOMDetailsEdit, Int64.Parse(ReqPara.UID));
            }
            return Response;
        }
    }
}
