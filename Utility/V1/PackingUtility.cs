using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class PackingUtility
    {


        SqlParameter[] param;
        DBActivity obj;
        public PackingUtility()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> StagingList(GetStagingListRequest req)
        {
            DataSet ds = new DataSet();
            //if (req.whereFilterCondtion == null || req.whereFilterCondtion == "All") { req.whereFilterCondtion = ""; }
            String jsonString = String.Empty;
            param = new SqlParameter[]
                    {
                        new SqlParameter("@currentpg", Int32.Parse(req.CurrentPage)),
                        new SqlParameter("@recordlmt", Int32.Parse(req.recordLimit)),
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@obj", req.Object),
                        new SqlParameter("@skeycol", req.whereFilterCondtion),
                        new SqlParameter("@skeyval", req.SearchValue),
                        new SqlParameter("@clientid", Int64.Parse(req.ClientId))
                    };
            ds = obj.Return_DataSet("PackingList", param);

            int totcnt = 0, socnt = 0, allocnt = 0, pickcnt = 0, stgcnt = 0, shipcnt = 0, cnclcnt = 0, packing = 0, qccnt = 0;

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

                jsonString = "{\"PackingListResult\":[{";
                jsonString = jsonString + "\"CurrentPage\":\"" + req.CurrentPage + "\",";
                jsonString = jsonString + "\"TotalRecords\":\"" + totcnt + "\",";
                jsonString = jsonString + "\"Dashboard\":[{";
                jsonString = jsonString + "\"OutboundOrder\":\"" + socnt + "\",";
                jsonString = jsonString + "\"Allocated\":\"" + allocnt + "\",";
                jsonString = jsonString + "\"Picking\":\"" + pickcnt + "\",";
                jsonString = jsonString + "\"QC\":\"" + qccnt + "\",";
                jsonString = jsonString + "\"Packing\":\"" + packing + "\",";
                jsonString = jsonString + "\"Shipped\":\"" + stgcnt + "\",";
                jsonString = jsonString + "\"CancelOrder\":\"" + cnclcnt + "\"";
                jsonString = jsonString + "}],";

                if (totcnt > 0)
                {
                    jsonString = jsonString + "\"PackingList\":";
                    jsonString = jsonString + JsonConvert.SerializeObject(ds.Tables[1]);
                }
                else
                {
                    jsonString = jsonString + "\"PackingList\":[]";
                }
                jsonString = jsonString + "}]}";


            }
            catch (Exception ex) { }
            return JsonDocument.Parse(jsonString).RootElement;
        }

        public async Task<JsonElement> StagingSOList(GetStagingSOListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@bid", Int64.Parse(req.BatchID)),
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@QcId", req.QCId)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("StagingSOList", param));
        }

        public async Task<JsonElement> StagingSODetail(GetStagingSODetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@soid", Int64.Parse(req.SOID)),
                        new SqlParameter("@bid", Int64.Parse(req.BatchID)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@PickupId", req.PickupId)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("StagingSODetail", param));
        }
        public async Task<JsonElement> ShippingPallet(GetShippingPalletRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@skey", req.SKey),
                        new SqlParameter("@orderid", Int64.Parse(req.OrderId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("ShippingPallet", param));
        }

        public async Task<JsonElement> StagingSKUList(GetStagingSKUListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@soid", Int64.Parse(req.OrderID)),
                        new SqlParameter("@skey", req.skey),
                        new SqlParameter("@qcid", Int64.Parse(req.qcid)),
                        new SqlParameter("@uid", Int64.Parse(req.userId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("StagingSKUList", param));
        }

        public async Task<JsonElement> StagingSKUDetail(GetStagingSKUDetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@soid", Int64.Parse(req.OrderID)),
                        new SqlParameter("@skuid", Int64.Parse(req.SKUID)),
                        new SqlParameter("@lot", req.Lot),
                        new SqlParameter("@QCId", req.QCId)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("StagingSKUDetail", param));
        }
        public string SaveStagingDetail(SaveStagingSKUDetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@soid", Int64.Parse(req.OrderID)),
                        new SqlParameter("@bid", Int64.Parse(req.BatchID)),
                        new SqlParameter("@remark", req.remark),
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@obj", req.obj),
                        new SqlParameter("@prdid", Int64.Parse(req.SKUID)),
                        new SqlParameter("@qty", Decimal.Parse(req.StagingQty)),
                        new SqlParameter("@uomid", Int64.Parse(req.UOMID)),
                        new SqlParameter("@pltid", Int64.Parse(req.PalletID)),
                        new SqlParameter("@pallet", req.Pallet),
                        new SqlParameter("@box", Int64.Parse(req.NoOfBox)),
                        new SqlParameter("@ht", Decimal.Parse(req.Height)),
                        new SqlParameter("@wth", Decimal.Parse(req.Width)),
                        new SqlParameter("@len", Decimal.Parse(req.Length)),
                        new SqlParameter("@wt", Decimal.Parse(req.Weight)),
                        new SqlParameter("@note", req.Notes),
                        new SqlParameter("@lot", req.Lotttable),
                        new SqlParameter("@packlocid", req.PackingLocationId),
                        new SqlParameter("@PickupId", req.PickupId)
                    };
            return obj.Return_ScalerValue("SaveStagingSKUDetail", param);
        }
        public string RemoveSku(RemveSkuRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@packingno", Int64.Parse(req.PackingNo)),
                        new SqlParameter("@orderid", Int64.Parse(req.OrderId)),
                        new SqlParameter("@palletid", Int64.Parse(req.PalletId)),
                        new SqlParameter("@prodid", Int64.Parse(req.ProdId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId))
                    };
            return obj.Return_ScalerValue("RemovePackingSku", param);
        }
        public string FinalSave(FinalSavePackingRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@packingno", Int64.Parse(req.PackingNo)),
                        new SqlParameter("@soid", Int64.Parse(req.OrderId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@QCID",  req.QCID)
                    };
            return obj.Return_ScalerValue("finalSavePacking", param);
        }
        public string DirectPackingOrders(DirectPackingOrdersRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@companyId", req.CompanyId),
                        new SqlParameter("@custid", req.custid),
                        new SqlParameter("@wrid", req.wrid),
                        new SqlParameter("@PickQAId", req.PickQAId),
                        new SqlParameter("@uid", req.uid),

                    };
            return obj.Return_ScalerValue("DirectPackingOrders", param);
        }

        public async Task<JsonElement> TransportDDList(transportList Req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@UserId", Convert.ToInt32(Req.UserID)),
                new SqlParameter("@WarehouseId", Convert.ToInt32(Req.WarehouseId)),
                new SqlParameter("@CustomerId", Convert.ToInt32(Req.CustomerId)),
                new SqlParameter("@VendorId", Convert.ToInt32(Req.VenodrId)),
                new SqlParameter("@CompanyId", Convert.ToInt32(Req.CompanyId))
            };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_TransportList", param));
        }
        public string saveTranspoter(TranspoteUpdate Req)
        {
            param = new SqlParameter[]
            {
                new SqlParameter("@PackingId", Req.PackingId),
                new SqlParameter("@UserId", Int32.Parse(Req.UserId)),
                new SqlParameter("@CustomerId", Int32.Parse(Req.CustomerId)),
                new SqlParameter("@WarehouseId", Int32.Parse(Req.WarehouseId)),
                new SqlParameter("@CompanyId",Int32.Parse(Req.CompanyId)),
                new SqlParameter("@TransportId", Int32.Parse(Req.TransportId))
            };
            return obj.Return_ScalerValue("sp_UpdateTranspoter", param);
        }

        public async Task<JsonElement> PackingLocation(GetPackingLocationRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@custid", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@wrid", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@uid", Int64.Parse(req.UserId)),
                        new SqlParameter("@skey", req.SKey)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("getPackingLocation", param));
        }
    }
}
