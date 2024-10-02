using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WMSWebAPI.Models.V1.Request;
using System.Security.Cryptography;
using System.IO;
using System.Net.Mail;
using System.Data;
using System.Text;
using System.Text.Json;

namespace WMSWebAPI.Utility.V1
{
    public class SubscriptionUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        SqlParameter[] userparam;
        public SubscriptionUtility()
        {
            obj = new DBActivity();
        }

        #region Dummy Company Customer User Registration and mail send
        //public string InsertRegistration(RegistrationDetaills req)
        //{
        //    string password = CreatePassword(7);
        //    string encriptPassword = encryptstring(password);
        //    encriptPassword = "|@|" + encriptPassword;

        //    param = new SqlParameter[]
        //            {                      
        //                new SqlParameter("@CompanyName", req.CompanyName),
        //                new SqlParameter("@Website", req.Website),
        //                new SqlParameter("@EmailID", req.EmailID),
        //                new SqlParameter("@Address", req.Address),
        //                new SqlParameter("@Landmark", req.PhoneNo),
        //                new SqlParameter("@Country", req.Country),
        //                new SqlParameter("@State", req.State),
        //                new SqlParameter("@City", req.City),
        //                new SqlParameter("@ZipCode", req.ZipCode),
        //                new SqlParameter("@PhoneNo", req.PhoneNo),
        //                new SqlParameter("@Logopath", req.Logopath),
        //                new SqlParameter("@FirstName", req.FirstName),
        //                new SqlParameter("@LastName", req.LastName),
        //                new SqlParameter("@UserEmail", req.UserEmail),
        //                new SqlParameter("@UserName", req.UserName),
        //                new SqlParameter("@Password", encriptPassword),                  
        //            };

        //    return obj.Return_ScalerValue("sub_InsertRegisterDetails", param);
        //}
        public string InsertRegistration(RegistrationDetaills req)
        {
            string password = CreatePassword(7);
            string encriptPassword = encryptstring(password);
            encriptPassword = "|@|" + encriptPassword;

            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyName", req.CompanyName),
                        new SqlParameter("@Website", req.Website),
                        new SqlParameter("@EmailID", req.EmailID),
                        new SqlParameter("@Address", req.Address),
                        new SqlParameter("@Landmark", req.PhoneNo),
                        new SqlParameter("@Country", req.Country),
                        new SqlParameter("@State", req.State),
                        new SqlParameter("@City", req.City),
                        new SqlParameter("@ZipCode", req.ZipCode),
                        new SqlParameter("@PhoneNo", req.PhoneNo),
                        new SqlParameter("@Logopath", req.Logopath),
                        new SqlParameter("@FirstName", req.FirstName),
                        new SqlParameter("@LastName", req.LastName),
                        new SqlParameter("@UserEmail", req.UserEmail),
                        new SqlParameter("@UserName", req.UserName),
                        new SqlParameter("@Password", encriptPassword),
                        new SqlParameter("@PlanID",Int32.Parse(req.PlanID)),
                        new SqlParameter("@PaymentId", Int32.Parse(req.PaymentId)),
                        new SqlParameter("@CustSubHeadId", Int32.Parse(req.CustSubHeadId)),
                        new SqlParameter("@TransactionReference", req.TransactionReference),
                        new SqlParameter("@PeriodType", req.PeriodType)
                    };

