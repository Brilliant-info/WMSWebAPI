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
    public class PickUpController : ControllerBase
    {



        SysException exe = new SysException();
        PickUpUtility obj = new PickUpUtility();

     

        [HttpPost]
        [Route(APIRoute.PickUp.GetPickUpList)]
        public async Task<ResponceList> GetPickUpList(GetPickUpListRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.PickUpList(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PickUp.GetPickUpList, Int64.Parse(reqPara.UserId));
            }
            return Response;
        }



        [HttpPost]
        [Route(APIRoute.PickUp.GetPickUpDetail)]
        public async Task<ResponceList> GetPickUpDetail(GetPickUpDetailRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.PickUpDetail(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PickUp.GetPickUpDetail, Int64.Parse(reqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.PickUp.FinalSavePickUp)]
        public Responce FinalSavePickUp(FinalSavePickUpRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string[] res = obj.FinalSavePickUp(ReqPara).Split('|');
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
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PickUp.FinalSavePickUp, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.PickUp.CancelPickUp)]
        public Responce CancelPickUp(CancelPickUpRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.CancelPickUp(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PickUp.CancelPickUp, ReqPara.UserId);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.PickUp.MarkPacked)]
        public Responce MarkPacked(MarkPackRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.MarkPacked(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PickUp.CancelPickUp, ReqPara.UserId);
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.PickUp.UpdatePickUp)]
        public Responce UpdatePickUp(UpdatePickUpRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.UpdatePickUp(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PickUp.UpdatePickUp, ReqPara.UserId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.PickUp.EditPickUpQty)]
        public Responce EditPickupQty(UpdatePickUpRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.EditPickUpQty(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PickUp.EditPickUpQty, ReqPara.UserId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.PickUp.RevertPickUpQty)]
        public Responce RevertPickUpQty(RevertPickUpRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.RevertPickUpQty(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PickUp.EditPickUpQty, ReqPara.UserId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.PickUp.ChkOrderAssignToUser)]
        public Responce ChkOrderAssignToUser(ChkAssignToRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string chkassign = "";
                    string result = obj.chkAssignToUser(ReqPara);
                    string successresult = result.Substring(0, 7);
                    chkassign = result.Substring(8);

                    if (successresult == "success")
                    {
                        Response = ResponceResult.SuccessResponse(chkassign);
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Error Occured..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.PickUp.ChkOrderAssignToUser, ReqPara.userid);
            }
            return Response;
        }
    }
}
