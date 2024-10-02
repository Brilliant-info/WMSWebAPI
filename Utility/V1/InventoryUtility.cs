using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Data;
using WMSWebAPI.Models.V1.Request;
using System.Text.Json;

namespace WMSWebAPI.Utility.V1
{
    public class InventoryUtility
    {

        SqlParameter[] param;
        DBActivity obj;
        public InventoryUtility()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> InventoryList(GetInventoryListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", Int64.Parse(req.CurrentPage)),
                        new SqlParameter("@RecordLimit", Int64.Parse(req.RecordLimit)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@Filter", req.Filter)
                    };
            return await  obj.ConvertDataSetToJObject(obj.Return_DataSet("InventorySnapshot", param));
        }
        public DataSet InventoryExport(GetInventoryExportRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                    };
            return obj.Return_DataSet("InventorySnapExport", param);
        }
        public async Task<JsonElement> AvailInventoryList(GetAvailInventoryListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", Int64.Parse(req.CurrentPage)),
                        new SqlParameter("@RecordLimit", Int64.Parse(req.RecordLimit)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                         new SqlParameter("@SkuId", Int64.Parse(req.SkuId)),
                        new SqlParameter("@Filter", req.Filter)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("AvailableInventory", param));
        }
        public async Task<JsonElement> HoldInventoryList(GetHoldInventoryListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", Int64.Parse(req.CurrentPage)),
                        new SqlParameter("@RecordLimit", Int64.Parse(req.RecordLimit)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                         new SqlParameter("@SkuId", Int64.Parse(req.SkuId)),
                        new SqlParameter("@Filter", req.Filter)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_HoldInventoryList", param));
        }
        public async Task<JsonElement> AllocateInventoryList(GetAllocateInventoryListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", Int64.Parse(req.CurrentPage)),
                        new SqlParameter("@RecordLimit", Int64.Parse(req.RecordLimit)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                         new SqlParameter("@SkuId", Int64.Parse(req.SkuId)),
                        new SqlParameter("@Filter", req.Filter)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_AllocateInventory", param));
        }
        public async Task<JsonElement> RejectedInventoryList(GetRejectedInventoryListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", Int64.Parse(req.CurrentPage)),
                        new SqlParameter("@RecordLimit", Int64.Parse(req.RecordLimit)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                         new SqlParameter("@SkuId", Int64.Parse(req.SkuId)),
                        new SqlParameter("@Filter", req.Filter)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_RejectedInventory", param));
        }
        public string CreateCyclePlan(CreateCycleRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Obj", req.Obj),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@SkuId", req.SkuId),
                        new SqlParameter("@PlanTitle", req.PlanTitle),
                        new SqlParameter("@PlanID", req.PlanID),
                    };
            return obj.Return_ScalerValue("Sp_CreateCycleCount", param);
        }
        public string HoldInventory(HoldInventoryRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@SkuID", Int64.Parse(req.SkuId)),
                        new SqlParameter("@locid", Int64.Parse(req.locationid)),
                        new SqlParameter("@pltid", Int64.Parse(req.palletid)),
                        new SqlParameter("@lot1", req.lot1),
                        new SqlParameter("@lot2", req.lot2),
                        new SqlParameter("@lot3", req.lot3),
                        new SqlParameter("@lot4", req.lot4),
                        new SqlParameter("@lot5", req.lot5),
                        new SqlParameter("@lot6", req.lot6),
                        new SqlParameter("@lot7", req.lot7),
                        new SqlParameter("@lot8", req.lot8),
                        new SqlParameter("@lot9", req.lot9),
                        new SqlParameter("@lot10", req.lot10),
                    };
            return obj.Return_ScalerValue("Sp_HoldInventory", param);
        }
        public string AdjustInventory(AdjustInventoryRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@SkuID", Int64.Parse(req.SkuId)),
                        new SqlParameter("@locid", Int64.Parse(req.locationid)),
                        new SqlParameter("@pltid", Int64.Parse(req.palletid)),
                        new SqlParameter("@lot1", req.lot1),
                        new SqlParameter("@lot2", req.lot2),
                        new SqlParameter("@lot3", req.lot3),
                        new SqlParameter("@lot4", req.lot4),
                        new SqlParameter("@lot5", req.lot5),
                        new SqlParameter("@lot6", req.lot6),
                        new SqlParameter("@lot7", req.lot7),
                        new SqlParameter("@lot8", req.lot8),
                        new SqlParameter("@lot9", req.lot9),
                        new SqlParameter("@lot10", req.lot10),
                        new SqlParameter("@qty", Decimal.Parse(req.Qty)),
                        new SqlParameter("@reasonid", Int64.Parse(req.ReasonID)),
                    };
            return obj.Return_ScalerValue("Sp_AdjustInventory", param);
        }
        public DataSet AllocateInventoryExport(GetAllocateInventoryExportRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", Int64.Parse(req.CurrentPage)),
                        new SqlParameter("@RecordLimit", Int64.Parse(req.RecordLimit)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@SkuId", Int64.Parse(req.SkuId))
                    };
            return obj.Return_DataSet("SP_AllocateInventoryExport", param);
        }
        public string DeallocateInventory(DeallocateInventoryRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@SkuID", Int64.Parse(req.SkuId)),
                        new SqlParameter("@locid", Int64.Parse(req.locationid)),
                        new SqlParameter("@pltid", Int64.Parse(req.palletid)),
                        new SqlParameter("@lot1", req.lot1),
                        new SqlParameter("@lot2", req.lot2),
                        new SqlParameter("@lot3", req.lot3),
                        new SqlParameter("@soid", Decimal.Parse(req.soid))
                    };
            return obj.Return_ScalerValue("Sp_DeallocateInventory", param);
        }
        public DataSet HoldInventoryExport(GetHoldInventoryExportRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", Int64.Parse(req.CurrentPage)),
                        new SqlParameter("@RecordLimit", Int64.Parse(req.RecordLimit)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@SkuId", Int64.Parse(req.SkuId))
                    };
            return obj.Return_DataSet("SP_HoldInventoryExport", param);
        }
        public string ReleaseInventory(HoldInventoryRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@SkuID", Int64.Parse(req.SkuId)),
                        new SqlParameter("@locid", Int64.Parse(req.locationid)),
                        new SqlParameter("@pltid", Int64.Parse(req.palletid)),
                        new SqlParameter("@lot1", req.lot1),
                        new SqlParameter("@lot2", req.lot2),
                        new SqlParameter("@lot3", req.lot3),
                        new SqlParameter("@lot4", req.lot4),
                        new SqlParameter("@lot5", req.lot5),
                        new SqlParameter("@lot6", req.lot6),
                        new SqlParameter("@lot7", req.lot7),
                        new SqlParameter("@lot8", req.lot8),
                        new SqlParameter("@lot9", req.lot9),
                        new SqlParameter("@lot10", req.lot10),
                    };
            return obj.Return_ScalerValue("Sp_ReleaseInventory", param);
        }
        public DataSet RejectedInventoryExport(GetRejectedInventoryExportRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", Int64.Parse(req.CurrentPage)),
                        new SqlParameter("@RecordLimit", Int64.Parse(req.RecordLimit)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@SkuId", Int64.Parse(req.SkuId))
                    };
            return obj.Return_DataSet("SP_RejectedInventoryExport", param);
        }
        public async Task<JsonElement> GetLocationbyFileter(GetLocationbySearch locationsearch)
        {
            param = new SqlParameter[]
                   {
                        new SqlParameter("@CustomerID", Int64.Parse(locationsearch.CustomerID)),
                        new SqlParameter("@WarehouseID ", Int64.Parse(locationsearch.WarehouseID)),
                        new SqlParameter("@LocFilter", locationsearch.LocFilter)
                   };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_RejectedInventory", param));
        }

        public async Task<JsonElement> InvGetLocation(InvLocationLstTransfr req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@Filter", req.Filter)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("GetwarehsLocation", param));
        }

        public async Task<JsonElement> GetBusinessrule(GetBusinessruleReq req)
        { 
            param = new SqlParameter[]
                    {
                        new SqlParameter("@warehouseid", req.warehouseid),
                        new SqlParameter("@customerid", req.customerid)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Bus_GetBusinessRule", param));
        }

        public async Task<JsonElement> GetPallet(PalletDetailRequestTrans req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@LocationID", Int64.Parse(req.LocationID)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@Filter", req.Filter)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Inv_TransGetPallet", param));
        }

        public string SaveTransfer(SaveINVTransferDetailRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@transid", Int64.Parse(req.transid)),
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@FromLocation", Int64.Parse(req.FromLocation)),
                        new SqlParameter("@FromPallet", Int64.Parse(req.FromPallet)),
                        new SqlParameter("@SkuId", Int64.Parse(req.SkuId)),
                        new SqlParameter("@Quantity", Decimal.Parse(req.Quantity)),
                        new SqlParameter("@ToLocation", Int64.Parse(req.ToLocation)),
                        new SqlParameter("@ToPallet", Int64.Parse(req.ToPallet)),
                        new SqlParameter("@Lotable1", req.Lotable1),
                        new SqlParameter("@Lotable2", req.Lotable2),
                        new SqlParameter("@Lotable3", req.Lotable3),
                        new SqlParameter("@Lotable4", req.Lotable4),
                        new SqlParameter("@Lotable5", req.Lotable5),
                        new SqlParameter("@Lotable6", req.Lotable6),
                        new SqlParameter("@Lotable7", req.Lotable7),
                        new SqlParameter("@Lotable8", req.Lotable8),
                        new SqlParameter("@Lotable9", req.Lotable9),
                        new SqlParameter("@Lotable10", req.Lotable10),
                        new SqlParameter("@FrmTRID", req.FrmTRID),
                    };
            return obj.Return_ScalerValue("InventoryTransferAdd", param);
        }
    }
}
