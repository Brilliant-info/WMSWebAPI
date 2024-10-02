using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;
using WMSWebAPI.Models.V1.Responce;
using WMSWebAPI.Route;
using WMSWebAPI.Utility.V1;


namespace WMSWebAPI.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CustomerUtility obj = new CustomerUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.Customer.GetCustomerList)]
        public async Task<ResponceList> GetCustomerList(GetCustomerListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.CustomerList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Customer.GetCustomerList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Customer.AddCustomer)]
        public async Task<Responce> AddCustomer(AddCustomerRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.AddCustomer(ReqPara);
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
        [Route(APIRoute.Customer.UploadLogo)]
        public string UploadLogo(string uploadedfilename, string objectname)
        {
            var exMessage = string.Empty;
            String jsonString = String.Empty;
            Random rnd = new Random();
            long CustUniuqeNo = rnd.Next();
            try
            {
                //HttpPostedFile file = null;
                //string fname;

                string ImageDownloadPath;
                string ImageSave;

                if (Request.Form.Files.Count > 0)
                {
                    Response.ContentType = "text/plain";
                    jsonString = "{\n\"upload_result\": [\n";   /*json Loop Start*/

                    //HttpFileCollection files = HttpContext.Current.Request.Files;
                    //file = files[0];

                    var file = Request.Form.Files[0]; //collection that contain all the uploaded files included in the form data
                    string fname = file.FileName;
                    string dirattachment = Path.Combine("~/Attachment/Image/" + CustUniuqeNo);
                    if (!Directory.Exists(dirattachment))
                    {
                        Directory.CreateDirectory(dirattachment);
                    }

                    fname = Path.Combine(("~/Attachment/Image/" + CustUniuqeNo + "/"), uploadedfilename);
                    //file.SaveAs(fname);

                    //saving an uploaded file to the server
                    using (var stream = new FileStream(fname, FileMode.Create))
                    {
                        file.CopyToAsync(stream);
                    }
                    ImageDownloadPath = "Image/" + CustUniuqeNo + "/" + uploadedfilename + "";
                    ImageSave = fname;

                    string AttachfileName = Path.GetFileName(fname);
                    jsonString = jsonString + "{\n";
                    if (System.IO.File.Exists(fname))
                    {

                        jsonString = jsonString + "\"status\": \"success\",\n";
                        jsonString = jsonString + "\"path\": \"" + CustUniuqeNo + "/" + AttachfileName + "\",\n";
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
        [Route(APIRoute.Customer.EditCustomer)]
        public async Task<ResponceList> EditCustomer(EditCustomerRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.EditCustomer(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Customer.EditCustomer, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Customer.ShowWarehouse)]
        public async Task<ResponceList> ShowWarehouse(ShowWarehouseRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.ShowWarehouse(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Customer.ShowWarehouse, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Customer.AssginCustomerWarehouse)]
        public Responce AssginCustomerWarehouse(AssginCustomerWarehouseRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.AssginCustomerWarehouse(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Customer.AssginCustomerWarehouse, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Customer.RemoveWarehouse)]
        public async Task<Responce> RemoveWarehouse(RemoveWarehouseRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.RemoveWarehouse(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Customer.RemoveWarehouse, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Customer.GetCompanyList)]
        public async Task<ResponceList> GetCompanyList(getcompanyRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetCompanybyUser(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Customer.GetCompanyList, ReqPara.UserID);
            }
            return Response;
        }
        //Send OTP TO Customer
        [HttpPost]
        [Route(APIRoute.Customer.sendOTPToCustomer)]
        public async Task<Responce> sendOTPToCustomer(reqCustomerDemandOtp ReqPara)
        {
            string email = ReqPara.Email;
            string getOTP = ReqPara.OTP;
            string result = "";

            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string GetOtp = obj.GetOTP1();
                    if (getOTP == null || getOTP == "")
                    {
                        ReqPara.OTP = GetOtp;
                    }

                    string getresult = obj.reqSendCustomerOTP(ReqPara);


                    string[] getdetils = getresult.Split('|');

                    if (getdetils.Length > 0)
                    {
                        result = getdetils[0];
                        getOTP = getdetils[1];

                    }
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                        string bodytext = "Thanks For Activation, Your OTP is <b>" + getOTP + "</b>,Please Complete Your User Registration Process.";
                        string sessionVal = obj.sendEmail(email, bodytext, "OTP Verification", "New Registration For The Application");
                        return Response;
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                        return Response;
                    }

                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Customer.sendOTPToCustomer, Convert.ToInt32(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Customer.validateOtp)]
        public async Task<Responce> checkOTP(reqValidateOTP ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.validateOtp(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                        return Response;
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                        return Response;
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Customer.validateOtp, Int32.Parse(ReqPara.UserId));

            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Customer.sendActivationLink)]
        public async Task<Responce> sendActivationLink(reqSendLink ReqPara)
        {
            string email = Convert.ToString(ReqPara.Email);
            string loginLink = Convert.ToString(ReqPara.ActivationLink);
            long CustomerID = Int32.Parse(ReqPara.CustomerID);
            string FinalLink = loginLink;
            ReqPara.ActivationLink = FinalLink;
            string result = "";
            string ActiveLink = "";
            string checkresp = "";
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string getresult = obj.ActivationLink(ReqPara);

                    string[] getCustomerDetails = getresult.Split('|');

                    if (getCustomerDetails.Length > 0)
                    {
                        result = getCustomerDetails[0];
                        ActiveLink = getCustomerDetails[1];

                    }

                    //result = checkresp + "|" + ActiveLink

                    if (result == "success")
                    {
                        string bodytext = "Thanks For Activation for Demand Portal, Your Activation link is <b>" + ActiveLink + "</b>, Please Complete Your User Registration Process.";
                        string sessionVal = obj.sendEmail(email, bodytext, "Activation for Demand Portal", "New Registration For The Application");

                        Response = ResponceResult.SuccessResponse(getresult);
                        return Response;
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse("Record Not Save");
                        return Response;
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Value Not Proper");
                }
            }
            catch (System.Exception ex)
            {

                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Customer.sendActivationLink, Int32.Parse(ReqPara.UserId));

            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Customer.GetDispDemandActivationLink)]
        public async Task<ResponceList> GetDispDemandActivationLink(GetDispDemandActivationLinkRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetDispDemandActivationLink(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Customer.GetDispDemandActivationLink, ReqPara.UserId);
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Customer.demandObjectList)]
        public async Task<ResponceList> demandObjectList(reqPickDropList Reqpara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (Reqpara != null)
                {
                    JsonElement result = await obj.DemandobjectList(Reqpara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Customer.demandObjectList, Int64.Parse(Reqpara.UserId));
            }

            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Customer.saveDemandObject)]
        public async Task<Responce> saveDemandObject(reqSaveDemandObject Reqpara)
        {
            Responce Response = new Responce();
            try
            {
                if (Reqpara != null)
                {

                    string result = obj.saveDemandObject(Reqpara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                        return Response;
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Customer.saveDemandObject, Int32.Parse(Reqpara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Customer.objectList)]
        public async Task<ResponceList> DemandObjectList(reqDemandObjectList ReqPara)
        {

            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getObjectList(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Customer.demandObjectList, Int64.Parse(ReqPara.UserId));
            }

            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Customer.removeObjectPoint)]
        public async Task<Responce> removeObjectPoint(reqRemoveObjPoint ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.removeObjectPoint(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                        return Response;
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }

                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Customer.removeObjectPoint, Int32.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Customer.GetLottableCutomer)]
        public async Task<Responce> GetLottableCutomer(reqLottableCutomer ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.LottableCutomer(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                        return Response;
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }

                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Customer.GetLottableCutomer, Int32.Parse(ReqPara.CustomerID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Customer.GetLottableCustomerList)]
        public async Task<ResponceList> GetLottableCustomerList(reqLottableCustomerList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.LottableCustomerList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Customer.GetLottableCustomerList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Customer.GetLottableSave)]
        public async Task<Responce> GetLottableSave(reqLottableCutomer ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.LottableCutomer(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                        return Response;
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }

                }
                else
                {
                    Response = ResponceResult.ErrorResponse("Record Not Save..");
                }
            }
            catch (System.Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Customer.GetLottableSave, Int32.Parse(ReqPara.CustomerID));
            }
            return Response;
        }
        [HttpPost]
        [Route(APIRoute.Customer.GetLottablesavelist)]
        public async Task<ResponceList> GetLottablesavelist(reqLottablesavelist ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.Lottablesavelist(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Customer.GetLottablesavelist, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }
    }
}
