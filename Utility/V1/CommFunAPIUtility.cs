using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Text;
using WMSWebAPI.Models.V1.Request;
using System.Text.Json;

namespace WMSWebAPI.Utility.V1
{
    public class CommFunAPIUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public CommFunAPIUtility()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> Get_PalletList(ReqPalletList reqPara)
        {

            param = new SqlParameter[]
                    {new SqlParameter("@companyId",Convert.ToInt64(reqPara.CompanyId)),
                    new SqlParameter("@userId",Convert.ToInt64(reqPara.userId)),
                    new SqlParameter("@whId",Convert.ToInt64(reqPara.whId)),
                    new SqlParameter("@custId",Convert.ToInt64(reqPara.custId)),
                    new SqlParameter("@PalletName",reqPara.PalletName),
                    new SqlParameter("@obj",reqPara.obj),
                    new SqlParameter("@grnid",reqPara.grnId),
                    new SqlParameter("@POId",reqPara.POID)
                    };

            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Get_PalletList", param));

        }
        public async Task<JsonElement> getLottablevalue(lottablereq req)
        {
            param = new SqlParameter[]
                   {new SqlParameter("@ProdID",req.prodID),
                   new SqlParameter("@OrderID",req.orderID),
                   new SqlParameter("@Obj",req.obj),
                   new SqlParameter("@grnID",req.GrnID),
                   new SqlParameter("@pallet",req.palletname),
                   new SqlParameter("@Lottable",req.lottable)
                   };

            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_getvaluelotV2", param));

        }
        public async Task<JsonElement> SKUSuggestionList(SKUSuggestionRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@orderid", Int64.Parse(req.OrderId)),
                         new SqlParameter("@obj", req.skuobject),
                        new SqlParameter("@skey", req.skey),
                        new SqlParameter("@orderfor", req.orderobj),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetSKUSuggestion", param));
        }
        public async Task<JsonElement> POSKUUOMList(SKUUOMRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@SkuId", Int64.Parse(req.SkuId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetPOSKUUOM", param));
        }
        public async Task<JsonElement> ScanSuggestionList(ScanSuggestionRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@orderid", Int64.Parse(req.OrderId)),
                         new SqlParameter("@obj", req.obj),
                        new SqlParameter("@currentpg", req.currentpg),
                        new SqlParameter("@recordlmt", req.recordlmt)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetScanSuggestion", param));
        }
        public async Task<JsonElement> Scaninbound(scanrequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@value",req.value),
                        new SqlParameter("@companyID",req.companyID),
                        new SqlParameter("@obj",req.obj),
                        new SqlParameter("@OrderID",req.orderID)

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_chkinboundscanvalue", param));
        }
        public async Task<JsonElement> userListList(userlist req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@companyID", Int64.Parse(req.companyID))

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_AssingUserList", param));
        }

        public string saveAssingment(assinguserRequest req)
        {
            string result = "";
            param = new SqlParameter[]
                    {

                        new SqlParameter("@type",req.type),
                        new SqlParameter("@userID",Convert.ToInt64(req.UserID)),
                        new SqlParameter("@assingmentdate", req.date),
                        new SqlParameter("@time",req.time),
                        new SqlParameter("@companyID",Convert.ToInt64(req.companyID)),
                        new SqlParameter("@customerID",Convert.ToInt64(req.customerID)),
                        new SqlParameter("@createdby",Convert.ToInt64(req.createdBy)),
                       new SqlParameter("@obj",req.obj),
                        new SqlParameter("@OrderID",Convert.ToInt64(req.orderID))
                    };
            result = obj.Return_ScalerValue("sp_saveassingment", param);
            if (result == "Success")
            {
                SendMailDynamic(Convert.ToInt64(req.UserID), req.orderID, req.type, req.obj);
            }
            return result;
        }
        public string SendMailDynamic(long uid, string orderid, string type, string objct)
        {
            DataSet ds = new DataSet();
            DataSet dsuser = new DataSet();
            string Email_host = "";
            string Email_password = "";
            string Email_port = "";
            string from = "";
            string bodytest = "You have assing #Order " + orderid + " for " + type + " at " + objct + "";
            //string heading = "Order Assignment";
            string Subject = "Order Assignment";

            param = new SqlParameter[]
                   {
                   };
            ds = obj.Return_DataSet("sp_emailDetails", param);
            if (ds.Tables[0].Rows.Count > 0)
            {
                emailParaD req = new emailParaD();
                Email_host = req.Email_host = ds.Tables[0].Rows[0]["EmailHost"].ToString();
                Email_password = req.Email_password = ds.Tables[0].Rows[0]["EmailPassword"].ToString();
                Email_port = req.Email_port = ds.Tables[0].Rows[0]["EmailPort"].ToString();
                from = req.from = ds.Tables[0].Rows[0]["EmailUsername"].ToString();
            }

            param = null;
            param = new SqlParameter[]
                   {
                        new SqlParameter("@uid",uid)
                   };
            ds = obj.Return_DataSet("getUserDetail", param);

            string MailStatus = "";
            string user = ds.Tables[0].Rows[0]["UserName"].ToString();
            string to = ds.Tables[0].Rows[0]["EmailID"].ToString();
            MailMessage message = new MailMessage(from, to);

            string MailBody = "";
            MailBody = " <div style='font-family: Helvetica,Arial,sans - serif; min - width:1000px; overflow: auto; line - height:2'>";
            MailBody = MailBody + " <div style='margin: 50px auto; width: 70 %; padding: 0px 0'>";
            //MailBody = MailBody + "   <div style='border - bottom:1px solid #eee'>";
            //MailBody = MailBody + "    <a href=''style='font-size:1.4em; color: #00466a;text-decoration:none;font-weight:600'>" + heading + "</a>";
            //MailBody = MailBody + " </div>";
            MailBody = MailBody + " <p style='font-size:1.1em'> Hello </p>";
            MailBody = MailBody + "<p>" + bodytest + "</p>";
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
            }
            return MailStatus;
        }

        #region Developed By Yashartha For Suggestion List 
        public async Task<JsonElement> POSKUSuggestionList(POOSKUSuggestionRequest req)
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
                        new SqlParameter("@lastSeqno", Int64.Parse(req.lastSeqno))
                    };
            ds = obj.Return_DataSet("SP_GetPOSKUSuggestion", param);

            List<SKUCommanFunSuggestList> slist = new List<SKUCommanFunSuggestList>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    SKUCommanFunSuggestList sku = new SKUCommanFunSuggestList();
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
                    dsuom = obj.Return_DataSet("SP_GetPOSSKUUOM", param);

                    List<UOMCommanFun> uomlst = new List<UOMCommanFun>();
                    for (int j = 0; j < dsuom.Tables[0].Rows.Count; j++)
                    {
                        UOMCommanFun uom = new UOMCommanFun();
                        uom.ID = dsuom.Tables[0].Rows[j]["ID"].ToString();
                        uom.Name = dsuom.Tables[0].Rows[j]["Description"].ToString();
                        uom.UnitValue = dsuom.Tables[0].Rows[j]["Quantity"].ToString();
                        uom.isSelected = dsuom.Tables[0].Rows[j]["isselect"].ToString();
                        uomlst.Add(uom);
                    }
                    sku.UOM = uomlst;

                    List<LottableCommanFun> lotlst = new List<LottableCommanFun>();
                    for (int k = 0; k < dsuom.Tables[1].Rows.Count; k++)
                    {
                        LottableCommanFun lot = new LottableCommanFun();
                        lot.ID = dsuom.Tables[1].Rows[k]["ID"].ToString();
                        lot.Name = dsuom.Tables[1].Rows[k]["LottableDescription"].ToString();
                        lot.DataType = dsuom.Tables[1].Rows[k]["LottableFormat"].ToString();
                        lot.isSelected = dsuom.Tables[1].Rows[k]["isselect"].ToString();
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
            //Changes done
            string JSONString = string.Empty;
            JsonDocument doc = JsonDocument.Parse(JSONString);
            JsonElement respjson = doc.RootElement;
            return respjson;
        }


        public async Task<JsonElement> SKUSuggestionListInQC(SKUSuggestionRequestInQC req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@orderid", Int64.Parse(req.OrderId)),
                         new SqlParameter("@obj", req.skuobject),

                        new SqlParameter("@orderfor", req.orderobj),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetSKUSuggestionInQC", param));
        }

        #endregion
    }
}
