using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RestSharp;
using System.Data.SqlClient;
using System.Data;
using System.Net;
using System.Text;
using WMSWebAPI.Models.V1.Request;
using System.Text.Json;

namespace WMSWebAPI.Utility.V1
{
    public class InboundQCUtility
    {

        SqlParameter[] param;
        DBActivity obj;
        public InboundQCUtility()
        {
            obj = new DBActivity();
        }

        public async Task<JsonElement> QClist(QCDetailRequest req)
        {
            param = new SqlParameter[]
                {
                        new SqlParameter("@POID", Convert.ToInt64(req.OrderId)),
                        new SqlParameter ("@userID",req.UserID),
                        new SqlParameter ("@custid",req.customerID),
                };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_getQualitycheck", param));

        }
        public async Task<JsonElement> QCHead(QCHeadRequest req)
        {
            param = new SqlParameter[]
                   {
                        new SqlParameter("@custid", Convert.ToInt64(req.CustomerId)),
                        new SqlParameter("@wrid", Convert.ToInt64(req.WarehouseId)),
                        new SqlParameter("@uid", req.UserId),
                        new SqlParameter("@grnID", Convert.ToInt64(req.grnID)),
                        new SqlParameter("@QCID", Convert.ToInt64(req.qcID)),
                        new SqlParameter("@ordertype", req.OrderType),
                        new SqlParameter("@obj", req.pageObj)
                   };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetQCHead", param));
        }
        public async Task<JsonElement> getQCID(grnidreq req)
        {
            param = new SqlParameter[]
                   {
                        new SqlParameter("@grnID", Convert.ToInt64(req.grnid)),
                        new SqlParameter("@obj", req.pageObj)
                   };

            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("getQCbyGrn", param));
        }

        public async Task<JsonElement> QCDetails(QCRequest req)
        {

            param = new SqlParameter[]
                   {
                        new SqlParameter("@custid", Convert.ToInt64(req.CustomerId)),
                        new SqlParameter("@wrid", Convert.ToInt64(req.WarehouseId)),
                        new SqlParameter("@uid", req.UserId),
                        new SqlParameter("@orderid", Convert.ToInt64(req.OrderId)),
                        new SqlParameter("@ordertype", req.ordertype)
                   };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetQCDetails", param));

        }

        public string SaveQCDetail(SaveQCDetailRequest req)
        {

            DataSet ds = new DataSet();
            DataTable dtlot = new DataTable();
            string Lottable1 = "0";
            string Lottable2 = "0";
            string Lottable3 = "0";
            string Lottable4 = "0";
            string Lottable5 = "0";
            string Lottable6 = "0";
            string Lottable7 = "0";
            string Lottable8 = "0";
            string Lottable9 = "0";
            string Lottable10 = "0";
            string avalue = "";

            if (req.Lottables != null)
            {

                dtlot = getLottables(req.prodID);
                //if (dtlot.Rows.Count > 0)
                //{
                //if (req.Lottables != "-")
                //{
                //    foreach (string item in req.Lottables.Split('|'))
                //    {
                //        string[] subs = item.Split(':');
                //        DataRow[] dr = dtlot.Select("ID = " + subs[0].ToString());
                //        if (dr.Length > 0)
                //        {
                //            avalue = dr[0]["LottableDescription"].ToString();
                //            if ("ExpDate".ToUpper() == avalue.ToUpper()) { Lottable1 = subs[1]; }
                //            if ("Batch".ToUpper() == avalue.ToUpper()) { Lottable2 = subs[1]; }
                //            if ("MfgDate".ToUpper() == avalue.ToUpper()) { Lottable3 = subs[1]; }

                //        }

                //    }

                //}
                //else {
                //    Lottable1 = "0";
                //    Lottable2 = "0";
                //    Lottable3 = "0";
                //}




                //}
                if (dtlot.Rows.Count > 0 && req.Lottables != "-")
                {
                    foreach (string item in req.Lottables.Split('|'))
                    {
                        string[] subs = item.Split(':');
                        DataRow[] dr = dtlot.Select("ID = " + subs[0].ToString());
                        if (dr.Length > 0)
                        {
                            avalue = dr[0]["LottableTitle"].ToString().ToLower();
                            if (avalue == "lottable-1") { Lottable1 = subs[1]; }
                            else if (avalue == "lottable-2") { Lottable2 = subs[1]; }
                            else if (avalue == "lottable-3") { Lottable3 = subs[1]; }
                            else if (avalue == "lottable-4") { Lottable4 = subs[1]; }
                            else if (avalue == "lottable-5") { Lottable5 = subs[1]; }
                            else if (avalue == "lottable-6") { Lottable6 = subs[1]; }
                            else if (avalue == "lottable-7") { Lottable7 = subs[1]; }
                            else if (avalue == "lottable-8") { Lottable8 = subs[1]; }
                            else if (avalue == "lottable-9") { Lottable9 = subs[1]; }
                            else if (avalue == "lottable-10") { Lottable10 = subs[1]; }
                        }
                    }
                }
            }

            string getdate = "";
            if (req.type == "ScanQC")
            {
                getdate = "";
            }
            else
            {
                getdate = req.qcDate;
            }
            param = new SqlParameter[]
                    {
                        new SqlParameter("@poID", req.poID),
                        new SqlParameter("@objectname",req.obj),
                        new SqlParameter("@QCdate",getdate),
                        new SqlParameter("@companyID", req.companyID),
                        new SqlParameter("@customerID", req.CustomerId),
                        new SqlParameter("@createdby",req.UserId),
                        new SqlParameter("@qcID", req.qcID),
                        new SqlParameter("@grnID", req.grnID),
                        new SqlParameter("@prdid", req.prodID),
                        new SqlParameter("@ReasonID",req.reasonID),
                        new SqlParameter("@uomid", req.UOMId),
                        new SqlParameter("@orderqty", req.RequestedQty),
                         new SqlParameter("@grnqty", req.GRNQty),
                        new SqlParameter("@Qcqty",req.qcQty),
                        new SqlParameter("@RejectedQty",req.rejectedQty),
                        new SqlParameter("@lot1", Lottable1),
                        new SqlParameter("@lot2", Lottable2),
                        new SqlParameter("@lot3", Lottable3),
                        new SqlParameter("@lot4", Lottable4),
                        new SqlParameter("@lot5", Lottable5),
                        new SqlParameter("@lot6", Lottable6),
                        new SqlParameter("@lot7", Lottable7),
                        new SqlParameter("@lot8", Lottable8),
                        new SqlParameter("@lot9", Lottable9),
                        new SqlParameter("@lot10", Lottable10),
                         new SqlParameter("@type",req.type),
                         new SqlParameter("@palletname",req.palletname),
                         new SqlParameter("@PalletID",req.PalletID)
                    };
            return obj.Return_ScalerValue("SP_SaveQCDetail", param);


        }
        public DataTable getLottables(long prodid)
        {
            DataTable dt = new DataTable();
            try
            {
                param = new SqlParameter[]
                   {
                        new SqlParameter("@ProdID", prodid)

                   };
                return obj.exeSP_DT_adapter("sp_lottables", param);

            }
            catch (Exception ex) { }
            finally { }
            return dt;
        }

