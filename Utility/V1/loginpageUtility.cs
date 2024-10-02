using Microsoft.AspNetCore.Identity.Data;
using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
//using Azure.Core;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;
using DocumentFormat.OpenXml.InkML;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using DocumentFormat.OpenXml.Office2016.Excel;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions; // For GetDisplayUrl()


namespace WMSWebAPI.Utility.V1
{
    public class loginpageUtility
    {

        HttpContext httpContext;
        SqlParameter[] param;
        DBActivity obj;
        public loginpageUtility()
        {
            obj = new DBActivity();
        }
        // Authentication using Token
        /*
        public JObject Getlogin(GetloginRequest req)
        {
            TokenAuthUtility tokenObj = new TokenAuthUtility();
            string GetToken = tokenObj.GenerateTokenCode();
            string EncrypPassword = "|@|" + encryptstring(req.Password);
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserName", req.UserName),
                        new SqlParameter("@Password", req.Password),
                        new SqlParameter("@EncrypPassword", EncrypPassword),
                        new SqlParameter("@Token", GetToken),
                    };
            return obj.ConvertDataSetToJObject(obj.Return_DataSet("LoginWithToken", param));
        }
        */
        // Old Login Method... 

        private string isLocalDevelopement(HttpContext httpContexts)

        {
            string apiRequestedUrl = httpContexts.Request.GetDisplayUrl().ToString();


            string isLocalDev = "no";
            string getRefererUrlSub = apiRequestedUrl.Substring(0, 17);
            if ((getRefererUrlSub == "http://localhost/") || (getRefererUrlSub == "http://localhost:"))
            {
                isLocalDev = "yes";
            }
            return isLocalDev;
        }

        public async Task<JsonElement> Getlogin(GetloginRequest req, HttpContext httpContext1)
        {
            //    if (httpContext1 == null)
            //    {
            //        throw new ArgumentNullException(nameof(httpContext1));
            //    }

            string EncrypPassword = "|@|" + encryptstring(req.Password);
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserName", req.UserName),
                        new SqlParameter("@Password", req.Password),
                        new SqlParameter("@EncrypPassword", EncrypPassword)

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Loginpage", param));

            //string isLocalDev = isLocalDevelopement(httpContext);
            //if ((isLocalDev == "yes"))
            //{
            //    string EncrypPassword = "|@|" + encryptstring(req.Password);
            //    param = new SqlParameter[]
            //            {
            //            new SqlParameter("@UserName", req.UserName),
            //            new SqlParameter("@Password", req.Password),
            //            new SqlParameter("@EncrypPassword", EncrypPassword)

            //            };
            //    return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Loginpage", param));
            //}
            //else
            //{
            //    TokenAuthUtility tokenObj = new TokenAuthUtility();
            //    string GetToken = tokenObj.GenerateTokenCode();
            //    string EncrypPassword = "|@|" + encryptstring(req.Password);
            //    param = new SqlParameter[]
            //            {
            //            new SqlParameter("@UserName", req.UserName),
            //            new SqlParameter("@Password", req.Password),
            //            new SqlParameter("@EncrypPassword", EncrypPassword),
            //            new SqlParameter("@Token", GetToken),
            //            };
            //    return await obj.ConvertDataSetToJObject(obj.Return_DataSet("LoginWithToken", param));
            //}

        }
        public async Task<JsonElement> Getlogin1(GetloginRequest req, HttpContext httpContext1)
        {
        //    if (httpContext1 == null)
        //    {
        //        throw new ArgumentNullException(nameof(httpContext1));
        //    }
            string isLocalDev = isLocalDevelopement(httpContext);
            if ((isLocalDev == "yes"))
            {
                string EncrypPassword = "|@|" + encryptstring(req.Password);
                param = new SqlParameter[]
                        {
                        new SqlParameter("@UserName", req.UserName),
                        new SqlParameter("@Password", req.Password),
                        new SqlParameter("@EncrypPassword", EncrypPassword)

                        };
                return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Loginpage", param));
            }
            else
            {
                TokenAuthUtility tokenObj = new TokenAuthUtility();
                string GetToken = tokenObj.GenerateTokenCode();
                string EncrypPassword = "|@|" + encryptstring(req.Password);
                param = new SqlParameter[]
                        {
                        new SqlParameter("@UserName", req.UserName),
                        new SqlParameter("@Password", req.Password),
                        new SqlParameter("@EncrypPassword", EncrypPassword),
                        new SqlParameter("@Token", GetToken),
                        };
                return await obj.ConvertDataSetToJObject(obj.Return_DataSet("LoginWithToken", param));
            }

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
        public string ResetPassword(ResetPasswordRequest1 req)
        {
            string EncrypOldPassword = "";
            string getOldPassword = req.OldPassword;
            string substr = getOldPassword.Substring(0, 3);
            if (substr.Trim() == "|@|")
            {
                EncrypOldPassword = req.OldPassword;
            }
            else
            {
                EncrypOldPassword = "|@|" + encryptstring(req.OldPassword);
            }
            // string EncrypOldPassword = "|@|" + encryptstring(req.OldPassword);
            string EncrypNewPassword = "|@|" + encryptstring(req.NewPassword);
            param = new SqlParameter[]
                    {

                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@OldPassword", EncrypOldPassword),
                        new SqlParameter("@NewPassword", EncrypNewPassword),
                        new SqlParameter("@UserName", req.UserName),
                    };
            return obj.Return_ScalerValue("Sp_ResetPassword", param);
        }


        public static string Decryptstring(string encryptString)
        {
            string substr = encryptString.Substring(0, 3);
            if (substr.Trim() == "|@|")
            {
                encryptString = encryptString.Remove(0, 3);
            }

            string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            encryptString = encryptString.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    encryptString = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return encryptString;
        }



        public string ForgetPassword(ForgetPasswordRequest req)
        {
            DataSet ds = new DataSet();
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserName", req.UserName),
                        new SqlParameter("@EmailID", req.EmailID)
                    };
            ds = obj.Return_DataSet("Sp_ForgetPassword", param);
            string result = ds.Tables[0].Rows[0]["Result"].ToString();
            if (result == "success")
            {
                string toemail = ds.Tables[0].Rows[0]["EmailID"].ToString();
                string password = ds.Tables[0].Rows[0]["Password"].ToString();
                string body = "Your password is <b>" + password + "</b>,Please Please login using this password";
                string heading = "Forgot Password";
                string Subject = "Forgot Password";

                result = SendMailDynamic(toemail, body, heading, Subject);
            }
            return result;
        }
        public string SendMailDynamic(string EmailId, string bodytest, string heading, string Subject)
        {
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
            MailMessage message = new MailMessage(from, to);

            string MailBody = "";
            MailBody = " <div style='font-family: Helvetica,Arial,sans - serif; min - width:1000px; overflow: auto; line - height:2'>";
            MailBody = MailBody + " <div style='margin: 50px auto; width: 70 %; padding: 20px 0'>";
            MailBody = MailBody + "   <div style='border - bottom:1px solid #eee'>";
            MailBody = MailBody + "    <a href=''style='font-size:1.4em; color: #00466a;text-decoration:none;font-weight:600'>" + heading + "</a>";
            MailBody = MailBody + " </div>";
            MailBody = MailBody + " <p style='font-size:1.1em'> Hello </p>";
            MailBody = MailBody + "<p>" + bodytest + "</p>";
            //MailBody = MailBody + " <h2 style='background: #00466a;margin: 0 auto;width: max-content;padding: 0 10px;color: #fff;border-radius: 4px;'>" + OTPMessage + "</h2>";
            MailBody = MailBody + "<p style='font-size:0.9em;'>Regards,<br /> Support Team </p>";
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

        //Get OTP
        public string GetOTP()
        {

            string alphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string small_alphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";

            string characters = "";

            characters += alphabets + small_alphabets + numbers;
            int length = 4;
            string otp = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (otp.IndexOf(character) != -1);
                otp += character;
            }
            return otp;
        }

