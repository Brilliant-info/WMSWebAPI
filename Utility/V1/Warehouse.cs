using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using System.Web;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class Warehouse
    {
        SqlParameter[] param;
        DBActivity obj;
        public Warehouse()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> WarehouseList(GetwarehouseListRequest req)
        {
            DataSet ds = new DataSet();
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", Int32.Parse(req.CurrentPage)),
                        new SqlParameter("@RecordLimit", Int32.Parse(req.RecordLimit)),
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@Search", req.Search),
                        new SqlParameter("@Filter", req.Filter)
                    };

            ds = obj.Return_DataSet("WarehouseList", param);

            String jsonString = String.Empty;
            int totcnt = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalRecord"]);
            jsonString = "{\"WarehouseListResult\":[{";
            jsonString = jsonString + "\"CurrentPage\":\"" + req.CurrentPage + "\",";
            jsonString = jsonString + "\"TotalRecord\":\"" + totcnt + "\",";

            if (totcnt > 0)
            {
                jsonString = jsonString + "\"Table\":";
                jsonString = jsonString + JsonConvert.SerializeObject(ds.Tables[1]).TrimStart('{').TrimEnd('}');
            }
            else
            {
                jsonString = jsonString + "\"Table\":[]";
            }
            jsonString = jsonString + "}]}";

            //return JObject.Parse(jsonString);
            JsonDocument doc = JsonDocument.Parse(jsonString);
            JsonElement respjson = doc.RootElement;
            return respjson;
        }
        public string SaveWarehouse(SaveWarehouseRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@WarehouseCode", req.WarehouseCode),
                        new SqlParameter("@WarehouseName", req.WarehouseName),
                        new SqlParameter("@Type", req.Type),
                        new SqlParameter("@Remark", req.Remark),
                        new SqlParameter("@LocalRate", Decimal.Parse (req.LocalRate)),
                        new SqlParameter("@OutstationRate",Decimal.Parse (req.OutstationRate)),
                        new SqlParameter("@Active", req.Active),
                        new SqlParameter("@Id", Int64.Parse(req.ID))
                    };
            return obj.Return_ScalerValue("SaveWarehouse", param);
        }
        public async Task<JsonElement> WarehouseLocationList(GetWarehouseLocationListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@CurrentPage", Int32.Parse(req.CurrentPage)),
                        new SqlParameter("@RecordLimit", Int32.Parse(req.RecordLimit)),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@CompanyId", Int64.Parse(req.CompanyId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@Search", req.Search),
                        new SqlParameter("@Filter", req.Filter)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_LocationList", param));
        }
        public async Task<JsonElement> editWarehouseList(editWarehouseList req)
        {
            param = new SqlParameter[]
                    {
                       new SqlParameter("@Id", Int64.Parse(req.Id)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_editWarhouse", param));
        }
        public string addWarehouseLocation(SaveWarehouseLocationListRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@LocationCode", req.LocationCode),
                        new SqlParameter("@ShelfName", req.Shelf),
                        new SqlParameter("@SectionName", req.Section),
                        new SqlParameter("@PassageName", req.Pathway),
                        new SqlParameter("@FloarName", req.Floor),
                        new SqlParameter("@BuildingName", req.Building),
                        new SqlParameter("@Id", Int64.Parse(req.ID)),
                        new SqlParameter("@userID", Int64.Parse(req.UserID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@ZoneCode", req.ZoneCode),
                        new SqlParameter("@SortCode", Int64.Parse(req.SortCode)),
                        new SqlParameter("@LocationTypeID", Int64.Parse(req.LocationType)),
                        new SqlParameter("@CapacityInID",Int64.Parse(req.CapacityIn)),
                        new SqlParameter("@ZoneLocationID", Int64.Parse(req.ZoneLocation)),
                        new SqlParameter("@Number", Decimal.Parse (req.Number)),
                        new SqlParameter("@Length", Decimal.Parse (req.Length)),
                        new SqlParameter("@Height", Decimal.Parse (req.Height)),
                        new SqlParameter("@Width", Decimal.Parse (req.Width)),
                        new SqlParameter("@Active", req.Active)
                    };
            return obj.Return_ScalerValue("Sp_SaveLocation", param);
        }
        public async Task<JsonElement> ddlLocation(ddlWarehouseLocationTypeList req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@userId", Int64.Parse(req.userId))
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_ddlLocationType", param));
        }

        public string CreateCyclePlanLocation(CreateCyclelocationRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@obj", req.Object),
                        new SqlParameter("@WarehouseId", Int64.Parse(req.WarehouseId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CustomerId", Int64.Parse(req.CustomerId)),
                        new SqlParameter("@locationids", req.locationids),
                        new SqlParameter("@PlanTitle", req.PlanTitle),
                        new SqlParameter("@PlanID", req.PlanID),
                    };
            return obj.Return_ScalerValue("SP_CycleCountLocation", param);
        }
    }
}
