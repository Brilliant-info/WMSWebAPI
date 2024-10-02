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
    public class DemandPortalController : ControllerBase
    {

        DemandPortalUtlity obj = new DemandPortalUtlity();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.DemandPortal.getOTP)]
        public Responce getOTP(reqEmailOtp ReqPara)
        {
            string email = ReqPara.Email;
            string getOTP = ReqPara.OTP;
            string result = "";

            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string GetOtp = obj.GetOTP();
                    if (getOTP == null || getOTP == "")
                    {
                        ReqPara.OTP = GetOtp;
                    }

                    string getresult = obj.getRequestedOtp(ReqPara);


                    string[] getOtpdetils = getresult.Split('|');

                    if (getOtpdetils.Length > 0)
                    {
                        result = getOtpdetils[0];
                        getOTP = getOtpdetils[1];

                    }
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                        string bodytext = "Thanks for signing up, Your OTP is <b>" + getOTP + "</b>,Please Complete Your User Registration Process.";
                        string sessionVal = obj.SendMailDynamic(email, bodytext, "OTP Verification", "New Registration For The Application");
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DemandPortal.getOTP, 0);
            }
            return Response;
        }

        //Send Forgot Password OTP
        [HttpPost]
        [Route(APIRoute.DemandPortal.ResetPassword)]
        public async Task<Responce> restPassword(reqForgotPass ReqPara)
        {
            string email = ReqPara.EmailId;
            string getOTP = ReqPara.OTP;
            string result = "";

            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string GetOtp = obj.GetOTP();
                    if (getOTP == null || getOTP == "")
                    {
                        ReqPara.OTP = GetOtp;
                    }

                    string getresult = obj.userResetPassword(ReqPara);


                    string[] getOtpdetils = getresult.Split('|');

                    if (getOtpdetils.Length > 0)
                    {
                        result = getOtpdetils[0];
                        getOTP = getOtpdetils[1];

                    }
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                        string bodytext = "Your OTP For Reset Your Password Is <b>" + getOTP + "</b>, Please Validate Your OTP.";
                        string sessionVal = obj.SendPasswordRestMailDynamic(email, bodytext);
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DemandPortal.ResetPassword, 0);
            }
            return Response;
        }


        //OTP Validate
        [HttpPost]
        [Route(APIRoute.DemandPortal.otpvalidate)]
        public async Task<Responce> UserRegistrationOtpValidate(reqOTPValidate ReqPara)
        {
            string result = "";
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    result = obj.userOtpValidation(ReqPara);
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
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DemandPortal.otpvalidate, 0);
            }
            return Response;
        }


        //Validate Forgot Password OTP
        [HttpPost]
        [Route(APIRoute.DemandPortal.validateResetPassword)]
        public async Task<Responce> ForgetvalidateOTP(reqResetPassword ReqPara)
        {
            string result = "";
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    result = obj.getRepPasswordChange(ReqPara);
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
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DemandPortal.otpvalidate, 0);
            }
            return Response;
        }


        //Set/Update New Password
        [HttpPost]
        [Route(APIRoute.DemandPortal.setupNewPass)]
        public async Task<Responce> setupNewPass(setNewPassword ReqPara)
        {
            string result = "";
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    result = obj.updatePassword(ReqPara);
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
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DemandPortal.otpvalidate, 0);
            }
            return Response;
        }


        //User Registration
        [HttpPost]
        [Route(APIRoute.DemandPortal.UserRegister)]
        public async Task<Responce> UserRegistration(reUserRegister ReqPara)
        {
            string result = "";
            string email = ReqPara.Email;
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    result = obj.saveUserRegistration(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                        string bodytext = "You have Succcessfully Register Into System, Now you can Login";
                        string sessionVal = obj.SendMailDynamic(email, bodytext, "User Registration", "New Registration For The Application");
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DemandPortal.UserRegister, 0);
            }
            return Response;
        }

        //Check User Login

        [HttpPost]
        [Route(APIRoute.DemandPortal.UserLogin)]
        public async Task<Responce> checkLogin(reqLogin ReqPara)
        {
            string result = "";
            string objectName = "";
            string getresult = "";
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    getresult = obj.checkUserLogin(ReqPara);
                    string[] getUserdetails = getresult.Split('|');

                    if (getUserdetails.Length > 0)
                    {
                        result = getUserdetails[0];
                        objectName = getUserdetails[1];

                    }

                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(getresult);
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DemandPortal.UserLogin, 0);
            }
            return Response;
        }

        //Drop Down list
        [HttpPost]
        [Route(APIRoute.DemandPortal.DashboardDropdown)]
        public async Task<ResponceList>  DashboardDropdown(reqDropdownList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getDropdownList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Dashboard.GetDropdownList, Int64.Parse(ReqPara.UserId));
            }
            return Response;
        }

        //User List For Approval
        [HttpPost]
        [Route(APIRoute.DemandPortal.UserApprovalList)]
        public async Task<ResponceList>  GetUserList(reqUserList ReqPara)
        {
            string SearchValue = ReqPara.SerchVal;
            if (SearchValue == "" || SearchValue == null)
            {
                ReqPara.SerchVal = "";
            }
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getUserList(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DemandPortal.UserLogin, 0);
            }
            return Response;
        }

        //User Approve Status

        [HttpPost]
        [Route(APIRoute.DemandPortal.userApprove)]
        public async Task<Responce> UserApporve(reqApporveUser ReqPara)
        {
            string result = "";

            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    result = obj.UserApproveStatus(ReqPara);

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
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DemandPortal.userApprove, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.DemandPortal.validateUser)]
        public async Task<Responce> checkUserName(reqcheckUserName ReqPara)
        {
            string result = "";

            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    result = obj.checkUserValidate(ReqPara);

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
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DemandPortal.validateUser, 0);
            }
            return Response;
        }

        //Template List

        [HttpPost]
        [Route(APIRoute.DemandPortal.OrderTemplateList)]
        public async Task<ResponceList>  GetTemplateList(reqTemplateList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getTemplateList(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DemandPortal.OrderTemplateList, Convert.ToInt64(ReqPara.UserId));

                return Response;
            }
        }

        //save New Template
        [HttpPost]
        [Route(APIRoute.DemandPortal.saveTemplate)]
        public async Task<Responce> saveNewOderTemplate(createTemplate ReqPara)
        {
            string result = "";

            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    result = obj.saveNewTemplate(ReqPara);

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
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DemandPortal.saveTemplate, 0);
            }
            return Response;
        }

        //Remove Template

        [HttpPost]
        [Route(APIRoute.DemandPortal.removeTemplate)]
        public async Task<Responce> removeTemplate(RemoveTemplate ReqPara)
        {
            string result = "";

            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    result = obj.removeUserTemplate(ReqPara);

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
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DemandPortal.removeTemplate, 0);
            }
            return Response;
        }

        //View Order Details

        [HttpPost]
        [Route(APIRoute.DemandPortal.ViewWmsOrder)]
        public async Task<ResponceList>  ViewWmsOrderDetails(viewWMSOrderDetails ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result =await  obj.getWmsViewOrderList(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DemandPortal.ViewWmsOrder, Convert.ToInt64(ReqPara.OrderId));

                return Response;
            }
        }

        //Approve Order        
        [HttpPost]
        [Route(APIRoute.DemandPortal.approveOrder)]
        public async Task<Responce> orderApprove(approveOrderDisp ReqPara)
        {
            string email = ReqPara.Email;
            string getOrderId = ReqPara.OrderId;
            string Reason = ReqPara.OrderStatus;
            if (Reason == "")
            {
                ReqPara.ReasonText = "";
            }
            string result = "";
            string bodytext = "";
            string sessionVal = "";
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    result = obj.orderApprove(ReqPara);

                    if (result == "success")
                    {

                        string OrderId = ReqPara.OrderId;
                        string getEmail = obj.getAdminlEmail(OrderId);
                        if (Reason == "Approved")
                        {
                            Response = ResponceResult.SuccessResponse(result);
                            bodytext = "Order Successfully Approved, Your Order " + getOrderId + " Is InProcess Now.";
                            sessionVal = obj.SendMailDynamic(email, bodytext, "Order Status", "Your Order Status Update");
                            sessionVal = obj.SendMailDynamic(getEmail, bodytext, "Order Status", "Your Order Status Update");

                        }
                        else if (Reason == "Delivered")
                        {

                            Response = ResponceResult.SuccessResponse(result);
                            bodytext = "Your Order " + getOrderId + " Successfully Delivery.";
                            sessionVal = obj.SendMailDynamic(email, bodytext, "Order Status", "Your Order Status Update");
                            sessionVal = obj.SendMailDynamic(getEmail, bodytext, "Order Status", "Your Order Status Update");
                        }
                        else
                        {
                            Response = ResponceResult.SuccessResponse(result);
                            bodytext = "Order " + getOrderId + " Is Rejected By Admin. ";
                            sessionVal = obj.SendMailDynamic(email, bodytext, "Order Status", "Your Order Status Update");
                            sessionVal = obj.SendMailDynamic(getEmail, bodytext, "Order Status", "Your Order Status Update");
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
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DemandPortal.saveTemplate, 0);
            }
            return Response;
        }

        // View Dispatch Order
        [HttpPost]
        [Route(APIRoute.DemandPortal.ViewDispatchOrder)]
        public async Task<ResponceList>  ViewDispatchOrder(viewDispatchOrder ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.viewDispatchOrderList(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DemandPortal.ViewDispatchOrder, Convert.ToInt64(ReqPara.OrderId));

                return Response;
            }
        }

        //Save Template Order

        [HttpPost]
        [Route(APIRoute.DemandPortal.saveTemplateOrder)]
        public async Task<Responce> saveTemplateOrder(saveTemplateOrder ReqPara)
        {
            string result = "";

            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    result = obj.saveTemplateOrder(ReqPara);

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
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DemandPortal.saveTemplateOrder, 0);
            }
            return Response;
        }

        //Reason Code
        [HttpPost]
        [Route(APIRoute.DemandPortal.ReasonList)]
        public async Task<ResponceList>  ReasonList(ReqReasonList ReqPara)
        {

            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getReasonList(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DemandPortal.ReasonList, 0);
            }
            return Response;
        }
        //Reject Order List

        [HttpPost]
        [Route(APIRoute.DemandPortal.RejectOrderList)]
        public async Task<ResponceList>  RejectOrderList(ReqRejectOrderList ReqPara)
        {
            string email = ReqPara.Email;
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetRejectOrderList(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                    string bodytext = "Order Is Rejected By Admin.";
                    string sessionVal = obj.SendMailDynamic(email, bodytext, "Order Status", "Your Order Status Update");
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DemandPortal.RejectOrderList, Convert.ToInt64(ReqPara.OrderId));

                return Response;
            }
        }

        //Sales Order Test API
        [HttpPost]
        [Route(APIRoute.DemandPortal.SalesOrderReq)]
        public async Task<Responce> getSalesOrderReq(reqSalesOrder ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.SalesNotification(Convert.ToInt64(ReqPara.OrderId));
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DemandPortal.SalesOrderReq, 0);
            }
            return Response;
        }
        //Sales Order Test API

        //Template View
        [HttpPost]
        [Route(APIRoute.DemandPortal.TemplateViewOrder)]
        public async Task<ResponceList>  TemplateViewOrder(reqTemplateView ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getTemplateOrderView(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DemandPortal.TemplateViewOrder, Convert.ToInt64(ReqPara.TemplateID));

                return Response;
            }
        }

        [HttpPost]
        [Route(APIRoute.DemandPortal.GetRegiClientList)]
        public async Task<ResponceList>  GetRegiClientList()
        {
            ResponceList Response = new ResponceList();
            try
            {
                JsonElement result = await obj.getDpClientList();
                Response = ResponceResult.SuccessResponseList(result);
                return Response;
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DemandPortal.UserLogin, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.DemandPortal.ViewDashboardOrder)]
        public async Task<ResponceList>  ViewDashboardOrder(reqTopFiveOrderList ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.ViewTopFiveOrder(ReqPara);
                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DemandPortal.ViewDispatchOrder, Convert.ToInt64(ReqPara.UserId));
            }
            return Response;
        }

        // Delete Order
        [HttpPost]
        [Route(APIRoute.DemandPortal.deleteOrder)]
        public Responce deleteOrder(reqDeleteOrderId ReqPara)
        {
            string result = "";

            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    result = obj.removeOrder(ReqPara);

                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                    }
                    else
                    {
                        Response = ResponceResult.ValidateResponse(result);
                    }
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponse(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DemandPortal.deleteOrder, Convert.ToInt64(ReqPara.UserId));
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.DemandPortal.UserReport)]
        public async Task<ResponceList>  UserReport(reqUserReport ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.getUserTypeReport(ReqPara);

                    Response = ResponceResult.SuccessResponseList(result);
                    return Response;
                }
                else
                {
                    Response = ResponceResult.ErrorResponseList("No record found..!");
                    return Response;
                }
            }
            catch (Exception ex)
            {
                Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
                exe.ErrorLog(ex.Message.ToString(), APIRoute.DemandPortal.UserReport, 0);

                return Response;
            }
        }
    }
}