        public async Task<JsonElement> getReasonCode(QCReasonRequest req)
        {

            param = new SqlParameter[]
                   {
                        new SqlParameter("@custid", Convert.ToInt64(req.CustomerId)),
                        new SqlParameter("@compid", Convert.ToInt64(req.CompanyID)),
                   };

            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetReasonCode", param));

        }
        public string UpdateQCStatus(UpdatQCStatus req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@OrderID", Convert.ToInt64(req.poID)),
                        new SqlParameter("@grnID", Convert.ToInt64(req.GRNID)),
                        new SqlParameter("@obj", req.pageObj)
                    };
            return obj.Return_ScalerValue("sp_UpdateQCStatus", param);
        }

        //public string ReciveNotification(UpdatQCStatus request)
        //{
        //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
        //    string result = "";
        //    ReciveNotification dn = new ReciveNotification();
        //    try
        //    {
        //        // Token
        //        string username = "C_BALAJI";
        //        string password = "Wittymoon502@";
        //        var clientcode = new RestClient("https://fiori-dev.da.com.bn/sap/opu/odata/sap/ZIWMS_GOOD_RECIEPT_SRV/GoodRecieptHeaderSet?sap-client=520");
        //        var reqcode = new RestRequest(Method.GET);
        //        reqcode.AddHeader("Content-Type", "application/json; charset=UTF-8");
        //        reqcode.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(username + ":" + password)));
        //        reqcode.AddHeader("X-CSRF-Token", "fetch");
        //        IRestResponse rescode = clientcode.Execute(reqcode);
        //        string name = rescode.Headers[3].Name.ToString();
        //        string value = rescode.Headers[3].Value.ToString();

        //        dn = ReqJSON(request);
        //        string json = JsonConvert.SerializeObject(dn);

        //        // Dispatch Notification
        //        var client = new RestClient("https://fiori-dev.da.com.bn/sap/opu/odata/sap/ZIWMS_GOOD_RECIEPT_SRV/GoodRecieptHeaderSet?sap-client=520");
        //        var req = new RestRequest(Method.POST);
        //        req.AddHeader("Authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(username + ":" + password)));
        //        req.AddHeader(name, value);
        //        foreach (var ck in rescode.Cookies)
        //        {
        //            req.AddCookie(ck.Name, ck.Value);
        //        }
        //        req.AddHeader("Accept", "application/json");
        //        req.AddParameter("application/json; charset=UTF-8", json, ParameterType.RequestBody);
        //        IRestResponse res = client.Execute(req);
        //        //DataSet myDataSet = JsonConvert.DeserializeObject<DataSet>(res.Content.ToString());
        //        // res.Content=
        //        if (res.StatusDescription == "Created")
        //        {
        //            result = "success";
        //        }
        //        else
        //        {
        //            result = "fail";
        //        }

        //        JObject joResponse = JObject.Parse(res.Content);
        //        JObject ojObject = (JObject)joResponse["d"];
        //        string materialdoc = ojObject["MaterialDoc"].ToString();
        //        string fiscalyear = ojObject["Fiscalyear"].ToString();
        //        //string typesds = joResponse["Type"].ToString();
        //        string docyear = materialdoc + fiscalyear;
        //        long poid = Convert.ToInt64(request.poID);
        //        long grnID = Convert.ToInt64(request.GRNID);
        //        if (materialdoc != "")
        //        {
        //            insertReciveLog(materialdoc, fiscalyear, "", "", "", docyear, poid, grnID, result);
        //        }
        //        else
        //        {
        //            JObject jsreturn = (JObject)ojObject["ReturnMessageSet"];
        //            // JObject obj = JsonNode.Parse(json).AsObject();
        //            JArray jsonArray = (JArray)jsreturn["results"];
        //            // JObject  = (JObject)joResponse["d"];
        //            string type = jsonArray[0]["Type"].ToString();
        //            string Number = jsonArray[0]["Number"].ToString();
        //            string Message = jsonArray[0]["Message"].ToString();
        //            string ID = jsonArray[0]["ID"].ToString();
        //            insertReciveLog(materialdoc, fiscalyear, type, Number, Message, docyear, poid, grnID, result);
        //        }

        //        //JArray array = (JArray)ojObject["SaleDocumentNo"];
        //        // int id = Convert.ToInt32(array[0].toString());

        //    }
        //    catch (Exception ex)
        //    {
        //        insertReciveLog("0", "0", "0", "0", ex.Message, "0", 0, 0, "Failed");
        //        result = ex.Message;
        //    }
        //    return result;
        //}
        public string insertReciveLog(string materialdoc, string fiscalyear, string type, string number, string message, string docyear, long poid, long grnID, string result)
        {

            param = new SqlParameter[]
                    {
                        new SqlParameter("@MaterialDoc",materialdoc),
                         new SqlParameter("@FiscalYear",fiscalyear),
                         new SqlParameter("@type",type),
                         new SqlParameter("@Number",number),
                         new SqlParameter("@message",message),
                         new SqlParameter("@MaterialYear",docyear),
                         new SqlParameter("@POID",poid),
                         new SqlParameter("@GrnID",grnID),
                         new SqlParameter("@APIStatus",result),


                    };
            return obj.Return_ScalerValue("sp_insertRecivelog", param);

        }
        public ReciveNotification ReqJSON(UpdatQCStatus req)
        {
            ReciveNotification main = new ReciveNotification();
            DataSet ds = new DataSet();
            try
            {
                param = new SqlParameter[]
                    {
                        new SqlParameter("@OrderID", req.poID),
                        new SqlParameter("@grnID", req.GRNID),
                    };
                ds = obj.Return_DataSet("sp_GetReciptDetailsData", param);

                main.OrderReferenceNO = ds.Tables[0].Rows[0]["OrderReferenceNO"].ToString();
                main.MaterialDoc = ds.Tables[0].Rows[0]["MaterialDoc"].ToString();
                main.RecieptDate = ds.Tables[0].Rows[0]["RecieptDate"].ToString();
                main.Fiscalyear = ds.Tables[0].Rows[0]["Fiscalyear"].ToString();
                main.DocDate = ds.Tables[0].Rows[0]["DocDate"].ToString();
                //GoodRecieptItemSet


                List<GoodRecieptItemSet> oislst = new List<GoodRecieptItemSet>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    GoodRecieptItemSet ois = new GoodRecieptItemSet();
                    ois.MovementIndicator = ds.Tables[0].Rows[i]["MovementIndicator"].ToString();
                    ois.OrderReferenceNO = ds.Tables[0].Rows[i]["OrderReferenceNO"].ToString();
                    ois.ItemNo = ds.Tables[0].Rows[i]["ItemNo"].ToString();
                    ois.CustomerNo = ds.Tables[0].Rows[i]["CustomerNo"].ToString();
                    ois.SKUcode = ds.Tables[0].Rows[i]["SKUcode"].ToString();
                    ois.MoveType = ds.Tables[0].Rows[i]["MoveType"].ToString();
                    ois.Plant = ds.Tables[0].Rows[i]["Plant"].ToString();
                    ois.WareHouseCode = ds.Tables[0].Rows[i]["WareHouseCode"].ToString();
                    ois.Quantity = ds.Tables[0].Rows[i]["Quantity"].ToString();
                    ois.Uom = ds.Tables[0].Rows[i]["Uom"].ToString();
                    oislst.Add(ois);
                }
                main.GoodRecieptItemSet = oislst;
                //ReturnMessageSet
                List<ReturnMessageSet> rmslst = new List<ReturnMessageSet>();
                main.ReturnMessageSet = rmslst;

            }
            catch (Exception ex)
            {
            }
            return main;
        }
        public string RemoveQCSKUDetail(RemoveQCSKURequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@QCid", req.QCid),
                        new SqlParameter("@recordID", req.recordID),
                        new SqlParameter("@obj",req.obj)
                    };
            return obj.Return_ScalerValue("SP_RemoveQCSKU", param);
        }
    }
}
