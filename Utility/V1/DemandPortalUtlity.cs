using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Text;
using WMSWebAPI.Models.V1.Request;
using System.Text.Json;
using RestSharp;
using WMSWebAPI.Models.V1.Responce;
using System.Threading.Tasks;
using System.Net.Http;
using WMSWebAPI.Models.V1;



namespace WMSWebAPI.Utility.V1
{
    public class DemandPortalUtlity
    {
        SqlParameter[] param;
        DBActivity obj;
        public DemandPortalUtlity()
        {
            obj = new DBActivity();
        }
        public string getRequestedOtp(reqEmailOtp req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Email", req.Email),
                        new SqlParameter("@OTP", req.OTP)
                    };
            return obj.Return_ScalerValue("sp_getOtP", param);

        }
        public string userResetPassword(reqForgotPass req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Email", req.EmailId),
                        new SqlParameter("@OTP", req.OTP)
                    };
            return obj.Return_ScalerValue("sp_getOtP", param);

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
                    // Models.V1.emailPara req = new Models.V1.emailPara();
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

        //Forgot Password
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
                    emailParaU req = new emailParaU();
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
            client.EnableSsl = true;
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

        //OTP Validation
        public string userOtpValidation(reqOTPValidate req)
        {
            param = new SqlParameter[]
                    {

                        new SqlParameter("@Email", req.Email),
                        new SqlParameter("@Otp", req.Otp)

                    };
            return obj.Return_ScalerValue("sp_validateOTP", param);
        }

        public string getRepPasswordChange(reqResetPassword req)
        {
            param = new SqlParameter[]
                    {

                        new SqlParameter("@OTP", req.OTP)
                    };
            return obj.Return_ScalerValue("sp_resetPasswordDP", param);

        }

        public string updatePassword(setNewPassword req)
        {
            param = new SqlParameter[]
                    {

                        new SqlParameter("@newPassword", req.newPassword),
                        new SqlParameter("@Email", req.Email)
                    };
            return obj.Return_ScalerValue("sp_updatePassword", param);

        }

