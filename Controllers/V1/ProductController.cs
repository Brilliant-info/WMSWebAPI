using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Threading.Tasks;

//using System.Web.HttpContext.Current;
using WMSWebAPI.Models.V1.Request;
using WMSWebAPI.Models.V1.Responce;
using WMSWebAPI.Route;
using WMSWebAPI.Utility.V1;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace WMSWebAPI.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductUtility obj = new ProductUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.Product.GetProductList)]
        public async Task<ResponceList> GetProductList(GetProductListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.ProductList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.GetProductList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Product.EditProduct)]
        public async Task<ResponceList> EditProduct(EditProductRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.EditProduct(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.EditProduct, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Product.AddProduct)]
        public async Task<Responce> AddProduct(AddProductRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.AddProduct(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.AddProduct, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Product.GetCategoryList)]
        public async Task<ResponceList> GetCategoryList(GetCategoryListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.CategoryList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.GetCategoryList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Product.AddCategory)]
        public async Task<Responce> AddCategory(AddCategoryRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.AddCategory(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.AddCategory, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Product.GetSubCategoryList)]
        public async Task<ResponceList> GetSubCategoryList(GetSubCategoryListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.SubCategoryList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.GetSubCategoryList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Product.AddSubCategory)]
        public async Task<Responce>  AddSubCategory(AddSubCategoryRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.AddSubCategory(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.AddSubCategory, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Product.ImageList)]
        public async Task<ResponceList> GetImageList(GetImageListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.ImageList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.ImageList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Product.AddImage)]
        public async Task<Responce> AddImage(AddImageRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.AddImage(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.AddImage, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Product.UploadImage)]
        public string UploadDocument(long SkuID, string uploadedfilename, string objectname)
        {
            var exMessage = string.Empty;
            String jsonString = String.Empty;

            try
            {

               // HttpPostedFile file = null;
                //IFormFile file = null;
               // string fname;

                string ImageDownloadPath;
                string ImageSave;
                //if (HttpContext.Current.Request.Files.Count > 0)
                 if (Request.Form.Files.Count > 0)
                {
                    //HttpContext.Current.Response.ContentType = "text/plain";
                    Response.ContentType = "text/plain";
                    jsonString = "{\n\"upload_result\": [\n";   /*json Loop Start*/
                    //  HttpFileCollection files = HttpContext.Current.Request.Files;

                    // file = files[0];
                    //fname = file.FileName;
                    var file = Request.Form.Files[0]; //collection that contain all the uploaded files included in the form data
                    string fname = file.FileName;
                    // string dirattachment = HttpContext.Current.Server.MapPath("~/Attachment/Image/" + SkuID);
                    string dirattachment = Path.Combine("~/Attachment/Image/" + SkuID);
                    if (!Directory.Exists(dirattachment))
                    {
                        Directory.CreateDirectory(dirattachment);
                    }

                    //fname = Path.Combine(HttpContext.Current.Server.MapPath("~/Attachment/Image/" + SkuID + "/"), uploadedfilename);
                    fname = Path.Combine(("~/Attachment/Image/" + SkuID + "/"), uploadedfilename);
                    // file.SaveAs(fname);
                    //saving an uploaded file to the server
                    using (var stream = new FileStream(fname, FileMode.Create))
                    {
                        file.CopyToAsync(stream);
                    }
                    ImageDownloadPath = "Image/" + SkuID + "/" + uploadedfilename + "";
                    ImageSave = fname;

                    string AttachfileName = Path.GetFileName(fname);
                    jsonString = jsonString + "{\n";
                    //  if (File.Exists(fname))
                    if (System.IO.File.Exists(fname))
                    {

                        jsonString = jsonString + "\"status\": \"success\",\n";
                        jsonString = jsonString + "\"path\": \"" + SkuID + "/" + AttachfileName + "\",\n";
                        jsonString = jsonString + "\"DownloadPath\": \"" + ImageDownloadPath + "\"\n";

                    }
                    else
                    {
                        jsonString = jsonString + "\"status\": \"success\"\n";
                    }

                    jsonString = jsonString + "}\n";
                    jsonString = jsonString + "]\n}";  /*json Loop End*/
                }
                return jsonString;

            }

            catch (Exception ex)
            {
                exMessage = ex.Message;
                return exMessage;
            }
        }

        [HttpPost]
        [Route(APIRoute.Product.RemoveImage)]
        public async Task<Responce> RemoveImage(RemoveImageRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.RemoveImage(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.RemoveImage, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Product.UomList)]
        public async Task<ResponceList> GetUomList(GetUomListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.UomList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.UomList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Product.AddUom)]
        public async Task<Responce> AddUom(AddUomRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.AddUom(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.AddUom, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Product.LottableList)]
        public async Task<ResponceList> GetLottableList(GetLottableListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.LottableList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.LottableList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Product.AddLottable)]
        public async Task<Responce> AddLottable(AddLottableRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.AddLottable(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.AddLottable, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Product.RemoveLottable)]
        public async Task<Responce> RemoveLottable(RemoveLottableRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.RemoveLottable(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.RemoveLottable, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Product.RemoveUom)]
        public async Task<Responce> RemoveUom(RemoveUomRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.RemoveUom(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.RemoveUom, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Product.packingfamilyddl)]
        public async Task<ResponceList> packingfamilyddl(GetpackingfamilyddlRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.packingfamilyddl(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.packingfamilyddl, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Product.Uomddl)]
        public async Task<ResponceList> Uomddl(GetUomddlRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.Uomddl(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.Uomddl, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Product.Lottableddl)]
        public async Task<ResponceList> Lottableddl(GetLottableddlRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.Lottableddl(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.Lottableddl, ReqPara.UserId);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Product.LotableDataTypeddl)]
        public async Task<ResponceList> LotableDataTypeddl(LotableDataType ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.LotableDataType(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.LotableDataTypeddl, ReqPara.UserID);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Product.ProductInventoryAssignList)]
        public async Task<ResponceList> ProductInventoryAssignList(ProductInventoryAssignListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result =  await obj.ProductInventoryAssignList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.ProductInventoryAssignList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Product.ProductLocationList)]
        public async Task<ResponceList> ProductLocationList(ProductLocationListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.ProductLocationList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.ProductLocationList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Product.AssighnSKULocation)]
        public async Task<Responce> AssighnSKULocation(AddSKULocationReq ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.AddSKULocation(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.RemoveUom, Int64.Parse(ReqPara.CreatedBy));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Product.RemoveSKULocation)]
        public async Task<Responce> RemoveSKULocation(RemoveSKULocRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.RemoveSKULoc(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.RemoveUom, Int64.Parse(ReqPara.CreatedBy));
            }
            return Response;
        }


        // API CHANGES FOR BARCODE CONFIGURATION - 27 Nov 2023
        [HttpPost]
        [Route(APIRoute.Product.SaveBarcodePrdConfig)]
        public async Task<ResponceList> SaveBarcodePrdConfig(SaveBarcodeRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.SaveBarcodePrdConfig(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.SaveBarcodePrdConfig, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Product.GetLottableSave)]
        public async Task<ResponceList> GetLottableSave(GetLottableSaveRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetLottableSave(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.GetLottableSave, Int64.Parse(ReqPara.SkuID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Product.GetLottableRemove)]
        public async Task<ResponceList> GetLottableRemove(GetLottableRemoveRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetLottableRemove(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.GetLottableRemove, Int64.Parse(ReqPara.SkuID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Product.GetLottableDropdown)]
        public async Task<ResponceList> GetLottableDropdown(GetLottableDropdownRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetLottableDropdown(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.GetLottableDropdown, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Product.GetLottablebarcode)]
        public async Task<ResponceList> GetLottablebarcode(GetLottablebarcodeRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetLottablebarcode(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.GetLottablebarcode, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.Product.GetPrdBarcodeConfig)]
        public async Task<ResponceList> GetPrdBarcodeConfig(GetPrdBarcodeConfigRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetPrdBarcodeConfig(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.GetLottablebarcode, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }
        // API CHANGES FOR BARCODE CONFIGURATION - 27 Nov 2023
        [HttpPost]
        [Route(APIRoute.Product.BindCategory)]
        public async Task<ResponceList> BindCategory(BindCategory ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.CategoryList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.BindCategory, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }



        [HttpPost]
        [Route(APIRoute.Product.GetPriceList)]
        public async Task<ResponceList> GetPriceList(GetPriceList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetPriceList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.GetPriceList, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.Product.SavePrice)]
        public async Task<Responce> SavePrice(SavePrice ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.SavePrice(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.SavePrice, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }



        [HttpPost]
        [Route(APIRoute.Product.GetGSTList)]
        public async Task<ResponceList> GetGSTList(GetGSTList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetGSTList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.GetGSTList, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.Product.SaveGST)]
        public async Task<Responce> SaveGST(SaveGST ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.SaveGST(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.SaveGST, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Product.Getskucodelist)]
        public async Task<ResponceList> Getskucodelist(GetskucodelistRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.Getskucodelist(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.Getskucodelist, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Product.Getskusave)]
        public async Task<Responce> Getskusave(GetskusaveRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.Getskusave(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.Getskusave, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Product.Getskubind)]
        public async Task<ResponceList> Getskubind(GetskubindRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.Getskubind(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.Getskubind, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Product.GetattributeSave)]
        public async Task<Responce> GetattributeSave(GetattributeSaveRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.GetattributeSave(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.GetattributeSave, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Product.Getattributebind)]
        public async Task<ResponceList> Getattributebind(GetattributebindRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.Getattributebind(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.Getattributebind, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Product.GetUOMDropdown)]
        public async Task<ResponceList> GetUOMDropdown(GetUOMDropdownRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetUOMDropdown(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.GetUOMDropdown, 0);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Product.DispSkuConvDetail)]
        public async Task<ResponceList> DispSkuConvDetail(DispSkuConvDetailRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.DispSkuConvDetail(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.DispSkuConvDetail, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Product.RemoveskuConv)]
        public async Task<Responce> RemoveskuConv(RemoveskuConvRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.RemoveskuConv(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.RemoveskuConv, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Product.EditGST)]
        public async Task<Responce> EditGST(EditGST ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.EditGST(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.SaveGST, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Product.ddlGetGST)]
        public async Task<ResponceList> ddlGetGST(ddlGetGST ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.ddlGetGST(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Product.ddlGetGST, Int64.Parse(ReqPara.UserID));
            }
            return Response;
        }
    }
}
