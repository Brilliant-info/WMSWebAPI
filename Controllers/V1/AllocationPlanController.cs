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
    public class AllocationPlanController : ControllerBase
    {
        AllocationUtility obj = new AllocationUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.AllocationPlan.BatchList)]
        public async Task<ResponceList> BatchList(BatchListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.BatchList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.AllocationPlan.BatchList, Convert.ToInt64(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.AllocationPlan.saveplandirect)]
        public Responce saveplandirect(saveplandirectrequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.saveplandirect(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.AllocationPlan.saveplandirect, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.AllocationPlan.getallocationplansumry)]
        public async Task<ResponceList> getallocationplansumry(getallocationplansumryrequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getallocationplansumry(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.AllocationPlan.getallocationplansumry, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.AllocationPlan.Getalcplndtl)]
        public async Task<ResponceList> Getalcplndtl(Getalcplndtlrequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.Getalcplndtl(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.AllocationPlan.Getalcplndtl, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.AllocationPlan.getSearchalcplndtls)]
        public async Task<ResponceList> getSearchalcplndtls(allocationplandtlsearchRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.allocationplandtlsearch(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.AllocationPlan.getSearchalcplndtls, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.AllocationPlan.updateallocationplanQty)]
        public async Task<Responce> updateallocationplanQty(updateallocationplanQty ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.updateallocationplanQty(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.AllocationPlan.updateallocationplanQty, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.AllocationPlan.updateallocationplanintransitQty)]
        public async Task<Responce> updallocationplanintransitquantity(updateallocationplanQty ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.updallocationplanintransitquantity(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.AllocationPlan.updateallocationplanintransitQty, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.AllocationPlan.CreateCustomBatch)]
        public async Task<Responce> CreateCustomBatch(getbatchidbysoids ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.UpdateResurveqty(Convert.ToInt64(obj.getbatchidbysoids(ReqPara)), ReqPara.confirm);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else if (result == "confirm")
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.AllocationPlan.updateallocationplanintransitQty, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.AllocationPlan.CancelBatch)]
        public async Task<Responce> cancelCustomBatch(cancelbatchRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string batchid = obj.getbatchidbysoid(Convert.ToInt64(ReqPara.soid));
                    string result = obj.cancelbatch(Convert.ToInt64(batchid));
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.AllocationPlan.CancelBatch, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.AllocationPlan.GetManualAllocationofSku)]
        public async Task<ResponceList> GetManualAllocationofSku(GetManualAllocationofSkuRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getmanualallocationplanskuwise(ReqPara.ProdID, ReqPara.soid);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.AllocationPlan.GetManualAllocationofSku, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.AllocationPlan.ManualallocationSearch)]
        public async Task<ResponceList> ManualallocationSearch(searchmanualalocrequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = new JsonElement();
                    if (ReqPara.whereFilterCondition != null)
                    {
                        result = await obj.searchmanualallocation(ReqPara.whereFilterCondition, ReqPara.prdid, ReqPara.soid);
                    }
                    else
                    {
                        result = await obj.getmanualallocationplanskuwise(ReqPara.prdid, ReqPara.soid);
                    }
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.AllocationPlan.GetManualAllocationofSku, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.AllocationPlan.UpdateQtyManualallocation)]
        public async Task<Responce> UpdateQtyManualallocation(updatemanualqtyrequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.updatemanualallocationqty(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.AllocationPlan.UpdateQtyManualallocation, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.AllocationPlan.DeAllocate)]
        public async Task<Responce> DeAllocateBatch(DeAllocateRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.DeAllocate(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.AllocationPlan.DeAllocate, Convert.ToInt64(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.AllocationPlan.TotalShrotQty)]
        public async Task<ResponceList> TotalShrotQty(TotalShrotQtyRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.TotalShrotQty(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.AllocationPlan.TotalShrotQty, Convert.ToInt64(ReqPara.CustId));
            }
            return Response;
        }
    }
}
