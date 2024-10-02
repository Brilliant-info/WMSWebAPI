using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using WMSWebAPI.Models.V1.Request;
using System.Security.Cryptography;
using System.IO;
using System.Net.Mail;
using System.Data;
using System.Configuration;
using System.Text.Json;

namespace WMSWebAPI.Utility.V1
{
    public class UserUtility
    {
        SqlParameter[] param;
        SqlParameter[] userparam;
        DBActivity obj;
        //ClassLibrary1.Class1 objmail = new Class1();
        public UserUtility()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> UserTypeList(GetUserTypeListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_dllUserType", param));
        }
        public async Task<JsonElement> Userlist(GetUserlistRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", Int32.Parse(req.CurrentPage)),
                        new SqlParameter("@RecordLimit", Int32.Parse(req.RecordLimit)),
                        new SqlParameter("@CompanyId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@Search", req.Search),
                        new SqlParameter("@Filter", req.Filter),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_UserList", param));
        }


        #region  User Add,Edit, password generation code start 
        public string SaveUser(SaveUserRequest req)
        {
            string password = CreatePassword(7);
            string encriptPassword = encryptstring(password);
            encriptPassword = "|@|" + encriptPassword;
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@UserType", req.UserType),
                        new SqlParameter("@FirstName", req.FirstName),
                        new SqlParameter("@LastName", req.LastName),
                        new SqlParameter("@EmployeeNo", req.EmployeeNo),
                        new SqlParameter("@EmailId", req.EmailId),
                        new SqlParameter("@MobileNo", req.MobileNo),
                        new SqlParameter("@username", req.username),
                        new SqlParameter("@Active", req.Active),
                        new SqlParameter("@CreatedBy", req.CreatedBy),
                        new SqlParameter("@EncriptPass", encriptPassword),
                         new SqlParameter("@ReportingTo", Int64.Parse(req.ReportingTo)),
                    };
            return obj.Return_ScalerValue("saveUser", param);


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

        public string decriptpassstring(string pass)
        {
            string decriptpass = "";
            decriptpass = Decryptstring(pass);
            return decriptpass;
        }

        public static string Decryptstring(string stringdecript)
        {
            string cipherText = stringdecript.Substring(3);
            string EncryptionKey = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
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
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        public string NewUserPass(NewUserPassRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@Username ",req.Username),
                        new SqlParameter("@UId", Int64.Parse(req.UId)),
                        new SqlParameter("@Email", req.Email),
                        new SqlParameter("@CompanyID ", Int64.Parse(req.CompanyID)),
                    };
            return obj.Return_ScalerValue("genratePassword", param);
        }

        // public string SendMailDynamic(string EmailId, string bodytest, string heading, string Subject)
        public string SendMailDynamic(long UserID)
        {
            DataSet userds = new DataSet();
            string EmailId = "", useremailname = "", username = "", Password = "";
            string bodytest = "You have successfully Register into system,please find below login details";
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
                     emailParaU req = new emailParaU();
                   // Models.V1.emailPara req = new Models.V1.emailPara();
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
            MailBody = MailBody + "<p> UserName: " + username + "</p>";
            MailBody = MailBody + "<p> Password: " + Password + "</p>";

            string apiComp = string.Empty;
         //   apiComp = ConfigurationManager.AppSettings["apilive"].ToString();
            
            MailBody = MailBody + "<p> Please Click here to Login: <a href=" + apiComp + ">Login</a></p>";

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
            System.Net.NetworkCredential basicCredential1 = new System.Net.NetworkCredential(from, Email_password);
            client.EnableSsl = false;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;

            //bool mailsend = objmail.mailsend(to, "mailto:ajit.k@brilliantwms.com", Subject, MailBody, from, Email_password, Email_host, int.Parse(Email_port), false);

            try
            {
                client.Send(message);
                //MailStatus = "success";
                //bool mailsend = objmail.mailsend(to, "dilip@brilliantwms.com", Subject, MailBody, from, Email_password, Email_host, int.Parse(Email_port), true);
                MailStatus = "success";
            }

            catch (Exception ex)
            {
                MailStatus = ex.Message;
                //throw ex;

            }

            return MailStatus;

        }

        #endregion  User Add,Edit, password generation code start 

