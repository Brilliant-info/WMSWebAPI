using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class CustomerUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public CustomerUtility()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> CustomerList(GetCustomerListRequest req)
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
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("CustomerList", param));

        }

        public string GetOTP1()
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

        internal string GetCustomerListRequest(GetCustomerListRequest reqPara)
        {
            throw new NotImplementedException();
        }

        public string AddCustomer(AddCustomerRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@CustomerName", req.CustomerName),
                        new SqlParameter("@CustomerCode", req.CustomerCode),
                        new SqlParameter("@Country", req.Country.Replace("0X#","")),
                        new SqlParameter("@State", req.State.Replace("0X#","")),
                        new SqlParameter("@City", req.City),
                        new SqlParameter("@Address", req.Address),
                        new SqlParameter("@Zipcode", req.Zipcode),
                        new SqlParameter("@Landmark", req.Landmark),
                        new SqlParameter("@MobileNo", req.MobileNo),
                        new SqlParameter("@EmailID", req.EmailID),
                        new SqlParameter("@Website", req.Website),
                        new SqlParameter("@ManufacturingCode", req.ManufacturingCode),
                        new SqlParameter("@Active", req.Active),
                        new SqlParameter("@logopath", req.logopath),
                        new SqlParameter("@logo", req.logo)
                    };
            return obj.Return_ScalerValue("SaveCustomer", param);
        }
        public async Task<JsonElement> ShowWarehouse(ShowWarehouseRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", req.CompanyId),
                        new SqlParameter("@UserId", req.UserId),
                        new SqlParameter("@CustomerId", req.CustomerId),
                        new SqlParameter("@skey", req.Skey)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("ShowWarehouse", param));
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
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("EditCustomer", param));
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
        }

        public async Task<JsonElement> GetCompanybyUser(getcompanyRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", req.UserID)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("CM_GetCompanyList", param));
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

        public string reqSendCustomerOTP(reqCustomerDemandOtp req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Email", req.Email),
                        new SqlParameter("@OTP", req.OTP),
                         new SqlParameter("@Active", req.Active),
                          new SqlParameter("@CustomerId", Convert.ToInt32(req.CustomerID)),
                          new SqlParameter("@WarehouseId",Convert.ToInt32(req.WarehouseId)),
                          new SqlParameter("@UserId",Convert.ToInt32(req.UserId)),
                    };
            return obj.Return_ScalerValue("sp_sendOTPToCustomer", param);

        }

        public string sendEmail(string EmailId, string bodytest, string heading, string Subject)
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
                    emailParaC req = new emailParaC();
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

        public async Task<JsonElement> GetDispDemandActivationLink(GetDispDemandActivationLinkRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CompanyId", req.CompanyId),
                        new SqlParameter("@CustomerId", req.CustomerId),
                        new SqlParameter("@WarehouseId", req.WarehouseId),
                        new SqlParameter("@UserId", req.UserId),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_DispDemandActivationLink", param));
        }
        public string validateOtp(reqValidateOTP req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@Email", req.Email),
                new SqlParameter("@OTP", req.OTP),
                new SqlParameter("@CustomerID", Convert.ToInt32(req.CustomerId)),
                new SqlParameter("@UserId", Convert.ToInt32(req.UserId))
            };
            return obj.Return_ScalerValue("valDemandActivation", param);
        }

        public string ActivationLink(reqSendLink req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@Email", req.Email),
                new SqlParameter("@ActivationLink", Convert.ToString(req.ActivationLink)),
                new SqlParameter("@CompanyId", Convert.ToString(req.CompanyId)),
                new SqlParameter("@CustomerID", Convert.ToInt32(req.CustomerID)),
                new SqlParameter("@WarehouseId", Convert.ToString(req.WarehouseId)),
                new SqlParameter("@UserId", Convert.ToInt32(req.UserId))
            };
            return obj.Return_ScalerValue("sp_saveAndSendDemandActivationLink", param);
        }

        public async Task<JsonElement> DemandobjectList(reqPickDropList req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerID", Convert.ToInt32(req.CustomerID)),
                new SqlParameter("@UserId", Convert.ToInt32(req.UserId)),
                new SqlParameter("@WarehouseId", Convert.ToInt32(req.WarehouseId)),
                new SqlParameter("@CompanyId", Convert.ToInt32(req.CompanyId))
            };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_getpickDropList", param));
        }

        public string saveDemandObject(reqSaveDemandObject req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@obj",req.Obj),
                new SqlParameter("@point",req.point),
                new SqlParameter("@CustomerID",Convert.ToInt32(req.CustomerID)),
                new SqlParameter("@WarehouseId",Convert.ToInt32(req.WarehouseId)),
                new SqlParameter("@UserId",Convert.ToInt32(req.UserId)),
                new SqlParameter("@CompanyId",Convert.ToInt32(req.CompanyId))
            };
            return obj.Return_ScalerValue("sp_saveDemandObject", param);
        }

        public async Task<JsonElement> getObjectList(reqDemandObjectList req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@obj",Convert.ToString(req.Obj)),
                new SqlParameter("@CustomerID",Convert.ToInt32(req.CustomerId)),
                new SqlParameter("@WarehouseId",Convert.ToInt32(req.WarehouseId)),
                new SqlParameter("@UserId",Convert.ToInt32(req.UserId)),
                new SqlParameter("@CompanyId",Convert.ToInt32(req.CompanyId))
            };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_getDemandObjectList", param));
        }

        public string removeObjectPoint(reqRemoveObjPoint req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@ObjectId",Convert.ToInt32(req.ObjectId)),
                new SqlParameter("@Obj",req.Obj),
                new SqlParameter("@CustomerId",Convert.ToInt32(req.CustomerId)),
                new SqlParameter("@WarehouseId",Convert.ToInt32(req.WarehouseId)),
                new SqlParameter("@CompanyId",Convert.ToInt32(req.CompanyId)),
            };
            return obj.Return_ScalerValue("sp_removeObjPoint", param);
        }
        public string LottableCutomer(reqLottableCutomer req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@CustomerID",Convert.ToInt64(req.CustomerID)),
                new SqlParameter("@CompanyID",Convert.ToInt64(req.CompanyID)),
                new SqlParameter("@Lottable",req.Lottable),
                new SqlParameter("@Active",req.Active)
            };
            return obj.Return_ScalerValue("sp_GetLottableCustomer", param);
        }

        public async Task<JsonElement> LottableCustomerList(reqLottableCustomerList req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerID", Int32.Parse(req.CustomerID)),
                        new SqlParameter("@CompanyID", Int32.Parse(req.CompanyID)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_LottableCustomerList", param));
        }
        public async Task<JsonElement> Lottablesavelist(reqLottablesavelist req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerID", Int32.Parse(req.CustomerID)),
                        new SqlParameter("@CompanyID", Int32.Parse(req.CompanyID)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetLottablesavelist", param));
        }
    }
}
