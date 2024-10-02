using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Text;
using WMSWebAPI.Models.V1.Request;
using System.Text.Json;

namespace WMSWebAPI.Utility.V1
{
    public class CompanyUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public CompanyUtility()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> CompanyList(GetCompanyListRequest req)
        {
            //DataSet ds = new DataSet();
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", Int64.Parse(req.CurrentPage)),
                        new SqlParameter("@RecordLimit", Int64.Parse(req.RecordLimit)),
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@Search", req.Search),
                        new SqlParameter("@Filter", req.Filter)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("CompanyList", param));

        }

        internal string GetCustomerListRequest(GetCompanyListRequest reqPara)
        {
            throw new NotImplementedException();
        }

        public string AddCompany(AddCompanyRequest req)
        {
            param = new SqlParameter[]
                    {
                         new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                         new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                         new SqlParameter("@CompanyName", req.CompanyName),
                         new SqlParameter("@Country", req.Country.Replace("0X#","")),
                         new SqlParameter("@State", req.State.Replace("0X#","")),
                         new SqlParameter("@City", req.City),
                         new SqlParameter("@Address", req.Address),
                         new SqlParameter("@Zipcode", req.Zipcode),
                         new SqlParameter("@Landmark", req.Landmark),
                         new SqlParameter("@MobileNo", req.MobileNo),
                         new SqlParameter("@EmailID", req.EmailID),
                         new SqlParameter("@Website", req.Website),
                         new SqlParameter("@Active", req.Active),
                         new SqlParameter("@logopath", req.logopath),
                         new SqlParameter("@logo", req.logo)
                    };
            return obj.Return_ScalerValue("SaveCompany ", param);
        }
        public async Task<JsonElement> EditCompany(EditCompanyRequest req)
        {
            param = new SqlParameter[]
                    {
                         new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                         new SqlParameter("@CID", Int64.Parse(req.CID))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("EditCompany", param));
        }
        public string EmailConfigSave(EmailConfigSave req)
        {
            string GetOtp = GetOTP();

            param = new SqlParameter[]
                    {
                         new SqlParameter("@EmailConfigId", req.EmailConfigId),
                         new SqlParameter("@CompanyId", req.CompanyId),
                         new SqlParameter("@WarehouseId", req.WarehouseId),
                         new SqlParameter("@UserId", req.UserId),
                         new SqlParameter("@CustomerId", req.CustomerId),
                         new SqlParameter("@DefaultsenderID", req.DefaultsenderID),
                         new SqlParameter("@Protocol", req.Protocol),
                         new SqlParameter("@Hostname", req.Hostname),
                         new SqlParameter("@EmailPort", req.EmailPort),
                         new SqlParameter("@SecurityMode", req.SecurityMode),
                         new SqlParameter("@CustomerKey", req.CustomerKey),
                         new SqlParameter("@CustomerValue", req.CustomerValue),
                         new SqlParameter("@EmailPassword", req.EmailPassword),
                         new SqlParameter("@Active", req.Active),
                         new SqlParameter("@EmailOTP", GetOtp),
                         new SqlParameter("@VerifiedOTP", req.VerifiedOTP)

                    };
            string result = obj.Return_ScalerValue("EmailConfigSave", param);
            if (result == "success")
            {
                // string bodytext = "Thanks for signing up, Your OTP is <b>" + GetOtp + "</b>,Please Complete Your User Registration Process.";
                //string sessionVal = SendMailDynamic(req.DefaultsenderID, bodytext, "OTP Verification", "New Registration For The Application", req.Hostname, req.EmailPassword, req.EmailPort, req.DefaultsenderID);
            }

            return result;

        }
        public string SendMailDynamic(string EmailId, string bodytest, string heading, string Subject, string Email_host, string Email_password, string Email_port, string from)
        {
            DataSet ds = new DataSet();
            String jsonString = String.Empty;
            //string Email_host = "";
            //string Email_password = "";
            //string Email_port = "";
            //string from = "";

            //param = new SqlParameter[]
            //       {

            //       };
            //ds = obj.Return_DataSet("sp_emailDetails", param);
            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //    {
            //        Models.V1.emailPara req = new Models.V1.emailPara();
            //        Email_host = req.Email_host = ds.Tables[0].Rows[i]["EmailHost"].ToString();
            //        Email_password = req.Email_password = ds.Tables[0].Rows[i]["EmailPassword"].ToString();
            //        Email_port = req.Email_port = ds.Tables[0].Rows[i]["EmailPort"].ToString();
            //        from = req.from = ds.Tables[0].Rows[i]["EmailUsername"].ToString();

            //    }
            //}

            string MailStatus = "";
            string to = EmailId; //To address    
            //string from = "development@brilliantinfosys.com"; //From address    
            //string Email_host = System.Configuration.ConfigurationManager.AppSettings["Email_host"];
            //string Email_password = System.Configuration.ConfigurationManager.AppSettings["Email_password"];
            //string Email_port = System.Configuration.ConfigurationManager.AppSettings["Email_port"];
            //string from = System.Configuration.ConfigurationManager.AppSettings["Email_userName"];
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
        public async Task<JsonElement> EmailConfigList(GetEmailConfigList req)
        {
            //DataSet ds = new DataSet();
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", req.CompanyId),
                        new SqlParameter("@CustomerId", req.CustomerId),
                        new SqlParameter("@WarehouseId", req.WarehouseId),
                        new SqlParameter("@UserId", req.UserId)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("EmailConfigList", param));

        }
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
        /*  public async Task<JsonElement> ShowWarehouse(ShowWarehouseRequest req)
          {
              param = new SqlParameter[]
                      {
                          new SqlParameter("@CompanyId", req.CompanyId),
                          new SqlParameter("@UserId", req.UserId),
                          new SqlParameter("@CustomerId", req.CustomerId),
                          new SqlParameter("@skey", req.Skey)
                      };
              return obj.ConvertDataSetToJObject(obj.Return_DataSet("ShowWarehouse", param));
          }
          public string SelectWarehouse(SelectWarehouseRequest req)
          {
              param = new SqlParameter[]
                      {
                          new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                          new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                          new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                          new SqlParameter("@WarehouseId", req.WarehouseId)
                      };
              return obj.Return_ScalerValue("SelectWarehouse", param);
          }
          public string RemoveWarehouse(RemoveWarehouseRequest req)
          {
              param = new SqlParameter[]
                      {
                          new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                          new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                          new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                          new SqlParameter("@WarehouseId", req.WarehouseId)
                      };
              return obj.Return_ScalerValue("RemoveWarehouse", param);
          }
          public async Task<JsonElement> EditCustomer(EditCustomerRequest req)
          {
              param = new SqlParameter[]
                      {
                          new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                          new SqlParameter("@CID", Int64.Parse(req.CID))
                      };
              return obj.ConvertDataSetToJObject(obj.Return_DataSet("EditCustomer", param));
          }
          public string AssginCustomerWarehouse(AssginCustomerWarehouseRequest req)
          {
              param = new SqlParameter[]
                      {
                          new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                          new SqlParameter("@WarehouseId", req.WarehouseId),
                          new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID))
                      };
              return obj.Return_ScalerValue("CustomerSelectWarehouse", param);
          }*/

        public async Task<JsonElement> GetholidayList(RequestGetholidayList req)
        {
            param = new SqlParameter[]
                    {
                          new SqlParameter("@ObjectType",req.ObjectType),
                          new SqlParameter("@ReferenceId", Int64.Parse(req.ReferenceId)),
                          new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_holidaylist ", param));
        }
        public string Saveholidaylist(reqSaveholidaylist req)
        {
            param = new SqlParameter[]
                    {
                          new SqlParameter("@ObjectType",req.ObjectType),
                          new SqlParameter("@ReferenceID",Int64.Parse(req.ReferenceID)),
                          new SqlParameter("@Date",req.Date),
                          new SqlParameter("@Description",req.Description),
                          new SqlParameter("@Remark",req.Remark),
                          new SqlParameter("@CustomerId",Int64.Parse(req.CustomerId)),
                          new SqlParameter("@CompanyId",Int64.Parse(req.CompanyId)),
                          new SqlParameter("@WarehouseId",Int64.Parse(req.WarehouseId)),

                    };
            return obj.Return_ScalerValue("SP_Saveholidaylist", param);
        }
        public string SaveTaxlist(reqSaveTaxlist req)
        {
            param = new SqlParameter[]
                    {
                          new SqlParameter("@CompanyId",Int64.Parse(req.CompanyId)),
                          new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                          new SqlParameter("@WarehouseID ", Int64.Parse(req.WarehouseID)),
                          new SqlParameter("@ReferenceID",Int64.Parse(req.ReferenceID)),
                          new SqlParameter("@TaxName",req.TaxName),
                          new SqlParameter("@Value",Int64.Parse(req.Value)),
                          new SqlParameter("@object",req.objectName),
                          new SqlParameter("@Remark",req.Remark),

                    };
            return obj.Return_ScalerValue("SaveTax", param);
        }
        public async Task<JsonElement> GetTaxList(RequestGetTaxList req)
        {
            param = new SqlParameter[]
                    {
                          new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                          new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                          new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                          new SqlParameter("@ReferenceID", Int64.Parse(req.ReferenceID)),
                          new SqlParameter("@UserID",Int64.Parse(req.UserID)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_GetTaxList", param));
        }
        public string EditTax(reqEditTax req)
        {
            param = new SqlParameter[]
                    {
                          new SqlParameter("@CompanyId",Int64.Parse(req.CompanyId)),
                          new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                          new SqlParameter("@WarehouseID ", Int64.Parse(req.WarehouseID)),
                          new SqlParameter("@RefID",Int64.Parse(req.RefID)),
                          new SqlParameter("@TaxName",req.TaxName),
                          new SqlParameter("@Value",Int64.Parse(req.Value)),
                          new SqlParameter("@Ramark",req.Ramark),
                          new SqlParameter("@UserID",Int64.Parse(req.UserID)),
                          new SqlParameter("@rowno",Int64.Parse(req.rowno)),

                    };
            return obj.Return_ScalerValue("SP_EditTax", param);
        }
    }
}
