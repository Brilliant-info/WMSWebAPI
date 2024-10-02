using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using System.Web;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class SOUtility
    {
        SqlParameter[] param;
        DBActivity obj;

        public SOUtility()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> GetOutboundList(GetOutboundListRequest req)
        {
            DataSet ds = new DataSet();
            if (req.filterval == null || req.filtercol == "All") { req.filtercol = ""; }
            param = new SqlParameter[]
                    {
                        new SqlParameter("@currentpg", Int32.Parse(req.CurrentPage)),
                        new SqlParameter("@recordlmt", Int32.Parse(req.recordLimit)),
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@clientid", Int64.Parse(req.ClientId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@obj", req.Object),
                        new SqlParameter("@skeycol", req.filtercol),
                        new SqlParameter("@skeyval", req.filterval)
                    };
            ds = obj.Return_DataSet("SP_GetOutboundList", param);

            int totcnt = 0, socnt = 0, allocnt = 0, pickcnt = 0, stgcnt = 0, cnclcnt = 0, packing = 0, qccnt = 0;
            //  string outboundHeader = "Order No,Reference No,Client Code,Warehouse Code,Order Type,Group Name,Order Date,Expected Delivery Date,Priority,Delivery Type,Shipping Address,Status,Action";
            string outboundHeader = "Order No,Reference No,Group Name,Warehouse Code,Order Type,Order Date,Requested Delivery Date,Priority,Delivery Type,Client Code,Shipping Address,Status,Action";
            string IsQC = "NO";

            String jsonString = String.Empty;
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    totcnt = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRecords"]);
                    socnt = Convert.ToInt32(ds.Tables[0].Rows[0]["OutboundOrder"]);
                    allocnt = Convert.ToInt32(ds.Tables[0].Rows[0]["Allocated"]);
                    pickcnt = Convert.ToInt32(ds.Tables[0].Rows[0]["Picking"]);
                    packing = Convert.ToInt32(ds.Tables[0].Rows[0]["Packing"]);
                    stgcnt = Convert.ToInt32(ds.Tables[0].Rows[0]["Dispatch"]);
                    cnclcnt = Convert.ToInt32(ds.Tables[0].Rows[0]["CancelOrder"]);
                    qccnt = Convert.ToInt32(ds.Tables[0].Rows[0]["QC"]);
                    IsQC = ds.Tables[0].Rows[0]["IsQC"].ToString();
                }

                jsonString = "{\"OutboundListResult\":[{";
                jsonString = jsonString + "\"CurrentPage\":\"" + req.CurrentPage + "\",";
                jsonString = jsonString + "\"TotalRecords\":\"" + totcnt + "\",";
                jsonString = jsonString + "\"Dashboard\":[{";
                jsonString = jsonString + "\"OutboundOrder\":\"" + socnt + "\",";
                jsonString = jsonString + "\"Allocated\":\"" + allocnt + "\",";
                jsonString = jsonString + "\"Picking\":\"" + pickcnt + "\",";
                jsonString = jsonString + "\"QC\":\"" + qccnt + "\",";
                jsonString = jsonString + "\"Packing\":\"" + packing + "\",";
                jsonString = jsonString + "\"Shipped\":\"" + stgcnt + "\",";
                jsonString = jsonString + "\"CancelOrder\":\"" + cnclcnt + "\",";
                jsonString = jsonString + "\"IsQC\":\"" + IsQC + "\"";
                jsonString = jsonString + "}],";
                jsonString = jsonString + "\"HeaderList\":\"" + outboundHeader + "\",";

                if (totcnt > 0)
                {
                    jsonString = jsonString + "\"OutboundList\":";
                    jsonString = jsonString + JsonConvert.SerializeObject(ds.Tables[1]);
                }
                else
                {
                    jsonString = jsonString + "\"OutboundList\":[]";
                }
                jsonString = jsonString + "}]}";


            }
            catch (Exception ex) { }
          //  return JObject.Parse(jsonString);

            JsonDocument doc = JsonDocument.Parse(jsonString);
            JsonElement respjson = doc.RootElement;
            return respjson;
        }
        public async Task<JsonElement> GetOutboundListDP(GetOutboundListRequest req)
        {
            DataSet ds = new DataSet();
            //if (req.filterval == null || req.filtercol == "All") 
            //{ req.filtercol = ""; }
            param = new SqlParameter[]
                    {
                        new SqlParameter("@currentpg", Int32.Parse(req.CurrentPage)),
                        new SqlParameter("@recordlmt", Int32.Parse(req.recordLimit)),
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@clientid", Int64.Parse(req.ClientId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@obj", req.Object),
                        new SqlParameter("@skeycol", req.filtercol),
                        new SqlParameter("@skeyval", req.filterval)
                    };
            ds = obj.Return_DataSet("SP_GetOutboundListDP", param);

            int Totalcnt = 0, Pendingcnt = 0, Approvecnt = 0, InProcesscnt = 0, Dispatchcnt = 0, Delivercnt = 0, Cancelcnt = 0, Returncnt = 0;

            String jsonString = String.Empty;
            try
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Totalcnt = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRecords"]);
                    Pendingcnt = Convert.ToInt32(ds.Tables[0].Rows[0]["Pending"]);
                    Approvecnt = Convert.ToInt32(ds.Tables[0].Rows[0]["Approved"]);
                    InProcesscnt = Convert.ToInt32(ds.Tables[0].Rows[0]["InProcess"]);
                    Dispatchcnt = Convert.ToInt32(ds.Tables[0].Rows[0]["Dispatch"]);
                    Delivercnt = Convert.ToInt32(ds.Tables[0].Rows[0]["Delivered"]);
                    Cancelcnt = Convert.ToInt32(ds.Tables[0].Rows[0]["CancelOrder"]);
                    Returncnt = Convert.ToInt32(ds.Tables[0].Rows[0]["Returned"]);
                }

                jsonString = "{\"OutboundListResult\":[{";
                jsonString = jsonString + "\"CurrentPage\":\"" + req.CurrentPage + "\",";
                jsonString = jsonString + "\"TotalRecords\":\"" + Totalcnt + "\",";
                jsonString = jsonString + "\"Dashboard\":[{";
                jsonString = jsonString + "\"Pending\":\"" + Pendingcnt + "\",";
                jsonString = jsonString + "\"Approved\":\"" + Approvecnt + "\",";
                jsonString = jsonString + "\"InProcess\":\"" + InProcesscnt + "\",";
                jsonString = jsonString + "\"Dispatch\":\"" + Dispatchcnt + "\",";
                jsonString = jsonString + "\"Delivered\":\"" + Delivercnt + "\",";
                jsonString = jsonString + "\"Cancel\":\"" + Cancelcnt + "\",";
                jsonString = jsonString + "\"Returned\":\"" + Returncnt + "\"";
                jsonString = jsonString + "}],";

                if (Totalcnt > 0)
                {
                    jsonString = jsonString + "\"OutboundList\":";
                    jsonString = jsonString + JsonConvert.SerializeObject(ds.Tables[1]);
                }
                else
                {
                    jsonString = jsonString + "\"OutboundList\":[]";
                }
                jsonString = jsonString + "}]}";


            }
            catch (Exception ex) { }
          //  return JObject.Parse(jsonString);
           JsonDocument doc = JsonDocument.Parse(jsonString);
            JsonElement respjson = doc.RootElement;
            return respjson;
        }
        public string SaveSOHead(SaveSOOrderHeadRequest req)
        {
            if (req.OrderFrom == "DemandPortal" && req.FinalSave == "yes")
            {
                long getUserId = (Int64.Parse(req.UserId));
                sendOrderAddEmail(req.Soid, getUserId);
            }
            param = new SqlParameter[]
                    {
                        new SqlParameter("@soid", Int64.Parse(req.Soid)),
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@obj", req.Object),
                        new SqlParameter("@reqdate", req.RequestedDate),
                        new SqlParameter("@strtdate", req.StartDate),
                        new SqlParameter("@enddate", req.EndDate),
                        new SqlParameter("@CustomerPO", req.CustomerPO),
                        new SqlParameter("@Client", req.Client),
                        new SqlParameter("@ClientId", Int64.Parse(req.ClientId)),
                        new SqlParameter("@BillToAddress", req.BillToAddress),
                        new SqlParameter("@BillToAddressId", Int64.Parse(req.BillToAddressId)),
                        new SqlParameter("@ShipToAddress", req.ShipToAddress),
                        new SqlParameter("@ShipToAddressId", Int64.Parse(req.ShipToAddressId)),
                        new SqlParameter("@Remark", req.Remark),
                        new SqlParameter("@priority", req.Priority),
                        new SqlParameter("@deltype", req.DeliveryType),
                        new SqlParameter("@sapno", req.SAPOrderNo),
                        new SqlParameter("@finalsave", req.FinalSave),
                        new SqlParameter("@orderfrom", req.OrderFrom)
                    };

            return obj.Return_ScalerValue("SP_SaveSOHead", param);
        }
        public void sendOrderAddEmail(string OrderId, long UserId)
        {
            DataSet ds = new DataSet();
            string PortalUser = "";
            string UserEmail = "";


            ds = DPUserEmail(OrderId, UserId);
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {

                    PortalUser = ds.Tables[0].Rows[i]["PortalUser"].ToString();
                    UserEmail = ds.Tables[0].Rows[i]["UserEmail"].ToString();
                }

            }
            string bodytext = "You Have Successfully Added your Order " + OrderId + " into the system, Your Order is Pending for Admin approval.";

            if (UserEmail != "")
            {
                SendMail(UserEmail, bodytext, "Order Status", "Your Order Status Update");
            }
            //if (PortalUser != "")
            //{
            //    SendMail(PortalUser, bodytext, "Order Status", "Your Order Status Update");

            //}

        }
        public DataSet DPUserEmail(string Oid, long UserId)
        {
            DataSet ds = new DataSet();
            param = new SqlParameter[]
                       {
                        new SqlParameter("@OrderId", Int64.Parse(Oid)),
                        new SqlParameter("@UserId", UserId)

                       };
            ds = obj.Return_DataSet("sp_getDPEmail", param);

            return ds;
        }
        public string SendMail(string EmailId, string bodytest, string heading, string Subject)
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
        public string SaveSOSKUDetail(SaveSOSKUDetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@soid", Int64.Parse(req.OrderId)),
                        new SqlParameter("@prdid", Int64.Parse(req.SkuId)),
                        new SqlParameter("@orderqty", Decimal.Parse(req.OrderQty)),
                        new SqlParameter("@uomid", Int64.Parse(req.UOMId)),
                        new SqlParameter("@lot", req.Lottable),
                        new SqlParameter("@uid", req.UserId),
                        new SqlParameter("@InitScopeQty", req.InitScopeQty),
                        new SqlParameter("@Projectcode", req.Projectcode),
                        new SqlParameter("@ProjectName", req.ProjectName),
                        new SqlParameter("@LogSpaceCode", req.LogSpaceCode),
                        new SqlParameter("@LogSpaceName", req.LogSpaceName),
                    };
            //return obj.Return_ScalerValue("SP_SaveSOSKUDetail", param);
            return obj.Return_ScalerValue("SP_SaveSOSKUDetail_NEW", param);
        }
        public string AutoAllocationDirect(Int64 SOID, Int64 userId, Int64 custid)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@SONO", SOID),
                        new SqlParameter("@userid", userId),
                        new SqlParameter("@customerid", custid)

                    };
            return obj.Return_ScalerValue("Auto_Allocationonebyone", param);
        }
        public string RemoveSOSKU(RemoveSOSKURequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@soid", Int64.Parse(req.OrderId)),
                        new SqlParameter("@id", Int64.Parse(req.Id))
                    };
            return obj.Return_ScalerValue("SP_RemoveSOSKU", param);
        }
        public string CancelSO(CancelSORequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@orderid", Int64.Parse(req.OrderId)),
                        new SqlParameter("@cancelby", Int64.Parse(req.UserId))
                    };
            return obj.Return_ScalerValue("SP_CancelSO", param);
        }
        public async Task<JsonElement> SOSKUSuggestionList(SOSKUSuggestionRequest req)
        {
            DataSet ds = new DataSet();
            DataSet dsuom = new DataSet();
            DataSet dslott = new DataSet();
            String jsonString = String.Empty;
            param = new SqlParameter[]
                    {
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@orderid", Int64.Parse(req.OrderId)),
                        new SqlParameter("@skey", req.skey),
                        new SqlParameter("@islist", req.isSuggestionList),
                        new SqlParameter("@clientid", req.ClientId),
                        new SqlParameter("@portal", req.portal),
                        new SqlParameter("@obj", req.Object),
                        new SqlParameter("@lot", req.Lot)
                    };
            ds = obj.Return_DataSet("SP_GetSOSKUSuggestion", param);

            List<SKUSuggestList> slist = new List<SKUSuggestList>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    SKUSuggestList sku = new SKUSuggestList();
                    sku.ID = ds.Tables[0].Rows[i]["ID"].ToString();
                    sku.ProductCode = ds.Tables[0].Rows[i]["ProductCode"].ToString();
                    sku.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                    sku.Description = ds.Tables[0].Rows[i]["Description"].ToString();
                    sku.UPCBarcode = ds.Tables[0].Rows[i]["UPCBarcode"].ToString();
                    sku.CurrentStock = ds.Tables[0].Rows[i]["CurrentStock"].ToString();
                    sku.ResurveQty = ds.Tables[0].Rows[i]["ResurveQty"].ToString();
                    sku.Category = ds.Tables[0].Rows[i]["Category"].ToString();
                    sku.SubCategory = ds.Tables[0].Rows[i]["SubCategory"].ToString();
                    sku.GroupSet = ds.Tables[0].Rows[i]["GroupSet"].ToString();
                    sku.ImagePath = ds.Tables[0].Rows[i]["ImagePath"].ToString();
                    sku.SKey = ds.Tables[0].Rows[i]["SKey"].ToString();
                    sku.Lottables = ds.Tables[0].Rows[i]["Lottables"].ToString();

                    dsuom = null;
                    param = new SqlParameter[]
                    {
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@orderid", Int64.Parse(req.OrderId)),
                        new SqlParameter("@SkuId", Int64.Parse(sku.ID)),
                    };
                    dsuom = obj.Return_DataSet("SP_GetSOSKUUOM", param);

                    List<UOM> uomlst = new List<UOM>();
                    for (int j = 0; j < dsuom.Tables[0].Rows.Count; j++)
                    {
                        UOM uom = new UOM();
                        uom.ID = dsuom.Tables[0].Rows[j]["ID"].ToString();
                        uom.Name = dsuom.Tables[0].Rows[j]["Description"].ToString();
                        uom.UnitValue = dsuom.Tables[0].Rows[j]["Quantity"].ToString();
                        uom.isSelected = dsuom.Tables[0].Rows[j]["isselect"].ToString();
                        uomlst.Add(uom);
                    }
                    sku.UOM = uomlst;

                    List<Lottable> lotlst = new List<Lottable>();
                    for (int k = 0; k < dsuom.Tables[1].Rows.Count; k++)
                    {
                        Lottable lot = new Lottable();
                        lot.ID = dsuom.Tables[1].Rows[k]["ID"].ToString();
                        lot.Name = dsuom.Tables[1].Rows[k]["LottableDescription"].ToString();
                        lot.DataType = dsuom.Tables[1].Rows[k]["LottableFormat"].ToString();
                        lot.isSelected = dsuom.Tables[1].Rows[k]["isselect"].ToString();
                        //lot.isSelected = dsuom.Tables[1].Rows[k]["isselect"].ToString();
                        lot.IsPartofOutward = dsuom.Tables[1].Rows[k]["IsPartofOutward"].ToString();
                        lotlst.Add(lot);
                    }
                    sku.Lottable = lotlst;
                    slist.Add(sku);
                }
                jsonString = "{\"SKUSuggestList\":";
                jsonString = jsonString + JsonConvert.SerializeObject(slist);
                jsonString = jsonString + "}";
            }
            else
            {
                jsonString = "{\"SKUSuggestList\":[]}";
            }
            //return JObject.Parse(jsonString);
            JsonDocument doc = JsonDocument.Parse(jsonString);
            JsonElement respjson = doc.RootElement;
            return respjson;
        }
        public async Task<JsonElement> SOSKUUOMList(SOSKUUOMRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@orderid", Int64.Parse(req.OrderId)),
                        new SqlParameter("@SkuId", Int64.Parse(req.SkuId)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetSOSKUUOM", param));
        }
        public async Task<JsonElement> SOSearchSKU(SOSearchSKUSRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@orderid", Int64.Parse(req.OrderId)),
                        new SqlParameter("@skey", req.skey)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetSOSearchSKU", param));
        }
        public async Task<JsonElement> SODetails(SODetailRequest req)
        {
            DataSet ds = new DataSet();
            DataSet dsuom = new DataSet();
            String jsonString = String.Empty;

            List<OutboundOrderDetails> podlst = new List<OutboundOrderDetails>();
            param = new SqlParameter[]
                    {
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@orderid", Int64.Parse(req.OrderId))
                    };
            ds = obj.Return_DataSet("SP_GetSODetails", param);

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    OutboundOrderDetails pod = new OutboundOrderDetails();
                    pod.Id = ds.Tables[0].Rows[i]["ID"].ToString();
                    pod.SkuId = ds.Tables[0].Rows[i]["SkuId"].ToString();
                    pod.ItemCode = ds.Tables[0].Rows[i]["Prod_Code"].ToString();
                    pod.ItemName = ds.Tables[0].Rows[i]["Prod_Name"].ToString();
                    pod.RequestedQty = ds.Tables[0].Rows[i]["OrderQty"].ToString();
                    pod.CurrentStock = ds.Tables[0].Rows[i]["CurrentStock"].ToString();
                    pod.ReserveQty = ds.Tables[0].Rows[i]["ResurveQty"].ToString();
                    pod.UOM = ds.Tables[0].Rows[i]["UOM"].ToString();
                    pod.UOMId = ds.Tables[0].Rows[i]["UOMID"].ToString();
                    pod.IsEdit = Convert.ToInt32(ds.Tables[0].Rows[i]["IsEdit"].ToString());
                    pod.InitScopeQty = ds.Tables[0].Rows[i]["InitScopeQty"].ToString();
                    pod.Projectcode = ds.Tables[0].Rows[i]["Projectcode"].ToString();
                    pod.ProjectName = ds.Tables[0].Rows[i]["ProjectName"].ToString();
                    pod.LogSpaceCode = ds.Tables[0].Rows[i]["LogSpaceCode"].ToString();
                    pod.LogSpaceName = ds.Tables[0].Rows[i]["LogSpaceName"].ToString();



                    param = new SqlParameter[]
                    {
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@orderid", Int64.Parse(req.OrderId)),
                        new SqlParameter("@SkuId", Int64.Parse(pod.SkuId)),
                    };
                    dsuom = obj.Return_DataSet("SP_GetSOSKUUOM", param);

                    List<UomList> uomlst = new List<UomList>();
                    for (int j = 0; j < dsuom.Tables[0].Rows.Count; j++)
                    {
                        UomList uom = new UomList();
                        uom.Id = dsuom.Tables[0].Rows[j]["ID"].ToString();
                        uom.Uom = dsuom.Tables[0].Rows[j]["Description"].ToString();
                        uom.UnitQty = dsuom.Tables[0].Rows[j]["Quantity"].ToString();
                        uomlst.Add(uom);
                    }
                    pod.UomList = uomlst;
                    pod.OrderQty = ds.Tables[0].Rows[i]["OrderQty"].ToString();
                    pod.Lottable = ds.Tables[0].Rows[i]["Lottable"].ToString();
                    podlst.Add(pod);
                }
                jsonString = "{\"OrderDetails\":";
                jsonString = jsonString + JsonConvert.SerializeObject(podlst);
                jsonString = jsonString + "}";
            }
            else
            {
                jsonString = "{\"OrderDetails\":[]}";
            }

            //return JObject.Parse(jsonString);
            JsonDocument doc = JsonDocument.Parse(jsonString);
            JsonElement respjson = doc.RootElement;
            return respjson;
        }
        public async Task<JsonElement> StagingDetail(GetStagingDetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@oid", Int64.Parse(req.OrderId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetStagingDetail", param));
        }
        public string SaveStagingDetail(SaveStagingDetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@soid", Int64.Parse(req.OrderId)),
                        new SqlParameter("@contid", req.DiapatchID),
                        new SqlParameter("@apointdtls", req.AppointDetail),
                        new SqlParameter("@apointdate", req.AppointDate),
                        new SqlParameter("@seal", req.SealNo),
                        new SqlParameter("@trailer", req.Trailer),
                        new SqlParameter("@transport", req.TransportName),
                        new SqlParameter("@transremark", req.TransportRemark),
                        new SqlParameter("@dock", Int64.Parse(req.DockNo)),
                        new SqlParameter("@airbill", req.AirBillNo),
                        new SqlParameter("@shiptype", req.ShipType),
                        new SqlParameter("@shipdate", req.ShipDate),
                        new SqlParameter("@expdeldate", req.ExpShipDate),
                        new SqlParameter("@lrno", req.LRNo),
                        new SqlParameter("@intime", req.InTime),
                        new SqlParameter("@outtime", req.OutTime),
                        new SqlParameter("@driver", req.Driver),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@prono", req.PRONo),
                        new SqlParameter("@fretcharge", req.FreightCharge),
                        new SqlParameter("@mbol", req.MasterBOL),
                        new SqlParameter("@codamt", req.CODAmt),
                        new SqlParameter("@fterm", req.feeTerm),
                        new SqlParameter("@lodedby", req.TrailerLoadBy),
                        new SqlParameter("@fretcntby", req.FrieghtCountBy),
                        new SqlParameter("@cnttyp", ""),
                        new SqlParameter("@trno", req.TrackingNo),
                        new SqlParameter("@qno", ""),
                        new SqlParameter("@refno", ""),
                        new SqlParameter("@bol", req.BOL)
                    };
            return obj.Return_ScalerValue("SP_SaveStagingDetail", param);
        }
        public async Task<JsonElement> GetSuggestedClient(GetSuggestedClientRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@skey", req.SearchKey),
                        new SqlParameter("@islist", req.isSuggestionList),
                        new SqlParameter("@obj", req.Object)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Getsuggestedclient", param));
        }
        public async Task<JsonElement> GetSuggestedClientAddr(GetSuggestedClientAddrRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@clientid", Int64.Parse(req.ClientID)),
                        new SqlParameter("@skey", req.SearchKey),
                        new SqlParameter("@islist", req.isSuggestionList),
                        new SqlParameter("@obj", req.Object)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GetsuggestedclientAddr", param));
        }
        public string SaveSkuKeyWard(SaveSkuKeyWardRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@key", req.Key),
                        new SqlParameter("@prdid", Int64.Parse(req.ProdID)),
                        new SqlParameter("@clientid", Int64.Parse(req.ClientID)),
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId))
                    };
            return obj.Return_ScalerValue("SaveSKUKeyward", param);
        }
        public string RemoveSkuKeyWard(RemoveSkuKeyWardRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@key", req.Key),
                        new SqlParameter("@prdid", Int64.Parse(req.ProdID)),
                        new SqlParameter("@clientid", Int64.Parse(req.ClientID)),
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId))
                    };
            return obj.Return_ScalerValue("RemoveSKUKeyward", param);
        }
        public string DeAllocateOrder(DeAllocateOrderRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@orderid", Int64.Parse(req.OrderId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId))
                    };
            return obj.Return_ScalerValue("SP_DeallocateOrder", param);
        }

        public string EditSOSKU(EditSOSKURequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@Id", Int64.Parse(req.Id)),
                        new SqlParameter("@InitialScopeQty", req.InitialScopeQty),
                        new SqlParameter("@RequestedQty", req.RequestedQty),
                        new SqlParameter("@OrderQty", req.OrderQty),
                        new SqlParameter("@projcode", req.projcode),
                        new SqlParameter("@projname", req.projname),
                        new SqlParameter("@logiccode", req.logiccode),
                        new SqlParameter("@logicname", req.logicname)
                    };
            return obj.Return_ScalerValue("SP_EditSOSKU", param);
        }
    }
}