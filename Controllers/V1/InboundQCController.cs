using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;
using WMSWebAPI.Models.V1.Responce;
using WMSWebAPI.Route;
using WMSWebAPI.Utility.V1;

namespace WMSWebAPI.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class InboundQCController : ControllerBase
    {

        InboundQCUtility obj = new InboundQCUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.InboundQC.QCList)]
        public async Task<ResponceList> GetQclist(QCDetailRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.QClist(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.InboundQC.QCList, 0);
            }
            return Response;
        }


  
        

        [HttpPost]
        [Route(APIRoute.InboundQC.GetQCHead)]
        public async Task<ResponceList> GetQCHead(QCHeadRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.QCHead(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.InboundQC.GetQCHead, 0);
            }
            return Response;
        }


 

        [HttpPost]
        [Route(APIRoute.InboundQC.getQCID)]
        public async Task<ResponceList> getQCID(grnidreq reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.getQCID(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.InboundQC.getQCID, 0);
            }
            return Response;
        }


  
        [HttpPost]
        [Route(APIRoute.InboundQC.GetQCDetail)]
        public async Task<ResponceList> GetQCDetail(QCRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.QCDetails(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.InboundQC.GetQCDetail, 0);
            }
            return Response;
        }



        [HttpPost]
        [Route(APIRoute.InboundQC.GetReasoncode)]
        public async Task<ResponceList> GetReasoncode(QCReasonRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.getReasonCode(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.InboundQC.GetReasoncode, 0);
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.InboundQC.SaveQCDetail)]
        public Responce SaveGRNDetail(SaveQCDetailRequest req)
        {

            Responce Response = new Responce();
            try
            {
                if (req != null)
                {
                    string result = obj.SaveQCDetail(req);
                    if (result != "0")
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.InboundQC.SaveQCDetail, 0);
            }
            return Response;
        }

        //[HttpPost]

        //[Route(APIRoute.InboundQC.UpdateQCStatus)]
        //public Responce UpdateQC(UpdatQCStatus ReqPara)
        //{

        //    Responce Response = new Responce();
        //    try
        //    {
        //        if (ReqPara != null)
        //        {
        //            string result = obj.UpdateQCStatus(ReqPara);
        //            if (result == "success")
        //            {
        //                Response = ResponceResult.SuccessResponse(result);
        //                string rek = obj.ReciveNotification(ReqPara);
        //            }
        //            else
        //            {
        //                Response = ResponceResult.ValidateResponse(result);
        //            }
        //        }
        //        else
        //        {
        //            Response = ResponceResult.ErrorResponse("Record Not Save..!");
        //            return Response;
        //        }
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Response = ResponceResult.ErrorResponse(ex.Message.ToString());
        //        exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.UpdateGrnStatus, 0);
        //    }
        //    return Response;
        //}

        [HttpPost]
        [Route(APIRoute.InboundQC.RemoveQCSKU)]
        public Responce RemoveQCSKU(RemoveQCSKURequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.RemoveQCSKUDetail(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.GRN.RemoveSKU, 0);
            }
            return Response;
        }
    }
}
