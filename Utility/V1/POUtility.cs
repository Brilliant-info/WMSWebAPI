using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;
using WMSWebAPI.Utility;

namespace WMSWebAPI.Utility.V1
{
    public class POUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public POUtility()
        {
            obj = new DBActivity();

        }

        public string SavePOHead(SaveOrderHeadRequest req)
        {
            if (req.Remark == null)
            {
                req.Remark = "";
            }
            param = new SqlParameter[]
                    {
                        new SqlParameter("@poid", Int64.Parse(req.Poid)),
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@obj", req.Object),
                        new SqlParameter("@recdate", req.InboundReceiptDate),
                        new SqlParameter("@deldate", req.ExpectedDeliveryDate),
                        new SqlParameter("@orderno", req.CustomerRefNo),
                        new SqlParameter("@remark", req.Remark),
                        new SqlParameter("@vendorid", Int64.Parse(req.VendorId))
                    };
            return  obj.Return_ScalerValue("SP_SavePOHead", param);
        }

        public string SavePOSKUDetail(SavePOSKUDetailRequest req)
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

            int Lott = 0;
            string avalue = "";
            string Status = "fail";

            dtlot =  getLottables(Convert.ToInt64(req.SkuId));
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

            param = new SqlParameter[]
                    {
                        new SqlParameter("@poid", Int64.Parse(req.OrderId)),
                        new SqlParameter("@prdid", Int64.Parse(req.SkuId)),
                        new SqlParameter("@orderqty", Decimal.Parse(req.OrderQty)),
                        new SqlParameter("@uomid", Int64.Parse(req.UOMId)),
                        new SqlParameter("@uom",req.UOM),
                        new SqlParameter("@lot1",Lottable1),
                        new SqlParameter("@lot2",Lottable2),
                        new SqlParameter("@lot3",Lottable3),
                        new SqlParameter("@lot4",Lottable4),
                        new SqlParameter("@lot5",Lottable5),
                        new SqlParameter("@lot6",Lottable6),
                        new SqlParameter("@lot7",Lottable7),
                        new SqlParameter("@lot8",Lottable8),
                        new SqlParameter("@lot9",Lottable9),
                        new SqlParameter("@lot10",Lottable10),
                        new SqlParameter("@netwt", Decimal.Parse(req.CaseNetWeight)),
                        new SqlParameter("@grosswt", Decimal.Parse(req.CaseGrossWeight)),
                        new SqlParameter("@totcartn", Decimal.Parse(req.TotalCarton))
                    };
            Status = obj.Return_ScalerValue("SP_SavePOSKUDetail", param);

