using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
    public class WebSubscriptionController : ControllerBase
    {
        WebSubscriptionUtility obj = new WebSubscriptionUtility();
        SysException exe = new SysException();

        [HttpPost]
        [Route(APIRoute.Subscription.SaveCustSubscription)]
        public async Task<ResponceList> SaveCustSubscription(WebSubscription ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.SaveCustSubscription(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.SaveCustSubscription, 0);
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.Subscription.SaveSubscriptionPaymentDetails)]
        public async Task<ResponceList> SaveSubscritionPaymentDetails(GetPaymentDetailsSaveRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.SaveSubscriptionPaymentDetails(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.SaveSubscriptionPaymentDetails, 0);
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.Subscription.UpdateCustSubscriptionHead)]
        public async Task<Responce> UpdateCustSubscriptionHead(UpdateCustSubscriptionHeadRequest ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.UpdateCustSubscriptionHead(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.UpdateCustSubscriptionHead, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Subscription.UpdatePaymentDetails)]
        public async Task<ResponceList> UpdatePaymentDetails(UpdatePaymentDetailsRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.UpdatePaymentDetails(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.UpdatePaymentDetails, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Subscription.GetCouponID)]
        public async Task<ResponceList> GetCouponID(GetCouponIDRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetCouponID(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.GetCouponID, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Subscription.CustomerDetailList)]
        public async Task<ResponceList> CustomerDetailList(CustomerDetailListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.CustomerDetailList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.CustomerDetailList, 0);
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.Subscription.SendEmailOtp)]
        public async Task<ResponceList> SendEmailOtp(SendEmailOtpRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.SendEmailOtp(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.SendEmailOtp, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Subscription.SendSMSOtp)]
        public async Task<ResponceList> SendSMSOtp(SendSMSOtpRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.SendSMSOtp(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.SendSMSOtp, 0);
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.Subscription.EmailOtpVerification)]
        public async Task<ResponceList> EmailOtpVerification(EmailOtpVerificationRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.EmailOtpVerification(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.EmailOtpVerification, 0);
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.Subscription.MobileOtpVerification)]
        public async Task<ResponceList> MobileOtpVerification(MobileOtpVerificationRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.MobileOtpVerification(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.MobileOtpVerification, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Subscription.CheckUserNameAvailability)]
        public async Task<ResponceList> CheckUserNameAvailability(CheckUserNameAvailability ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.CheckUserNameAvailability(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.MobileOtpVerification, 0);
            }
            return Response;
        }

        //[HttpPost]
        //[Route(APIRoute.Subscription.RazorPayClientCreateOrder)]
        //public async Task<ResponceList> RazorPayClientCreateOrder(RazorPayClientCreateOrderRequest ReqPara)
        //{
        //    ResponceList Response = new ResponceList();
        //    try
        //    {
        //        if (ReqPara != null)
        //        {
        //            JsonElement result = await obj.RazorPayClientCreateOrder(ReqPara);

        //            Response = ResponceResult.SuccessResponseList(result);
        //        }
        //        else
        //        {
        //            Response = ResponceResult.ErrorResponseList("No record found..!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response = ResponceResult.ErrorResponseList(ex.Message.ToString());
        //        exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.RazorPayClientCreateOrder, 0);
        //    }
        //    return Response;
        //}

        [HttpPost]
        [Route(APIRoute.Subscription.GetSubscriptionPaymentList)]
        public async Task<ResponceList> GetSubscriptionPaymentList(GetSubscriptionPaymentListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetSubscriptionPaymentList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.CustomerDetailList, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Subscription.GetSubscriptionTaxList)]
        public async Task<ResponceList> GetSubscriptionTaxList(GetSubscriptionTaxListRequest ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.GetSubscriptionTaxList(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.CustomerDetailList, 0);
            }
            return Response;
        }
    }
}