        public string saveUserRegistration(reUserRegister req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@FirstName", req.FirstName),
                        new SqlParameter("@LastName", req.LastName),
                        new SqlParameter("@Email", req.Email),
                        new SqlParameter("@MobileNo", req.MobileNo),
                        new SqlParameter("@EmployeeNo", req.EmployeeNo),
                        new SqlParameter("@ClientID", Convert.ToInt64(req.ClientID)),
                        new SqlParameter("@ClientName", req.ClientName),
                        new SqlParameter("@UserType", req.UserType),
                        new SqlParameter("@Zipcode", req.Zipcode),
                        new SqlParameter("@UserName", req.UserName),
                        new SqlParameter("@Password", req.Password)

                    };
            return obj.Return_ScalerValue("sp_demandRegistrastion", param);

        }

        public string checkUserLogin(reqLogin req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@Username", req.Username),
                new SqlParameter("@Password",req.Password)
            };
            return obj.Return_ScalerValue("sp_DemandLogin", param);
        }

        public async Task<JsonElement> getUserList(reqUserList req)
        {
            param = new SqlParameter[]
                    {
                       new SqlParameter("@ClientId", Convert.ToInt64(req.ClientId)),
                       new SqlParameter("@recordlimit", Convert.ToInt64(req.recordLimit)),
                       new SqlParameter("@CurrentPage", Convert.ToInt64(req.CurrentPage)),
                       new SqlParameter("@SerchPara",req.SerchPara),
                       new SqlParameter("@SerchVal", req.SerchVal),
                       new SqlParameter("@UserId",Convert.ToInt64(req.UserId))

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_demandUserList", param));
        }

        public string UserApproveStatus(reqApporveUser req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@UserId", Convert.ToInt64(req.UserId)),
                new SqlParameter("@ObjectName",req.ObjectName)
            };
            return obj.Return_ScalerValue("sp_UserApproval", param);
        }

        public string checkUserValidate(reqcheckUserName req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@objUsername",req.Username)
            };
            return obj.Return_ScalerValue("sp_validateUsername", param);
        }

        public async Task<JsonElement> getTemplateList(reqTemplateList req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId",req.UserId),
                        new SqlParameter("@ClientId", req.ClientId)
                    };
            return  await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_DemandtempateList", param));
        }

        public string saveNewTemplate(createTemplate req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@Id", Convert.ToInt64(req.Id)),
                new SqlParameter("@OrderId", Convert.ToInt64(req.OrderId)),
                new SqlParameter("@UserId", Convert.ToInt64(req.UserId)),
                new SqlParameter("@OrderRefNo",req.OrderRefNo),
                new SqlParameter("@ClientID", Convert.ToInt64(req.ClientId)),
                new SqlParameter("@CustomerId",Convert.ToInt64(req.CustomerId)),
                new SqlParameter("@CompanyId",Convert.ToInt64(req.CompanyId)),
                new SqlParameter("@Title",req.Title),
                new SqlParameter("@flag", req.flag),
                new SqlParameter("@JsonOrder", req.OrderJson),
                new SqlParameter("@OrderHead", req.OrderHead)
            };
            return obj.Return_ScalerValue("sp_createNewTemplate", param);
        }
        //Remove Template
        public string removeUserTemplate(RemoveTemplate req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter ("@TemplateID", Convert.ToInt64(req.TemplateID)),
                new SqlParameter("@OrderID",Convert.ToInt64(req.OrderID)),
                new SqlParameter("@UserID",Convert.ToInt64(req.UserID)),
                new SqlParameter("@flag", req.flag)
            };
            return obj.Return_ScalerValue("sp_removeTemplateDP", param);
        }

        public async Task<JsonElement> getWmsViewOrderList(viewWMSOrderDetails req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@OrderID",Convert.ToInt64(req.OrderId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_viewOrderDetails", param));
        }
        public string orderApprove(approveOrderDisp req)
        {

            //string res = SalesNotification(Convert.ToInt64(req.OrderId));
            string res = "0";
            if (res != "")
            {
                res = "";
                param = new SqlParameter[]
                {
                    new SqlParameter("@UserId", Convert.ToInt64(req.UserId)),
                    new SqlParameter("@OrderId", Convert.ToInt64(req.OrderId)),
                    new SqlParameter("@ClientID", Convert.ToInt64(req.ClientId)),
                    new SqlParameter("@WarehouseId",Convert.ToInt64(req.WarehouseId)),
                    new SqlParameter("@remark",req.Remkar),
                    new SqlParameter("@OrderStatus",req.OrderStatus),
                    new SqlParameter("@SalesOrderNo",res)

                };
                return obj.Return_ScalerValue("sp_approveOrder", param);
            }
            else
            {
                return res;
            }
        }

        public string getAdminlEmail(string getOrderId)
        {
            param = new SqlParameter[]
               {
                    new SqlParameter("@OrderId", Convert.ToInt64(getOrderId))
               };
            return obj.Return_ScalerValue("sp_getUserEmail", param);
        }


        public async Task<JsonElement> viewDispatchOrderList(viewDispatchOrder req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@OrderID",Convert.ToInt64(req.OrderId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_DP_DispatchApproveOrder", param));
        }

        //save Template Order
        public string saveTemplateOrder(saveTemplateOrder req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter ("@OrderRefNo",req.OrderRefNo),
                new SqlParameter("@OrderId",Convert.ToInt64(req.OrderId)),
                new SqlParameter("@UserId",Convert.ToInt64(req.UserId)),
                 new SqlParameter("@ClientId",Convert.ToInt64(req.UserId)),
                new SqlParameter("@CustomerId", Convert.ToInt64(req.CustomerId)),
                new SqlParameter("@WarehouseId",Convert.ToInt64(req.WarehouseId))
            };
            return obj.Return_ScalerValue("sp_saveDPTemplateOrder", param);
        }

        public async Task<JsonElement> getReasonList(ReqReasonList req)
        {
            param = new SqlParameter[]
                    {
                       new SqlParameter("@UserId", req.UserId)
                    };
            return  await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_getReasonCodeDP", param));
        }

        public async Task<JsonElement> GetRejectOrderList(ReqRejectOrderList req)
        {
            param = new SqlParameter[]
                    {
                       new SqlParameter("@ReasonId", req.ReasonId),
                       new SqlParameter("@Remark", req.Remark),
                       new SqlParameter("@OrderId", req.OrderId)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_RejectOrderDP", param));
        }
        //SALES ORDER

        public string SalesNotification(long OrderId)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
            string result = "";
            ReqSalesOrders resl = new ReqSalesOrders();
            try
            {
                // Token
                string username = "C_BALAJI";
                string password = "Wittymoon502@";
                var clientcode = new RestClient("https://fiori-dev.da.com.bn/sap/opu/odata/sap/ZIWMS_SALE_ORDER_SRV/SaleOrderHeaderSet?sap-client=520");
                var reqcode = new RestRequest("client",Method.Get);
                reqcode.AddHeader("Content-Type", "application/json; charset=UTF-8");
                reqcode.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(username + ":" + password)));
                reqcode.AddHeader("X-CSRF-Token", "fetch");

                //IRestResponse rescode = clientcode.Execute(reqcode);
                //string name = rescode.Headers[3].Name.ToString();
                //string value = rescode.Headers[3].Value.ToString();

                RestResponse rescode = clientcode.Execute(reqcode);

                var header = rescode.Headers.ElementAt(3); // Get the fourth header
                string name = header.Name;
                string value = header.Value.ToString();

                resl = ReqJSON(OrderId);
                string json = JsonConvert.SerializeObject(resl);

                // Dispatch Notification
                var client = new RestClient("https://fiori-dev.da.com.bn/sap/opu/odata/sap/ZIWMS_SALE_ORDER_SRV/SaleOrderHeaderSet?sap-client=520");
                var req = new RestRequest("client",Method.Post); // Update here with endpoint
                req.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(username + ":" + password)));
                req.AddHeader(name, value);
                foreach (var ck in rescode.Cookies)
                {
                    //req.AddCookie(ck.Name, ck.Value);
                    var cookie = ck as Cookie;
                    req.AddHeader(cookie.Name, cookie.Value);
                }
                req.AddHeader("Accept", "application/json");
                req.AddParameter("application/json; charset=UTF-8", json, ParameterType.RequestBody);
               RestResponse res = client.Execute(req);

                string val = "";
                string ResponseCode = "";
                string ObjectName = "SalesOrder";
                string sapOrderNo = "";
                JObject joResponse = JObject.Parse(res.Content);
                JObject ojObject = (JObject)joResponse["d"];

                ResponseCode = "200";

                if (ojObject == null)
                {
                    JObject getErrorJson = (JObject)joResponse["error"];
                    JObject getErrorVal = (JObject)getErrorJson["message"];
                    val = getErrorVal["value"].ToString();
                    ResponseCode = "400";

                }
                if (val != null && val == "")
                {
                    val = ojObject["SaleDocumentNo"].ToString();
                    sapOrderNo = val;
                }
                result = val;

                string getResult = addSapOrderDetails(OrderId, sapOrderNo, ResponseCode, result, ObjectName);

            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        //Json SalesOrder
        public ReqSalesOrders ReqJSON(long OrderId)
        {
            ReqSalesOrders main = new ReqSalesOrders();
            DataSet ds = new DataSet();
            try
            {
                param = new SqlParameter[]
                    {
                        new SqlParameter("@OrderId", OrderId)
                    };
                ds = obj.Return_DataSet("sp_getsalesOrderData", param);

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    main.BillBlock = ds.Tables[0].Rows[0]["BillBlock"].ToString();
                    main.SaleDocumentNo = ds.Tables[0].Rows[0]["SaleDocumentNo"].ToString();
                    main.CustRefDate = ds.Tables[0].Rows[0]["CustRefDate"].ToString();
                    main.DocType = ds.Tables[0].Rows[0]["DocType"].ToString();
                    main.ReqDelivDate = ds.Tables[0].Rows[0]["ReqDelivDate"].ToString();
                    main.PriceDate = ds.Tables[0].Rows[0]["PriceDate"].ToString();
                    main.SalesOrg = ds.Tables[0].Rows[0]["SalesOrg"].ToString();
                    main.DistrChan = ds.Tables[0].Rows[0]["DistrChan"].ToString();
                    main.DocumentDate = ds.Tables[0].Rows[0]["DocumentDate"].ToString();
                    main.Division = ds.Tables[0].Rows[0]["Division"].ToString();

                }
                List<SaleOrderItemSet> oislst = new List<SaleOrderItemSet>();
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    SaleOrderItemSet ois = new SaleOrderItemSet();
                    ois.ItemNumber = ds.Tables[0].Rows[0]["ItemNumber"].ToString();
                    ois.Paytterms = ds.Tables[0].Rows[0]["Paytterms"].ToString();
                    ois.Material = ds.Tables[0].Rows[0]["Material"].ToString();
                    ois.Plant = ds.Tables[0].Rows[0]["Plant"].ToString();
                    ois.StoreLocation = ds.Tables[0].Rows[0]["StoreLocation"].ToString();
                    ois.TargetQty = ds.Tables[0].Rows[0]["TargetQty"].ToString();
                    ois.TargetQu = ds.Tables[0].Rows[0]["TargetQu"].ToString();
                    oislst.Add(ois);
                }
                main.SaleOrderItemSet = oislst;

                List<SaleOrderPartnerSet> ohpslst = new List<SaleOrderPartnerSet>();
                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                {
                    SaleOrderPartnerSet ohts = new SaleOrderPartnerSet();
                    ohts.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                    ohts.PartnerRole = ds.Tables[0].Rows[0]["PartnerRole"].ToString();
                    ohts.PartnerNumber = ds.Tables[0].Rows[0]["PartnerNumber"].ToString();
                    ohts.ItemNumber = ds.Tables[0].Rows[0]["ItemNumber"].ToString();
                    ohpslst.Add(ohts);
                }
                main.SaleOrderPartnerSet = ohpslst;

                //ReturnMessageSet
                List<ReturnMessageSet> rmslst = new List<ReturnMessageSet>();
                main.ReturnMessageSet = rmslst;
                //ReturnMessageSet End
            }
            catch (Exception ex)
            {
            }
            return main;
        }
        //SALES ORDER

        //View Template Order
        public async Task<JsonElement> getTemplateOrderView(reqTemplateView req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@TemplateID",Convert.ToInt64(req.TemplateID)),
                        new SqlParameter("@ClientId",Convert.ToInt64(req.ClinetId)),
                        new SqlParameter("@CustomerId",Convert.ToInt64(req.CustomerId)),
                        new SqlParameter("@WarehouseId",Convert.ToInt64(req.WarehouseId)),
                        new SqlParameter("@UserId",Convert.ToInt64(req.UserId))

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetTemplateOrderView", param));
        }

        public string addSapOrderDetails(long OrderId, string sapOrderNo, string ResponseCode, string result, string ObjectName)
        {
            //string getOrderno = OrderId;
            param = new SqlParameter[]
                {
                    new SqlParameter("@OrderNo", Convert.ToInt64(OrderId)),
                    new SqlParameter("@SapOrderNo",sapOrderNo),
                    new SqlParameter("@SapOrderMessage",result),
                    new SqlParameter("@ObjectName",ObjectName),
                    new SqlParameter("@ResponseCode",ResponseCode)

                };
            return obj.Return_ScalerValue("sp_getSapErrorLog", param);

        }

        public async Task<JsonElement> getDpClientList()
        {
            param = new SqlParameter[]
                    {

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_getDPRegisterClientList", param));
        }

        public async Task<JsonElement> ViewTopFiveOrder(reqTopFiveOrderList req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId",Convert.ToInt64(req.UserId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_getTopFiveClientList", param));
        }

        public async Task<JsonElement> getDropdownList(reqDropdownList req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@uid", req.UserId)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_getDemandDropdownlist", param));
        }

        public string removeOrder(reqDeleteOrderId req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@Uid",Convert.ToInt64(req.UserId)),
                new SqlParameter("@OrderId",Convert.ToInt64(req.OrderId))

            };
            return obj.Return_ScalerValue("sp_deleteDPorder", param);
        }

        public async Task<JsonElement> getUserTypeReport(reqUserReport req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Object",req.Object)

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_UserReportList", param));
        }
    }
}