            return Status;
        }
        public string RemovePOSKU(RemovePOSKURequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@OrderID", Int64.Parse(req.OrderId)),
                        new SqlParameter("@id", Int64.Parse(req.Id)),
                        new SqlParameter("@obj", req.obj),
                        new SqlParameter("@lot", Int64.Parse(req.POIDDT)),
                    };
            return obj.Return_ScalerValue("SP_RemovePOSKU", param);
        }
        public string closePOpopup(closePOpopup req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Orderid", Int64.Parse(req.orderID))

                    };
            return obj.Return_ScalerValue("sp_POclosePopup", param);
        }
        public string RemovePO(long poID)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@poid",poID),

                    };
            return obj.Return_ScalerValue("SP_RemovePO", param);
        }
        public async Task<JsonElement> GetInboundList(GetInboundListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@currentpg", Int32.Parse(req.CurrentPage)),
                        new SqlParameter("@recordlmt", Int32.Parse(req.recordLimit)),
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int32.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int32.Parse(req.UserId)),
                        new SqlParameter("@obj", req.Object),
                        new SqlParameter("@tabfileter", req.Activetab),
                        new SqlParameter("@searchfilter",req.searchFilter),
                        new SqlParameter("@searchvalue", req.searchValue)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GetInboundListFilterPartial", param));
        }
        public async Task<JsonElement> POSearchSKU(POSearchSKUSRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@orderid", Int64.Parse(req.OrderId)),
                        new SqlParameter("@skey", req.skey)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetPOSearchSKU", param));
        }
        public async Task<JsonElement> DispPODetail(PODetailRequest req)
        {
            DataSet ds = new DataSet();
            DataSet dsuom = new DataSet();
            param = new SqlParameter[]
                    {
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@orderid", Int64.Parse(req.OrderId))
                    };
            ds =  obj.Return_DataSet("SP_DispPODetail", param);

            List<PurchaseOrderDetails> podlst = new List<PurchaseOrderDetails>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    PurchaseOrderDetails pod = new PurchaseOrderDetails();
                    pod.Id = ds.Tables[0].Rows[i]["ID"].ToString();
                    pod.SkuId = ds.Tables[0].Rows[i]["SkuId"].ToString();
                    pod.ItemCode = ds.Tables[0].Rows[i]["Prod_Code"].ToString();
                    pod.ItemName = ds.Tables[0].Rows[i]["Prod_Name"].ToString();
                    pod.ItemDescription = ds.Tables[0].Rows[i]["Prod_Description"].ToString();
                    pod.RequestedQty = ds.Tables[0].Rows[i]["OrderQty"].ToString();
                    pod.UOM = ds.Tables[0].Rows[i]["UOM"].ToString();
                    pod.UOMId = ds.Tables[0].Rows[i]["UOMID"].ToString();
                    SqlParameter[] paramuom;
                    paramuom = new SqlParameter[]
                    {
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@SkuId", Int64.Parse(pod.SkuId))
                    };
                    dsuom =  obj.Return_DataSet("SP_GetPOSKUUOM", paramuom);
                    List<UomList> uomlst = new List<UomList>();
                    for (int j = 0; j < dsuom.Tables[0].Rows.Count; j++)
                    {
                        UomList uom = new UomList();
                        uom.Id = dsuom.Tables[0].Rows[j]["Id"].ToString();
                        uom.Uom = dsuom.Tables[0].Rows[j]["Uom"].ToString();
                        uom.UnitQty = dsuom.Tables[0].Rows[j]["UnitQty"].ToString();
                        uomlst.Add(uom);
                    }
                    pod.UomList = uomlst;
                    pod.OrderQty = ds.Tables[0].Rows[i]["OrderQty"].ToString();
                    pod.RemainingQty = ds.Tables[0].Rows[i]["RemQty"].ToString();
                    string lot1 = ds.Tables[0].Rows[i]["Lottable1"].ToString();
                    string lot2 = ds.Tables[0].Rows[i]["Lottable2"].ToString();
                    string lot3 = ds.Tables[0].Rows[i]["Lottable3"].ToString();
                    string lot4 = ds.Tables[0].Rows[i]["Lottable4"].ToString();
                    string lot5 = ds.Tables[0].Rows[i]["Lottable5"].ToString();
                    string lot6 = ds.Tables[0].Rows[i]["Lottable6"].ToString();
                    string lot7 = ds.Tables[0].Rows[i]["Lottable7"].ToString();
                    string lot8 = ds.Tables[0].Rows[i]["Lottable8"].ToString();
                    string lot9 = ds.Tables[0].Rows[i]["Lottable9"].ToString();
                    string lot10 = ds.Tables[0].Rows[i]["Lottable10"].ToString();
                    pod.Lot1 = lot1 + "|" + lot2 + "|" + lot3 + "|" + lot4 + "|" + lot5 + "|" + lot6 + "|" + lot7 + "|" + lot8 + "|" + lot9 + "|" + lot10;
                    pod.CaseNetWeight = ds.Tables[0].Rows[i]["casenetweight"].ToString();
                    pod.CaseGrossWeight = ds.Tables[0].Rows[i]["casegrossweight"].ToString();
                    pod.TotalCarton = ds.Tables[0].Rows[i]["totalcartons"].ToString();
                    pod.isfinal = ds.Tables[0].Rows[i]["isfinal"].ToString();
                    pod.orderfrom = ds.Tables[0].Rows[i]["orderfrom"].ToString();
                    podlst.Add(pod);
                }
            }
            string str = "{\"PurchaseOrderDetails\":" + JsonConvert.SerializeObject(podlst) + "}";
            //JsonElement respjson = JsonElement.Parse(str);
            // return respjson;
            JsonDocument doc = JsonDocument.Parse(str);
            JsonElement respjson = doc.RootElement;
            return respjson;
        }
       
        public async Task<JsonElement> GetPODetail(PODetailRequest req)
        {
            DataSet ds = new DataSet();
            DataSet dsuom = new DataSet();
            param = new SqlParameter[]
                    {
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@orderid", Int64.Parse(req.OrderId))
                    };
            ds = obj.Return_DataSet("SP_GetPODetails", param);

            List<PurchaseOrderDetails> podlst = new List<PurchaseOrderDetails>();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    PurchaseOrderDetails pod = new PurchaseOrderDetails();
                    pod.Id = ds.Tables[0].Rows[i]["ID"].ToString();
                    pod.SkuId = ds.Tables[0].Rows[i]["SkuId"].ToString();
                    pod.ItemCode = ds.Tables[0].Rows[i]["Prod_Code"].ToString();
                    pod.ItemName = ds.Tables[0].Rows[i]["Prod_Name"].ToString();
                    pod.ItemDescription = ds.Tables[0].Rows[i]["Prod_Description"].ToString();
                    pod.RequestedQty = ds.Tables[0].Rows[i]["OrderQty"].ToString();
                    pod.UOM = ds.Tables[0].Rows[i]["UOM"].ToString();
                    pod.UOMId = ds.Tables[0].Rows[i]["UOMID"].ToString();
                    SqlParameter[] paramuom;
                    paramuom = new SqlParameter[]
                    {
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@SkuId", Int64.Parse(pod.SkuId))
                    };
                    dsuom = obj.Return_DataSet("SP_GetPOSKUUOM", paramuom);
                    List<UomList> uomlst = new List<UomList>();
                    for (int j = 0; j < dsuom.Tables[0].Rows.Count; j++)
                    {
                        UomList uom = new UomList();
                        uom.Id = dsuom.Tables[0].Rows[j]["Id"].ToString();
                        uom.Uom = dsuom.Tables[0].Rows[j]["Uom"].ToString();
                        uom.UnitQty = dsuom.Tables[0].Rows[j]["UnitQty"].ToString();
                        uomlst.Add(uom);
                    }
                    pod.UomList = uomlst;
                    pod.OrderQty = ds.Tables[0].Rows[i]["OrderQty"].ToString();
                    pod.RemainingQty = ds.Tables[0].Rows[i]["RemQty"].ToString();
                    string lot1 = ds.Tables[0].Rows[i]["Lottable1"].ToString();
                    string lot2 = ds.Tables[0].Rows[i]["Lottable2"].ToString();
                    string lot3 = ds.Tables[0].Rows[i]["Lottable3"].ToString();
                    string lot4 = ds.Tables[0].Rows[i]["Lottable4"].ToString();
                    string lot5 = ds.Tables[0].Rows[i]["Lottable5"].ToString();
                    string lot6 = ds.Tables[0].Rows[i]["Lottable6"].ToString();
                    string lot7 = ds.Tables[0].Rows[i]["Lottable7"].ToString();
                    string lot8 = ds.Tables[0].Rows[i]["Lottable8"].ToString();
                    string lot9 = ds.Tables[0].Rows[i]["Lottable9"].ToString();
                    string lot10 = ds.Tables[0].Rows[i]["Lottable10"].ToString();
                    pod.Lot1 = lot1 + "|" + lot2 + "|" + lot3 + "|" + lot4 + "|" + lot5 + "|" + lot6 + "|" + lot7 + "|" + lot8 + "|" + lot9 + "|" + lot10;
                    pod.CaseNetWeight = ds.Tables[0].Rows[i]["casenetweight"].ToString();
                    pod.CaseGrossWeight = ds.Tables[0].Rows[i]["casegrossweight"].ToString();
                    pod.TotalCarton = ds.Tables[0].Rows[i]["totalcartons"].ToString();
                    pod.isfinal = ds.Tables[0].Rows[i]["isfinal"].ToString();
                    pod.orderfrom = ds.Tables[0].Rows[i]["orderfrom"].ToString();
                    podlst.Add(pod);
                }
            }
            string str = "{\"PurchaseOrderDetails\":" + JsonConvert.SerializeObject(podlst) + "}";
            //   JObject respjson = JObject.Parse(str);
            // return respjson;
            JsonDocument doc = JsonDocument.Parse(str);
            JsonElement respjson = doc.RootElement;
            return respjson;
        }
        public async Task<JsonElement> POHead(POHeadRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@orderid", Int64.Parse(req.OrderId)),
                        new SqlParameter("@ordertype", req.OrderType)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_GetPOHead", param));
        }
        //public async Task<JsonElement> getlottable(lottablereq ReqPara)
        //{
        //    param = new SqlParameter[]
        //            {
        //                new SqlParameter("@prodID", Int64.Parse(ReqPara.prodID))

        //            };
        //    return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_getlottbyID", param));

        //}
        public async Task<JsonElement> getQualitycheck(qualitycheckreq req)
        {

            param = new SqlParameter[]
                   {
                        new SqlParameter("@customerID", Int64.Parse(req.customerID)),

                   };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("getisQCvalue", param));

        }
        public string updatePO(UpdatePostatus req)
        {

            param = new SqlParameter[]
                    {
                        new SqlParameter("@OrderID", Convert.ToInt64(req.OrderID))


                    };
            return obj.Return_ScalerValue("sp_UpdatePostatus", param);

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
                return  obj.exeSP_DT_adapter("sp_lottables", param);

            }
            catch (Exception ex) { }
            finally { }
            return dt;
        }
        public async Task<JsonElement> GetVendorList(GetVendorRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@compid", req.CompanyId),
                        new SqlParameter("@WarehouseId",req.WarehouseId),
                        new SqlParameter("@custid", req.CustomerId),
                        new SqlParameter("@uid", req.UserId),
                        new SqlParameter("@obj", req.Object),
                        new SqlParameter("@skey", req.Skey)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("getVendor", param));
        }
        public string cancelPOOrder(reqOrderDetails req)
        {
            param = new SqlParameter[]
            {
                    new SqlParameter("@orderId", req.OrderId),
                    new SqlParameter("@userId", req.UserId),
                    new SqlParameter("@WarehouseId", req.WarehouseId),
                    new SqlParameter("@CompanyId",req.CompanyId),
                    new SqlParameter("@CustomerId", req.CustomerId)
            };
            return obj.Return_ScalerValue("sp_cnclPurchaseOrder", param);

        }

        public string markCompletedRece(reqOrderDetails req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@orderId", req.OrderId),
                new SqlParameter("@userId", req.UserId),
                new SqlParameter("@WarehouseId", req.WarehouseId),
                new SqlParameter("@CompanyId",req.CompanyId),
                new SqlParameter("@CustomerId", req.CustomerId)
            };
            return obj.Return_ScalerValue("sp_markCompletedReceiving", param);
        }
        public async Task<JsonElement> GetINTaskCompleteSKULst(ReqTaskCompleteSKULst req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", req.CurrentPage),
                        new SqlParameter("@recordLimit", req.recordLimit),
                        new SqlParameter("@OrderID", req.OrderID),
                        new SqlParameter("@ObjectName", req.ObjectName),
                        new SqlParameter("@UserID", req.UserID),
                        new SqlParameter("@searchFilter", req.searchFilter),
                        new SqlParameter("@searchValue", req.searchValue),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Tsk_GetTaskCompletedSKUList", param));
        }
        public async Task<JsonElement> GetINTaskComplete(ReqTaskComplete req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", req.CurrentPage),
                        new SqlParameter("@recordLimit", req.recordLimit),
                        new SqlParameter("@UserID", req.UserID),
                        new SqlParameter("@CustomerID", req.CustomerID),
                        new SqlParameter("@warehouseID", req.warehouseID),
                        new SqlParameter("@searchFilter", req.searchFilter),
                        new SqlParameter("@searchValue", req.searchValue),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Tsk_GetTskCompletedOrders", param));
        }
    }
}
