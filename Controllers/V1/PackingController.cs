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
    public class PackingController : ControllerBase
    {


        PackingUtility obj = new PackingUtility();
        SysException exe = new SysException();



        [HttpPost]
        [Route(APIRoute.Packing.GetStagingList)]
        public async Task<ResponceList> GetStagingList(GetStagingListRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.StagingList(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Packing.GetStagingList, Int64.Parse(reqPara.UserId));
            }
            return Response;
        }

    



        [HttpPost]
        [Route(APIRoute.Packing.GetStagingSOList)]
        public async Task<ResponceList> StagingSOList(GetStagingSOListRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.StagingSOList(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Packing.GetStagingSOList, Int64.Parse(reqPara.UserId));
            }
            return Response;
        }

  

        [HttpPost]
        [Route(APIRoute.Packing.GetStagingSODetail)]
        public async Task<ResponceList> GetStagingSODetail(GetStagingSODetailRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.StagingSODetail(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Packing.GetStagingSODetail, Int64.Parse(reqPara.UserId));
            }
            return Response;
        }

  
        [HttpPost]
        [Route(APIRoute.Packing.ShippingPallet)]
        public async Task<ResponceList> ShippingPallet(GetShippingPalletRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.ShippingPallet(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Packing.ShippingPallet, 0);
            }
            return Response;
        }



        [HttpPost]
        [Route(APIRoute.Packing.StagingSKUList)]
        public async Task<ResponceList> StagingSKUList(GetStagingSKUListRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.StagingSKUList(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Packing.StagingSKUList, 0);
            }
            return Response;
        }

 

        [HttpPost]
        [Route(APIRoute.Packing.StagingSKUDetail)]
        public async Task<ResponceList> StagingSKUDetail(GetStagingSKUDetailRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.StagingSKUDetail(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Packing.StagingSKUDetail, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Packing.SaveStagingSKUDetail)]
        public async Task<Responce> SaveStagingSKUDetail(SaveStagingSKUDetailRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string[] arr = obj.SaveStagingDetail(ReqPara).Split('|');
                    string result = arr[0].ToString();
                    if ((result == "success") || (result == "completed"))
                    {
                        Response = ResponceResult.SuccessResponseOrder(result, arr[1].ToString());
                    }
                    else
                    {
                        Response = ResponceResult.SuccessResponseOrder(result, "0");
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Packing.SaveStagingSKUDetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Packing.RemoveSKUDetail)]
        public async Task<Responce>  RemoveSKUDetail(RemveSkuRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.RemoveSku(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        Response = ResponceResult.SuccessResponse(result);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Packing.RemoveSKUDetail, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Packing.FinalSavePacking)]
        public async Task<Responce> FinalSavePacking(FinalSavePackingRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.FinalSave(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        Response = ResponceResult.SuccessResponse(result);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Packing.FinalSavePacking, 0);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Packing.DirectPackingOrders)]
        public async Task<Responce> DirectPackingOrders(DirectPackingOrdersRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.DirectPackingOrders(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        Response = ResponceResult.SuccessResponse(result);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Packing.FinalSavePacking, 0);
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.Packing.getTransportList)]
        public async Task<ResponceList> getTransportList(transportList reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.TransportDDList(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Packing.getTransportList, Int64.Parse(reqPara.UserID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Packing.UpdateTranspoter)]
        public async Task<Responce>  UpdateTranspoter(TranspoteUpdate ReqPara)
        {
            Responce response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.saveTranspoter(ReqPara);
                    if (result == "success")
                    {
                        response = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        response = ResponceResult.SuccessResponse(result);
                    }
                }
                else
                {
                    response = ResponceResult.ErrorResponse("Record Not Found..!!");
                }
            }
            catch (Exception ex)
            {
                response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Packing.UpdateTranspoter, Int32.Parse(ReqPara.UserId));
            }
            return response;
        }




        [HttpPost]
        [Route(APIRoute.Packing.PackingLocation)]
        public async Task<ResponceList> PackingLocation(GetPackingLocationRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.PackingLocation(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Packing.PackingLocation, Int64.Parse(reqPara.UserId));
            }
            return Response;
        }
    }
}