        public string ReqOTP(reqOTP req)
        {

            param = new SqlParameter[]
                    {
                        new SqlParameter("@EmailID", req.EmailID),
                        new SqlParameter("@UserName", req.UserName),
                        new SqlParameter("@OTP", req.OTP)
                    };
            return obj.Return_ScalerValue("sendValidtePassOTP", param);
        }

        public string SendPasswordRestMailDynamic(string EmailId, string bodytest)
        {
            string heading = "Reset Password";
            string Subject = "OTP For Reset Your Password";
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
            //string from = "development@brilliantinfosys.com"; //From address    
            //string Email_host = System.Configuration.ConfigurationManager.AppSettings["Email_host"];
            //string Email_password = System.Configuration.ConfigurationManager.AppSettings["Email_password"];
            //string Email_port = System.Configuration.ConfigurationManager.AppSettings["Email_port"];
            //string from = System.Configuration.ConfigurationManager.AppSettings["Email_userName"];
            MailMessage message = new MailMessage(from, Email_password);

            string MailBody = "";
            MailBody = " <div style='font-family: Helvetica,Arial,sans - serif; min - width:1000px; overflow: auto; line - height:2'>";
            MailBody = MailBody + " <div style='margin: 50px auto; width: 70 %; padding: 20px 0'>";
            MailBody = MailBody + "   <div style='border - bottom:1px solid #eee'>";
            MailBody = MailBody + "    <a href=''style='font-size:1.4em; color: #00466a;text-decoration:none;font-weight:600'>" + heading + "</a>";
            MailBody = MailBody + " </div>";
            MailBody = MailBody + " <p style='font-size:1.1em'> Hello </p>";
            MailBody = MailBody + "<p>" + bodytest + "</p>";
            //MailBody = MailBody + " <h2 style='background: #00466a;margin: 0 auto;width: max-content;padding: 0 10px;color: #fff;border-radius: 4px;'>" + OTPMessage + "</h2>";
            MailBody = MailBody + "<p style='font-size:0.9em;'>Regards,<br /> Support Team </p>";
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

        public string checkOTP(reqOTP req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Email", req.EmailID),
                        new SqlParameter("@username", req.UserName),
                        new SqlParameter("@OTP", req.OTP)
                    };
            return obj.Return_ScalerValue("validateOTP", param);

        }
        //Forgot Password Password Reset

        public string newPasswordUpdate(changePassword req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@newPassword", req.Password),
                        new SqlParameter("@username", req.UserName),
                        new SqlParameter("@Email", req.EmailID),
                    };
            return obj.Return_ScalerValue("sp_changePassword", param);

        }

        public string checkUserName(checkUserName req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Email", req.EmailID),
                        new SqlParameter("@UserName", req.UserName),
                    };
            return obj.Return_ScalerValue("sp_checkUsername", param);

        }
    }
}
