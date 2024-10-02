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
    public class ApprovalController : ControllerBase
    {
        SysException exe = new SysException();
        ApprovalUtility obj = new ApprovalUtility();

        #region Start Main Approval Master Code


        [HttpPost]
        [Route(APIRoute.ApprovalMaster.GetApplication)]
        public async Task<ResponceList> GetApplication(GetApplicationReq ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetApplicationUtil(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ApprovalMaster.GetApplication, ReqPara.UserID);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ApprovalMaster.GetApproObject)]
        public async Task<ResponceList> GetApproObject(GetObjectReq ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetObjectUtil(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ApprovalMaster.GetApproObject, ReqPara.UserID);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ApprovalMaster.GetApproEvent)]
        public async Task<ResponceList> GetApproEvent(GetEventReq ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetEventUtil(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ApprovalMaster.GetApproEvent, ReqPara.UserID);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ApprovalMaster.GetApproverList)]
        public async Task<ResponceList> GetApproverList(GetApproverReq ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetApproverlistUtil(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ApprovalMaster.GetApproverList, ReqPara.UserID);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ApprovalMaster.SaveApprovalHead)]
        public async Task<Responce> SaveApprovalHead(AddMApprovalHeadReq ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string[] res = obj.AddApprovalHeadUtil(ReqPara).Split('|');
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
                    Response = ResponceResult.ErrorResponse("Record Not Saved..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ApprovalMaster.SaveApprovalHead, ReqPara.UserID);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ApprovalMaster.SaveApprovalDetail)]
        public async Task<Responce> SaveApprovalDetail(AddMApprovalDetailReq ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.AddMApprovalDetailUtil(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record Not Updated..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ApprovalMaster.SaveApprovalDetail, ReqPara.UserID);
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.ApprovalMaster.GetMApprovalhead)]
        public async Task<ResponceList> GetMApprovalhead(GetMApproheadReq ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetMApproheadUtil(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ApprovalMaster.GetMApprovalhead, ReqPara.UserID);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ApprovalMaster.GetMApprovalDetail)]
        public async Task<ResponceList> GetMApprovalDetail(GetMApprodetailReq ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetMApprodetailUtil(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ApprovalMaster.GetMApprovalDetail, ReqPara.UserID);
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.ApprovalMaster.RemoveApprovalUser)]
        public async Task<Responce> RemoveApprovalUser(RemoveApproUserReq ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.RemoveApproUserUtil(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record Not Updated..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ApprovalMaster.RemoveApprovalUser, ReqPara.ModifiedByID);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ApprovalMaster.SaveRemoveApprovalRec)]
        public async Task<Responce> SaveRemoveApprovalRec(SaveCancelApproReq ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.SaveCancelApproUtil(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record Not Updated..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ApprovalMaster.SaveRemoveApprovalRec, ReqPara.UserID);
            }
            return Response;
        }


        #endregion End Main Approval Master Code

        #region Start Main Approval Transaction Code
        [HttpPost]
        [Route(APIRoute.ApprovalMaster.SaveapprovalTrans)]
        public async Task<Responce> SaveapprovalTrans(SaveApprovalTransReq ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.SaveApprovalTransUtil(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record Not Updated..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ApprovalMaster.SaveapprovalTrans, ReqPara.UserID);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ApprovalMaster.GetApprovalTrans)]
        public async Task<ResponceList> GetApprovalTrans(GetApprovalTransReq ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetApprovalTransUtil(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ApprovalMaster.GetApprovalTrans, ReqPara.UserID);
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.ApprovalMaster.UpdateApprovalTrans)]
        public async Task<Responce> UpdateApprovalTrans(UpdateApprovalTransReq ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.UpdateApprovalTransUtil(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record Not Updated..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ApprovalMaster.UpdateApprovalTrans, ReqPara.UserID);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ApprovalMaster.InsertApprovalTrans)]
        public async Task<Responce> InsertApprovalTrans(InsertApprovalTransReq ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.InsertApprovalTransUtil(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record Not Inserted..!");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ApprovalMaster.InsertApprovalTrans, ReqPara.UserID);
            }
            return Response;
        }

        #endregion
    }
}

