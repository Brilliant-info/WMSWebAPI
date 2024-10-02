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
    public class ImportDesignerController : ControllerBase
    {


        ImportDesignerUtility obj = new ImportDesignerUtility();
        SysException exe = new SysException();


        [HttpPost]
        [Route(APIRoute.ImportDesigner.ImportDesignerList)]
        public async Task<ResponceList> ImportDesignerList(ImportDesignerListRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.ImportDesignerList(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ImportDesigner.ImportDesignerList, 0);
            }
            return Response;
        }

        

  

        [HttpPost]
        [Route(APIRoute.ImportDesigner.ImportDesignerObjectList)]
        public async Task<ResponceList> ImportDesignerObject(ImportDesignerObjectListRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.ImportDesignerObjectList(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ImportDesigner.ImportDesignerObjectList, 0);
            }
            return Response;
        }

      

        [HttpPost]
        [Route(APIRoute.ImportDesigner.ImpDesignTableColoumlist)]
        public async Task<ResponceList> ImportDesignerObject(ImpDesignTableColoumRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.ImpDesignTableColoumlist(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ImportDesigner.ImpDesignTableColoumlist, 0);
            }
            return Response;
        }


    
        [HttpPost]
        [Route(APIRoute.ImportDesigner.ImpDesignTblColoumDataType)]
        public async Task<ResponceList> ImpDesignTblColoumDataType(ImpDesignTblColoumDataTypeRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.ImpDesignTblColoumDataType(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ImportDesigner.ImpDesignTblColoumDataType, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ImportDesigner.ImportDesignerSave)]
        public Responce ImportDesignerSave(ImportDesignerSaveRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.ImportDesignerSave(ReqPara);
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
                    Response = ResponceResult.ErrorResponse("Record Not Removed..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ImportDesigner.ImportDesignerSave, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.ImportDesigner.ImportDesignerViewList)]
        public async Task<ResponceList> ImportDesignerViewList(ImportDesignerViewListRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.ImportDesignerViewList(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ImportDesigner.ImportDesignerViewList, 0);
            }
            return Response;
        }




        [HttpPost]
        [Route(APIRoute.ImportDesigner.CustomImportDetailSavedata)]
        public async Task<ResponceList> CustomImportDetailSavedata(CustomImportDetailSavedataRequest reqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (reqPara != null)
                {
                    JsonElement result = await obj.CustomImportDetailSavedata(reqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.ImportDesigner.CustomImportDetailSavedata, 0);
            }
            return Response;
        }

       

    }
}
