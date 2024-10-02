using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
//using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Web;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class WebSubscriptionUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public WebSubscriptionUtility()
        {
            obj = new DBActivity();
        }

        public async Task<JsonElement> SaveCustSubscription(WebSubscription req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@SubscriptionHeadId", Int64.Parse(req.SubscriptionHeadId)),
                        new SqlParameter("@CompanyName", req.CompanyName),
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@Email", req.Email),
                        new SqlParameter("@phone", req.phone),
                        new SqlParameter("@Address", req.Address),
                        new SqlParameter("@ContactPerson", req.ContactPerson),
                        new SqlParameter("@City", req.City),
                        new SqlParameter("@state", req.state),
                        new SqlParameter("@ZipCode", req.ZipCode),
                        new SqlParameter("@country", req.country),
                        new SqlParameter("@SubscriptionType", req.SubscriptionType),
                        new SqlParameter("@SubscriptionTypeId", req.SubscriptionTypeId),
                        new SqlParameter("@NoOfUsers", Int64.Parse(req.NoOfUsers)),
                        new SqlParameter("@NoOfWarehouse", Int64.Parse(req.NoOfWarehouse)),
                        new SqlParameter("@TaxType", req.TaxType),
                        new SqlParameter("@TaxId", req.TaxId),
                        new SqlParameter("@PackagePeroid", req.PackagePeriod)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_SaveCustSubscription", param));
        }


        public async Task<JsonElement> SaveSubscriptionPaymentDetails(GetPaymentDetailsSaveRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustSubHeadId", Int64.Parse(req.CustSubHeadId)),
                        new SqlParameter("@PackageId", Int64.Parse(req.PackageId)),
                        new SqlParameter("@TransactionType", req.TransactionType),
                        new SqlParameter("@TotalUsers", req.TotalUsers),
                        new SqlParameter("@AdditionalUsers", req.AdditionalUsers),
                        new SqlParameter("@SubTotal", req.SubTotal),
                        new SqlParameter("@CouponId", Int64.Parse(req.CouponId)),
                        new SqlParameter("@DiscountInPercent",Decimal.Parse(req.DiscountInPercent)),
                        new SqlParameter("@Discount",Decimal.Parse(req.Discount)),
                        new SqlParameter("@TaxInPercent",Decimal.Parse(req.TaxInPercent)),
                        new SqlParameter("@TaxNetPayment",Decimal.Parse(req.TaxNetPayment)),
                        new SqlParameter("@TransactionId", Int64.Parse(req.TransactionId)),
                        new SqlParameter("@TransactionStatus", req.TransactionStatus),
                        new SqlParameter("@TransactionBy", req.TransactionBy)

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_SavePaymentDetails", param));
        }


        public string UpdateCustSubscriptionHead(UpdateCustSubscriptionHeadRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId",Int64.Parse(req.CompanyId)),
                        new SqlParameter("@NoOfUsers",Int64.Parse(req.NoOfUsers)),
                        new SqlParameter("@NoOfWarehouse",Int64.Parse(req.NoOfWarehouse))
                    };
            return obj.Return_ScalerValue("sp_UpdateCustSubscriptionHead", param);
        }

        public async Task<JsonElement> UpdatePaymentDetails(UpdatePaymentDetailsRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ID",Int64.Parse(req.ID)),
                        new SqlParameter("@CustSubHeadId",Int64.Parse(req.CustSubHeadId)),
                        new SqlParameter("@TransactionId",Int64.Parse(req.TransactionId)),
                        new SqlParameter("@TransactionReference",req.TransactionReference),
                        new SqlParameter("@TransactionStatus",req.TransactionStatus),
                        new SqlParameter("@TransactionBy",req.TransactionBy)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_UpdatePaymentDetails", param));
        }


        public async Task<JsonElement> GetCouponID(GetCouponIDRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CouponCode", req.CouponCode)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_CouponMasterGetIDNew", param));
        }

        public async Task<JsonElement> CustomerDetailList(CustomerDetailListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ID",Int64.Parse(req.ID))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_CustomerdetailslistNew", param));


        }

        public async Task<JsonElement> SendEmailOtp(SendEmailOtpRequest req)
        {
            string getOtp = CreateEmailOTP();
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Email",(req.Email)),
                        new SqlParameter("@OTP",getOtp)
                    };
            DataSet spOtpResult = obj.Return_DataSet("SendEmailOtp", param);
            string readDsResult = spOtpResult.Tables[0].Rows[0]["Status"].ToString().ToLower();
            if (readDsResult.Trim() == "success")
            {
                string isEmailSent = SendMailEmailOtp(req.Email, getOtp);
            }
            return await obj.ConvertDataSetToJObject(spOtpResult);
        }

        private string SendMailEmailOtp(string EmailId, string EmailOtp)
        {
            DataSet userds = new DataSet();
            string bodytest = "Please use following OTP to validate your email address on EasyCloudWMS website for WMS package purchase.";
            string Subject = "OTP to validate Email for EasyCloudWMS Package";

            DataSet ds = new DataSet();
            String jsonString = String.Empty;
            string Email_host = "";
            string Email_password = "";
            string Email_port = "";
            string from = "";

            param = new SqlParameter[]
                   {

                   };
            ds = obj.Return_DataSet("sp_emailDetails", param);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    emailParaU req = new emailParaU();
                    Email_host = req.Email_host = ds.Tables[0].Rows[i]["EmailHost"].ToString();
                    Email_password = req.Email_password = ds.Tables[0].Rows[i]["EmailPassword"].ToString();
                    Email_port = req.Email_port = ds.Tables[0].Rows[i]["EmailPort"].ToString();
                    from = req.from = ds.Tables[0].Rows[i]["EmailUsername"].ToString();

                }
            }

            string MailStatus = "";
            string to = EmailId;
            MailMessage message = new MailMessage(from, to);

            string MailBody = "";
            MailBody = " <div style='font-family: Helvetica,Arial,sans - serif; min - width:1000px; overflow: auto; line - height:2'>";
            MailBody = MailBody + " <div style='margin: 50px auto; width: 70 %; padding: 20px 0'>";
            MailBody = MailBody + "   <div style='border - bottom:1px solid #eee'>";
            // MailBody = MailBody + "    <a href=''style='font-size:1.4em; color: #00466a;text-decoration:none;font-weight:600'>" + heading + "</a>";
            MailBody = MailBody + " </div>";
            MailBody = MailBody + " <p style='font-size:1.1em'> Dear Sir/Madam,</p>";
            MailBody = MailBody + "<p>" + bodytest + "</p>";
            MailBody = MailBody + "<p> OTP to Validate: <b>" + EmailOtp + "</b></p>";
            MailBody = MailBody + "<p style='font-size:0.9em;'>Thanks & Regards,<br /> EasyCloudWMS Support Team </p>";
            MailBody = MailBody + "<hr style='border:none; border-top:1px solid #eee '/>";
            MailBody = MailBody + " <div style='float:right; padding: 8px 0; color:#aaa;font-size:0.8em;line-height:1;font-weight:300'>";
            MailBody = MailBody + "</div>";
            MailBody = MailBody + " </div>";
            MailBody = MailBody + "</div>";

            message.Subject = Subject;
            message.Body = MailBody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient(Email_host, int.Parse(Email_port)); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential(from, Email_password);
            client.EnableSsl = false;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
                MailStatus = "success";
            }

            catch (Exception ex)
            {
                MailStatus = ex.Message;
                //throw ex;

            }

            return MailStatus;

        }

        public async Task<JsonElement> SendSMSOtp(SendSMSOtpRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Mobile",(req.Mobile)),
                        new SqlParameter("@OTP",(req.OTP))

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SendSMSOtp", param));
        }

        public async Task<JsonElement> EmailOtpVerification(EmailOtpVerificationRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Email",(req.Email)),
                        new SqlParameter("@OTP",(req.OTP))

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_VerifyEmailOtp", param));
        }


        public async Task<JsonElement> MobileOtpVerification(MobileOtpVerificationRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Mobile",(req.Mobile)),
                        new SqlParameter("@OTP",(req.OTP))

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_SendMobileOtpVerification", param));
        }

        private string CreateEmailOTP()
        {
            int length = 6;
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        private string CreatePhoneOTP()
        {
            int length = 4;
            const string valid = "1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        public async Task<JsonElement> CheckUserNameAvailability(CheckUserNameAvailability req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserName",(req.UserName))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_CheckUserNameAvailability", param));
        }

        //public async Task<JsonElement> RazorPayClientCreateOrder(RazorPayClientCreateOrderRequest req)
        //{
        //    ServicePointManager.Expect100Continue = true;
        //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

        //    string getAPI_Key = req.ApiKey;
        //    string getDbApiKey = "";
        //    string getDbApiKeySecret = "";
        //    try
        //    {
        //        param = new SqlParameter[]
        //                {
        //                new SqlParameter("@apikey",(req.ApiKey))
        //                };

        //        DataSet apiObject = obj.Return_DataSet("SP_GetPaymentAPIDetails", param);
        //        getDbApiKey = apiObject.Tables[0].Rows[0]["APIKey"].ToString();
        //        getDbApiKeySecret = apiObject.Tables[0].Rows[0]["APISecret"].ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        // Do nothing... 
        //    }
        //   JObject jsonObj = new JObject();
            

        //    if (getAPI_Key == getDbApiKey)
        //    {
        //        // Do not store below secret key anywhere  - Use hard code and should not be dynamic
        //        RazorpayClient client = new RazorpayClient(getAPI_Key, getDbApiKeySecret);
        //        Dictionary<string, object> options = new Dictionary<string, object>();
        //        options.Add("amount", req.Amount); // amount in the smallest currency unit
        //        options.Add("receipt", req.Receipt);
        //        options.Add("currency", req.Currency);
        //        Order order = client.Order.Create(options);

        //        string get_id = order.Attributes["id"];
        //        string get_entity = order.Attributes["entity"];
        //        int get_amount = order.Attributes["amount"];
        //        int get_amount_paid = order.Attributes["amount_paid"];
        //        int get_amount_due = order.Attributes["amount_due"];
        //        string get_currency = order.Attributes["currency"];
        //        string get_receipt = order.Attributes["receipt"];
        //        // int get_offer_id = order.Attributes["offer_id"];
        //        string get_status = order.Attributes["status"];
        //        int get_attempts = order.Attributes["attempts"];
        //        // string get_notes = order.Attributes["notes"];
        //        int get_created_at = order.Attributes["created_at"];

                
        //        jsonObj.Add("apistatus", "success");
        //        jsonObj.Add("apimessage", "");
        //        jsonObj.Add("id", get_id);
        //        jsonObj.Add("entity", get_entity);
        //        jsonObj.Add("amount", get_amount);
        //        jsonObj.Add("amount_paid", get_amount_paid);
        //        jsonObj.Add("amount_due", get_amount_due);
        //        jsonObj.Add("currency", get_currency);
        //        jsonObj.Add("receipt", get_receipt);
        //        // jsonObj.Add("offer_id", get_offer_id);
        //        jsonObj.Add("status", get_status);
        //        jsonObj.Add("attempts", get_attempts);
        //        //jsonObj.Add("notes", get_notes);
        //        jsonObj.Add("created_at", get_created_at);
        //    }
        //    else
        //    {
        //        jsonObj.Add("apistatus", "failed");
        //        jsonObj.Add("apimessage", "Invalid API Key!!");
        //    }

        //    return jsonObj;
        //}

        public async Task<JsonElement> GetSubscriptionPaymentList(GetSubscriptionPaymentListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId",(req.CompanyId)),
                        new SqlParameter("@UserId",(req.UserId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetSubscriptionPaymentList", param));
        }
        public async Task<JsonElement> GetSubscriptionTaxList(GetSubscriptionTaxListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@PlanId",(req.PlanId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetSubscriptionTaxList", param));
        }
    }
}
