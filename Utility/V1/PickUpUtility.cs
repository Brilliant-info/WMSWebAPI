using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using WMSWebAPI.Models.V1.Request;
using System.Text.Json;

using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;
using System.Threading.Tasks;

namespace WMSWebAPI.Utility.V1
{
    public class PickUpUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public PickUpUtility()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> PickUpList(GetPickUpListRequest req)
        {
            DataSet ds = new DataSet();
            if (req.whereFilterCondtion == null || req.whereFilterCondtion == "All") { req.whereFilterCondtion = ""; }
            param = new SqlParameter[]
                    {
                        new SqlParameter("@curentpg", req.CurrentPage),
                        new SqlParameter("@limit", req.recordLimit),
                        new SqlParameter("@custid", req.CustomerId),
                        new SqlParameter("@wrid", req.WarehouseId),
                        new SqlParameter("@obj", req.Object),
                        new SqlParameter("@scol", req.whereFilterCondtion),
                        new SqlParameter("@skey", req.SearchValue),
                        new SqlParameter("@clientid", Convert.ToInt64(req.ClientId)),
                        new SqlParameter("@uid", Convert.ToInt64(req.UserId))
                    };
            ds = obj.Return_DataSet("SP_PickUPLst", param);
            int totcnt = 0, socnt = 0, allocnt = 0, pickcnt = 0, stgcnt = 0, shipcnt = 0, cnclcnt = 0, packing = 0, qccnt = 0;
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

                jsonString = "{\"PickUpListResult\":[{";
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

                if (totcnt > 0)
                {
                    jsonString = jsonString + "\"PickUpList\":";
                    jsonString = jsonString + JsonConvert.SerializeObject(ds.Tables[1]);
                }
                else
                {
                    jsonString = jsonString + "\"PickUpList\":[]";
                }
                jsonString = jsonString + "}]}";


            }
            catch (Exception ex) { }
            return JsonDocument.Parse(jsonString).RootElement;
        }
        public async Task<JsonElement> PickUpDetail(GetPickUpDetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@bid", req.BatchID),
                        new SqlParameter("@PKID", req.PickUpID),
                        new SqlParameter("@uid", req.UserId),
                        new SqlParameter("@custid", req.CustomerId),
                        new SqlParameter("@wrid", req.WarehouseId),
                        new SqlParameter("@soid", req.SOID)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_PickUpDetail", param));
        }
        public string FinalSavePickUp(FinalSavePickUpRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@bid", Int64.Parse(req.BatchID)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@obj", req.Object)
                    };
            return obj.Return_ScalerValue("FinalSavePickUp", param);
        }
        public string CancelPickUp(CancelPickUpRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@bid", req.BatchId),
                        new SqlParameter("@pkid", req.PickUpId),
                        new SqlParameter("@custid", req.CustomerId),
                        new SqlParameter("@wrid", req.WarehouseId),
                        new SqlParameter("@uid", req.UserId)
                    };
            return obj.Return_ScalerValue("CancelPickUp", param);
        }
        public string MarkPacked(MarkPackRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@bid", req.BatchId),
                        new SqlParameter("@pkid", req.PickUpId),
                        new SqlParameter("@compId", req.compid),
                        new SqlParameter("@custid", req.CustomerId),
                        new SqlParameter("@wrid", req.WarehouseId),
                        new SqlParameter("@uid", req.UserId),
                        new SqlParameter("@OrderId", req.OrderId)
                    };
            return obj.Return_ScalerValue("DirectPackingOrders", param);
        }
        public string AutoPacking(Int64 BatchId, Int64 PickUpId, Int64 CustomerId, Int64 WarehouseId, Int64 UserId)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@bid", BatchId),
                        new SqlParameter("@pkid", PickUpId),
                       /// new SqlParameter("@compId", compid),
                        new SqlParameter("@custid", CustomerId),
                        new SqlParameter("@wrid", WarehouseId),
                        new SqlParameter("@uid", UserId)
                        ///new SqlParameter("@OrderId",OrderId)
                    };
            return obj.Return_ScalerValue("AutoPackingOrders", param);
        }
        public string UpdatePickUp(UpdatePickUpRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@alcplnid", req.ID),
                        new SqlParameter("@newqty", req.NewQty),
                        new SqlParameter("@oldqty", req.alocQty),
                        new SqlParameter("@uid", req.UserId)
                    };
            return obj.Return_ScalerValue("updatePickupQty", param);
        }
        public string chkAssignToUser(ChkAssignToRequest req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@customerid",req.customerid),
                new SqlParameter("@userid",req.userid),
                new SqlParameter("@object",req.objectname),
                new SqlParameter("@referenceid",req.referenceid)
            };
            return obj.Return_ScalerValue("tsk_checkassigntouser", param);
        }
        public string EditPickUpQty(UpdatePickUpRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@alcplnid", req.ID),
                        new SqlParameter("@newqty", req.NewQty),
                        new SqlParameter("@alocqty", req.alocQty),
                        new SqlParameter("@uid", req.UserId)
                    };
            return obj.Return_ScalerValue("EditPickupQty", param);
        }
        public string RevertPickUpQty(RevertPickUpRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@BatchId", req.batchID),
                        new SqlParameter("@uid", req.UserId)
                    };
            return obj.Return_ScalerValue("RevertPickUpQty", param);
        }
    }
}