            return obj.Return_ScalerValue("sub_InsertRegisterDetails", param);
        }
        public string CreatePassword(int length)
        {
            const string valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder res = new StringBuilder();
            Random rnd = new Random();
            while (0 < length--)
            {
                res.Append(valid[rnd.Next(valid.Length)]);
            }
            return res.ToString();
        }

        public static string encryptstring(string encryptString)
        {
            string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }

        public string SendMailDynamic(long UserID)
        {
            DataSet userds = new DataSet();
            string EmailId = "", useremailname = "", username = "", Password = "";
            string bodytest = "You have successfully Registered into system,please find below login details";
            string Subject = "New User Login Details";
            userparam = new SqlParameter[]
                   {
                        new SqlParameter("@UserId", UserID)
                   };
            userds = obj.Return_DataSet("User_SendpasswordEmail", userparam);
            if (userds.Tables[0].Rows.Count > 0)
            {
                EmailId = userds.Tables[0].Rows[0]["EmailID"].ToString();
                useremailname = userds.Tables[0].Rows[0]["UserfullName"].ToString();
                username = userds.Tables[0].Rows[0]["UserName"].ToString();
                Password = userds.Tables[0].Rows[0]["Password"].ToString();
            }

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
                    emailParaD req = new emailParaD();
                    Email_host = req.Email_host = ds.Tables[0].Rows[i]["EmailHost"].ToString();
                    Email_password = req.Email_password = ds.Tables[0].Rows[i]["EmailPassword"].ToString();
                    Email_port = req.Email_port = ds.Tables[0].Rows[i]["EmailPort"].ToString();
                    from = req.from = ds.Tables[0].Rows[i]["EmailUsername"].ToString();

                }
            }

            string MailStatus = "";
            string to = EmailId; //To address    
                                 //string from = "mailto:development@brilliantinfosys.com"; //From address    
                                 //string Email_host = System.Configuration.ConfigurationManager.AppSettings["Email_host"];
                                 //string Email_password = System.Configuration.ConfigurationManager.AppSettings["Email_password"];
                                 //string Email_port = System.Configuration.ConfigurationManager.AppSettings["Email_port"];
                                 //string from = System.Configuration.ConfigurationManager.AppSettings["Email_userName"];
            MailMessage message = new MailMessage(from, to);

            string MailBody = "";
            MailBody = " <div style='font-family: Helvetica,Arial,sans - serif; min - width:1000px; overflow: auto; line - height:2'>";
            MailBody = MailBody + " <div style='margin: 50px auto; width: 70 %; padding: 20px 0'>";
            MailBody = MailBody + "   <div style='border - bottom:1px solid #eee'>";
            // MailBody = MailBody + "    <a href=''style='font-size:1.4em; color: #00466a;text-decoration:none;font-weight:600'>" + heading + "</a>";
            MailBody = MailBody + " </div>";
            MailBody = MailBody + " <p style='font-size:1.1em'> Dear  " + useremailname + "</p>";
            MailBody = MailBody + "<p>" + bodytest + "</p>";
            MailBody = MailBody + "<p> User Name: " + username + "</p>";
            MailBody = MailBody + "<p> Password: " + Password + "</p>";
            MailBody = MailBody + "<p> Please Click here to Login: <a href='http://173.212.244.46/BWMSWebApp2.2/Public/Login.html'>Login</a></p>";
            //MailBody = MailBody + " <h2 style='background: #00466a;margin: 0 auto;width: max-content;padding: 0 10px;color: #fff;border-radius: 4px;'>" + OTPMessage + "</h2>";
            MailBody = MailBody + "<p style='font-size:0.9em;'>Thanks & Regards,<br /> Support Team </p>";
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

        public string UtlRegCheckusername(SubReqCheckUsername req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@username", req.UserName)
                    };
            return obj.Return_ScalerValue("sub_RegcheckUserName", param);
        }

        #endregion

        #region Get Company/Customer Subscription and Invoice details
        public async Task<JsonElement> UtlGetSubscription(ReqGetSubscription req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyID", req.CompanyID),
                        new SqlParameter("@CustomerID", req.CustomerID),
                        new SqlParameter("@UserID", req.UserID),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sub_GetSubscriptionDetails", param));
        }

        public async Task<JsonElement> utlGetInvoiceRpt(ReqGetInvoiceRpt req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyID", req.CompanyID),
                        new SqlParameter("@CustomerID", req.CustomerID),
                        new SqlParameter("@InvoiceID", req.InvoiceID),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Inv_GetInvoicetoPrint", param));
        }

        public async Task<JsonElement> UtlGetSubscriptionPlans(ReqGetSubscriptionPlans req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@PlanCode", req.PlanCode),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sub_GetSubscriptionPlan", param));
        }

        public async Task<JsonElement> utlGetInvoiceDetails(ReqGetInvoiceDetails req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyID", req.CompanyID),
                        new SqlParameter("@CustomerID", req.CustomerID),
                        new SqlParameter("@UserID", req.UserID),
                        new SqlParameter("@PlanCode", req.PlanCode),
                        new SqlParameter("@PlanTitle", req.PlanTitle),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Inv_GetInvoiceDetails", param));
        }
        #endregion

        #region Add Dummy Data
        public string UtlInsertDummyData(ReqAddDummyData req)
        {
            string Result = "Fail", MsstwearDataresult = "", warehousrid = "0", masterresult = "", Inboudresult = "", outboundresult = "";

            MsstwearDataresult = InsertMasterData(req);
            masterresult = MsstwearDataresult.Substring(0, 7);
            warehousrid = MsstwearDataresult.Substring(7);

            if (masterresult == "success")
            {
                Inboudresult = InsertInboundData(req, Convert.ToInt64(warehousrid));
                if (Inboudresult == "success")
                {
                    outboundresult = InsertOutbndData(req, Convert.ToInt64(warehousrid));
                    if (outboundresult == "success")
                    {
                        Result = "success";
                    }
                }
            }
            return Result;
        }

        public string InsertMasterData(ReqAddDummyData req)
        {
            param = new SqlParameter[]
                                {
                        new SqlParameter("@companyid", req.companyid),
                        new SqlParameter("@userid", req.userid),
                        new SqlParameter("@customerid", req.customerid),
            };
            return obj.Return_ScalerValue("AddMasterData", param);
        }

        public string InsertInboundData(ReqAddDummyData req, long WarehouseID)
        {
            param = new SqlParameter[]
                                {
                        new SqlParameter("@companyid", req.companyid),
                        new SqlParameter("@customerid", req.customerid),
                        new SqlParameter("@warehouseid", WarehouseID),
                        new SqlParameter("@userid", req.userid),
            };
            return obj.Return_ScalerValue("AddInwardData", param);
        }

        public string InsertOutbndData(ReqAddDummyData req, long WarehouseID)
        {
            param = new SqlParameter[]
                                {
                        new SqlParameter("@companyid", req.companyid),
                        new SqlParameter("@userid", req.userid),
                        new SqlParameter("@customerid", req.customerid),
                        new SqlParameter("@warehouseid", WarehouseID),
            };
            return obj.Return_ScalerValue("AddOutwardData", param);
        }

        public string utlCheckDummyData(ReqCheckDummyData req)
        {
            param = new SqlParameter[]
                                {
                        new SqlParameter("@CompanyID", req.CompanyID),
                        new SqlParameter("@CustomerID", req.CustomerID),
                        new SqlParameter("@UserID", req.UserID),
            };
            return obj.Return_ScalerValue("Dum_CheckDummyDataPresent", param);
        }
        #endregion

        #region Code to save Subscription plan after payment done
        public string utlSaveSubscribeplan(ReqSaveSubscribePlan req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyID", req.CompanyID),
                        new SqlParameter("@CustomerID", req.CustomerID),
                        new SqlParameter("@UserID", req.UserID),
                        new SqlParameter("@PlanID", req.PlanID),
                        new SqlParameter("@PlanAmount", req.PlanAmount),
                        new SqlParameter("@Discount", req.Discount),
                        new SqlParameter("@TotalTax", req.TotalTax),
                        new SqlParameter("@TransactionNo", req.TransactionNo),
                        new SqlParameter("@paymentmethod", req.paymentmethod),
                    };
            return obj.Return_ScalerValue("sub_SaveSubscribedPlan", param);
        }

        #endregion

        #region Remove Dummy Data
        public string UtlRemoveDummyData(ReqRemoveDummyData req)
        {
            string Result = "Fail", InResult = "", outResult = "", masterResult = "";
            InResult = RemoveInwardDumyData(req);
            if (InResult == "success")
            {
                outResult = RemoveOutwardDumyData(req);
                if (outResult == "success")
                {
                    masterResult = RemoveMasterDumyData(req);
                    if (masterResult == "success")
                    {
                        Result = "success";
                    }
                }
            }
            return Result;
        }

        public string RemoveInwardDumyData(ReqRemoveDummyData req)
        {
            param = new SqlParameter[]
           {
                new SqlParameter("@companyid",req.CompanyID),
                new SqlParameter("@customerid",req.CustomerID),
                new SqlParameter("@userid",req.UserID),
           };
            return obj.Return_ScalerValue("Rem_RmvInwardDummyData", param);
        }

        public string RemoveOutwardDumyData(ReqRemoveDummyData req)
        {
            param = new SqlParameter[]
           {
                new SqlParameter("@companyid",req.CompanyID),
                new SqlParameter("@customerid",req.CustomerID),
                new SqlParameter("@userid",req.UserID),
           };
            return obj.Return_ScalerValue("Rem_RmvOutwardDummyData", param);
        }
        public string RemoveMasterDumyData(ReqRemoveDummyData req)
        {
            param = new SqlParameter[]
           {
                new SqlParameter("@companyid",req.CompanyID),
                new SqlParameter("@customerid",req.CustomerID),
                new SqlParameter("@userid",req.UserID),
           };
            return obj.Return_ScalerValue("Rem_RmvMasterDummyData", param);
        }

        #endregion

        public string utlContactUsForm(ContactUsForm req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyName", req.CompanyName),
                        new SqlParameter("@ContactPerson", req.ContactPerson),
                        new SqlParameter("@Email", req.EmailID),
                        new SqlParameter("@ContactNo", req.ContactNo),
                        new SqlParameter("@City", req.City),
                        new SqlParameter("@State", req.State),
                        new SqlParameter("@Country", req.Country),
                        new SqlParameter("@PlanDetails", req.PlanDetails),
                    };
            return obj.Return_ScalerValue("sp_contactusform", param);
        }

        public string SendContactUsMailDynamic(string EmailId, string ContactPerson, string bodytest, string Subject)
        {
            DataSet ds = new DataSet();
            String jsonString = String.Empty;
            //string Email_host = "mail.brilliantwms.com";
            //string Email_password = "Easycloudwms@123456";
            //string Email_port = "587";
            //string from = "contactus@easycloudwms.com";
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
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    Models.V1.emailPara req = new Models.V1.emailPara();
                //    Email_host = req.Email_host = ds.Tables[0].Rows[i]["EmailHost"].ToString();
                //    Email_password = req.Email_password = ds.Tables[0].Rows[i]["EmailPassword"].ToString();
                //    Email_port = req.Email_port = ds.Tables[0].Rows[i]["EmailPort"].ToString();
                //    from = req.from = ds.Tables[0].Rows[i]["EmailUsername"].ToString();
                //}
            }
            string MailStatus = "";
            string to = EmailId;
            MailMessage message = new MailMessage(from, to);

            string MailBody = "";
            MailBody = " <div style='font-family: Helvetica,Arial,sans - serif; min - width:1000px; overflow: auto; line - height:2'>";
            MailBody = MailBody + " <div style='width: 70 %; padding: 20px 0'>";
            MailBody = MailBody + "   <div style='border - bottom:1px solid #eee'>";
            MailBody = MailBody + " </div>";
            MailBody = MailBody + " <p style='font-size:1.1em'> Dear  " + ContactPerson + "</p>";
            MailBody = MailBody + "<p>" + bodytest + "</p>";
            MailBody = MailBody + "<p style='font-size:0.9em;'>Happy Warehousing! </p>";
            MailBody = MailBody + "<p style='font-size:0.9em;'>Best regards,<br /> Team EasyCloud WMS. </p>";
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
            System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential(from, Email_password);
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
            }
            return MailStatus;
        }

        public string MailToSupportteam(string CompanyName, string ContactPerson, string EmailId, string ContactNo, string PlanDetails, string Address)
        {
            DataSet ds = new DataSet();
            //string Email_host = "mail.brilliantwms.com";
            //string Email_password = "Easycloudwms@123456";
            //string Email_port = "587";
            //string from = "contactus@easycloudwms.com";
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
                //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                //{
                //    Models.V1.emailPara req = new Models.V1.emailPara();
                //    Email_host = req.Email_host = ds.Tables[0].Rows[i]["EmailHost"].ToString();
                //    Email_password = req.Email_password = ds.Tables[0].Rows[i]["EmailPassword"].ToString();
                //    Email_port = req.Email_port = ds.Tables[0].Rows[i]["EmailPort"].ToString();
                //    from = req.from = ds.Tables[0].Rows[i]["EmailUsername"].ToString();
                //}
            }

            string MailStatus = "";
            string to = "contactus@easycloudwms.com";
            // string to = "rahul@brilliantinfosys.com";
            MailMessage message = new MailMessage(from, to);

            string MailBody = "";
            MailBody = " <div style='font-family: Helvetica,Arial,sans - serif; min - width:1000px; overflow: auto; line - height:2'>";
            MailBody = MailBody + " <div style='width: 70 %; padding: 20px 0'>";
            MailBody = MailBody + "   <div style='border - bottom:1px solid #eee'>";
            // MailBody = MailBody + "    <a href=''style='font-size:1.4em; color: #00466a;text-decoration:none;font-weight:600'>" + heading + "</a>";
            MailBody = MailBody + " </div>";
            MailBody = MailBody + " <p style='font-size:1.1em'> Dear Sales Team</p>";
            MailBody = MailBody + "<p>  Enquiry is generated from below Details. </p>";
            MailBody = MailBody + "<p> Company Name : " + CompanyName + "</p>";
            MailBody = MailBody + "<p> Contact Person : " + ContactPerson + "</p>";
            MailBody = MailBody + "<P> Email ID : " + EmailId + " </p>";
            MailBody = MailBody + "<P> Contact No. : " + ContactNo + " </p>";
            MailBody = MailBody + "<P> Selected Plan : " + PlanDetails + " </p>";
            MailBody = MailBody + "<P> Address : " + Address + " </p>";
            MailBody = MailBody + "<p style='font-size:0.9em;'>Thanks & Regards,<br /> Team EasyCloud WMS </p>";
            MailBody = MailBody + "<hr style='border:none; border-top:1px solid #eee '/>";
            MailBody = MailBody + " <div style='float:right; padding: 8px 0; color:#aaa;font-size:0.8em;line-height:1;font-weight:300'>";
            MailBody = MailBody + "</div>";
            MailBody = MailBody + " </div>";
            MailBody = MailBody + "</div>";

            message.Subject = "Easy Cloude WMS Enquiry From Website";
            message.Body = MailBody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient(Email_host, int.Parse(Email_port)); //Gmail smtp 
            System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential(from, Email_password);
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
            }
            return MailStatus;
        }
        public string utlCheckSubScription(CheckSubscription req)
        {
            param = new SqlParameter[]
                                {
                        new SqlParameter("@CompanyID", req.CompanyID),
                        new SqlParameter("@CustomerID", req.CustomerID),
                        new SqlParameter("@UserID", req.UserID),
            };
            return obj.Return_ScalerValue("checksubscription", param);
        }

        public async Task<JsonElement> utlgetWarehouseIDandName(getWarehouseIDandName req)

        {
            param = new SqlParameter[]
                                {
                        new SqlParameter("@CompanyID", req.CompanyID),
                        new SqlParameter("@CustomerID", req.CustomerID),
                        new SqlParameter("@UserID", req.UserID),
            };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("getWarehouseIDandName", param));
        }
        public string UpdateTransaction(UpdateTransactionRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@OrderId", Int32.Parse(req.OrderId)),
                        new SqlParameter("@CompanyId", Int32.Parse(req.CompanyId)),
                        new SqlParameter("@CustomerId", Int32.Parse(req.CustomerId)),
                        new SqlParameter("@Discount", Int32.Parse(req.Discount)),
                        new SqlParameter("@TotalAmount", Int32.Parse(req.TotalAmount)),
                        new SqlParameter("@TransactionID", Int32.Parse(req.TransactionID)),
                        new SqlParameter("@TransactionID1", Int32.Parse(req.TransactionID1)),
                        new SqlParameter("@TransactionID2", Int32.Parse(req.TransactionID2)),
                    };
            return obj.Return_ScalerValue("sp_UpdateTransaction", param);
        }
        public async Task<JsonElement> Checklimit(ChecklimitRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                  };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_Checklimit", param));
        }
    }
}
