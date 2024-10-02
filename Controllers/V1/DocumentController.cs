using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;
using WMSWebAPI.Models.V1.Responce;
using WMSWebAPI.Route;
using WMSWebAPI.Utility.V1;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web;

namespace WMSWebAPI.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {

        private readonly IWebHostEnvironment _hostingEnvironment;
    

        DocumentUtility Obj = new DocumentUtility();
        SysException exe = new SysException();

        //private readonly IWebHostEnvironment _hostingEnvironment;
        //private readonly DocumentUtility _documentUtility;
        //private readonly SysException _sysException;

        //public DocumentController(IWebHostEnvironment hostingEnvironment, DocumentUtility documentUtility, SysException sysException)
        //{
        //    _hostingEnvironment = hostingEnvironment;
        //    _documentUtility = documentUtility;
        //    _sysException = sysException;
        //}


        [HttpPost]
        [Route(APIRoute.Document.GetDocumentList)]
        public async Task<ResponceList> DocumentList(GetDocumentList req)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (req != null)
                {
                    JsonElement result = await Obj.GetAll(req);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Document.GetDocumentList, 0);
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.Document.Savedocument)]
        public Responce SaveDocument(SavedocumentRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string serverFilePath = Path.Combine(_hostingEnvironment.ContentRootPath, "Attachment", "Document", ReqPara.DocumentSavePath);
                    string downPath = Path.Combine("/Attachment", "Document", ReqPara.DocumentDownloadPath);

                    ReqPara.DocumentDownloadPath = serverFilePath;
                    string result = Obj.SaveDocument(ReqPara, downPath);

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
                    Response = ResponceResult.ErrorResponse("Record Not Saved..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message);
                exe.ErrorLog(ex.Message, APIRoute.Document.Savedocument, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Document.RemoveDocument)]
        public Responce RemoveDocument(RemoveDocumentRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = Obj.RemoveDocument(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Document.RemoveDocument, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Document.UploadDocument)]
        public IActionResult UploadDocument(long orderId, IFormFile uploadedFile, string objectName)
        {
            if (uploadedFile == null || uploadedFile.Length == 0)
            {
                return BadRequest(new { status = "error", message = "No file uploaded." });
            }

            string jsonString = "{\n\"upload_result\": [\n";

            try
            {
                string dirAttachment = Path.Combine(_hostingEnvironment.ContentRootPath, "Attachment", "Document", orderId.ToString());
                if (!Directory.Exists(dirAttachment))
                {
                    Directory.CreateDirectory(dirAttachment);
                }

                string filePath = Path.Combine(dirAttachment, uploadedFile.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    uploadedFile.CopyTo(stream);
                }

                string documentDownloadPath = $"../Attachment/Document/{orderId}/{uploadedFile.FileName}";

                jsonString += "{\n";
                jsonString += "\"status\": \"success\",\n";
                jsonString += $"\"path\": \"{orderId}/{uploadedFile.FileName}\"\n";
                jsonString += "}\n";
                jsonString += "]\n}";  /*json Loop End*/

                return Ok(jsonString);
            }
            catch (Exception ex)
            {
                exe.ErrorLog(ex.Message, APIRoute.Document.UploadDocument, orderId);
                return StatusCode(StatusCodes.Status500InternalServerError, new { status = "error", message = ex.Message });
            }
        }
    }
}
