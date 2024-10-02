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
    public class APITPListController : ControllerBase
    {
        APITPListUtility obj = new APITPListUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.APITP.GetAPITPList)]

        public async Task<ResponceList> GetAPITPListAsync(APITPList ReqPara)
        {


            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetAPITPList(ReqPara);


                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.APITP.GetAPITPList, Int64.Parse(ReqPara.UserId));
            }

            return Response;
        }



        [HttpPost]
        [Route(APIRoute.APITP.APITPSave)]
        public async Task<Responce> APITPSave(RequestAPITPSave ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.APITPSave(ReqPara);
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
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.APITP.APITPSave, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.APITP.APITPActiveList)]

        public async Task<ResponceList> APITPActiveList(RequestAPITPActiveList ReqPara)
        {


            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.APITPActiveList(ReqPara);


                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.APITP.APITPActiveList, Int64.Parse(ReqPara.UserId));
            }

            return Response;
        }


        [HttpPost]
        [Route(APIRoute.APITP.APITPLogList)]

        public async Task<ResponceList> APITPLogList(RequestAPITPLogList ReqPara)
        {


            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result =await obj.APITPLogList(ReqPara);


                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.APITP.APITPLogList, Int64.Parse(ReqPara.UserId));
            }

            return Response;
        }

        [HttpPost]
        [Route(APIRoute.APITP.APITPKEY)]

        public async Task<ResponceList> APITPKEY(RequestAPITPKEY ReqPara)
        {


            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.APITPKEY(ReqPara);


                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.APITP.APITPKEY, Int64.Parse(ReqPara.UserId));
            }

            return Response;
        }
        [HttpPost]
        [Route(APIRoute.APITP.APITPReqReadJSON)]

        public async Task<ResponceList> APITPReqReadJSON(RequestAPIJSON ReqPara)
        {


            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result =await  obj.APITPReqReadJSON(ReqPara);


                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.APITP.APITPKEY, Int64.Parse("0"));
            }

            return Response;
        }
        [HttpPost]
        [Route(APIRoute.APITP.APITPRespReadJSON)]

        public async Task<ResponceList> APITPRespReadJSON(ResponseAPIJSON ReqPara)
        {


            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result =await obj.APITPRespReadJSON(ReqPara);


                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.APITP.APITPKEY, Int64.Parse("0"));
            }

            return Response;
        }

        [HttpPost]
        [Route(APIRoute.APITP.getAPITPParameterlist)]

        public async Task<ResponceList> getAPITPParameterlist(APITPParameterlist ReqPara)
        {


            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getAPITPParameterlist(ReqPara);


                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());

                exe.ErrorLog(ex.Message.ToString(), APIRoute.APITP.getAPITPParameterlist, 0);
            }

            return Response;
        }
    }
}
