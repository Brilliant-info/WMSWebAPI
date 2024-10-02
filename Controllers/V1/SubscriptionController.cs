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
    public class SubscriptionController : ControllerBase
    {
        SubscriptionUtility obj = new SubscriptionUtility();
        SysException exe = new SysException();

        #region Dummy Company Customer User Registration and mail send
        [HttpPost]
        [Route(APIRoute.Subscription.DemoRegistration)]
        public async Task<Responce> DemoRegistration(RegistrationDetaills ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.InsertRegistration(ReqPara);

                    string successresult = result.Substring(0, 7);
                    string userID = result.Substring(7);

                    if (successresult == "success")
                    {
                        Response = ResponceResult.SuccessResponse(successresult);
                        //  long checkuser = Int64.Parse(ReqPara.UserId);
                        //   if (checkuser == 0)
                        //  {
                        string mailsendresult = obj.SendMailDynamic(Convert.ToInt64(userID));
                        //   }
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.DemoRegistration, 0);
            }
            return Response;

        }
        [HttpPost]
        [Route(APIRoute.Subscription.Checkusername)]
        public async Task<Responce> Checkusername(SubReqCheckUsername ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.UtlRegCheckusername(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.Checkusername, 0);
            }
            return Response;

        }

        #endregion

        #region Get Company/Customer Subscription and Invoice details
        [HttpPost]
        [Route(APIRoute.Subscription.GetSubscriptiondetail)]
        public async Task<ResponceList> GetSubscriptiondetail(ReqGetSubscription ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.UtlGetSubscription(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.GetSubscriptiondetail, ReqPara.UserID);
            }
            return Response;
        }



        [HttpPost]
        [Route(APIRoute.Subscription.GetSubscriptionPlans)]
        public async Task<ResponceList> GetSubscriptionPlans(ReqGetSubscriptionPlans ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.UtlGetSubscriptionPlans(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.GetSubscriptionPlans, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Subscription.GetInvoiceRpt)]
        public async Task<ResponceList> GetInvoiceRpt(ReqGetInvoiceRpt ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.utlGetInvoiceRpt(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.GetInvoiceRpt, 0);
            }
            return Response;
        }


        [HttpPost]
        [Route(APIRoute.Subscription.GetInvoiceDetails)]
        public async Task<ResponceList> GetInvoiceDetails(ReqGetInvoiceDetails ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.utlGetInvoiceDetails(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.GetInvoiceDetails, ReqPara.UserID);
            }
            return Response;
        }
        #endregion

        #region Add Dummy Data
        [HttpPost]
        [Route(APIRoute.Subscription.InsertDummyData)]
        public async Task<Responce> InsertDummyData(ReqAddDummyData ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.UtlInsertDummyData(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.InsertDummyData, ReqPara.userid);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Subscription.CheckDummyData)]
        public async Task<Responce> CheckDummyData(ReqCheckDummyData ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.utlCheckDummyData(ReqPara);
                    if (result == "success" || result == "DirectLogin")
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.CheckDummyData, ReqPara.UserID);
            }
            return Response;
        }
        #endregion

        #region Code to save Subscription plan after payment done
        [HttpPost]
        [Route(APIRoute.Subscription.SaveSubscribeplan)]
        public async Task<Responce> SaveSubscribeplan(ReqSaveSubscribePlan ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.utlSaveSubscribeplan(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.SaveSubscribeplan, ReqPara.UserID);
            }
            return Response;
        }

        #endregion


        #region Remove Dummy Data
        [HttpPost]
        [Route(APIRoute.Subscription.RemoveDummyData)]
        public async Task<Responce> RemoveDummyData(ReqRemoveDummyData ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.UtlRemoveDummyData(ReqPara);
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.RemoveDummyData, ReqPara.UserID);
            }
            return Response;
        }
        #endregion

        [HttpPost]
        [Route(APIRoute.Subscription.ContactUsForm)]
        public async Task<Responce> ContactUsForm(ContactUsForm ReqPara)
        {
            string CompanyName = "", ContactNo = "", Address = "", PlanDetails = "";
            string EmailId = ReqPara.EmailID;
            string ContactPerson = ReqPara.ContactPerson;
            CompanyName = ReqPara.CompanyName; ContactNo = ReqPara.ContactNo; PlanDetails = ReqPara.PlanDetails;
            Address = ReqPara.City + ", " + ReqPara.State + ", " + ReqPara.Country;
            string bodytest = "Thank You for getting in touch with EasyCloud WMS. Our Sales team will contact you shortly.";
            string Subject = "Thanks for reaching out – Team EasyCloud WMS";
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.utlContactUsForm(ReqPara);
                    if (result == "success")
                    {
                        Response = ResponceResult.SuccessResponse(result);
                        //  long checkuser = Int64.Parse(ReqPara.UserId);
                        //   if (checkuser == 0)
                        //  {
                        string mailsendresult = obj.SendContactUsMailDynamic(EmailId, ContactPerson, bodytest, Subject);
                        string mailtosupport = obj.MailToSupportteam(CompanyName, ContactPerson, EmailId, ContactNo, PlanDetails, Address);
                        //   }
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.ContactUsForm, 0);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Subscription.CheckSubScription)]
        public async Task<Responce> CheckSubScription(CheckSubscription ReqPara)
        {
            Responce Response = new Responce();
            try
            {
                if (ReqPara != null)
                {
                    string result = obj.utlCheckSubScription(ReqPara);
                    if (result == "Success" || result == "Fail")
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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.CheckSubScription, ReqPara.UserID);
            }
            return Response;
        }

        [HttpPost]
        [Route(APIRoute.Subscription.getWarehouseIDandName)]
        public async Task<ResponceList> getWarehouseIDandName(getWarehouseIDandName ReqPara)
        {
            ResponceList Response = new ResponceList();
            try
            {
                if (ReqPara != null)
                {
                    JsonElement result = await obj.utlgetWarehouseIDandName(ReqPara);

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
                exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.getWarehouseIDandName, ReqPara.UserID);
            }
            return Response;
        }

        //[HttpPost]
        //[Route(APIRoute.Subscription.UpdateTransaction)]        
        //public async Task<Responce> UpdateTransaction(UpdateTransactionRequest ReqPara)
        //{
        //    Responce Response = new Responce();
        //    try
        //    {
        //        if (ReqPara != null)
        //        {
        //            string result = obj.UpdateTransaction(ReqPara);
        //            if (result == "success")
        //            {
        //                Response = ResponceResult.SuccessResponse(result);
        //            }
        //            else
        //            {
        //                Response = ResponceResult.ValidateResponse(result);
        //            }
        //        }
        //        else
        //        {
        //            Response = ResponceResult.ErrorResponse("Record Not Save..!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Response = ResponceResult.ErrorResponse(ex.Message.ToString());
        //        exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.UpdateTransaction, 0);
        //    }
        //    return Response;
        //}

        //[HttpPost]
        //[Route(APIRoute.Subscription.Checklimit)]
        //public async Task<ResponceList> Checklimit(ChecklimitRequest ReqPara)
        //{
        //    ResponceList Response = new ResponceList();
        //    try
        //    {
        //        if (ReqPara != null)
        //        {
        //            JsonElement result = await obj.Checklimit(ReqPara);

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
        //        exe.ErrorLog(ex.Message.ToString(), APIRoute.Subscription.Checklimit, Int64.Parse(ReqPara.CompanyId));
        //    }
        //    return Response;
        //}

    }
}
