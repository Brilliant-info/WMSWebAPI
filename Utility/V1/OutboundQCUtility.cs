using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using WMSWebAPI.Models.V1.Request;
using System.Text.Json;

namespace WMSWebAPI.Utility.V1
{
    public class OutboundQCUtility
    {

        SqlParameter[] param;
        DBActivity obj;
        public OutboundQCUtility()
        {
            obj = new DBActivity();
        }

        public async Task<JsonElement> QCList(GetQCListRequest req)
        {
            DataSet ds = new DataSet();
            if (req.whereFilterCondtion == null || req.whereFilterCondtion == "All")
            {
                req.whereFilterCondtion = "";
            }

            param = new SqlParameter[]
            {
                new SqlParameter("@curentpg", Int32.Parse(req.CurrentPage)),
                new SqlParameter("@limit", Int32.Parse(req.recordLimit)),
                new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                new SqlParameter("@obj", req.Object),
                new SqlParameter("@scol", req.whereFilterCondtion),
                new SqlParameter("@skey", req.SearchValue),
                new SqlParameter("@clientid", Int64.Parse(req.ClientId)),
                new SqlParameter("@uid", Int64.Parse(req.UserId))
            };

            ds = obj.Return_DataSet("SP_QCList", param);

            int totcnt = 0, socnt = 0, allocnt = 0, pickcnt = 0, stgcnt = 0, cnclcnt = 0, packing = 0, qccnt = 0;

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
                }

                jsonString = "{\"QCListResult\":[{";
                jsonString += "\"CurrentPage\":\"" + req.CurrentPage + "\",";
                jsonString += "\"TotalRecords\":\"" + totcnt + "\",";
                jsonString += "\"Dashboard\":[{";
                jsonString += "\"OutboundOrder\":\"" + socnt + "\",";
                jsonString += "\"Allocated\":\"" + allocnt + "\",";
                jsonString += "\"Picking\":\"" + pickcnt + "\",";
                jsonString += "\"QC\":\"" + qccnt + "\",";
                jsonString += "\"Packing\":\"" + packing + "\",";
                jsonString += "\"Shipped\":\"" + stgcnt + "\",";
                jsonString += "\"CancelOrder\":\"" + cnclcnt + "\"";
                jsonString += "}],";

                if (totcnt > 0)
                {
                    jsonString += "\"QCList\":";
                    jsonString += JsonConvert.SerializeObject(ds.Tables[1]);
                }
                else
                {
                    jsonString += "\"QCList\":[]";
                }
                jsonString += "}]}";
            }
            catch (Exception ex)
            {
                // Handle exception as needed
            }

            using (var doc = JsonDocument.Parse(jsonString))
            {
                return doc.RootElement.Clone();
            }
        }

        public async Task<JsonElement> BatchQCList(GetBatchQCListRequest req)
        {
            DataSet ds = new DataSet();
            string Header = "Batch No,Batch Name,Pick Up No,Pick Up Date,Pick Up By,Status";
            string jsonString = string.Empty;

            param = new SqlParameter[]
            {
                new SqlParameter("@bid", req.BatchID),
                new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                new SqlParameter("@uid", Int64.Parse(req.UserId)),
                new SqlParameter("@OrderId", req.OrderId)
            };

            ds = obj.Return_DataSet("SP_BatchQCList", param);

            jsonString = "{\"BatchQCListResult\":[{";
            jsonString += "\"HeaderList\":\"" + Header + "\",";

            if (ds.Tables[0].Rows.Count > 0)
            {
                jsonString += JsonConvert.SerializeObject(ds).TrimStart('{').TrimEnd('}');
            }
            else
            {
                jsonString += "\"BatchQCList\":[]";
            }

            jsonString += "}]}";

            using (var doc = JsonDocument.Parse(jsonString))
            {
                return doc.RootElement.Clone();
            }
        }
        public async Task<JsonElement> ReasonCode(GetReasonCodeRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_ReasonCode", param));
        }
        public async Task<JsonElement> QCDetail(GetQCDetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@bid", Int64.Parse(req.BatchID)),
                        new SqlParameter("@pkid", Int64.Parse(req.PickUpNo)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@Soid", Int64.Parse(req.SOID)),
                        new SqlParameter("@QCIDPara", Int64.Parse(req.QCIDPara)),
                    };

            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GetQCHeadDetail", param));
        }
        public async Task<JsonElement> QCRemoveSKU(RemoveQCSKURequestOut req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@gid", Int64.Parse(req.gID)),
                        new SqlParameter("@recordID", Int64.Parse(req.recordID)),
                        new SqlParameter("@obj",req.obj)

                    };

            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_RemoveQCOutBSKU", param));
        }
        public async Task<JsonElement> QCSuggestSKU(GetQCSKURequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@pkid", Int64.Parse(req.PickUpNo)),
                        new SqlParameter("@skey", req.skey),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@SOID", Int64.Parse(req.SOID)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("QCSuggestSKU", param));
        }
        public async Task<JsonElement> QCSKUDetail(GetQCSKUDetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@pkid", Int64.Parse(req.PickUpNo)),
                        new SqlParameter("@skuid", Int64.Parse(req.SKUID)),
                        new SqlParameter("@lot", req.Lot),
                        new SqlParameter("@SOID", req.SOID),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GetQCSKUDetail", param));
        }
        public string SaveQCDetail(SaveQCSKUDetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@pkid", Int64.Parse(req.PickUpNo)),
                        new SqlParameter("@obj", req.Object),
                        new SqlParameter("@bid", Int64.Parse(req.BatchID)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@remark", req.Remark),
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@prdid", Int64.Parse(req.ProdId)),
                        new SqlParameter("@lot1", req.Lot1),
                        new SqlParameter("@lot2", req.Lot2),
                        new SqlParameter("@lot3", req.Lot3),
                        new SqlParameter("@lot4", req.Lot4),
                        new SqlParameter("@lot5", req.Lot5),
                        new SqlParameter("@lot6", req.Lot6),
                        new SqlParameter("@lot7", req.Lot7),
                        new SqlParameter("@lot8", req.Lot8),
                        new SqlParameter("@lot9", req.Lot9),
                        new SqlParameter("@lot10", req.Lot10),
                        new SqlParameter("@qty", Decimal.Parse(req.Qty)),
                        new SqlParameter("@rejqty", Decimal.Parse(req.RejectQty)),
                        new SqlParameter("@rid", Int64.Parse(req.ReasonID)),
                        new SqlParameter("@soid", Int64.Parse(req.SOID)),
                        new SqlParameter("@qcidPara", Int64.Parse(req.qcidPara)),
                    };
            return obj.Return_ScalerValue("SaveQCDetailWeb", param);
        }
        public string FinalSaveQCDetail(FinalSaveQCSKUDetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@pkid", Int64.Parse(req.PickUpNo)),
                        new SqlParameter("@obj", req.Object),
                        new SqlParameter("@bid", Int64.Parse(req.BatchID)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@SOID", Int64.Parse(req.SOID))
                    };
            return obj.Return_ScalerValue("FinalSaveQCDetail", param);
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

    }
}
