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
    public class OutboundQCController : ControllerBase
    {


        OutboundQCUtility obj = new OutboundQCUtility();
        SysException exe = new SysException();

       
        [HttpPost]
        [Route(APIRoute.OutboundQC.GetQCList)]
        public async Task<ResponceList> GetQCList(GetQCListRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.QCList(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.OutboundQC.GetQCList, Int64.Parse(reqPara.UserId));
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.OutboundQC.GetBatchQCList)]
        public async Task<ResponceList> GetBatchQCList(GetBatchQCListRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.BatchQCList(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.OutboundQC.GetBatchQCList, Int64.Parse(reqPara.UserId));
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.OutboundQC.QCRemoveSKU)]
        public async Task<ResponceList> RemoveSKU(RemoveQCSKURequestOut reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.QCRemoveSKU(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.OutboundQC.QCRemoveSKU, Int64.Parse(reqPara.recordID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.OutboundQC.GetReasonCode)]
        public async Task<ResponceList> GetReasonCode(GetReasonCodeRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.ReasonCode(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.OutboundQC.GetReasonCode, Int64.Parse(reqPara.UserId));
            }
            return Response;
        }

 

        [HttpPost]
        [Route(APIRoute.OutboundQC.GetQCDetail)]
        public async Task<ResponceList> GetQCDetail(GetQCDetailRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.QCDetail(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.OutboundQC.GetQCDetail, Int64.Parse(reqPara.UserId));
            }
            return Response;
        }

        

        [HttpPost]
        [Route(APIRoute.OutboundQC.GetQCSuggestSKU)]
        public async Task<ResponceList> GetQCSuggestSKU(GetQCSKURequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.QCSuggestSKU(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.OutboundQC.GetQCSuggestSKU, Int64.Parse(reqPara.UserId));
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.OutboundQC.GetQCSKUDetail)]
        public async Task<ResponceList> GetQCSKUDetail(GetQCSKUDetailRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.QCSKUDetail(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.OutboundQC.GetQCSKUDetail, Int64.Parse(reqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.OutboundQC.SaveQCSKUDetail)]
        public Responce SaveQCSKUDetail(SaveQCSKUDetailRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string[] res = obj.SaveQCDetail(ReqPara).Split('|');
                    string result = res[0].ToString();
                    string Fresult = res[0].ToString() + '|' + res[1].ToString();
                    //string result = obj.SaveQCDetail(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(Fresult);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.OutboundQC.SaveQCSKUDetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.OutboundQC.FinalSaveQCDetail)]
        public Responce FinalSaveQCSKUDetail(FinalSaveQCSKUDetailRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string[] res = obj.FinalSaveQCDetail(ReqPara).Split('|');
                    string result = res[0].ToString();
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                        if (res[2].ToString() == "YES")
                        {
                            obj.AutoPacking(Int64.Parse(ReqPara.BatchID), Int64.Parse(res[1].ToString()), Int64.Parse(ReqPara.CustomerId), Int64.Parse(ReqPara.WarehouseId), Int64.Parse(ReqPara.UserId));
                        }

                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }

                    //string result = obj.FinalSaveQCDetail(ReqPara);
                    //if (result == "success")
                    //{
                    //    Response = ResponceResult.SuccessResponse(result);
                    //}

                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.OutboundQC.FinalSaveQCDetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
    }
}
