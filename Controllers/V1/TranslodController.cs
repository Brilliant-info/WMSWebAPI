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
    public class TranslodController : ControllerBase
    {
        TransloadUtility obj = new TransloadUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.Transload.GetAll)]
        public async Task<ResponceList> GetAll(ReqTransloadList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.TransloadListGetAll(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.GetAll, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.TransloadListID)]
        public async Task<ResponceList> TransloadListID(ReqTransloadListID ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {

                    JsonElement result = await obj.TransloadListID(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);

                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }

            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.TransloadListID, ReqPara.UserId);
                return Response;
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.TranloadSave)]
        public async Task<Responce> TranloadSave(ReqTranloadSave ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.TranloadSave(ReqPara);
                    if (result != "")
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
                    Response = ResponceResult.ErrorResponse("Record not save");

                }

            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.TranloadSave, ReqPara.UserId);
                return Response;
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.TranloadSaveDT)]
        public async Task<Responce> TranloadSaveDT(ReqTranloadSaveDT ReqPara)
        {
            Responce Response = new Responce();

            try
            {
                if (ReqPara != null)
                {
                    string result = obj.TranloadSaveDT(ReqPara);
                    if (result != "")
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
                    Response = ResponceResult.ErrorResponse("Record not save");

                }

            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.TranloadSaveDT, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.TranloadRemoveDT)]
        public async Task<Responce> TranloadRemoveDT(ReqRemoveTransloadDT ReqPara)
        {
            Responce Response = new Responce();

            try
            {
                if (ReqPara != null)
                {
                    string result = obj.TranloadRemoveDT(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record not save");

                }

            }
            catch (Exception ex)
            {

                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.TranloadRemoveDT, ReqPara.UserId);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.TransloadListReceving)]
        public async Task<ResponceList> TransloadListReceving(ReqTransloadListReceving ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.TransloadListReceving(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);

                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.TransloadListReceving, ReqPara.UserId);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.TranloadSaveReceiving)]
        public async Task<Responce> TranloadSave_Receiving(ReqSaveReceving ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.TranloadSave_Receiving(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record not save");

                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.TranloadSaveReceiving, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.ChangeOrdertype)]
        public async Task<Responce> ChangeOrdertype(ReqChangeOrderType ReqPara)
        {
            Responce Response = new Responce();

            try
            {
                if (ReqPara != null)
                {
                    string result = obj.ChangeOrdertype(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record not save");
                }

            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.ChangeOrdertype, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.TranloadSaveRecDT)]
        public async Task<Responce> TranloadSaveRecDT(ReqTTransload_RecDT ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.TranloadSave_RecDT(ReqPara);
                    if (result != "")
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
                    Response = ResponceResult.ErrorResponse("Record not save");
                }

            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.TranloadSaveRecDT, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.TranloadRemoveRecDT)]
        public async Task<Responce> TranloadRemoveRecDT(ReqRemoveTL_RecDT ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.TranloadRemove_RecDT(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record not save");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.TranloadRemoveRecDT, ReqPara.UserId);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.UpdateDockIdStatus)]
        public async Task<Responce> UpdateDockIdStatus(ReqUpdateDockIdStatus ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.UpdateDockIdStatus(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record not save");
                }

            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.TranloadRemoveRecDT, ReqPara.UserId);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.RemoveDockIdStatus)]
        public async Task<Responce> RemoveDockIdStatus(ReqRemoveDockIdStatus ReqPara)
        {
            Responce Response = new Responce();

            try
            {
                if (ReqPara != null)
                {
                    string result = obj.RemoveDockIdStatus(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record not save");
                }

            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.RemoveDockIdStatus, ReqPara.UserId);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.GetDispatchDetails)]
        public async Task<ResponceList> GetDispatchDetails(ReqGetDispatchDetails ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetDispatchDetails(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }

            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.GetDispatchDetails, ReqPara.UserId);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.SaveDispatchHead)]
        public async Task<Responce> SaveDispatchHead(ReqSaveDispatchHead ReqPara)
        {
            Responce Response = new Responce();

            try
            {
                if (ReqPara != null)
                {
                    string result = obj.SaveDispatchHead(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record not save");
                }

            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.SaveDispatchHead, ReqPara.UserId);
            }
            return Response;

        }

        [HttpPost]
        [Route(APIRoute.Transload.clientSugg)]
        public async Task<ResponceList> clientSugg(ReqClientList reqpara)
        {
            ResponceList Response = new ResponceList();

            try
            {
                if (reqpara != null)
                {
                    JsonElement result = await obj.clientList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.clientSugg, reqpara.userId);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.UOMList)]
        public async Task<ResponceList> UOMList(ReqUOMList reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqpara != null)
                {
                    JsonElement result = await obj.UOMList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.UOMList, reqpara.userId);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.UOMSugg)]
        public async Task<ResponceList> UOMSugg(ReqUOMSugg reqpara)
        {
            ResponceList Response = new ResponceList();

            try
            {
                if (reqpara != null)
                {
                    JsonElement result = await obj.UOMSugg(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.UOMSugg, reqpara.userId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.PallettypeList)]
        public async Task<ResponceList> PallettypeList(ReqPallettypeList reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqpara != null)
                {
                    JsonElement result = await obj.PallettypeList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.PallettypeList, reqpara.userId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.RateActivitylist)]
        public async Task<ResponceList> RateActivitylist(ReqRateActivitylist reqpara)
        {
            ResponceList Response = new ResponceList();

            try
            {
                if (reqpara != null)
                {
                    JsonElement result = await obj.RateActivitylist(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.RateActivitylist, reqpara.userId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.StagingList)]
        public async Task<ResponceList> StagingList(ReqStagingSugg reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqpara != null)
                {
                    JsonElement result = await obj.StagingSugg(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.StagingList, reqpara.userId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.StagingSugg)]
        public async Task<ResponceList> StagingSugg(ReqStagingSugg reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqpara != null)
                {
                    JsonElement result = await obj.StagingSugg(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.StagingSugg, reqpara.userId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.OrderTypeList)]
        public async Task<ResponceList> OrderTypeList(ReqOrderTypeList reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqpara != null)
                {
                    JsonElement result = await obj.OrderTypeList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.OrderTypeList, reqpara.userId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.clientList)]
        public async Task<ResponceList> clientList(ReqClientList reqpara)
        {
            ResponceList Response = new ResponceList();

            try
            {
                if (reqpara != null)
                {
                    JsonElement result = await obj.clientList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.clientList, reqpara.userId);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.AddList)]
        public async Task<ResponceList> AddList(ReqAddressList reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqpara != null)
                {
                    JsonElement result = await obj.Get_AddressList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.AddList, reqpara.userId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.AddSugg)]
        public async Task<ResponceList> AddSugg(ReqAddressList reqpara)
        {
            ResponceList Response = new ResponceList();

            try
            {
                if (reqpara != null)
                {
                    JsonElement result = await obj.Get_AddressList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.AddSugg, reqpara.userId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.DockList)]
        public async Task<ResponceList> DockList(ReqDockList reqpara)
        {
            ResponceList Response = new ResponceList();

            try
            {
                if (reqpara != null)
                {
                    JsonElement result = await obj.Get_DockList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.DockList, reqpara.userId);
            }
            return Response;
        }
        //[HttpPost]
        //[Route(APIRoute.CommFunAPI.ScanDataAPI)]
        //public async Task<ResponceList> ScanDataAPI(ReqScanDataAPI reqpara)
        //{
        //    ApiResponse Response = new ApiResponse();

        //    try
        //    {
        //        string Jsondata = ObjRepositry.ScanDataAPI(reqpara);
        //        if (Jsondata != "-1")

        //        {
        //            //string result = "";
        //            //Jsondata = ResponseOutPut.SplitStirng(Jsondata);
        //            Jsondata = "{\"jsonObject\":" + Jsondata + "}";
        //            Response = ResponseOutPut.SuccessResponse(MethodBase.GetCurrentMethod().Name, Jsondata);
        //            return Response;
        //        }
        //        else
        //        {
        //            Response = ResponseOutPut.ErrorReponse(MethodBase.GetCurrentMethod().Name, "Error found....");
        //            return Response;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response = ResponseOutPut.ErrorReponse(ex.Message, new { });
        //        return Response;
        //    }
        //}
        //[HttpPost]
        //[Route(APIRoute.CommFunAPI.Mob_ScanData)]
        //public async Task<ResponceList> Mob_ScanData(ReqMob_ScanData reqpara)
        //{
        //    ApiResponse Response = new ApiResponse();

        //    try
        //    {
        //        string Jsondata = ObjRepositry.Mob_ScanData(reqpara);
        //        if (Jsondata != "-1")

        //        {
        //            //string result = "";
        //            //Jsondata = ResponseOutPut.SplitStirng(Jsondata);
        //            Jsondata = "{\"jsonObject\":" + Jsondata + "}";
        //            Response = ResponseOutPut.SuccessResponse(MethodBase.GetCurrentMethod().Name, Jsondata);
        //            return Response;
        //        }
        //        else
        //        {
        //            Response = ResponseOutPut.ErrorReponse(MethodBase.GetCurrentMethod().Name, "Error found....");
        //            return Response;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response = ResponseOutPut.ErrorReponse(ex.Message, new { });
        //        return Response;
        //    }
        //}
        [HttpPost]
        [Route(APIRoute.Transload.DockSugg)]
        public async Task<ResponceList> DockSugg(ReqDockList reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqpara != null)
                {
                    JsonElement result = await obj.Get_DockList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.DockSugg, reqpara.userId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.TransportList)]
        public async Task<ResponceList> TransportList(ReqvendorList reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqpara != null)
                {
                    JsonElement result = await obj.Get_vendorList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.TransportList, reqpara.userId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.TransportSugg)]
        public async Task<ResponceList> TransportSugg(ReqvendorList reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqpara != null)
                {
                    JsonElement result = await obj.Get_vendorList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.TransportSugg, reqpara.userId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.PalletList)]
        public async Task<ResponceList> PalletList(ReqTransPalletList reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqpara != null)
                {
                    JsonElement result = await obj.Get_PalletList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.PalletList, reqpara.userId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.PalletSugg)]
        public async Task<ResponceList> PalletSugg(ReqTransPalletList reqpara)
        {
            ResponceList Response = new ResponceList();

            try
            {
                if (reqpara != null)
                {
                    JsonElement result = await obj.Get_PalletList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.PalletSugg, reqpara.userId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.TLHeadDetail)]
        public async Task<ResponceList> TLHeadDetail(ReqTLHeadDetail reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqpara != null)
                {
                    JsonElement result = await obj.TLHeadDetail(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.TLHeadDetail, reqpara.userId);
            }
            return Response;
        }

        //Order Adjustment
        [HttpPost]
        [Route(APIRoute.Transload.GetOrderAdjList)]
        public async Task<ResponceList> GetOrderAdjList(ReqOrderAdjList reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqpara != null)
                {
                    JsonElement result = await obj.GetOrderAdjList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.GetOrderAdjList, reqpara.UserId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.AddPalletList)]
        public async Task<ResponceList> AddPalletList(ReqOrderPalletList reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqpara != null)
                {
                    JsonElement result = await obj.AddPalletList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.AddPalletList, reqpara.UserId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.OrderAdjSave)]
        public async Task<Responce> OrderAdjSave(ReqOrderAdjSave reqpara)
        {
            Responce Response = new Responce();
            try
            {
                if (reqpara != null)
                {
                    string result = obj.OrderAdjSave(reqpara);
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
                    Response = ResponceResult.ErrorResponse("Record not save");
                }

            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.OrderAdjSave, reqpara.UserId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Transload.OrderAdjRemove)]
        public async Task<Responce> OrderAdjRemove(ReqOrderAdjRemove reqpara)
        {
            Responce Response = new Responce();
            try
            {
                if (reqpara != null)
                {
                    string result = obj.OrderAdjRemove(reqpara);
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
                    Response = ResponceResult.ErrorResponse("Record not save");
                }

            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.OrderAdjRemove, reqpara.UserId);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.UpdateStagingTraDetail)]
        public async Task<Responce> UpdateStagingTraDetail(ReqStagingTraDetail reqpara)
        {
            Responce Response = new Responce();
            try
            {
                if (reqpara != null)
                {
                    string result = obj.UpdateStagingTraDetail(reqpara);
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
                    Response = ResponceResult.ErrorResponse("Record not save");
                }

            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.UpdateStagingTraDetail, reqpara.UserId);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.GetStagingTraDetail)]
        public async Task<ResponceList> GetStagingTraDetail(ReqGetStagingTraDetail reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqpara != null)
                {
                    JsonElement result = await obj.StagingTraDetailGetAll(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.GetStagingTraDetail, reqpara.UserId);
            }
            return Response;
        }


        //Transpoter Detail
        [HttpPost]
        [Route(APIRoute.Transload.UpdateTransportDetail)]
        public async Task<Responce> UpdateTransportDetail(ReqTransportDetail reqpara)
        {
            Responce Response = new Responce();
            try
            {
                if (reqpara != null)
                {
                    string result = obj.UpdateTransportDetail(reqpara);
                    if (result != "")
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
                    Response = ResponceResult.ErrorResponse("Record not save");
                }

            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.UpdateStagingTraDetail, reqpara.UserId);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Transload.GetTransportDetailList)]
        public async Task<ResponceList> GetTransportDetailList(ReqGetTransportDetail reqpara)
        {
            ResponceList Response = new ResponceList();

            try
            {
                if (reqpara != null)
                {
                    JsonElement result = await obj.GetAllTransportDetailList(reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("Record not found");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Transload.GetTransportDetailList, reqpara.UserId);
            }
            return Response;
        }
    }
}