        #region User Warehouse code start
        public async Task<JsonElement> WarehouseList(WarehouseListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CreatedBy",req.CreatedBy)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("userWarehouseList", param));
        }
        public string AssginUserWarehouse(AssginUserWarehouseRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@WarehouseId", req.WarehouseId),
                        new SqlParameter("@UID", Int64.Parse(req.UID))
                    };
            return obj.Return_ScalerValue("UserSelectWarehouse", param);
        }
        public string RemoveUserWarehouse(RemoveUserWarehouseRequest req)
        {
            param = new SqlParameter[]
                {
                    new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                    new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                    new SqlParameter("@CreatedBy",Int64.Parse(req.CreatedBy))
                };
            return obj.Return_ScalerValue("RemoveUserWarehouse", param);
        }

        #endregion User Warehouse code end

        #region User customer code start
        public async Task<JsonElement> CustomerList(CustomerListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CreatedBy",req.CreatedBy)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("userCustomerList", param));
        }
        public string AssginUserCustomer(AssginUserCustomerRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", req.CustomerId),
                        new SqlParameter("@CreatedBy", Int64.Parse(req.CreatedBy)),
                    };
            return obj.Return_ScalerValue("UserSelectCustomer", param);
        }
        public string RemoveUserCustomer(RemoveUserCustomerRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@CreatedBy", Int64.Parse(req.CreatedBy)),
                    };
            return obj.Return_ScalerValue("RemoveUserCustomer", param);
        }
        public string RemoveUserClient(RemoveUserCustomerRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId))
                    };
            return obj.Return_ScalerValue("RemoveUserClient", param);
        }
        #endregion User customer code end

        public string lockunlockuser(lockunlockrequest req)
        {
            param = new SqlParameter[]
                {
                    new SqlParameter("@UserID", Int64.Parse(req.UserId)),
                    new SqlParameter("@lockunlock", req.lockunlock),
                };
            return obj.Return_ScalerValue("Usr_LockUnlockUser", param);
        }

        #region User Client code
        public async Task<JsonElement> ClientList(ClientListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("userunassignclientlist", param));
        }
        public async Task<JsonElement> ClientAssignlist(ClientAssignListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerID)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("userassignclientlist", param));

        }
        public string AssginUserClient(AssginUserClientRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ClientId", req.ClientId),
                        new SqlParameter("@CreatedBy", Int64.Parse(req.CreatedBy)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerID)),
                    };
            return obj.Return_ScalerValue("SelectUserclient", param);
        }
        public string RemoveUserClient(RemoveUserClientRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@ClientId", Int64.Parse(req.ClientId)),
                        new SqlParameter("@CreatedBy", Int64.Parse(req.CreatedBy)),
                    };
            return obj.Return_ScalerValue("RemoveUserClient", param);
        }
        #endregion

        #region User Roles code start
        public async Task<JsonElement> RoleList(GetRoleList req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@CustomerID", req.CustomerID)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("usr_GetRolelist", param));
        }

        public async Task<JsonElement> GetRoleDetailsByID(GetRoleDetailsbyID req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Roleid", Int64.Parse(req.Roleid)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("usr_GetRoleDetailsbyRole", param));
        }

        public string SaveUserRoles(SaveUserRole req)
        {
            param = new SqlParameter[]
                   {
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@RoleID", Int64.Parse(req.Roleid)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@CreatedBy", Int64.Parse(req.CreatedBy)),
                        new SqlParameter("@RoleDetailID", Int64.Parse(req.RoleDetailID)),
                        new SqlParameter("@MenuID", Int64.Parse(req.MenuID)),
                        new SqlParameter("@Action", req.Action),
                   };
            return obj.Return_ScalerValue("Role_SaveUerRole", param);
        }

        public async Task<JsonElement> CheckuserPreviousRole(ChkUserpreRole req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@RoleID", Int64.Parse(req.Roleid)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("usr_CheckuserPreviosRole", param));
        }

        public string SaveSelectAllRole(SelectAllRoleReq req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("Roleid",(req.Roleid)),
                new SqlParameter("UserID",(req.UserID)),
                new SqlParameter("CompanyID",(req.CompanyID)),
                new SqlParameter("CreatedBy",(req.CreatedBy)),
                new SqlParameter("Action",(req.Action)),
                new SqlParameter("Checkval",(req.Checkval)),
            };
            return obj.Return_ScalerValue("Role_SelectAllRoleSave", param);
        }


        #endregion User Roles code end

        public async Task<JsonElement> GetUserReportingToList(GetUserreportingToRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_dllUserReportingTo", param));
        }
    }
}
