using Newtonsoft.Json.Linq;
using System.Data.SqlClient;
using System.Text.Json;
using WMSWebAPI.Models.V1.Request;

namespace WMSWebAPI.Utility.V1
{
    public class IOTConfigUtility
    {
        SqlParameter[] param;
        DBActivity obj;
        public IOTConfigUtility()
        {
            obj = new DBActivity();
        }
        public async Task<JsonElement> IOTConfigList(GetIOTConfigRequest req)
 
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@Currentpage ", Int64.Parse(req.Currentpage)),
                        new SqlParameter("@Recordlimit", Int64.Parse(req.Recordlimit)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@Search",req.Search),
                        new SqlParameter("@Filter",req.Filter)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("SP_IoTConfigList", param));
        }
        public async Task<JsonElement> SaveIOTConfig(GetSaveIOTConfigRequest req)
        {
            param = new SqlParameter[]
                    {

                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@Locationtype",req.Locationtype),
                        new SqlParameter("@Pathway",req.Pathway),
                        new SqlParameter("@Section",req.Section),
                        new SqlParameter("@Shelf",req.Shelf),
                        new SqlParameter("@devicetype",req.devicetype),
                        new SqlParameter("@devicecode",req.devicecode),
                        new SqlParameter("@minTemp", decimal.Parse(req.minTemp)),
                        new SqlParameter("@maxTemp", decimal.Parse(req.maxTemp)),
                        new SqlParameter("@minhumidity", decimal.Parse(req.minhumidity)),
                        new SqlParameter("@maxhumidity", decimal.Parse(req.maxhumidity)),
                        new SqlParameter("@Currtemp", decimal.Parse(req.Currtemp)),
                        new SqlParameter("@CurrHumidity", decimal.Parse(req.CurrHumidity)),
                        new SqlParameter("@IOTConfigID", Int64.Parse(req.IOTConfigID)),
                        new SqlParameter("@Active",req.Active)

                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_SaveIOTConfig", param));
        }
        public async Task<JsonElement> LocationTypeIOTConfig(GetLocationTypeIOTConfigRequest req)
        { 
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                        new SqlParameter("@WarehouseID", Int64.Parse(req.WarehouseID)),
                        new SqlParameter("@LocationType", Int64.Parse(req.LocationType)),
                        new SqlParameter("@CompanyID", Int64.Parse(req.CompanyID)),
                        new SqlParameter("@CustomerID", Int64.Parse(req.CustomerID)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_locationType", param));
        }
        public async Task<JsonElement> deviceTypeIOTConfig(GetdeviceTypeIOTConfigRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@UserID", Int64.Parse(req.UserID)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("sp_ddldeviceType", param));
        }
        public async Task<JsonElement> IOTConfigTemp(GetIOTConfigTempRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                        new SqlParameter("@CustId", Int64.Parse(req.CustId)),
                        new SqlParameter("@WhId", Int64.Parse(req.WhId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CompId", Int64.Parse(req.CompId)),
                        new SqlParameter("@deviceId",req.deviceId),
                        new SqlParameter("@Date",req.Date),
                        new SqlParameter("@obj",req.obj)
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_IOTConfigTemp", param));
        }
        public async Task<JsonElement> IOTConfigReport(GetIOTConfigReportRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                        new SqlParameter("@CustId", Int64.Parse(req.CustId)),
                        new SqlParameter("@WhId", Int64.Parse(req.WhId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CompId", Int64.Parse(req.CompId)),
                        new SqlParameter("@fromDate",req.fromDate),
                        new SqlParameter("@toDate",req.toDate),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Sp_IOTConfigReport", param));
        }
        public async Task<JsonElement> IOTLocbind(GetIOTLocbindRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@LocID", Int64.Parse(req.LocID)),
                        new SqlParameter("@CustId", Int64.Parse(req.CustId)),
                        new SqlParameter("@WhId", Int64.Parse(req.WhId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CompId", Int64.Parse(req.CompId)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("Get_LocDT_IOTConfig", param));
        }
        public async Task<JsonElement> IOTdeviceIDbind(GetIOTdeviceIDbindRequest req)
        {
            param = new SqlParameter[]
                    {
                        new SqlParameter("@ID", Int64.Parse(req.ID)),
                        new SqlParameter("@CustId", Int64.Parse(req.CustId)),
                        new SqlParameter("@WhId", Int64.Parse(req.WhId)),
                        new SqlParameter("@UserId", Int64.Parse(req.UserId)),
                        new SqlParameter("@CompId", Int64.Parse(req.CompId)),
                    };
            return await obj.ConvertDataSetToJObject(obj.Return_DataSet("IOT_GetdeviceID", param));
        }
    }
}
