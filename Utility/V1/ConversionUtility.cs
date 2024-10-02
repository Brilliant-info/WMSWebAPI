using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using static WMSWebAPI.Models.V1.Request.Conversion;
using System.Data.SqlClient;
using System.Data;
using System.Text.Json;

namespace WMSWebAPI.Utility.V1
{
    public class ConversionUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public ConversionUtility()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> GetConversionSKUList(GetConversionSKUListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", Int64.Parse(req.CurrentPage)),
                        new SqlParameter("@RecordLimit", Int64.Parse(req.RecordLimit)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@Search", req.Search),
                        new SqlParameter("@Filter", req.Filter)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_Conversionlist", param));
        }
        public async Task<JsonElement> GetConvSKUSuggestion(GetConvSKUSuggestionRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", Int64.Parse(req.CurrentPage)),
                        new SqlParameter("@RecordLimit", Int64.Parse(req.RecordLimit)),
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@orderid", Int64.Parse(req.OrderId)),
                        new SqlParameter("@skey", req.skey),
                        new SqlParameter("@islist", req.isSuggestionList),
                        new SqlParameter("@clientid", req.ClientId),
                        new SqlParameter("@portal", req.portal),
                        new SqlParameter("@obj", req.Object),
                        new SqlParameter("@lot", req.Lot),
                        new SqlParameter("@skuid", Int64.Parse(req.skuid))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetConvSKUSuggestion", param));
        }
        public string GetSkuConversionSave(GetSkuConversionSaveRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@convId", req.convId),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                       // new SqlParameter("@ConversionDate", req.ConversionDate),
                        new SqlParameter("@Remark", req.Remark),
                        new SqlParameter("@SkuID ",Int64.Parse(req.SkuID)),
                        new SqlParameter("@Locationcode", req.Locationid),
                        new SqlParameter("@Palletid",Int64.Parse(req.Palletid)),
                        new SqlParameter("@Lottable", req.Lottable),
                        new SqlParameter("@Qty", Int64.Parse(req.Qty)),
                        new SqlParameter("@isFinalSave", req.isFinalSave),
                        new SqlParameter("@TrId", req.TrId),
                        new SqlParameter("@ConversionQty", req.ConversionQty),
                        new SqlParameter("@Conversionweight", req.Conversionweight)
                    };
            return obj.Return_ScalerValue("SP_SkuConversionSaveV1", param);
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
        public async Task<JsonElement> SaveDTConverstion(SkuConversionSaveRequestDT req)
        {
            DataSet ds = new DataSet();
            DataTable dtlot = new DataTable();
            string Lottable1 = "0";
            string Lottable2 = "0";
            string Lottable3 = "0";
            int Lott = 0;
            string avalue = "";
            List<string> subs1 = new List<string>();

            dtlot = getLottables(Convert.ToInt64(req.SkuID));
            if (req.Lottable != "-")
            {
                foreach (string item in req.Lottable.Split('|'))
                {
                    string[] subs = item.Split(':');
                    subs1.Add(subs[0].ToString());
                }
                String[] str = subs1.ToArray();
                Lottable1 = str[0];
                Lottable2 = str[1];
                Lottable3 = str[2];
            }

            /*if (dtlot.Rows.Count > 0 && req.Lottable != "-")
            {
                foreach (string item in req.Lottable.Split('|'))
                {
                    string[] subs = item.Split(':');
                    DataRow[] dr = dtlot.Select("ID = " + subs[0].ToString());
                    if (dr.Length > 0)
                    {
                        avalue = dr[0]["LottableTitle"].ToString().ToLower();
                        if (avalue == "lottable-1") { Lottable1 = subs[1]; }
                        else if (avalue == "lottable-2") { Lottable2 = subs[1]; }
                        else if (avalue == "lottable-3") { Lottable3 = subs[1]; }
                    }
                }
            }*/

            param = new SqlParameter[]
                    {
                         new SqlParameter("@custid", req.CustomerId),
                        new SqlParameter("@wrid", req.WarehouseId),
                         new SqlParameter("@ClientId", req.ClientId),
                        new SqlParameter("@convId", req.ConvId),
                        new SqlParameter("@UserID", req.UserId),
                        new SqlParameter("@UOM", req.UOM),
                        new SqlParameter("@SkuID ",Int64.Parse(req.SkuID)),
                        new SqlParameter("@Remark", req.Remark),
                        new SqlParameter("@Locationcode", req.Locationcode),
                        new SqlParameter("@Palletid",Int64.Parse(req.Palletid)),
                        new SqlParameter("@Lottable1", Lottable1),
                        new SqlParameter("@Lottable2", Lottable2),
                        new SqlParameter("@Lottable3", Lottable3),
                        new SqlParameter("@Qty", Int64.Parse(req.Qty)),
                        new SqlParameter("@MTrId", Int64.Parse(req.MTrId)),
                        new SqlParameter("@TrId", Int64.Parse(req.TrId)),
                        new SqlParameter("@weight" , req.weight),
                        new SqlParameter("@cost", req.cost),
                        new SqlParameter("@actualyield", req.actualyield),
                        new SqlParameter("@difference", req.difference)
                        //new SqlParameter("@actualyield", Int64.Parse(req.actualyield)),
                        //new SqlParameter("@difference", Int64.Parse(req.difference))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_SkuConversionSaveDTV1", param));
        }
        public async Task<JsonElement> GetconvDetail(ConvDetailRequest req)
        {
            DataSet ds = new DataSet();
            DataSet dsuom = new DataSet();
            String jsonString = String.Empty;

            List<ConversionOrderDetails> podlst = new List<ConversionOrderDetails>();
            param = new SqlParameter[]
                    {
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@orderid", Int64.Parse(req.OrderId))
                    };
            ds = obj.Return_DataSet("SP_GetConvDetails", param);

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ConversionOrderDetails pod = new ConversionOrderDetails();
                    pod.Id = ds.Tables[0].Rows[i]["ID"].ToString();
                    pod.SkuId = ds.Tables[0].Rows[i]["SkuId"].ToString();
                    pod.ItemCode = ds.Tables[0].Rows[i]["Prod_Code"].ToString();
                    pod.ItemName = ds.Tables[0].Rows[i]["Prod_Name"].ToString();
                    //pod.RequestedQty = ds.Tables[0].Rows[i]["OrderQty"].ToString();
                    //pod.CurrentStock = ds.Tables[0].Rows[i]["CurrentStock"].ToString();
                    //pod.ReserveQty = ds.Tables[0].Rows[i]["ResurveQty"].ToString();
                    pod.UOM = ds.Tables[0].Rows[i]["UOM"].ToString();
                    pod.UOMId = ds.Tables[0].Rows[i]["UOMID"].ToString();
                    pod.skuWeight = ds.Tables[0].Rows[i]["skuWeight"].ToString();
                    pod.skuCost = ds.Tables[0].Rows[i]["skuCost"].ToString();
                    pod.AYield = ds.Tables[0].Rows[i]["AYield"].ToString();
                    pod.diffyield = ds.Tables[0].Rows[i]["diffyield"].ToString();

                    param = new SqlParameter[]
                    {
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@orderid", Int64.Parse(req.OrderId)),
                        new SqlParameter("@SkuId", Int64.Parse(pod.SkuId)),
                    };
                    dsuom = obj.Return_DataSet("SP_GetSOSKUUOM", param);

                    List<SKUUomList> uomlst = new List<SKUUomList>();
                    for (int j = 0; j < dsuom.Tables[0].Rows.Count; j++)
                    {
                        SKUUomList uom = new SKUUomList();
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

            //changes done
            string JSONString = string.Empty;
            JsonDocument doc = JsonDocument.Parse(JSONString);
            JsonElement respjson = doc.RootElement;
            return respjson;
        }
        //SaveDTConverstion
        public async Task<JsonElement> GetconvHead(ConvHeadRequest req)
        {
            param = new SqlParameter[]
                    {
                          new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@orderid", Int64.Parse(req.OrderId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetConvHead", param));
        }
    }
}
